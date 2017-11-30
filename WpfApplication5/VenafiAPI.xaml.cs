using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Reflection;
using System.Net;
using System.IO;

namespace VSG
{
    /// <summary>
    /// Interaction logic for VenafiAPI.xaml
    /// </summary>
    public partial class VenafiAPI : UserControl
    {
        private MainWindow MReference { get { return ((MainWindow)System.Windows.Application.Current.MainWindow); } }

        private string _textData;
        private string _functionName;
        private string _commandType;
        private string _commandOutput;
        private string _errorM;
        private string _callUrl;

        private Dictionary<string, string> _apiKey = new Dictionary<string, string>();

        public Dictionary<string, List<string>> FNames = new Dictionary<string, List<string>>();
        public List<string> ClassUrls = new List<string>();
        public Dictionary<string, string> ForloopFunction = new Dictionary<string, string>();

        public bool Authenticate = false;
        public bool APITest = false;
        public SavedFunctionControl SelectedFunction;

        public JsonHelper JHelper = new JsonHelper();
        public CodeHelper CHelper = new CodeHelper();

        public string ApiKey {
            get { return _apiKey["X-Venafi-Api-Key"]; }
            set { _apiKey["X-Venafi-Api-Key"] = value; } }

        public string CommandOutput
        {
            get { return _commandOutput; }
            set { _commandOutput = value; }
        }
        public string CommandType
        {
            get { return _commandType; }
            set { _commandType = value; }
        }
        public string TextData
        {
            get { return _textData; }
            set { _textData = value; JSonin.Text = _textData; }
        }
        public string FunctionName
        {
            get {
                if (_functionName == null)
                {
                    _functionName = "Function_Name";
                }
                return _functionName;
            }
            set { _functionName = value; FNamex.Text = value; }
        }
        public string ErrorM
        {
            get { return _errorM; }
            set { CallResult.Content = value; _errorM = value; }
        }
        public string CallUrl {
            get { return _callUrl.Replace("_","/"); }
            set { _callUrl = CallUrls.SelectedValue.ToString(); } }
        public bool Foreach = false;

        public void GenerateButton(object sender, RoutedEventArgs e)
        {
            if (!APITest)
            {
                JHelper.ParseString(JSonin.Text, true);
            }
            OutPutFields.Children.Clear();
            if (JHelper.JsonError == null)
            {
                foreach (LabelAndField LFI in JHelper.FieldList)
                {
                    OutPutFields.Children.Add(LFI);
                }
                ErrorM = "Success";
            }
            else
            {
                ErrorM = JHelper.JsonError.Message;
            }
        }

        public void UpdateJson(object sender, RoutedEventArgs e)
        {
            if (JHelper.JsonError == null)
            {
                JHelper.UpdateJson(OutPutFields.Children);
                TextData = JHelper.ReturnJsonString(true,true);
            }
        }

        private void AddVAPICall(object sender, SelectionChangedEventArgs e)
        {
            Assembly assem = typeof(APIJsonReference).Assembly;
            var instance = Activator.CreateInstance(typeof(APIJsonReference));
            var test = assem.GetType("VSG.APIJsonReference+" + CallUrls.SelectedValue);
            var instance2 = (IApiCall)Activator.CreateInstance(test);
            CallUrl = CallUrls.SelectedValue.ToString();
            TextData = instance2.JSONExample;
            APITest = false;
            Authenticate = false;
            GenerateButton(sender, (RoutedEventArgs)e);
        }

