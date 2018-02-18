using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Logic.Properties;

namespace Logic.ViewModels
{
    public class SettingsViewModel : ViewModelBase
    {
        public string firstName { get; set; }
        public string lastName { get; set; }

        private int _dailyTarget;
        public string stringDailyTarget
        {
            get
            {
                return _dailyTarget + "";
            }
            set
            {
                if (!int.TryParse(value, out _dailyTarget))
                {
                    _dailyTarget = 0;
                }
            }
        }

        private int _monthlyTarget;
        public string stringMonthlyTarget
        {
            get
            {
                return _monthlyTarget + "";
            }
            set
            {
                if (!int.TryParse(value, out _monthlyTarget))
                {
                    _monthlyTarget = 0;
                }
            }
        }

        public RelayCommand SaveCommand { get; set; }

        public SettingsViewModel()
        {
            _dailyTarget = (int) Settings.Default["DailyTargetAll"];
            _monthlyTarget = (int) Settings.Default["MonthlyTargetAll"];
            firstName = Settings.Default["firstName"].ToString();
            lastName = Settings.Default["lastName"].ToString();

            SaveCommand = new RelayCommand(() =>
            {
                Settings.Default["DailyTargetAll"] = _dailyTarget;
                Settings.Default["MonthlyTargetAll"] = _monthlyTarget;
                Settings.Default["firstName"] = firstName;
                Settings.Default["lastName"] = lastName;
                Settings.Default.Save();
            });
        }
    }
}
