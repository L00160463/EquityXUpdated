using EquityX_L00160463.ViewModels;
using Microcharts;
using Microcharts.Maui;
using SkiaSharp;

namespace EquityX_L00160463.View;


//Data for the chart this was on a youtub video I watched heres the link https://www.youtube.com/watch?v=yMG8oPIuMig&ab_channel=GeraldVersluis
public partial class Crypto : ContentPage
{
    public Crypto(AssetViewModel assetViewModel)
    {
        InitializeComponent();
        assetViewModel.LoadCrytpoAssets();
        BindingContext = assetViewModel;
    }


    private void OnBuyCryptoClicked(object sender, EventArgs e)
    {
        // Use navigation to go to the target page
        Navigation.PushAsync(new BuyCrypto()); // Replace 'BuyStockPage' with the actual page you want to navigate to
    }

}