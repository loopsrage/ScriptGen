﻿#pragma checksum "..\..\LabelAndField.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "524C7C12431D2B983846C5475D480438"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using VSG;


namespace VSG {
    
    
    /// <summary>
    /// LabelAndField
    /// </summary>
    public partial class LabelAndField : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 9 "..\..\LabelAndField.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid Fields;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\LabelAndField.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label textLabel;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\LabelAndField.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtValue;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\LabelAndField.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox SelFunc;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/WpfApplication5;component/labelandfield.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\LabelAndField.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.Fields = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.textLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.txtValue = ((System.Windows.Controls.TextBox)(target));
            
            #line 20 "..\..\LabelAndField.xaml"
            this.txtValue.LostFocus += new System.Windows.RoutedEventHandler(this.txtValue_LostFocus);
            
            #line default
            #line hidden
            return;
            case 4:
            this.SelFunc = ((System.Windows.Controls.ComboBox)(target));
            
            #line 21 "..\..\LabelAndField.xaml"
            this.SelFunc.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.UpdateFNames);
            
            #line default
            #line hidden
            
            #line 21 "..\..\LabelAndField.xaml"
            this.SelFunc.DropDownOpened += new System.EventHandler(this.SelFunc_DropDownOpened);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

