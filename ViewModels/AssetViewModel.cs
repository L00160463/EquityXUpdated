using EquityX_L00160463.Models;
using EquityX_L00160463.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace EquityX_L00160463.ViewModels
{
    public class AssetViewModel : INotifyPropertyChanged
    {
        private readonly IAssetDataService _assetDataService;
        private ObservableCollection<Asset> _assets;
        private Asset _selectedAsset;

        public ObservableCollection<Asset> Assets
        {
            get => _assets;
            set
            {
                _assets = value;
                OnPropertyChanged(nameof(Assets));
            }
        }

        public Asset SelectedAsset
        {
            get => _selectedAsset;
            set
            {
                _selectedAsset = value;
                OnPropertyChanged(nameof(SelectedAsset));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public AssetViewModel(IAssetDataService assetDataService)
        {
            _assetDataService = assetDataService;
            Assets = new ObservableCollection<Asset>();
            LoadAssetsAsync();
        }

        private async void LoadAssetsAsync()
        {
            var assets = await _assetDataService.GetAssetsData();
            foreach (var asset in assets)
            {
                Assets.Add(asset);
            }
        }

        public async Task LoadStockAssetsAsync()
        {
            var allAssets = await _assetDataService.GetAssetsData();
            var stockAssets = allAssets.Where(asset => asset.QuoteType == "EQUITY").ToList();

            Assets.Clear();
            foreach (var asset in stockAssets)
            {
                Assets.Add(asset);
            }
        }

        public async Task LoadCrytpoAssets()
        {
            var allAssets = await _assetDataService.GetAssetsData();
            var CryptoAsset = allAssets.Where(asset => asset.QuoteType == "CRYPTOCURRENCY").ToList();

            Assets.Clear();
            foreach (var asset in CryptoAsset)
            {
                Assets.Add(asset);
            }
        }

        public async Task LoadTopAssetsByChangePercentAsync()
        {
            var assets = await _assetDataService.GetAssetsData();
            var topAssets = assets.OrderByDescending(asset => Math.Abs(asset.RegularMarketChangePercent))
                                  .Take(3)
                                  .ToList();

            Assets.Clear();
            foreach (var asset in topAssets)
            {
                Assets.Add(asset);
            }
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void HandleAssetSelection(Asset selectedAsset)
        {
            SelectedAsset = selectedAsset;
        }
    }
}
