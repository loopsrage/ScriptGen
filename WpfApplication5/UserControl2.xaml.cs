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

namespace WpfApplication5
{
    /// <summary>
    /// Interaction logic for UserControl2.xaml
    /// </summary>
    public partial class UserControl2 : UserControl
    {
        private string _venafiAPIURl;
        private string _Username;
        private bool _sslTrust = true;

        public string VenafiAPIURL
        {
            get { return _venafiAPIURl; }
            set { _venafiAPIURl = value; }
        }

        public string Username
        {
            get { return _Username; }
            set { _Username = value; }
        }

        public bool SSLTrust
        {
            get { return _sslTrust; }
            set { _sslTrust = value; }
        }
        public UserControl2()
        {
            InitializeComponent();
            this.DataContext = this;
        }
    }
}
