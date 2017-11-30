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
    /// Interaction logic for GlobalVariables.xaml
    /// </summary>
    public partial class GlobalVariables : UserControl
    {
        private string _Gname;
        private string _Gvalue;

        public string GlobalNameB {
            get { return _Gname; }
            set { _Gname = value; } }

        public string GlobalValueB {
            get { return _Gvalue; }
            set { _Gvalue = value; } }

        public GlobalVariables(string GName, string GValue)
        {
            InitializeComponent();
            DataContext = this;
            GlobalNameB = GName;
            GlobalValueB = GValue;
        }

        private void DeleteGlobal_Click(object sender, RoutedEventArgs e)
        {
            StackPanel SP = (StackPanel)this.Parent;
            SP.Children.Remove(this);
        }
    }
}
