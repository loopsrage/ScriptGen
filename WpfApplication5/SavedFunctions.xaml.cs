using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace VSG
{
    /// <summary>
    /// Interaction logic for SavedFunctions.xaml
    /// </summary>
    public partial class SavedFunctionControl : UserControl
    {
        private string _functionName;
        private string _functionCode;
        private string _jsonData;
        private string _responseData;
        private int _callUrl;
        private MainWindow MReference { get { return ((MainWindow)System.Windows.Application.Current.MainWindow); } }

        public string FunctionName {
            get { return _functionName; }
            set { _functionName = value; } }
        public string FunctionCode {
            get { return _functionCode; }
            set { _functionCode = value; } }
        public string JsonData {
            get { return _jsonData; }
            set { _jsonData = value; } }
        public int CallUrl {
            get { return _callUrl; }
            set { _callUrl = value; } }
        public string ResponseData {
            get { return _responseData; }
            set { _responseData = value; } }

        public SavedFunctionControl(string Fname, string JsonTextdata, string Fcode, int Fcall = 0)
        {
            InitializeComponent();
            DataContext = this;
            FunctionName = Fname;
            JsonData = JsonTextdata;
            CallUrl = Fcall;
            FunctionCode = Fcode;
            this.Name = Fname;
        }
        private void FunctionNamex_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MReference.VedAPI.CallUrls.SelectedIndex = CallUrl;
            MReference.VedAPI.CodeOut.Text = FunctionCode;
            MReference.VedAPI.SelectedFunction = this;
            MReference.VedAPI.FunctionName = FunctionName;
            MReference.VedAPI.TextData = JsonData;
            MReference.VedAPI.GenerateButton(sender,e);
            MReference.VedAPI.TestApi(sender,(RoutedEventArgs)e);
            ResponseData = MReference.VedAPI.JHelper.ReturnJsonString(true,false,true);
            MReference.VedAPI.TestResults.Text = ResponseData;
            MReference.VenafiAPiContent.Focus();
        }

        private void RemoveFunction(object sender, RoutedEventArgs e)
        {
            StackPanel SP = (StackPanel)this.Parent;
            SP.Children.Remove(this);
            MReference.UnregisterName(FunctionName);
            MReference.VedAPI.FNames.Remove(FunctionName);
            MReference.VedAPI.GenerateButton(sender,e);
        }
    }
}
