using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Windows.Controls;
using System.Text;
using System;
using System.Windows;
using System.IO;
using System.Linq;
namespace VSG
{
    public class JsonHelper
    {
        private MainWindow MReference { get { return ((MainWindow)System.Windows.Application.Current.MainWindow); } }

        public JsonException JsonError;
        public JObject JsonObject;
        public JObject forjsonText = new JObject();
        public JObject ResponseJson;
        public List<string> Paths = new List<string>();
        public List<LabelAndField> FieldList = new List<LabelAndField>();
        public string ActualValueJson;
        public bool _fromAH;
        public void JsonParser(JObject JSObject)
        {
            List<JsonData> ParsedJson = new List<JsonData>();
            foreach (JToken JT in JSObject.Descendants())
            {
                string Ntype = JT.Type.ToString();
                if (Ntype == "String" || Ntype == "Integer" || Ntype == "Date" || Ntype == "Boolean")
                {
                    if (JT.Path != "")
                    {
                        JToken SelTok = JSObject.SelectToken(JT.Path);
                        JsonData JD = new JsonData(JT.Type.ToString(), JT.Path, SelTok.ToString());
                        ParsedJson.Add(JD);
                    }
                }
            }
            foreach (JsonData JDft in ParsedJson)
            {
                 FieldList.Add(new LabelAndField(JDft.Name, JDft.SValue,_fromAH));
            }
        }

        public string ParseString(string JsonString, bool TextFields = false, bool FromAH = false)
        {
            string PE;
            _fromAH = FromAH;
            string FunctionName = MReference.VedAPI.FunctionName;
            try
            {
                JObject PJE = JObject.Parse(JsonString);
                PE = fixFormatting(PJE.ToString(),false);
                if (TextFields)
                {
                    FieldList.Clear();
                    JsonParser(PJE);
                    JsonObject = PJE;
                }
                if (MReference.VedAPI.Authenticate)
                {
                    MReference.VedAPI.ApiKey = PJE.SelectToken("APIKey").ToString();
                    return string.Empty;
                }
                if (MReference.VedAPI.APITest)
                {
                    Paths.Clear();
                    ResponseJson = PJE;
                    IEnumerable<string> DescPaths = PJE.Descendants().Where(y => y.Path.Contains(".")).Select(x=>x.Path.Substring(x.Path.IndexOf('.'))).Distinct();
                    foreach (JToken PI in PJE.DescendantsAndSelf())
                    {
                        JTokenType JType = PI.Type;
                        if (JType == JTokenType.Array || JType == JTokenType.Object)
                        {
                            if (PI.Path != string.Empty)
                            {
                                Paths.Add(PI.Path);
                                if (!PI.Path.Contains("["))
                                {
                                    foreach (string P in DescPaths)
                                    {
                                        Paths.Add(PI.Path + P);
                                    }
                                }
                            }
                        }
                        else if(JType != JTokenType.Property)
                        {
                            if (PI.Path != string.Empty)
                            {
                                string OPTList = PI.Path + " - " + ResponseJson.SelectToken(PI.Path).ToString();
                                Paths.Add(OPTList);
                            }
                        }
                    }
                    if (MReference.VedAPI.FNames[FunctionName] != null)
                    {
                        MReference.VedAPI.FNames[FunctionName].Clear();
                        foreach (string LI in Paths)
                        {
                            if (!MReference.VedAPI.FNames[FunctionName].Contains(LI))
                            {
                                MReference.VedAPI.FNames[FunctionName].Add(LI);
                            }
                        }
                    }
                }
                JsonError = null;
            }
            catch (JsonException JE)
            {
                JsonError = JE;
                PE = JE.Message;
            }
            return PE;
        }

        public string fixFormatting(string ResponseJson, bool tabbed)
        {
            JObject Format = JObject.Parse(ResponseJson);
            if (tabbed)
            {
                return Format.ToString();
            }
            else
            {
                return Format.ToString(Formatting.None);
            }
        }
        public Dictionary<string, int> selectToken(string Path, bool fromResponse = true, string fromString = "")
        {
            JObject thisJson;
            JToken SelectedToken;
            Dictionary<string, int> ItemCount = new Dictionary<string, int>();
            if (fromString != "")
            {
                thisJson = JObject.Parse(fromString);
            }
            else
            {
                if (fromResponse)
                {
                    thisJson = ResponseJson;
                }
                else
                {
                    thisJson = JsonObject;
                }
            }
            SelectedToken = thisJson.SelectToken(Path);
            ItemCount.Add(SelectedToken.ToString(),thisJson.Count);
            return ItemCount;
        }
        public string ReturnJsonString(bool FixFormatting, bool jsonTextValue = false,bool ReturnResponse = false)
        {
            string RJS;
            if (ReturnResponse)
            {
                if (ResponseJson != null)
                {
                    RJS = fixFormatting(ResponseJson.ToString(), FixFormatting);
                }
                else
                {
                    RJS = "Enter the Config Settings";
                }
                return RJS;
            }
            if (jsonTextValue)
            {
                RJS = fixFormatting(forjsonText.ToString(),FixFormatting);
            }
            else
            {
                RJS = fixFormatting(JsonObject.ToString(), FixFormatting);
            }
            return RJS;

        }
        public string BuildNewObject(Dictionary<string,string> NewObject, bool tabbed)
        {
            JObject newObject = new JObject();
            string OutputJson;
            foreach (KeyValuePair<string,string> KVP in NewObject)
            {
                JProperty JsonProp = new JProperty(KVP.Key,KVP.Value);
                newObject.Add(JsonProp);
            }
            OutputJson = fixFormatting(newObject.ToString(), tabbed);
            return OutputJson;
        }

