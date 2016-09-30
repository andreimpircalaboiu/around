using GoogleMobileAds.Api;

public class Banner  {


    public static BannerView bannerView;
    private static InterstitialAd interstitial;
    public static bool BannerIsLoaded { get; set; }
    public static bool InterstitialIsLoaded { get; set; }
   




    public static void RequestBanner()
    {
        BannerIsLoaded = false;
#if UNITY_EDITOR
        string adUnitId = "unused";
#elif UNITY_ANDROID
            string adUnitId = "ca-app-pub-1315005540329283/4713540257";
#elif UNITY_IPHONE
            string adUnitId = "INSERT_IOS_INTERSTITIAL_AD_UNIT_ID_HERE";

#else
            string adUnitId = "unexpected_platform";
#endif

        // Create a 320x50 banner at the top of the screen.
        bannerView = new BannerView(adUnitId, AdSize.SmartBanner, AdPosition.Top);
        // Register for ad events.
        AdRequest request = new AdRequest.Builder().Build();
        bannerView.LoadAd(request);
        bannerView.AdLoaded += delegate (System.Object o, System.EventArgs e)
        { BannerIsLoaded = true; };




    }

    private static void BannerView_AdLoaded(object sender, System.EventArgs e)
    {
        throw new System.NotImplementedException();
    }

    public static void DestroyBanner()
    {
        bannerView.Destroy();
    }


    public static void ShowBanner()
    {
        if (bannerView != null)
        {
            bannerView.Show();
        }
    }
    public static void DestroyInterstitial()
    {
        interstitial.Destroy();
    }
   
    public static bool IsLoaded()
    {
        if (!BannerIsLoaded)
            return false;
      
        return true;
    }
    public static void HideBanner ()
    {
        if (bannerView != null)
        {
            bannerView.Hide();
        }
    }

    public static void RequestInterstitial()
    {
#if UNITY_EDITOR
        string adUnitId = "unused";
#elif UNITY_ANDROID
            string adUnitId = "ca-app-pub-1315005540329283/6190273450";
#elif UNITY_IPHONE
            string adUnitId = "INSERT_IOS_INTERSTITIAL_AD_UNIT_ID_HERE";
#else
            string adUnitId = "unexpected_platform";
#endif

        // Create an interstitial.
        interstitial = new InterstitialAd(adUnitId);
        AdRequest request = new AdRequest.Builder().Build();
       interstitial.LoadAd(request);
       InterstitialIsLoaded = true;
       
    }

    public static void ShowInterstitial()
    {
        if (interstitial.IsLoaded())
        {
            interstitial.Show();
        }
      
    }
 
 
}
