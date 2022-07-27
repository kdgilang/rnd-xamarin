﻿using System;
using Xamarin.Forms;
using System.Linq;
using Poseidon.Product.Models;
using System.Windows.Input;
using Poseidon.ViewModels;
using Poseidon.Product.UseCases.UpdateProductByIdUseCase;

namespace Poseidon.Product.ViewModels
{
    public class ProductListPageViewModel : ProductsViewModel
    {
        private readonly IUpdateProductByIdUseCase _updateProductById;

        public ProductListPageViewModel()
        {
            _updateProductById = DependencyService.Get<IUpdateProductByIdUseCase>();
        }

        public ICommand EditCommandAsync =>
            new Command<ProductModel>(async (ProductModel product) =>
            {
                await App.Current.MainPage.DisplayAlert($"Edit {product.Id}", "This action is TBA", "ok");
            }
        );

        public ICommand ArchiveCommandAsync =>
            new Command<long>(async (long id) =>
            {
                bool isDelete = await App.Current.MainPage
                    .DisplayAlert
                    (
                        "Archive",
                        "Are you sure want to archive this item?",
                        "Yes",
                        "Cancel"
                     );

                if (isDelete)
                {
                    IsLoading = true;
                    try
                    {
                        Products.Single(item => item.Id == id).IsActive = false;

                        var resProduct = await _updateProductById.ExecuteAsync
                            (
                                Products.FirstOrDefault(x => x.Id == id)
                            );

                        Products = Products.Where(x => x.IsActive).ToList();
                    }
                    catch (Exception e)
                    {
                        await App.Current.MainPage.DisplayAlert("Error", $"{e.Message}", "ok");
                    }
                    finally
                    {
                        IsLoading = false;
                    }
                }
            }
        );

        public ICommand DeleteCommandAsync =>
            new Command<long>(async (long id) =>
            {
                bool isDelete = await App.Current.MainPage
                    .DisplayAlert
                    (
                        "Delete",
                        "Are you sure want to delete this item?",
                        "Yes",
                        "Cancel"
                     );

                await App.Current.MainPage.DisplayAlert($"Delete {isDelete}", "This action is TBA", "ok");
            }
        );

        public ICommand SearchCommand =>
            new Command<string>(async (string text) =>
            {
                await App.Current.MainPage.DisplayAlert($"Edit {text}", "This action is TBA", "ok");
            }
        );

        public ICommand RefreshCommandAsync =>
            new Command(async () =>
            {
                if(IsLoading)
                {
                    return;
                }

                IsLoading = true;

                await PopulateDataAsync();

                IsLoading = false;
            }
        );

        public ICommand AddCommandAsync =>
            new Command(async () =>
            {
                await App.Current.MainPage.DisplayAlert($"Add", "This action is TBA", "ok");
            }
        );

        public override void OnAppearing()
        {
           base.OnAppearing();
        }
    }
}
