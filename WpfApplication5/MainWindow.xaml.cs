using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.IO;
using System.Windows.Controls;
using System.Text;
using System;
namespace VSG
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public ConfigControl Config = new ConfigControl();
        public VenafiAPI VedAPI = new VenafiAPI();
        public AdaptableControl AHControl = new AdaptableControl();

        public List<SavedFunctionControl> SavedFuncListt = new List<SavedFunctionControl>();
        public List<AHSavedFunction> AHSavedFuncListt = new List<AHSavedFunction>();
        public List<AHSavedFunction> AHLoadFuncListt = new List<AHSavedFunction>();
        public List<SavedFunctionControl> LoadFuncListt = new List<SavedFunctionControl>();
        public string UserPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)+"VConfig.txt";
        public SaveData SD;
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            ConfigCont.Content = Config;
            VenafiAPiContent.Content = VedAPI;
            OtherAPIContent.Content = AHControl;

            VedAPI.CallUrls.SelectedIndex = 0;
            SD = new SaveData(UserPath);
            SD.LoadSavedFunctions();
            if (LoadFuncListt.Count > 0)
            {
                foreach (SavedFunctionControl SC in LoadFuncListt)
                {
                    VedAPI.FNames.Add(SC.FunctionName, new List<string>());
                    SavedVariables.Children.Insert(1, SC);
                    this.RegisterName(SC.FunctionName,SC);
                }
            }
            if (AHLoadFuncListt.Count > 0)
            {
                foreach (AHSavedFunction SC in AHLoadFuncListt)
                {
                    AHSavedFunction SF1 = new AHSavedFunction(SC.FunctionData);
                    AHControl.FuncNames.Add(SF1.FunctionData.FunctionName);
                    SavedVariables.Children.Insert(1, SF1);
                    this.RegisterName(SF1.FunctionData.FunctionName.Replace('-','_'), SF1);
                }
            }
        }

        private void Build_Script(object sender, RoutedEventArgs e)
        {
            if (Config.FileLocation != null)
            {

                IEnumerable<AHSavedFunction> AHSavedVars = SavedVariables.Children.OfType<AHSavedFunction>();
                List<AdaptableHelper.AHFunctionData> Unused = new List<AdaptableHelper.AHFunctionData>();
                IEnumerable<KeyValuePair<String,String>> KL =  AHControl.AH.FunctionDescription.Where(x=>!AHControl.FuncNames.Where(y => y == x.Key).Contains(x.Key));
                foreach (KeyValuePair<string,string> UnusedAHFunctions in KL)
                {
                    AdaptableHelper.AHFunctionData UFD = new AdaptableHelper.AHFunctionData();
                    UFD.FunctionName = UnusedAHFunctions.Key;
                    UFD.FunctionDescription = UnusedAHFunctions.Value;
                    UFD.Used = false;
                    UFD = AHControl.AH.AHBuildFunction(UFD);
                    Unused.Add(UFD);
                }
                IEnumerable<SavedFunctionControl> SavedVars = SavedVariables.Children.OfType<SavedFunctionControl>();
                if (File.Exists(Config.FileLocation))
                {
                    using (StreamWriter file = new StreamWriter(Config.FileLocation, false))
                    {
                        file.Write("");
                    }
                }
                int NumberofAHFunctionsUsed = AHControl.AH.FunctionDescription.Where(x => AHControl.FuncNames.Where(y => y == x.Key).Contains(x.Key)).Count();
                StackPanel Params = (StackPanel)Config.FindName("Parameters");
                StringBuilder ParamBlock = new StringBuilder();
                ParamBlock.AppendLine("Param(");
                if (Params.Children.Count > 0)
                {
                    foreach (GlobalVariables Param in Params.Children)
                    {
                        if (Param.GlobalValue.Text != "")
                        {
                            ParamBlock.Append("\t[Parameter(Mandatory=$false)]$" + Param.GlobalName.Text);
                            ParamBlock.Append("=" + "'" + Param.GlobalValue.Text + "'");
                        }
                        else
                        {
                            ParamBlock.Append("\t[Parameter(Mandatory=$true)]$" + Param.GlobalName.Text);
                        }
                        ParamBlock.Append(",\r\n");
                    }
                }
                ParamBlock.AppendLine("\t[Parameter(Mandatory=$true)]$Server,");
                ParamBlock.AppendLine("\t[Parameter(Mandatory=$true)]$Username,");
                ParamBlock.AppendLine("\t[Parameter(Mandatory=$true)]$Password");
                ParamBlock.AppendLine("\r\n)");
                using (StreamWriter file = new StreamWriter(Config.FileLocation, true))
                {
                    file.WriteLine(ParamBlock.ToString());
                }
                if (NumberofAHFunctionsUsed > 0)
                {
                    if (AHSavedVars.Count() > 0)
                    {
                        foreach (AHSavedFunction AH1 in AHSavedVars)
                        {
                            using (StreamWriter file = new StreamWriter(Config.FileLocation, true))
                            {
                                file.WriteLine(AH1.FunctionData.FunctionCode);
                            }
                        }
                        if (Unused.Count > 0)
                        {
                            foreach (AdaptableHelper.AHFunctionData UnusedCode in Unused)
                            {
                                using (StreamWriter file = new StreamWriter(Config.FileLocation, true))
                                {
                                    file.WriteLine(UnusedCode.FunctionCode);
                                }
                            }
                        }
                    }
                    using (StreamWriter file = new StreamWriter(Config.FileLocation, true))
                    {
                        file.WriteLine("<###################### THE FUNCTIONS AND CODE BELOW THIS LINE ARE NOT CALLED DIRECTLY BY VENAFI ######################>");
                    }
                    foreach (string GenFunc in AHControl.AH.GenericFunctions.Keys)
                    {
                        using (StreamWriter file = new StreamWriter(Config.FileLocation, true))
                        {
                            file.WriteLine(AHControl.AH.GenericFunctions[GenFunc]);
                        }
                    }
                }
                foreach (SavedFunctionControl UC1 in SavedVars)
                {
                    using (StreamWriter file = new StreamWriter(Config.FileLocation, true))
                    {
                        file.WriteLine(UC1.FunctionCode);
                    }
                }
            }

            else
            {
                VedAPI.TestResults.Text = "No file location selected";
            }
        }
        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            foreach (AHSavedFunction AHSFC in SavedVariables.Children.OfType<AHSavedFunction>())
            {
                AHSavedFuncListt.Add(AHSFC);
            }
            foreach (SavedFunctionControl SFC in SavedVariables.Children.OfType<SavedFunctionControl>())
            {
                SavedFuncListt.Add(SFC);
            }
            SD.SaveallFunctions();
            base.OnClosing(e);
        }
    }
}
