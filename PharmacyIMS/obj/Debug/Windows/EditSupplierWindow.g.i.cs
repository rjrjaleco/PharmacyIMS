﻿#pragma checksum "..\..\..\Windows\EditSupplierWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "422E7D22757E907CA0C598182C963F39CF516819"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using PharmacyIMS.Windows;
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


namespace PharmacyIMS.Windows {
    
    
    /// <summary>
    /// EditSupplierWindow
    /// </summary>
    public partial class EditSupplierWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 29 "..\..\..\Windows\EditSupplierWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox SupplierNameTbx;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\Windows\EditSupplierWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox SupplierAddressTbx;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\Windows\EditSupplierWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox SupplierDetailsTbx;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\Windows\EditSupplierWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button EditSupplierBtn;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\Windows\EditSupplierWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CancelSupplierBtn;
        
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
            System.Uri resourceLocater = new System.Uri("/PharmacyIMS;component/windows/editsupplierwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Windows\EditSupplierWindow.xaml"
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
            this.SupplierNameTbx = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.SupplierAddressTbx = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.SupplierDetailsTbx = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.EditSupplierBtn = ((System.Windows.Controls.Button)(target));
            
            #line 34 "..\..\..\Windows\EditSupplierWindow.xaml"
            this.EditSupplierBtn.Click += new System.Windows.RoutedEventHandler(this.EditSupplierBtn_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.CancelSupplierBtn = ((System.Windows.Controls.Button)(target));
            
            #line 35 "..\..\..\Windows\EditSupplierWindow.xaml"
            this.CancelSupplierBtn.Click += new System.Windows.RoutedEventHandler(this.CancelSupplierBtn_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

