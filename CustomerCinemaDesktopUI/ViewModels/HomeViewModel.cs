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

        public HomeViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
        }

        public void Repetoire()
        {
            _eventAggregator.PublishOnUIThreadAsync(new OpenRepetoireEventModel());
        }

        public void Calendar()
        {
            _eventAggregator.PublishOnUIThreadAsync(new OpenCalendarEvent());
        }
    }
}
