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
    /// Interaction logic for AdaptableControl.xaml
    /// </summary>
    public partial class AdaptableControl : UserControl
    {
        public AdaptableHelper AH = new AdaptableHelper();
        public JsonHelper JH = new JsonHelper();
        public SOAPHelper SH = new SOAPHelper();
        public Dictionary<string, List<string>> AHNames = new Dictionary<string, List<string>>();
        public List<string> FuncNames = new List<string>();
        private MainWindow MReference { get { return ((MainWindow)System.Windows.Application.Current.MainWindow); } }
        public SavedFunctionControl SelectedFunction;
        public string RType;

        public AdaptableControl()
        {
            InitializeComponent();
            DataContext = this;
            AHFunctionNames.ItemsSource = AH.FunctionDescription.Keys;
            AHPScommand.ItemsSource = AH.PSC;
            AHNames.Add("General",AH.GHT.ToList<string>());

            foreach (string GenFunc in AH.GenericFunctions.Keys)
            {
                AHNames.Add(GenFunc,new List<string>());
            }
            AHMethod.ItemsSource = AH.Methods;
            AHRequestType.ItemsSource = AH.RequestType;

            AHMethod.SelectedIndex = 0;
            AHRequestType.SelectedIndex = 0;
            AHPScommand.SelectedIndex = 0;
            AHFunctionNames.SelectedIndex = 0;
        }

        private void AHFunctionNames_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CustomFunctionName.Text = AHFunctionNames.SelectedValue.ToString();
            string AHSelection = AHFunctionNames.SelectedValue.ToString();
            if (AH.Specific.Keys.Contains(AHSelection))
            {
                if (AHNames.ContainsKey("Specific"))
                {
                    AHNames.Remove("Specific");
                }
                AHNames.Add("Specific", new List<string>());
            }
            else
            {
                if (AHNames.ContainsKey("Specific"))
                {
                    AHNames.Remove("Specific");
                }
            }
        }

        private void AHSave_Click(object sender, RoutedEventArgs e)
        {
            AdaptableHelper.AHFunctionData AFD = new AdaptableHelper.AHFunctionData();
            AHSavedFunction AHNewSF;
            List<Dictionary<string,string>> AHheaders = new List<Dictionary<string, string>>();

            AFD.FunctionName = CustomFunctionName.Text;
            AFD.CallURL = AHURL.Text;
            AFD.CBIndex.Add(AHFunctionNames.Name,AHFunctionNames.SelectedIndex);
            AFD.RequestMethod = AHMethod.SelectedValue.ToString();
            AFD.CBIndex.Add(AHMethod.Name, AHMethod.SelectedIndex);
            AFD.RequestType = AHRequestType.SelectedValue.ToString();
            AFD.CBIndex.Add(AHRequestType.Name, AHRequestType.SelectedIndex);
            AFD.CommandType = AHPScommand.SelectedValue.ToString();
            AFD.CBIndex.Add(AHPScommand.Name, AHPScommand.SelectedIndex);
            AFD.FunctionDescription = AH.FunctionDescription[AFD.FunctionName];

            foreach (AddedHeader HeaderItem in CustomConfig.Children.OfType<AddedHeader>())
            {
                AHheaders.Add(HeaderItem.ReturnObject());
            }
            AFD.CallHeaders = AHheaders;
            switch (AHRequestType.SelectedValue.ToString())
            {
                case "Json":
                    AFD.RequestBody = JH.ReturnJsonString(true, true);
                    break;
                case "SOAP":
                    AFD.RequestBody = SH.ReturnXMLString();
                    break;
                default:
                    break;
            }

            AFD.Used = true;
            AFD = AH.AHBuildFunction(AFD);

            if (!FuncNames.Contains(AFD.FunctionName))
            {
                AHNewSF = new AHSavedFunction(AFD);
                UIElement GenerateScriptBTN = MReference.SavedVariables.Children.OfType<Button>().Single();
                int BeforeButton = MReference.SavedVariables.Children.IndexOf(GenerateScriptBTN);
                MReference.SavedVariables.RegisterName(AFD.FunctionName.Replace('-', '_'), AHNewSF);
                MReference.SavedVariables.Children.Insert(BeforeButton,AHNewSF);
                FuncNames.Add(AFD.FunctionName);
            }
            else
            {
                AHNewSF = (AHSavedFunction)MReference.SavedVariables.FindName(AFD.FunctionName.Replace('-','_'));
                AHNewSF.FunctionData = AFD;
            }
            AHCodeOut.Text = AFD.FunctionCode;
        }

        private void AHaddConfig_Click(object sender, RoutedEventArgs e)
        {
            AddedHeader NewHeader = new AddedHeader();
            CustomConfig.Children.Add(NewHeader);
        }
        public void AHUpdateJson(object sender, RoutedEventArgs e)
        {
            if (JH.JsonError == null)
            {
                JH.UpdateJson(AHLFout.Children);
                BodyOrHeaderInput.Text = JH.ReturnJsonString(true, true);
            }
        }
        public void BodyOrHeaderInput_LostFocus(object sender, RoutedEventArgs e)
        {
            switch (AHRequestType.SelectedValue.ToString())
            {
                case "Json":
                    JH.ParseString(BodyOrHeaderInput.Text, true, true);
                    AHLFout.Children.Clear();
                    foreach (LabelAndField LAF in JH.FieldList)
                    {
                        AHLFout.Children.Add(LAF);
                    }
                    break;
                case "SOAP":
                    SH.ParseXML(BodyOrHeaderInput.Text);
                    AHLFout.Children.Clear();
                    foreach (LabelAndField LAF in SH.LAF)
                    {
                        AHLFout.Children.Add(LAF);
                    }
                    break;
                default:
                    break;
            }

        }
        public void UpdateBodyOrHeaderInput()
        {
            switch (AHRequestType.SelectedValue.ToString())
            {
                case "Json":
                    BodyOrHeaderInput.Text = JH.ReturnJsonString(true, true);
                    break;
                case "SOAP":
                    SH.UpdateXML(AHLFout.Children);
                    BodyOrHeaderInput.Text = SH.ReturnXMLString();
                    break;
                default:
                    break;
            }
        }
        private void CustomFunctionName_GotFocus(object sender, RoutedEventArgs e)
        {
            if (CustomFunctionName.Text == "Function Name")
            {
                CustomFunctionName.Text = "";
            }
        }
    }
}
