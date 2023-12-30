using Microcharts;
using Microcharts.Maui;
using SkiaSharp;

namespace EquityX_L00160463.View;

public partial class BuyStock : ContentPage
{


    ChartEntry[] entries = new[]
   {
          new ChartEntry(32f)
    {

        ValueLabel = "32",
        Color = SKColor.Parse("#264653")
    },
    new ChartEntry(50f)
    {

        ValueLabel = "50",
        Color = SKColor.Parse("#2a9d8f")
    },
    new ChartEntry(80f)
    {

        ValueLabel = "80",
        Color = SKColor.Parse("#e9c46a")
    },
    new ChartEntry(100f)
    {

        ValueLabel = "100",
        Color = SKColor.Parse("#f4a261")
    },
    new ChartEntry(97f)
    {

        ValueLabel = "97",
        Color = SKColor.Parse("#e76f51")
    },
    };


    public BuyStock()
    {
        InitializeComponent();


        chartView.Chart = new LineChart()
        {
            Entries = entries
        };


    }

    // Method to add 1 or take away 1 from the label I got this online on stackoverflow
    private void OnPlusClicked(object sender, EventArgs e)
    {
        Label quantityLabel = (Label)((Button)sender).CommandParameter;
        int quantity = int.Parse(quantityLabel.Text);
        quantity++;
        quantityLabel.Text = quantity.ToString();
    }

    private void OnMinusClicked(object sender, EventArgs e)
    {
        Label quantityLabel = (Label)((Button)sender).CommandParameter;
        int quantity = int.Parse(quantityLabel.Text);
        if (quantity > 1)
        {
            quantity--;
            quantityLabel.Text = quantity.ToString();
        }
    }
}