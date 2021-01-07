using Caliburn.Micro;
using CustomerCinemaDesktopUI.EventModels;
using CustomerCinemaDesktopUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CustomerCinemaDesktopUI.ViewModels
{
    public class ShellViewModel : Conductor<object>, IHandle<OpenRepetoireEvent>, IHandle<BackToHomeEvent>
        ,IHandle<ShowFilmDetailsEvent>, IHandle<ShowFilmScreeningsEvent>, IHandle<OpenCalendarEvent>
        ,IHandle<ShowFilmsByTitleEvent>, IHandle<OpenScreeningViewEvent>, IHandle<OpenBookingViewEvent>
    {
        private readonly IEventAggregator _events;

        public ShellViewModel(IEventAggregator events)
        {
            _events = events;

            _events.SubscribeOnPublishedThread(this);
            ActivateItemAsync(IoC.Get<HomeViewModel>());
        }


        public async Task HandleAsync(OpenRepetoireEvent message, CancellationToken cancellationToken)
        {
            RepetoireViewModel repetoireVM = IoC.Get<RepetoireViewModel>();
            await repetoireVM.LoadFilms();

            await ChangeActiveItemAsync(repetoireVM, true);
        }

        public async Task HandleAsync(BackToHomeEvent message, CancellationToken cancellationToken)
        {
            await ChangeActiveItemAsync(IoC.Get<HomeViewModel>(), true);
        }

        public async Task HandleAsync(ShowFilmDetailsEvent message, CancellationToken cancellationToken)
        {
            FilmDetailsViewModel filmDetailsVM = IoC.Get<FilmDetailsViewModel>();
            filmDetailsVM.Film = message.Film;
            
            await ChangeActiveItemAsync(filmDetailsVM, true);
        }

        public async Task HandleAsync(ShowFilmScreeningsEvent message, CancellationToken cancellationToken)
        {
            CalendarViewModel calendarVM = IoC.Get<CalendarViewModel>();

            await calendarVM.LoadScreeningsByFilmId(message.FilmId);

            await ChangeActiveItemAsync(calendarVM, true);
        }

        public async Task HandleAsync(OpenCalendarEvent message, CancellationToken cancellationToken)
        {
            await ChangeActiveItemAsync(IoC.Get<CalendarViewModel>(), true);
        }

        public async Task HandleAsync(ShowFilmsByTitleEvent message, CancellationToken cancellationToken)
        {
            RepetoireViewModel repetoireVM = IoC.Get<RepetoireViewModel>();

            await repetoireVM.SearchByTitle(message.Title);

            await ChangeActiveItemAsync(repetoireVM, true);
        }

        public async Task HandleAsync(OpenScreeningViewEvent message, CancellationToken cancellationToken)
        {
            ScreeningViewModel screeningVM = IoC.Get<ScreeningViewModel>();
            await screeningVM.LoadData(message.ScreeningId);

            await ChangeActiveItemAsync(screeningVM, true);
        }

        public async Task HandleAsync(OpenBookingViewEvent message, CancellationToken cancellationToken)
        {
            BookingViewModel bookingVM = IoC.Get<BookingViewModel>();
            bookingVM.Room = message.Room;
            bookingVM.Screening = message.Screening;
            bookingVM.Film = message.Film;

            await bookingVM.LoadTakenSeats();

            await bookingVM.ActivateRoomView();

            await ChangeActiveItemAsync(bookingVM, true);
        }
    }
}
