//===================================================================================
// Microsoft patterns & practices
// Composite Application Guidance for Windows Presentation Foundation and Silverlight
//===================================================================================
// Copyright (c) Microsoft Corporation.  All rights reserved.
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE.
//===================================================================================
// The example companies, organizations, products, domain names,
// e-mail addresses, logos, people, places, and events depicted
// herein are fictitious.  No association with any real company,
// organization, product, domain name, email address, logo, person,
// places, or events is intended or should be inferred.
//===================================================================================
using System.Windows;
using System.ComponentModel.Composition;
using System.Diagnostics.CodeAnalysis;
using StockTraderTransaq.ControlLibrary;
using System;

namespace StockTraderTransaq
{
    /// <summary>
    /// Interaction logic for Shell.xaml
    /// </summary>   
    [Export]
    public partial class Shell : ShellWindow
    {
        public Shell()
        {
            InitializeComponent();

            this.Closing += Shell_Closing;
        }

        void Shell_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (DataContext is IDisposable)
            {
                (DataContext as IDisposable).Dispose();
            }
        }

        /// <summary>
        /// Sets the ViewModel.
        /// </summary>
        /// <remarks>
        /// This set-only property is annotated with the <see cref="ImportAttribute"/> so it is injected by MEF with
        /// the appropriate view model.
        /// </remarks>
        [Import]
        [SuppressMessage("Microsoft.Design", "CA1044:PropertiesShouldNotBeWriteOnly", Justification = "Needs to be a property to be composed by MEF")]
        public ShellViewModel ViewModel
        {
            set
            {
                this.DataContext = value;
            }
        }
    }
}
