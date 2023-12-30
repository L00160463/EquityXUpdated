using EquityX_L00160463.Services;
using EquityX_L00160463.ViewModels;
using Microcharts;
using SkiaSharp;

namespace EquityX_L00160463.View;

public partial class Stocks : ContentPage
{

    public Stocks(AssetViewModel assetViewModel)
    {
        InitializeComponent();
        assetViewModel.LoadStockAssetsAsync();
        BindingContext = assetViewModel;
    }


    private void OnBuyStockClicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new BuyStock());
    }


}