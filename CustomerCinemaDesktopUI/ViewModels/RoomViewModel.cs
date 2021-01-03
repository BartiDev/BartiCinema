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
            switch (Room.Name)
            {
                case "Haumea":
                    RoomHaumeaViewModel roomHaumeaVM = IoC.Get<RoomHaumeaViewModel>();
                    roomHaumeaVM.CurrentRoom = Room;

                    await ActivateItemAsync(roomHaumeaVM);                    
                    break;

                case "Eris":
                    RoomErisViewModel roomErisVM = IoC.Get<RoomErisViewModel>();
                    roomErisVM.CurrentRoom = Room;

                    await ActivateItemAsync(roomErisVM);
                    break;

                case "Ceres":
                    RoomCeresViewModel roomCeresVM = IoC.Get<RoomCeresViewModel>();
                    roomCeresVM.CurrentRoom = Room;

                    await ActivateItemAsync(roomCeresVM);
                    break;
            }
        }
    }
}
