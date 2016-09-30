using GoogleMobileAds.Api;

namespace GoogleMobileAds.Common
{
    internal class DummyClient : IGoogleMobileAdsBannerClient, IGoogleMobileAdsInterstitialClient
    {
        public DummyClient(IAdListener listener)
        {

        }

        public void CreateBannerView(string adUnitId, AdSize adSize, AdPosition position)
        {
           
        }

        public void LoadAd(AdRequest request)
        {
           
        }

        public void ShowBannerView()
        {
           
        }

        public void HideBannerView()
        {
           
        }

        public void DestroyBannerView()
        {
        
        }

        public void CreateInterstitialAd(string adUnitId) {
        
        }

        public bool IsLoaded() {
        
            return true;
        }

        public void ShowInterstitial() {
        
        }

        public void DestroyInterstitial() {
        
        }
    }
}
