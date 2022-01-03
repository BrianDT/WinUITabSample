// <copyright file="IMainViewModel.cs" company="Visual Software Systems Ltd.">Copyright (c) 2022 All rights reserved</copyright>

namespace WinUITabSample.ViewModelInterfaces
{
    using Vssl.Samples.ViewModelInterfaces;
    using Vssl.VisualFramework.ViewModelInterfaces;

    /// <summary>
    /// The view model for the main window.
    /// </summary>
    public interface IMainViewModel : IPageViewModelBase, IPresenterLoadedViewModel
    {
        /// <summary>
        /// Gets a value indicating whether the home tabs should be displayed.
        /// </summary>
        bool ShowHomeTabs { get; }

        /// <summary>
        /// Gets a value indicating whether the setting tabs should be displayed.
        /// </summary>
        bool ShowSettingsTabs { get; }

        /// <summary>
        /// Gets a value indicating whether the T Fata tabs should be displayed.
        /// </summary>
        bool ShowTDataTabs { get; }

        /// <summary>
        /// Gets a value indicating whether the Left Hand panel should be displayed.
        /// </summary>
        bool ShowLHPanel { get; }

        /// <summary>
        /// Gets the sub header text.
        /// </summary>
        string SubHeader { get; }

        /// <summary>
        /// Toggle the visibility of the Left Hand panel.
        /// </summary>
        void ToggleLHPanel();
    }
}