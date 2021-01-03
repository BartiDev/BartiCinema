using Caliburn.Micro;
using CinemaDesktopUI.Library.Models;
using CustomerCinemaDesktopUI.EventModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CustomerCinemaDesktopUI.ViewModels
{
    public class RoomViewModel : Conductor<object>, IHandle<ContinueBookingEvent>
    {
        private readonly IEventAggregator _events;

        public RoomModel Room { get; set; }
        public int ScreeningId { get; set; }

        public RoomViewModel(IEventAggregator events)
        {
            _events = events;
            _events.SubscribeOnPublishedThread(this);
        }

        public async Task ActivateRoomView()
        {
            switch (Room.Name)
            {
                case "Haumea":
                    RoomHaumeaViewModel roomHaumeaVM = IoC.Get<RoomHaumeaViewModel>();
                    roomHaumeaVM.CurrentRoom = Room;
                    roomHaumeaVM.ScreeningId = ScreeningId;

                    await ActivateItemAsync(roomHaumeaVM);                    
                    break;

                case "Eris":
                    RoomErisViewModel roomErisVM = IoC.Get<RoomErisViewModel>();
                    roomErisVM.CurrentRoom = Room;
                    roomErisVM.ScreeningId = ScreeningId;

                    await ActivateItemAsync(roomErisVM);
                    break;

                case "Ceres":
                    RoomCeresViewModel roomCeresVM = IoC.Get<RoomCeresViewModel>();
                    roomCeresVM.CurrentRoom = Room;
                    roomCeresVM.ScreeningId = ScreeningId;

                    await ActivateItemAsync(roomCeresVM);
                    break;
            }
        }

        public async Task HandleAsync(ContinueBookingEvent message, CancellationToken cancellationToken)
        {
            message.Room = Room;
            message.ScreeningId = ScreeningId;


        }
    }
}
