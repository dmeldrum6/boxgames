﻿#pragma checksum "..\..\Clear.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "31813EC0EBB9C5A4D06F0DED1B233BF1370CD64F"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using BoxGames;
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


namespace BoxGames {
    
    
    /// <summary>
    /// Clear
    /// </summary>
    public partial class Clear : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 1 "..\..\Clear.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal BoxGames.Clear winClear;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\Clear.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel stpClearHeader;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\Clear.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid gridClearHeadButtons;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\Clear.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button butClearRestart;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\Clear.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button butClearExit;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\Clear.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid gridClearHeadScores;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\Clear.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tbClearYourScore;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\Clear.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tbClearHighScore;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\Clear.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid gridClearBoard;
        
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
            System.Uri resourceLocater = new System.Uri("/BoxGames;component/clear.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Clear.xaml"
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
            this.winClear = ((BoxGames.Clear)(target));
            
            #line 8 "..\..\Clear.xaml"
            this.winClear.Closing += new System.ComponentModel.CancelEventHandler(this.winClear_Closing);
            
            #line default
            #line hidden
            return;
            case 2:
            this.stpClearHeader = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 3:
            this.gridClearHeadButtons = ((System.Windows.Controls.Grid)(target));
            return;
            case 4:
            this.butClearRestart = ((System.Windows.Controls.Button)(target));
            
            #line 33 "..\..\Clear.xaml"
            this.butClearRestart.Click += new System.Windows.RoutedEventHandler(this.butClearRestart_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.butClearExit = ((System.Windows.Controls.Button)(target));
            
            #line 41 "..\..\Clear.xaml"
            this.butClearExit.Click += new System.Windows.RoutedEventHandler(this.butClearExit_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.gridClearHeadScores = ((System.Windows.Controls.Grid)(target));
            return;
            case 7:
            this.tbClearYourScore = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 8:
            this.tbClearHighScore = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 9:
            this.gridClearBoard = ((System.Windows.Controls.Grid)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

