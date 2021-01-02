using Caliburn.Micro;
using CinemaDesktopUI.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CustomerCinemaDesktopUI.ViewModels
{
    public class RoomViewModel : Conductor<object>
    {
        private readonly IEventAggregator _events;

        public RoomModel Room { get; set; }

        public RoomViewModel(IEventAggregator events)
        {
            _events = events;
        }

        public async Task ActivateRoomView()
        {
            RoomHaumeaViewModel roomHaumeaVM = IoC.Get<RoomHaumeaViewModel>();
            roomHaumeaVM.CurrentRoom = Room;

            await ActivateItemAsync(roomHaumeaVM);
        }
    }
}
