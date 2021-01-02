using Caliburn.Micro;
using CinemaDesktopUI.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerCinemaDesktopUI.ViewModels
{
    public class RoomViewModel : Conductor<object>
    {
        private readonly IEventAggregator _events;

        public RoomModel Room { get; set; }

        public RoomViewModel(IEventAggregator events)
        {
            _events = events;

            ActivateItemAsync(IoC.Get<RoomHaumeaViewModel>());
        }


    }
}
