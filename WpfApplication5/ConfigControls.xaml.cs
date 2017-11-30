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
using Microsoft.Win32;
namespace VSG
{
    /// <summary>
    /// Interaction logic for UserControl2.xaml
    /// </summary>
    public partial class ConfigControl : UserControl
    {
        private string _venafiAPIURl;
        private string _Username;
        private string _Password;
        private bool _sslTrust = true;
        private string _fileLocation;
        private string _codeLanguage;
        private MainWindow MReference { get { return ((MainWindow)System.Windows.Application.Current.MainWindow); } }


        public string CodeLanguage {
            get { return _codeLanguage; }
            set { _codeLanguage = value; LanguageSelect.SelectedValue = value.ToString(); } }

        public string Password {
            get { return _Password; }
            set { _Password = value; } }

        public string VenafiAPIURL
        {
            get { return _venafiAPIURl; }
            set { _venafiAPIURl = value; } }

        public string Username
        {
            get { return _Username; }
            set { _Username = value; } }

        public bool SSLTrust
        {
            get { return _sslTrust; }
            set { _sslTrust = value; } }

        public string FileLocation {
            get { return _fileLocation; }
            set { _fileLocation = value; FLocation.Text = _fileLocation; } }

        public Dictionary<string,string> GetAuthData()
        {
            Dictionary<string, string> AuthData = new Dictionary<string, string>();
            AuthData.Add("Username",Username);
            AuthData.Add("Password",Password);
            return AuthData;
        }
        public ConfigControl()
        {
            InitializeComponent();
            LanguageSelect.ItemsSource = new string[] { "Powershell", "Python" };
            LanguageSelect.SelectedIndex = 0;
            this.DataContext = this;
        }

        private void ChooseFileLocation(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();

            // Set filter for file extension and default file extension
            switch (LanguageSelect.SelectedValue.ToString())
            {
                case "Python":
                    dlg.DefaultExt = ".py";
                    dlg.Filter = "Python Files (*.py)|*.py";
                    break;
                case "Powershell":
                    dlg.DefaultExt = ".ps1";
                    dlg.Filter = "Powershell Files (*.ps1)|*.ps1";
                    break;
                default:
                    dlg.DefaultExt = ".ps1";
                    break;
            }
            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                FileLocation = dlg.FileName;
            }
        }

        private void AddGlobal_Click(object sender, RoutedEventArgs e)
        {
            GlobalVariables NGV = new GlobalVariables("","");
            Globals.Children.Add(NGV);
        }

        private void AddParam_Click(object sender, RoutedEventArgs e)
        {
            GlobalVariables NGV = new GlobalVariables("", "");
            Parameters.Children.Add(NGV);
        }
    }
}
