using EquityX_L00160463.Services;
using EquityX_L00160463.ViewModels;
using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;

namespace EquityX_L00160463.View
{
    public partial class BindingTest : ContentPage
    {
        public BindingTest(AssetViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }


        private async void NavigateToBindingTest(object sender, EventArgs e)
        {
            var assetViewModel = new AssetViewModel(new AssetDataService());
            await assetViewModel.LoadTopAssetsByChangePercentAsync(); // Load top assets
            await Navigation.PushAsync(new BindingTest(assetViewModel));
        }
    }


}
