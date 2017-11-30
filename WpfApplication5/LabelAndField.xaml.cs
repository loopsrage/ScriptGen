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
using System.Reflection;

namespace VSG
{
    /// <summary>
    /// Interaction logic for LabelAndField.xaml
    /// </summary>
    public partial class LabelAndField : UserControl
    {
        private string _dataValue;
        private string _dataName;
        private Dictionary<string, int> _selectedJsonValue;
        private bool _fromAH;
        public bool _fromSOAP;
        public string XMLPath;
        private MainWindow MReference { get { return ((MainWindow)System.Windows.Application.Current.MainWindow); } }

        public string DataValue {
            get { return _dataValue; }
            set { _dataValue = value; } }
        public string DataName {
            get { return _dataName; }
            set { _dataName = value; } }
        public Dictionary<string,int> SelectedJson {
            get { return _selectedJsonValue; }
            set { _selectedJsonValue = value; } }

        public ComboBox NCB { get; set; }

        public LabelAndField(string labelText, string valueText="", bool FromAH = false, bool fromSoap = false, string xpath = "")
        {
            InitializeComponent();
            this.DataContext = this;
            DataValue = valueText;
            DataName = labelText;
            textLabel.Content = labelText;
            _fromAH = FromAH;
            _fromSOAP = fromSoap;
            XMLPath = xpath;
        }

        private void UpdateFNames(object sender, SelectionChangedEventArgs e)
        {
            string SelectedFunction = SelFunc.SelectedValue.ToString();
            MReference.VedAPI.SelectedFunction = (SavedFunctionControl)MReference.SavedVariables.FindName(SelectedFunction);
            int SelectedGenericFunctions = MReference.AHControl.AH.GenericFunctions.Where(x => x.Key.Contains(SelectedFunction)).Count();
            Dictionary<string, string> KV = new Dictionary<string, string>();
            foreach (GlobalVariables GV in MReference.Config.Globals.Children)
            {
                KV.Add(GV.GlobalNameB, GV.GlobalValueB);
            }
            int GlobalVarsUsedCount = KV.Where(x => x.Key.Contains(SelectedFunction)).Count();
            if (SelectedGenericFunctions <= 0 && GlobalVarsUsedCount <= 0)
            {
                TextBox TB = (TextBox)this.FindName(_dataValue);
                Fields.Children.Remove(TB);
                NCB = new ComboBox();
                NCB.SetValue(Grid.ColumnProperty, 1);
                NCB.Name = "CBVValue";
                NCB.DropDownOpened += NCB_DropDownOpened;
                NCB.SelectionChanged += NCB_SelectionChanged;
                Fields.Children.Add(NCB);
            }
            else
            {
                if (GlobalVarsUsedCount > 0)
                {
                    txtValue.Text = KV[SelectedFunction];
                }
                else
                {
                    txtValue.Text = "$(" + SelectedFunction + ")";
                }
            }
        }

        private void NCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string SelectionString;
            string SubSelectionString;
            string SelectedFunction = SelFunc.SelectedValue.ToString();
            if (SelectedFunction == "General" || SelectedFunction == "Specific")
            {
                SelectionString = textLabel.Content.ToString();
                SubSelectionString = SelectionString;
                if (_fromSOAP)
                {
                    MReference.AHControl.UpdateBodyOrHeaderInput();
                }
                else
                {
                    SelectedJson = MReference.AHControl.JH.selectToken(SubSelectionString, false);
                    MReference.AHControl.AHUpdateJson(sender,(RoutedEventArgs)e);
                }
            }
            else
            {
                SelectionString = NCB.SelectedValue.ToString();
                if (SelectionString.Contains("-"))
                {
                    SubSelectionString = SelectionString.Substring(0, SelectionString.IndexOf('-') - 1);
                }
                else if (!SelectionString.Contains("[") && SelectionString.Contains("."))
                {
                    SubSelectionString = SelectionString.Substring(0, SelectionString.IndexOf('.'));
                }
                else
                {
                    SubSelectionString = SelectionString;
                }
                SavedFunctionControl ResponseJson = (SavedFunctionControl)MReference.SavedVariables.FindName(SelectedFunction);
                string RJ = ResponseJson.ResponseData.ToString();
                SelectedJson = MReference.VedAPI.JHelper.selectToken(SubSelectionString, true , RJ);
                if (_fromAH && !_fromSOAP)
                {
                    MReference.AHControl.AHUpdateJson(sender, (RoutedEventArgs)e);
                }
                else if (_fromSOAP)
                {
                    MReference.AHControl.UpdateBodyOrHeaderInput();
                }
                else
                {
                    MReference.VedAPI.UpdateJson(sender, (RoutedEventArgs)e);
                }
            }
        }

        private void NCB_DropDownOpened(object sender, EventArgs e)
        {
            List<string> NCBSource = new List<string>();
            Dictionary<string, string> KV = new Dictionary<string, string>();
            string SelectedFunction = SelFunc.SelectedValue.ToString();
            string SelectedAHFunction = MReference.AHControl.AHFunctionNames.SelectedValue.ToString();
            int GenericFunctionsUsedCount = MReference.AHControl.AH.GenericFunctions.Where(x => x.Key.Contains(SelectedFunction)).Count();
            foreach (GlobalVariables GV in MReference.Config.Globals.Children)
            {
                KV.Add(GV.GlobalNameB,GV.GlobalValueB);
            }
            int GlobalFunctionsUsedCount = KV.Where(x => x.Key.Contains(SelectedFunction)).Count();
            if (GlobalFunctionsUsedCount > 0 || GenericFunctionsUsedCount > 0 || SelectedFunction == "General")
            {
                if (GlobalFunctionsUsedCount <= 0)
                {
                    NCBSource.AddRange(MReference.AHControl.AHNames[SelectedFunction]);
                }
            }
            else if(SelectedFunction == "Specific")
            {
                NCBSource.AddRange(MReference.AHControl.AH.Specific[SelectedAHFunction]);
            }
            else
            {
                NCBSource.AddRange(MReference.VedAPI.FNames[SelectedFunction]);
            }
            NCB.ItemsSource = NCBSource;
        }

        private void SelFunc_DropDownOpened(object sender, EventArgs e)
        {
            List<string> Source = MReference.VedAPI.FNames.Keys.ToList<string>();
            if (_fromAH)
            {
                Source.AddRange(MReference.AHControl.AHNames.Keys);
            }
            foreach (GlobalVariables GV in MReference.Config.Globals.Children)
            {
                Source.Add(GV.GlobalNameB);
            }
            SelFunc.ItemsSource = Source;
        }

        private void txtValue_LostFocus(object sender, RoutedEventArgs e)
        {
            if (_fromSOAP)
            {
                MReference.AHControl.UpdateBodyOrHeaderInput();
            }
            else
            {
                MReference.VedAPI.UpdateJson(sender, e);
            }
        }
    }
}
