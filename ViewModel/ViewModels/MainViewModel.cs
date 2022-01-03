// <copyright file="MainViewModel.cs" company="Visual Software Systems Ltd.">Copyright (c) 2022. All rights reserved</copyright>

namespace WinUITabSample.ViewModels
{
    using Vssl.VisualFramework.ServiceInterfaces;
    using WinUITabSample.Services.ServiceInterfaces;
    using WinUITabSample.ViewInterfaces;
    using WinUITabSample.ViewModelInterfaces;

    /// <summary>
    /// The view model for the main window.
    /// </summary>
    public class MainViewModel : PageViewModelBase, IMainViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainViewModel"/> class
        /// </summary>
        /// <param name="navigationService">The navigation service.</param>
        /// <param name="messageService">The bottom bar message service.</param>
        public MainViewModel(INavigationService navigationService, IMessageService messageService)
            : base(navigationService, messageService)
        {
        }

        /// <summary>
        /// Gets a value indicating whether the home tabs should be displayed.
        /// </summary>
        public bool ShowHomeTabs { get; private set; }

        /// <summary>
        /// Gets a value indicating whether the setting tabs should be displayed.
        /// </summary>
        public bool ShowSettingsTabs { get; private set; }

        /// <summary>
        /// Gets a value indicating whether the T Fata tabs should be displayed.
        /// </summary>
        public bool ShowTDataTabs { get; private set; }

        /// <summary>
        /// Gets a value indicating whether the Left Hand panel should be displayed.
        /// </summary>
        public bool ShowLHPanel { get; private set; }

        /// <summary>
        /// Gets the sub header text.
        /// </summary>
        public string SubHeader { get; private set; }

        #region [ IPresenterLoadedViewModel Methods ]

        /// <summary>
        /// Override method called when the view model is loaded
        /// </summary>
        /// <returns>The async task that can be awaited</returns>
        public async Task OnLoad()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// Override method called when the view model is unloaded
        /// </summary>
        /// <returns>The async task that can be awaited</returns>
        public async Task OnUnload()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// Called when the page referencing the view model is navigated to
        /// After the datacontext has been set.
        /// </summary>
        /// <param name="navigationParameters">The optional n avigation parameters</param>
        public void OnNavigatedTo(object navigationParameters)
        {
            this.NavigateToPage("home", null);
        }

        #endregion

        /// <summary>
        /// Navigate the the page identified by the tag string
        /// </summary>
        /// <param name="navItemTag">The navigation tab tag</param>
        /// <param name="transitionInfo">Optional transition information</param>
        public override void NavigateToPage(string navItemTag, object transitionInfo)
        {
            Type pageType = null;
            int frameNo = 0;

            switch (navItemTag)
            {
                case "home":
                    this.SubHeader = "Home";
                    this.ShowSettingsTabs = false;
                    this.ShowHomeTabs = true;
                    pageType = typeof(IHomePage);
                    this.OnPropertyChanged(nameof(this.ShowSettingsTabs));
                    this.OnPropertyChanged(nameof(this.ShowHomeTabs));
                    break;
                case "settings":
                    this.SubHeader = "Settings";
                    this.ShowHomeTabs = false;
                    this.ShowSettingsTabs = true;
                    pageType = typeof(IS1Page);
                    this.OnPropertyChanged(nameof(this.ShowSettingsTabs));
                    this.OnPropertyChanged(nameof(this.ShowHomeTabs));
                    break;
                case "W":
                    this.SubHeader = "Home";
                    pageType = typeof(IHomePage);
                    break;
                case "T":
                    this.SubHeader = null;
                    this.ShowTDataTabs = true;
                    pageType = typeof(IT1Page);
                    this.OnPropertyChanged(nameof(this.ShowTDataTabs));
                    break;
                case "C":
                    pageType = typeof(ICPage);
                    this.SubHeader = "C Data";
                    break;
                case "V":
                    break;
                case "G":
                    break;
                case "F":
                    break;
                case "R":
                    break;
                case "T1":
                    pageType = typeof(IT1Page);
                    break;
                case "T2":
                    pageType = typeof(IT2Page);
                    break;
                case "T3":
                    break;
                case "T4":
                    break;
                case "LH1":
                    pageType = typeof(ILH1Page);
                    frameNo = 1;
                    break;
                case "LH2":
                    pageType = typeof(ILH2Page);
                    frameNo = 1;
                    break;
            }

            this.OnPropertyChanged(nameof(this.SubHeader));
            if (this.SubHeader != null && this.ShowTDataTabs)
            {
                this.ShowTDataTabs = false;
                this.OnPropertyChanged(nameof(this.ShowTDataTabs));
            }

            if (pageType != null)
            {
                switch (frameNo)
                {
                    case 0:
                        this.NavigationService.Navigate(pageType, null, transitionInfo);
                        break;
                    case 1:
                        this.NavigationService.NavigateSecondary(frameNo, pageType, null, transitionInfo);
                        break;
                }
            }
            else
            {
                this.MessageService.Notify($"No registered page found for tag '{navItemTag}'");
            }
        }

        /// <summary>
        /// Toggle the visibility of the Left Hand panel.
        /// </summary>
        public void ToggleLHPanel()
        {
            this.ShowLHPanel = !this.ShowLHPanel;
            this.OnPropertyChanged(nameof(this.ShowLHPanel));

            if (this.ShowLHPanel)
            {
                this.NavigateToPage("LH1", null);
            }
        }
    }
}