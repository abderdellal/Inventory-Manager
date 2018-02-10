using GalaSoft.MvvmLight;

namespace Logic.ViewModels
{


    public class AboutViewModel : ViewModelBase
    {
        public string appName { get; set; } = "Inventory Manager 1.0";

        public AboutViewModel()
        {
            if (IsInDesignMode)
            {
                // Code runs in Blend --> create design time data.
                appName += " - Design";
            }
            else
            {
                // Code runs "for real"
            }
        }
        
    }
}
