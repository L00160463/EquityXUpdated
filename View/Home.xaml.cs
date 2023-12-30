using EquityX_L00160463.Models;
using EquityX_L00160463.Services;
using EquityX_L00160463.ViewModels;

namespace EquityX_L00160463.View;

public partial class Home : ContentPage
{
    private AssetViewModel _assetViewModel;

    public Home(AssetViewModel viewModel)
    {
        InitializeComponent();
        _assetViewModel = viewModel;
        BindingContext = _assetViewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _assetViewModel.LoadTopAssetsByChangePercentAsync(); // Load top assets
    }

    private async void OnViewClicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        if (button?.BindingContext is Asset selectedAsset)
        {
            var assetViewModel = BindingContext as AssetViewModel;
            assetViewModel?.HandleAssetSelection(selectedAsset);

            await Navigation.PushAsync(new ViewAsset(assetViewModel));
        }
    }


    private void OnViewPortfolioClicked(object sender, EventArgs e)
    {
        // Use navigation to go to the target page
        Navigation.PushAsync(new Portfolio());
    }
    private void OnAddMoneyClicked(object sender, EventArgs e)
    {
        // Use navigation to go to the target page
        Navigation.PushAsync(new Account_Card());
    }

    private void onWithdrawFunds(object sender, EventArgs e)
    {
        // Use navigation to go to the target page
        Navigation.PushAsync(new WithdrawFunds());
    }







}