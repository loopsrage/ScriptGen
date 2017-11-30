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
    /// Interaction logic for AHSavedFunction.xaml
    /// </summary>
    public partial class AHSavedFunction : UserControl
    {
        private AdaptableHelper.AHFunctionData _FunctionData;
        private string _functionName;
        private MainWindow MReference { get { return ((MainWindow)System.Windows.Application.Current.MainWindow); } }

        public AHSavedFunction(AdaptableHelper.AHFunctionData AHD)
        {
            InitializeComponent();
            DataContext = this;
            FunctionData = AHD;
            AHFunctionNamex.Content = AHD.FunctionName;
        }
        public string AHFunctionName
        {
            get { return _functionName; }
            set { _functionName = value; AHFunctionNamex.Content = _functionName; }
        }
        public AdaptableHelper.AHFunctionData FunctionData {
            get { return _FunctionData; }
            set { _FunctionData = value; } }

        private void AHFunctionNamex_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MReference.AHControl.AHURL.Text = FunctionData.FunctionName;
            MReference.AHControl.AHCodeOut.Text = FunctionData.FunctionCode;
            MReference.AHControl.AHURL.Text = FunctionData.CallURL;
            MReference.AHControl.SH.ParseXML(FunctionData.RequestBody);
            MReference.AHControl.BodyOrHeaderInput.Text = FunctionData.RequestBody;
            MReference.AHControl.CustomConfig.Children.Clear();
            MReference.AHControl.SH.LAF.Clear();
            foreach (Dictionary<string,string> HD in FunctionData.CallHeaders)
            {
                MReference.AHControl.CustomConfig.Children.Add(new AddedHeader(HD));
            }
            foreach (string CBName in FunctionData.CBIndex.Keys)
            {
                ComboBox SCB = (ComboBox)MReference.AHControl.FindName(CBName);
                SCB.SelectedIndex = FunctionData.CBIndex[CBName];
            }
            MReference.AHControl.BodyOrHeaderInput_LostFocus(sender,(RoutedEventArgs)e);
            MReference.OtherAPIContent.Focus();
        }
        private void AHRemoveFunction_Click(object sender, RoutedEventArgs e)
        {
            StackPanel SP = (StackPanel)this.Parent;
            SP.Children.Remove(this);
            MReference.AHControl.FuncNames.Remove(FunctionData.FunctionName);
            MReference.UnregisterName(FunctionData.FunctionName.Replace('-','_'));
        }
    }
}
