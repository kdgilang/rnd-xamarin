﻿using System;
using Xamarin.Forms;
using Poseidon.Configs;
using Poseidon.ViewModels;

namespace Poseidon
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();


            MainPage = new AppShell();
        }

        protected override async void OnStart()
        {
            try
            {
                var user = await AuthenticatedUser.getAuthenticatedUserAsync();
                var userId = user?.UsersPermissionsUser?.Data?.Id.ToString();

                if (!string.IsNullOrEmpty(userId))
                {
                    var product = new ProductsViewModel();
                    await product.PopulateDataAsync();
                    await Shell.Current.GoToAsync("//home");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
