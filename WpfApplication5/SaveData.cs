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
    public class SaveData
    {
        private MainWindow MReference { get { return ((MainWindow)System.Windows.Application.Current.MainWindow); } }
        public string FileLocation;
        public void SaveallFunctions()
        {
            JsonSerializer JFile = new JsonSerializer();
            SaveDataFileInfo SaveObject = new SaveDataFileInfo();
            SaveObject.SaveConfig(MReference.Config);
            foreach (AHSavedFunction S1 in MReference.AHSavedFuncListt)
            {
                SaveObject.SaveAHFunction(S1.FunctionData);
            }
            foreach (SavedFunctionControl S in MReference.SavedFuncListt)
            {
                SaveObject.SaveFunction(S);
            }
            string SaveData = JsonConvert.SerializeObject(SaveObject);
            if (File.Exists(FileLocation))
            {
                using (StreamWriter file = new StreamWriter(FileLocation, false))
                {
                    file.Write("");
                }
            }
            using (StreamWriter file = new StreamWriter(FileLocation, true))
            {
                file.Write(SaveData);
            }
        }
        public void LoadSavedFunctions()
        {
            string Jdata;
            if (File.Exists(FileLocation))
            {
                using (StreamReader file = new StreamReader(FileLocation, true))
                {
                    Jdata = file.ReadLine();
                }
                if (Jdata != null || Jdata != "")
                {
                    SaveDataFileInfo NN = new SaveDataFileInfo();
                    NN = JsonConvert.DeserializeObject<SaveDataFileInfo>(Jdata);
                    if (NN != null)
                    {
                        foreach (SaveDataFileInfo.AHSaveFunc AHFSF in NN.AHFuncInfo.Reverse<SaveDataFileInfo.AHSaveFunc>())
                        {
                            AHSavedFunction Nor1 = new AHSavedFunction(AHFSF.AHD);
                            MReference.AHLoadFuncListt.Add(Nor1);
                        }
                        foreach (SaveDataFileInfo.SaveFunc SF in NN.FuncInfo.Reverse<SaveDataFileInfo.SaveFunc>())
                        {
                            SavedFunctionControl NorO = new SavedFunctionControl(SF.FunctionName, SF.JsonData, SF.FunctionCode, SF.CallUrl);
                            MReference.LoadFuncListt.Add(NorO);
                        }
                        foreach (KeyValuePair<string, string> SGV in NN.ConfigInfo.AHGlobalVars)
                        {
                            MReference.Config.Globals.Children.Add(new GlobalVariables(SGV.Key, SGV.Value));
                        }
                        foreach (KeyValuePair<string, string> SGV in NN.ConfigInfo.AHParamVars)
                        {
                            MReference.Config.Parameters.Children.Add(new GlobalVariables(SGV.Key, SGV.Value));
                        }
                        MReference.Config.VenafiAPIURL = NN.ConfigInfo.VenafiAPIurl;
                        MReference.Config.Username = NN.ConfigInfo.Username;
                        MReference.Config.Password = NN.ConfigInfo.Password;
                        MReference.Config.SSLTrust = NN.ConfigInfo.SSLtrust;
                        MReference.Config.FileLocation = NN.ConfigInfo.FileLocation;
                        MReference.Config.CodeLanguage = NN.ConfigInfo.CodeLanguage;
                    }
                }
            }
        }
        public class SaveDataFileInfo
        {
            public SaveConfigData ConfigInfo;
            public List<SaveFunc> FuncInfo = new List<SaveFunc>();
            public List<AHSaveFunc> AHFuncInfo = new List<AHSaveFunc>();
            public class SaveConfigData
            {
                public string VenafiAPIurl;
                public string Username;
                public string Password;
                public bool SSLtrust;
                public string FileLocation;
                public string CodeLanguage;
                public Dictionary<string, string> AHGlobalVars = new Dictionary<string, string>();
                public Dictionary<string, string> AHParamVars = new Dictionary<string, string>();
                public SaveConfigData(ConfigControl SaveConfig)
                {
                    foreach (GlobalVariables GVD in SaveConfig.Globals.Children)
                    {
                        if (GVD.GlobalNameB != null || GVD.GlobalNameB != string.Empty)
                        {
                            if (!AHGlobalVars.ContainsKey(GVD.GlobalNameB))
                            {
                                AHGlobalVars.Add(GVD.GlobalNameB, GVD.GlobalValue.Text);
                            }
                            else
                            {
                                AHGlobalVars[GVD.GlobalNameB] = GVD.GlobalValue.Text;
                            }
                        }
                    }
                    foreach (GlobalVariables GVD in SaveConfig.Parameters.Children)
                    {
                        if (GVD.GlobalNameB != null || GVD.GlobalNameB != string.Empty)
                        {
                            if (!AHParamVars.ContainsKey(GVD.GlobalNameB))
                            {
                                AHParamVars.Add(GVD.GlobalNameB, GVD.GlobalValue.Text);
                            }
                            else
                            {
                                AHParamVars[GVD.GlobalNameB] = GVD.GlobalValue.Text;
                            }
                        }
                    }
                    VenafiAPIurl = SaveConfig.VenafiAPIURL;
                    Username = SaveConfig.Username;
                    Password = SaveConfig.Password;
                    SSLtrust = SaveConfig.SSLTrust;
                    FileLocation = SaveConfig.FileLocation;
                    CodeLanguage = SaveConfig.LanguageSelect.SelectedValue.ToString();
                }
                public SaveConfigData()
                {

                }
            }
            public class AHSaveFunc
            {
                public AdaptableHelper.AHFunctionData AHD;
                public AHSaveFunc(AdaptableHelper.AHFunctionData NS)
                {
                    AHD = NS;
                }
                public AHSaveFunc()
                {

                }
            }
            public class SaveFunc
            {
                public string FunctionName;
                public string FunctionCode;
                public string JsonData;
                public string ResponseData;
                public int CallUrl;
                public SaveFunc(SavedFunctionControl NS)
                {
                    FunctionName = NS.FunctionName;
                    FunctionCode = NS.FunctionCode;
                    JsonData = NS.JsonData;
                    ResponseData = NS.ResponseData;
                    CallUrl = NS.CallUrl;
                }
                public SaveFunc()
                {

                }
            }
            public void SaveFunction(SavedFunctionControl NS)
            {
                SaveFunc SF = new SaveFunc(NS);
                FuncInfo.Add(SF);
            }
            public void SaveConfig(ConfigControl SaveConfig)
            {
                ConfigInfo = new SaveConfigData(SaveConfig);
            }
            public void SaveAHFunction(AdaptableHelper.AHFunctionData NS)
            {
                AHSaveFunc SF = new AHSaveFunc(NS);
                AHFuncInfo.Add(SF);
            }
            public SaveDataFileInfo()
            {

            }
        }
        public SaveData(string fileLocation)
        {
            FileLocation = fileLocation;
        }
    }

}