        public void UpdateJson(UIElementCollection LOT)
        {

            forjsonText = JObject.Parse(JsonObject.ToString());
            foreach (LabelAndField LF in LOT)
            {
                JToken FJT = forjsonText.SelectToken(LF.textLabel.Content.ToString());
                if (LF.NCB != null)
                {
                    if (LF.SelectedJson != null)
                    {
                        string FNV = LF.SelectedJson.Select(x => x.Key).Single().ToString();
                        FJT.Replace(FNV);
                    }
                }
                else
                {
                    FJT.Replace(LF.txtValue.Text);
                }
                JToken NJT = JsonObject.SelectToken(LF.textLabel.Content.ToString());
                if (LF.NCB != null)
                {
                    if (LF.NCB.SelectedValue != null)
                    {
                        string Selection;
                        string subSelection;
                        string functionSelection;
                        string[] subSelectionFor = {"",""};
                        string NCV;
                        string NNCV;
                        if (_fromAH)
                        {
                            Selection = LF.NCB.SelectedValue.ToString();
                            functionSelection = LF.SelFunc.SelectedValue.ToString();
                            subSelection = Selection;
                        }
                        else
                        {
                            Selection = LF.NCB.SelectedValue.ToString();
                            functionSelection = LF.SelFunc.SelectedValue.ToString();
                            SavedFunctionControl SFC = (SavedFunctionControl)MReference.SavedVariables.FindName(functionSelection);
                            if (Selection.Contains("-"))
                            {
                                subSelection = Selection.Substring(0, Selection.IndexOf('-') - 1);
                            }
                            else if(!Selection.Contains("["))
                            {
                                if (Selection.Contains("."))
                                {
                                    subSelectionFor = Selection.Split('.');
                                    subSelection = "$I." + subSelectionFor[1];
                                }
                                else
                                {
                                    subSelection = "$I."+Selection;
                                }
                                MReference.VedAPI.Foreach = true;
                            }
                            else
                            {

                                subSelection = Selection;
                            }
                        }
                        if (MReference.Config.LanguageSelect.Text == "Powershell")
                        {
                            if (subSelection.Contains("$I"))
                            {
                                NNCV = "'+" + subSelection + "+'";
                                if (subSelection.EndsWith("DN") || subSelection.Contains("Parent"))
                                {
                                    NCV = "'+((" + subSelection + ") -replace '\\','\\\\')+' ";
                                }
                                else
                                {
                                    NCV = "'+" + subSelection.Split('.')[0] + "+'";
                                }
                                if (MReference.VedAPI.ForloopFunction.ContainsKey(functionSelection + "." + subSelectionFor[0]))
                                {
                                    MReference.VedAPI.ForloopFunction[functionSelection + "." + subSelectionFor[0]] = NNCV;
                                }
                                else
                                {
                                    MReference.VedAPI.ForloopFunction.Add(functionSelection+"."+subSelectionFor[0], NNCV);
                                }
                            }
                            else
                            {
                                if (subSelection.EndsWith("DN") || subSelection.Contains("Parent"))
                                {
                                    
                                    NCV = "'+$(((" + functionSelection + ")." + subSelection + ") -replace '\\','\\\\')+'";
                                }
                                else
                                {
                                    if (functionSelection == "General")
                                    {
                                        NCV = "'+$($" + functionSelection + "." + subSelection + ")+'";
                                    }
                                    else
                                    {
                                        NCV = "'+$((" + functionSelection + ")." + subSelection + ")+'";
                                    }
                                }
                            }
                        }
                        else
                        {
                            StringBuilder Sel = new StringBuilder();
                            string[] SubSel = subSelection.Split('.');
                            foreach (string S in SubSel)
                            {
                                string AddSTR;
                                if (S.Contains("["))
                                {
                                    Sel.Append("['");
                                    AddSTR = S.Replace("[", "'][");
                                    Sel.Append(AddSTR);
                                }
                                else
                                {
                                    Sel.Append("['" + S + "']");
                                }
                            }
                            if (subSelection.EndsWith("DN") || subSelection.Contains("Parent"))
                            {
                                NCV = "'+json.loads(json.dumps(_" + functionSelection + "()))" + Sel.ToString() + ".replace('\\','\\\\')+'";
                            }
                            else
                            {
                                NCV = "'+json.loads(json.dumps(_" + functionSelection + "()))" + Sel.ToString() + "+'";
                            }
                        }
                        NJT.Replace(NCV);
                    }
                }
                else
                {
                    NJT.Replace(LF.txtValue.Text);
                }

            }
        }
        
        public JsonHelper()
        {

        }
    }
    public class JsonData
    {
        public string Type;
        public string Name;
        public string SValue;
        public JsonData(string type, string name, string Svalue)
        {
            Type = type;
            Name = name;
            SValue = Svalue;
        }
    }
}
