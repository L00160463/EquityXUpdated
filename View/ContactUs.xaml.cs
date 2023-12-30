
namespace EquityX_L00160463.View;
using Xamarin.Essentials;



public partial class ContactUs : ContentPage
{
    public ContactUs()
    {
        InitializeComponent();
    }


    private void OnVisitWebsiteClicked(object sender, EventArgs e)
    {
        string websiteUrl = "https://www.lyit.ie/";

        Launcher.OpenAsync(new Uri(websiteUrl));
    }
}