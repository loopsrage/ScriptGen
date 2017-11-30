using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Net;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace VSG
{
    public class CodeHelper
    {
        private MainWindow MReference { get { return ((MainWindow)System.Windows.Application.Current.MainWindow); } }
        public bool TrustSSL;

        public string BuildFunction( string CommandType, string FuncName, string url,string jText,string codeLanguage,bool Foreach = false)
        {
            string Output;
            switch (codeLanguage)
            {
                case "Powershell":
                    Output = BuildPowershell(CommandType,FuncName,url,jText,Foreach);
                    break;
                case "Python":
                    Output = BuildPython(FuncName,url,jText);
                    break;
                default:
                    Output = BuildPowershell(CommandType,FuncName,url,jText, Foreach);
                    break;
            }
            return Output;
        }
        public string BuildPython(string FuncName, string url, string jText)
        {
            TrustSSL = MReference.Config.SSLTrust;
            string CallURL = url.Replace("_", "/");
            string NewUrl = BuildURL(CallURL);
            string NewFuncName;

            StringBuilder CommandString = new StringBuilder();
            StringBuilder CodeString = new StringBuilder();

            if (FuncName == string.Empty)
            {
                NewFuncName = "Function_" + CallURL;
            }
            else
            {
                NewFuncName = FuncName;
            }
            if (CallURL == "/authorize")
            {
                CodeString.AppendLine(@"import sys, ast, getopt, types, os
import json
import requests
import argparse");
                CodeString.AppendLine("AuthData = {'X-Venafi-Api-Key':''}");
            }
            if (CallURL == "/authorize")
            {
                CodeString.AppendLine("def _Auth():");
            }
            else
            {
                CodeString.AppendLine("def _" + NewFuncName + "():");
            }
            CodeString.AppendLine("\tURL = '" + NewUrl+"'");
            CodeString.AppendLine("\tJson = '" + jText+"'");
            CodeString.Append("\theaders = {'content-type':'application/json','Accept-Charset':'UTF-8'");
            if (CallURL == "/authorize")
            {
                CodeString.Append("}\r\n");
            }
            else
            {
                CodeString.Append(",'X-Venafi-Api-Key': AuthData['X-Venafi-Api-Key']}\r\n");
            }
            CodeString.Append("\ttry :\r\n\t\tr = requests.post(URL,data=Json,headers=headers");
            if (TrustSSL)
            {
                CodeString.Append(",verify=False)\r\n");
            }
            else
            {
                CodeString.Append(")\r\n");
            }
            if (CallURL == "/authorize")
            {
                CodeString.AppendLine("\t\treturn r.json()['APIKey']");
            }
            else
            {
                CodeString.AppendLine("\t\treturn r.json()");
            }
            CodeString.AppendLine("\texcept requests.exceptions.RequestException as e:");
            CodeString.AppendLine("\t\tprint(e)");
            if (CallURL != "/authorize")
            {
                CodeString.AppendLine("\t\tif r.status_code == 401:");
                CodeString.AppendLine("\t\t\t_Auth");
                CodeString.AppendLine("\t\t\t_"+NewFuncName+"()");
                CodeString.AppendLine("\t\t\treturn r.json()");
            }
            if (CallURL == "/authorize")
            {
                CodeString.AppendLine("AuthData['X-Venafi-Api-Key'] = _Auth()");
            }
            return CodeString.ToString();

        }
        public string BuildPowershell(string CommandType, string FuncName, string url, string jText,bool Foreach = false)
        {
            TrustSSL = MReference.Config.SSLTrust;
            string NewFuncName;
            string CallURL = url.Replace("_", "/");
            string NewUrl = BuildURL(CallURL);
            StringBuilder CommandString = new StringBuilder();
            StringBuilder CodeString = new StringBuilder();
            StringBuilder ParamBlock = new StringBuilder();
            if (FuncName == string.Empty)
            {
                NewFuncName = "Function_" + CallURL;
            }
            else
            {
                NewFuncName = FuncName;
            }

            CommandString.Append(CommandType);

            if (TrustSSL && CallURL == "/authorize")
            {
                CodeString.Append("[Net.ServicePointManager]::ServerCertificateValidationCallback = {$true}\r\n");
            }
            if (CallURL == "/authorize")
            {
                CodeString.Append("if(!$Global:VAPIKey){\r\n");
                CodeString.Append("\t$Global:VAPIKey=@{\"X-Venafi-Api-Key\"=\"\"}");
                CodeString.Append("\r\n}\r\n");
            }
            if (CallURL == "/authorize")
            {
                CodeString.Append("Function Auth()\r\n{\r\n");
            }
            else
            {
                CodeString.Append("Function " + FuncName + "()\r\n{\r\n");
            }
            if (CallURL != "/authorize")
            {
                CodeString.Append("\ttry\r\n\t{");
            }
            if (Foreach)
            {
                string[] FN = MReference.VedAPI.ForloopFunction.Select(x => x.Key).First().Split('.');
                if (FN.Count() > 0)
                {
                    if (FN[1] == "")
                    {
                        CodeString.Append("\r\n\t\tforeach($I in $(" + FN[0] + ")" + FN[1] + ")");
                    }
                    else
                    {
                        CodeString.Append("\r\n\t\tforeach($I in $((" + FN[0] + ")." + FN[1] + "))");
                    }
                }
                else
                {
                    KeyValuePair<string,string> KFN = MReference.VedAPI.ForloopFunction.First();
                    CodeString.Append("\r\n\t\tforeach($I in $((" + KFN.Key.TrimEnd('.') + ")." + KFN.Value.Split('.')[1].TrimEnd('\'').TrimEnd('+') + ")");
                }
                CodeString.Append("\r\n\t\t{");
                CodeString.Append("\r\n\t\t\t$Json='" + jText + "'\r\n");
                CodeString.Append("\t\t\t$Output=" + CommandString.ToString());
                CodeString.Append(" -URI " + NewUrl);
                CodeString.Append(" -Body $Json");
                CodeString.Append(" -ContentType 'application/json'");
                CodeString.Append(" -Method POST");
                if (CallURL != "/authorize")
                {
                    CodeString.Append(" -Headers $Global:VAPIKey");
                }
                CodeString.Append("\r\n\t\t\t$Output");
                CodeString.Append("\r\n\t\t}\r\n");
            }
            else
            {
                if (CallURL == "/authorize")
                {
                    CodeString.Append("\r\n\t\t$Json='{\"Username\":\"'+$($Username)+'\",\"Password\":\"'+$($Password)+'\"}'\r\n");
                }
                else
                {
                    CodeString.Append("\r\n\t\t$Json='" + jText + "'\r\n");
                }
                CodeString.Append("\t\t$Output=" + CommandString.ToString());
                CodeString.Append(" -URI " + NewUrl);
                CodeString.Append(" -Body $Json");
                CodeString.Append(" -ContentType 'application/json'");
                CodeString.Append(" -Method POST");
                if (CallURL != "/authorize")
                {
                    CodeString.Append(" -Headers $Global:VAPIKey");
                }
            }
            if (CallURL != "/authorize")
            {
                CodeString.Append("\r\n\t}\r\n\tcatch\r\n\t{");
                CodeString.Append("\r\n\t\tif($_.Exception -match 'Unauthorized')\r\n\t\t{\r\n\t\t\tAuth\r\n\t\t\t" + FuncName + "\r\n\t\t}\r\n\t\telse\r\n\t\t{");
                CodeString.Append("\r\n\t\t\t$Output = $_\r\n\t\t}\r\n\t}");
            }
            if (CallURL == "/authorize")
            {
                CodeString.Append("\r\n\t\t$Global:VAPIKey.'X-Venafi-Api-Key'=$Output.ApiKey");
                CodeString.Append("\r\n}\r\n");
            }
            else
            {
                CodeString.Append("\r\n\treturn $Output\r\n}");
            }
            return CodeString.ToString();
        }
        private string BuildURL(string CallUrl)
        {
            StringBuilder URL = new StringBuilder();
            if (CallUrl != null)
            {
                URL.Append("https://$Server/vedsdk" + CallUrl);
            }
            return URL.ToString();
        }

    }
}
