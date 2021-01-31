using Caliburn.Micro;
using CustomerCinemaDesktopUI.EventModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerCinemaDesktopUI.ViewModels
{
    class HomeViewModel : Screen
    {
        private readonly IEventAggregator _eventAggregator;
        private bool _isLoadingMessageVisible;

        public bool IsLoadingMessageVisible
        {
            get { return _isLoadingMessageVisible; }
            set { _isLoadingMessageVisible = value; NotifyOfPropertyChange(() => IsLoadingMessageVisible); }
        }


        public HomeViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            IsLoadingMessageVisible = false;
        }

        public void Repetoire()
        {
            IsLoadingMessageVisible = true;
            _eventAggregator.PublishOnUIThreadAsync(new OpenRepetoireEvent());
        }

        public void Calendar()
        {
            _eventAggregator.PublishOnUIThreadAsync(new OpenCalendarEvent());
        }
    }
}
