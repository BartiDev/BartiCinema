using Caliburn.Micro;
using CinemaDesktopUI.Library.API;
using CinemaDesktopUI.Library.Models;
using CustomerCinemaDesktopUI.EventModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CustomerCinemaDesktopUI.ViewModels
{
    public class BookingViewModel : Conductor<object>, IHandle<ContinueToCustomerInfoEvent>,
        IHandle<ContinueToSummaryEvent>, IHandle<BackToBookingEvent>, IHandle<BackToCustomerInfoEvent>
    {
        private readonly IEventAggregator _events;
        private readonly IScreeningEndpoint _screeningEndpoint;

        public RoomModel Room { get; set; }
        public ScreeningModel Screening { get; set; }
        public FilmModel Film { get; set; }
        public List<ReservedSeatModel> ReservedSeats { get; set; }
        public List<SeatModel> SeatsToReserve { get; set; }
        public CustomerModel Customer { get; set; }


        public BookingViewModel(IEventAggregator events, IScreeningEndpoint screeningEndpoint)
        {
            _events = events;
            _screeningEndpoint = screeningEndpoint;

            _events.SubscribeOnPublishedThread(this);
        }


        public async Task ActivateRoomView()
        {
            switch (Room.Name)
            {
                case "Haumea":
                    RoomHaumeaViewModel roomHaumeaVM = IoC.Get<RoomHaumeaViewModel>();
                    roomHaumeaVM.CurrentRoom = Room;
                    roomHaumeaVM.ScreeningId = Screening.Id;
                    roomHaumeaVM.ReservedSeats = ReservedSeats;
                    if(SeatsToReserve != null)
                    {
                        roomHaumeaVM.SeatsToReserve = SeatsToReserve;
                    }

                    await ActivateItemAsync(roomHaumeaVM);                    
                    break;

                case "Eris":
                    RoomErisViewModel roomErisVM = IoC.Get<RoomErisViewModel>();
                    roomErisVM.CurrentRoom = Room;
                    roomErisVM.ScreeningId = Screening.Id;
                    roomErisVM.ReservedSeats = ReservedSeats;
                    if (SeatsToReserve != null)
                    {
                        roomErisVM.SeatsToReserve = SeatsToReserve;
                    }

                    await ActivateItemAsync(roomErisVM);
                    break;

                case "Ceres":
                    RoomCeresViewModel roomCeresVM = IoC.Get<RoomCeresViewModel>();
                    roomCeresVM.CurrentRoom = Room;
                    roomCeresVM.ScreeningId = Screening.Id;
                    roomCeresVM.ReservedSeats = ReservedSeats;
                    if (SeatsToReserve != null)
                    {
                        roomCeresVM.SeatsToReserve = SeatsToReserve;
                    }

                    await ActivateItemAsync(roomCeresVM);
                    break;
            }
        }

        public async Task LoadTakenSeats()
        {
            ReservedSeats = await _screeningEndpoint.GetAllReservedSeats(Screening.Id);
        }

        public async Task HandleAsync(ContinueToCustomerInfoEvent message, CancellationToken cancellationToken)
        {
            SeatsToReserve = message.SeatsToReserve;

            BookingCustomerInfoViewModel bookingCustomerInfoVM = IoC.Get<BookingCustomerInfoViewModel>();
            if(Customer != null)
            {
                bookingCustomerInfoVM.Customer = Customer;
            }

            await ChangeActiveItemAsync(bookingCustomerInfoVM, true);
        }

        public async Task HandleAsync(ContinueToSummaryEvent message, CancellationToken cancellationToken)
        {
            BookingSummaryViewModel bookingSummaryVM = IoC.Get<BookingSummaryViewModel>();

            bookingSummaryVM.Customer = message.Customer;
            bookingSummaryVM.Room = this.Room;
            bookingSummaryVM.Screening = this.Screening;
            bookingSummaryVM.SeatsToReserve = this.SeatsToReserve;
            bookingSummaryVM.Film = this.Film;
            bookingSummaryVM.Ticket = message.Ticket;

            await ChangeActiveItemAsync(bookingSummaryVM, true);
        }

        public async Task HandleAsync(BackToBookingEvent message, CancellationToken cancellationToken)
        {
            Customer = message.Customer;

            await ActivateRoomView();
        }

        public async Task HandleAsync(BackToCustomerInfoEvent message, CancellationToken cancellationToken)
        {
            BookingCustomerInfoViewModel bookingCustomerInfoVM = IoC.Get<BookingCustomerInfoViewModel>();
            if (Customer != null)
            {
                bookingCustomerInfoVM.Customer = Customer;
            }

            await ChangeActiveItemAsync(bookingCustomerInfoVM, true);
        }
    }
}
