using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using Poseidon.ViewModels;

namespace Poseidon
{
    public partial class AppShell : Shell
    {
        private AppShellViewModel _vm;

        public AppShell()
        {
            InitializeComponent();

            _vm = new AppShellViewModel();

            if (_vm.User != null)
            {
                BindingContext = _vm;
            }
        }

        protected override void OnNavigating(ShellNavigatingEventArgs args)
        {
            base.OnNavigating(args);

            //Cancel any back navigation
            //if (args.Source == ShellNavigationSource.Pop)
            //{
            //    args.Cancel();
            //}

            string current = args.Current?.Location?.ToString();
            string target = args.Target?.Location?.ToString();
            if (current == "//login" && target == "///home" && _vm.User != null)
            {
                BindingContext = _vm;
            }
        }

        protected override void OnNavigated(ShellNavigatedEventArgs args)
        {
            base.OnNavigated(args);

            // Perform required logic
        }
    }
}
