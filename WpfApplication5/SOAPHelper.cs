using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Windows.Controls;

namespace VSG
{
    public class SOAPHelper
    {
        public XmlDocument AHDocument = new XmlDocument();
        public XDocument xAHDocument;
        public IEnumerable<XName> Paths;
        private MainWindow MReference { get { return ((MainWindow)System.Windows.Application.Current.MainWindow); } }
        public List<LabelAndField> LAF = new List<LabelAndField>();

        public void ParseXML(string AHSoapRequest)
        {
            try
            {
                AHDocument.LoadXml(AHSoapRequest);
                using (var nodeReader = new XmlNodeReader(AHDocument))
                {
                    nodeReader.MoveToContent();
                    xAHDocument = XDocument.Load(nodeReader);
                    Paths = xAHDocument.Root.DescendantNodesAndSelf().OfType<XElement>().Where(y => y.HasElements == false && !y.IsEmpty).Select(x => x.Name).Distinct();
                }
                LAF.Clear();
                foreach (XName XN in Paths)
                {
                    IEnumerable<XElement> XE = xAHDocument.DescendantNodes().OfType<XElement>().Where(x => x.Name == XN);
                    if (XE.Count() > 0)
                    {
                        foreach (XElement X in XE)
                        {
                            if (X.Name.ToString().Contains("name"))
                            {
                                string FName = X.ToString().Substring(X.ToString().IndexOf('>') + 1);
                                string Name = FName.Substring(0,FName.IndexOf('<'));
                                XElement NodeValue = (XElement)X.NextNode;
                                string Value = NodeValue.Value;
                                LAF.Add(new LabelAndField(Name, Value, true, true, X.Name.ToString()));
                            }
                            else if(!X.Name.ToString().Contains("value"))
                            {
                                string FName = X.Name.ToString().Substring(X.Name.ToString().IndexOf('}') + 1);
                                LAF.Add(new LabelAndField(FName, X.Value, true, true,X.Name.ToString()));
                            }
                        }
                    }
                    else
                    {
                        LAF.Add(new LabelAndField(XE.First().Name.ToString(), XE.First().Value, true, true));
                    }
                }
            }
            catch (XmlException E)
            {
                Console.WriteLine(E.Message);
            }

        }
        public IEnumerable<XElement> SelectNode(string NodeName)
        {
            IEnumerable<XElement> XE;
            if (NodeName.Contains("name"))
            {
                XE = xAHDocument.DescendantNodes().OfType<XElement>().Where(x => x.Name == NodeName);
            }
            else
            {
                XE = xAHDocument.DescendantNodes().OfType<XElement>().Where(x => x.Name == NodeName);
            }
            return XE;
        }
        public string ReturnXMLString()
        {
            if (xAHDocument != null)
            {
                return xAHDocument.ToString();
            }
            else
            {
                return string.Empty;
            }
        }
        public void UpdateXML(UIElementCollection LOT)
        {
            foreach (LabelAndField NameVal in LOT)
            {
                if (NameVal.NCB != null)
                {
                    if (NameVal.NCB.SelectedValue != null)
                    {
                        string Selection;
                        string subSelection;
                        string functionSelection;
                        string NCV;

                        Selection = NameVal.NCB.SelectedValue.ToString();
                        functionSelection = NameVal.SelFunc.SelectedValue.ToString();
                        if (Selection.Contains("-"))
                        {
                            subSelection = Selection.Substring(0, Selection.IndexOf('-') - 1);
                        }
                        else
                        {
                            subSelection = Selection;
                        }
                        if (MReference.Config.LanguageSelect.Text == "Powershell")
                        {
                            if (functionSelection == "General" || functionSelection == "Specific")
                            {
                                NCV = "$($" + functionSelection + "." + subSelection + ")";
                            }
                            else
                            {
                                if (subSelection.EndsWith("DN") || subSelection.Contains("Parent"))
                                {
                                    NCV = "$(((" + functionSelection + ")." + subSelection + ") -replace '\\','\\\\')";
                                }
                                else
                                {
                                    NCV = "$((" + functionSelection + ")." + subSelection + ")";
                                }
                            }
                        

                        }
                        else
                        {
                            StringBuilder Sel = new StringBuilder();
                            string[] SubSel = subSelection.Split('.');
                            foreach (string S in SubSel)
                            {
                                string AddSTR;
                                if (S.Contains("["))
                                {
                                    Sel.Append("['");
                                    AddSTR = S.Replace("[", "'][");
                                    Sel.Append(AddSTR);
                                }
                                else
                                {
                                    Sel.Append("['" + S + "']");
                                }
                            }
                            if (subSelection.EndsWith("DN") || subSelection.Contains("Parent"))
                            {
                                NCV = "'+json.loads(json.dumps(_" + functionSelection + "()))" + Sel.ToString() + ".replace('\\','\\\\')+'";
                            }
                            else
                            {
                                NCV = "'+json.loads(json.dumps(_" + functionSelection + "()))" + Sel.ToString() + "+'";
                            }
                        }
                        XElement SE;
                        IEnumerable<XElement> SN = SelectNode(NameVal.XMLPath);
                        if (SN.Count() > 1)
                        {
                            XElement SE1 = SN.Where(x => x.Value == NameVal.textLabel.Content.ToString()).Single();
                            SE = (XElement)SE1.NextNode;
                            SE.Value = NCV;
                        }
                        else
                        {
                            SE = SN.First();
                            SE.Value = NCV;
                        }
                    }
                }
                else
                {
                    XElement SE;
                    IEnumerable<XElement> SN = SelectNode(NameVal.XMLPath);
                    if (SN.Count() > 1)
                    {
                        XElement SE1 = SN.Where(x=>x.Value == NameVal.textLabel.Content.ToString()).Single();
                        SE = (XElement)SE1.NextNode;
                        SE.Value = NameVal.txtValue.Text;
                    }
                    else
                    {
                        SE = SN.First();
                        SE.Value = NameVal.txtValue.Text;
                    }
                }
            }
        }
    }
}
