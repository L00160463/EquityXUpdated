namespace EquityX_L00160463.View;
using Xamarin.Essentials;


public partial class AboutUs : ContentPage
{
    public AboutUs()
    {
        InitializeComponent();


    }

    // Method to open the website in the default browser I got this online on stackoverflow 
    private void OnVisitWebsiteClicked(object sender, EventArgs e)
    {
        string websiteUrl = "https://www.lyit.ie/";

        Launcher.OpenAsync(new Uri(websiteUrl));
    }
}