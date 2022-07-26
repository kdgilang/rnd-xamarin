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
        public Dictionary<string, Type> Routes { get; private set; } = new Dictionary<string, Type>();

        public ICommand HelpCommand => new Command<string>(async (url) =>
            await Browser.OpenAsync(url, new BrowserLaunchOptions
            {
                LaunchMode = BrowserLaunchMode.SystemPreferred,
                TitleMode = BrowserTitleMode.Show,
                PreferredToolbarColor = Color.AliceBlue,
                PreferredControlColor = Color.Violet
            })
        );

        public AppShell()
        {
            InitializeComponent();

            BindingContext = new AppShellViewModel();
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
            if (current == "//login" && target == "///home")
            {
                BindingContext = new AppShellViewModel();
            }
        }

        protected override void OnNavigated(ShellNavigatedEventArgs args)
        {
            base.OnNavigated(args);

            // Perform required logic
        }
    }
}
