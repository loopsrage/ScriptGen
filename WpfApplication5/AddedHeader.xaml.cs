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
    /// Interaction logic for AddedHeader.xaml
    /// </summary>
    public partial class AddedHeader : UserControl
    {
        private string _Hvalue;
        private string _Hname;

        public string Hvalue { get { return _Hvalue; } set { _Hvalue = value; } }
        public string Hname { get { return _Hname; } set { _Hname = value; } }

        public Dictionary<string,string> RD = new Dictionary<string, string>();

        public Dictionary<string,string> ReturnObject()
        {
            if (Hvalue != null && Hname != null)
            {
                if (RD.ContainsKey(Hname) == false)
                {
                    RD.Add(Hname, Hvalue);
                }
            }
            return RD;
        }
        public AddedHeader(Dictionary<string,string> SavedHeader)
        {
            InitializeComponent();
            DataContext = this;
            foreach (KeyValuePair<string,string> SH in SavedHeader)
            {
                Hvalue = SH.Value;
                Hname = SH.Key;
            }
        }
        public AddedHeader()
        {
            InitializeComponent();
            DataContext = this;
        }
    }
}
