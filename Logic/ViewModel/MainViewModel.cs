﻿using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace Logic.ViewModel
{
    /// <summary>
    /// ViewModel of the Main Window
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// View/ViewModel to be displayed in the main frame (the View will be selected according to this ViewModel type)
        /// </summary>
        public ViewModelBase SelectedViewModel { get; set; }

        /// <summary>
        /// the view model locaor
        /// </summary>
        public ViewModelLocator locator { get; set; }

        /// <summary>
        /// command to be called from the main window to change the selected View/ViewModel
        /// </summary>
        public RelayCommand<ViewModelBase> changeViewCommand { get; set; }

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(ViewModelLocator locator)
        {
            this.locator = locator;

            //Home view/viewModel will be selected at startup
            SelectedViewModel = locator.Home;

            changeViewCommand = new RelayCommand<ViewModelBase>(vm =>
                                                                        {
                                                                            SelectedViewModel = vm;
                                                                        }
                                                                );
        }
    }
}