        private void SaveButton(object sender, RoutedEventArgs e)
        {
            CommandType = Command.SelectedValue.ToString();
            CallUrl = CallUrls.SelectedValue.ToString();
            UpdateJson(sender, e);
            SavedFunctionControl NorO;
            string CodeString = CHelper.BuildFunction(CommandType, FunctionName,CallUrl,JHelper.ReturnJsonString(false),MReference.Config.LanguageSelect.SelectedValue.ToString(),Foreach);
            Foreach = false;
            if (!FNames.ContainsKey(FunctionName))
            {
                NorO = new SavedFunctionControl(FunctionName, JHelper.ReturnJsonString(true,true), CodeString, CallUrls.SelectedIndex);
                FNames.Add(FunctionName, new List<string>());
                MReference.SavedVariables.RegisterName(FunctionName, NorO);
                UIElement GenerateScriptBTN = MReference.SavedVariables.Children.OfType<Button>().Single();
                int BeforeButton = MReference.SavedVariables.Children.IndexOf(GenerateScriptBTN);
                MReference.SavedVariables.Children.Insert(BeforeButton,NorO);
            }
            else
            {
                NorO = (SavedFunctionControl)MReference.SavedVariables.FindName(FunctionName);
                NorO.FunctionCode = CodeString;
                NorO.CallUrl = CallUrls.SelectedIndex;
                NorO.JsonData = JHelper.ReturnJsonString(true,true);
            }
            GenerateButton(sender,e);
            if (!APITest)
            {
                TestApi(sender, e);
                NorO.ResponseData = JHelper.ReturnJsonString(true, false, true);
            }
            CodeOut.Text = CodeString;
        }
        public void TestApi(object sender, RoutedEventArgs e)
        {
            if (MReference.Config.SSLTrust)
            {
                ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
            }
            if (ApiKey == string.Empty && MReference.Config.VenafiAPIURL != null && MReference.Config.Username != null && MReference.Config.Password != null)
            {
                Authenticate = true;
            }
            APITest = true;
            Byte[] PostData;
            HttpWebRequest WR;
            string responseString;
            HttpWebResponse response;
            if (MReference.Config.VenafiAPIURL != null && MReference.Config.Username != null && MReference.Config.Password != null)
            {

                StringBuilder RequestURL = new StringBuilder("https://" + MReference.Config.VenafiAPIURL + "/vedsdk");
                string AuthData = JHelper.BuildNewObject(MReference.Config.GetAuthData(),false);
                if (Authenticate)
                {
                    RequestURL.Append("/authorize");
                    PostData = Encoding.ASCII.GetBytes(AuthData);
                }
                else
                {
                    PostData = Encoding.ASCII.GetBytes(TextData);
                    RequestURL.Append(CallUrl);
                }

                WR = (HttpWebRequest)WebRequest.Create(RequestURL.ToString());
                WR.Method = "Post";
                WR.ContentType = "application/json";
                WR.ContentLength = PostData.Length;

                if (ApiKey != null)
                {
                    WR.Headers.Add("X-Venafi-Api-Key", ApiKey);
                }

                try
                {
                    using (var stream = WR.GetRequestStream())
                    {
                        stream.Write(PostData, 0, PostData.Length);
                    }

                    response = (HttpWebResponse)WR.GetResponse();
                    responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

                    if (Authenticate && !responseString.Contains("Unauthorized"))
                    {
                        JHelper.ParseString(responseString,false);
                        Authenticate = false;
                        TestApi(sender, e);
                    }
                    else
                    {
                        TestResults.Text = JHelper.ParseString(responseString);
                        APITest = false;
                    }
                }
                catch (WebException WRE)
                {
                    ErrorM = WRE.Message;
                    Console.WriteLine(WRE.Message);
                }
            }
            else
            {
                responseString = "Enter the Config Settings";
                ErrorM = "Enter the Config settings";
            }
        }

        public VenafiAPI()
        {
            InitializeComponent();
            DataContext = this;
            _apiKey.Add("X-Venafi-Api-Key", string.Empty);
            Command.ItemsSource = new string[] { "Invoke-WebRequest", "Invoke-RestMethod" };
            CallUrls.ItemsSource = ClassUrls;
            Command.SelectedIndex = 1;
            Assembly CaUrls = typeof(APIJsonReference).Assembly;
            foreach (Type T in CaUrls.GetTypes().Where(x => x.Name.StartsWith("_")))
            {
                ClassUrls.Add(T.Name);
            }
        }

        private void JSonin_LostFocus(object sender, RoutedEventArgs e)
        {
            APITest = false;
            GenerateButton(sender,e);
        }
    }
}
