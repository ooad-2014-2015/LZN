﻿#pragma checksum "..\..\UnosKorisnika.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "B9960F4FC5B1574B0315991FFA636D5F"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
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


namespace AdministratorForme {
    
    
    /// <summary>
    /// UnosKorisnika
    /// </summary>
    public partial class UnosKorisnika : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 35 "..\..\UnosKorisnika.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox korisnikId;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\UnosKorisnika.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox korisnikIme;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\UnosKorisnika.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox korisnikPrezime;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\UnosKorisnika.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox korisnikUsername;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\UnosKorisnika.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox korisnikPw;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\UnosKorisnika.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox korisnikPwPotvrda;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\UnosKorisnika.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox korisnikSpol;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\UnosKorisnika.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox korisnikPravaPristupa;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\UnosKorisnika.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.StatusBar status;
        
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
            System.Uri resourceLocater = new System.Uri("/AdministratorForme;component/unoskorisnika.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\UnosKorisnika.xaml"
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
            this.korisnikId = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.korisnikIme = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.korisnikPrezime = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.korisnikUsername = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.korisnikPw = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 6:
            this.korisnikPwPotvrda = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 7:
            this.korisnikSpol = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 8:
            this.korisnikPravaPristupa = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 9:
            this.status = ((System.Windows.Controls.Primitives.StatusBar)(target));
            return;
            case 10:
            
            #line 44 "..\..\UnosKorisnika.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.PotvrdiUnosButtonClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

