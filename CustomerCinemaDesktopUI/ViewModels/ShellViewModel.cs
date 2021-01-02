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
        ,IHandle<ShowFilmsByTitleEvent>, IHandle<OpenScreeningViewEvent>, IHandle<OpenRoomViewEvent>
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

            await ActivateItemAsync(repetoireVM);
        }

        public async Task HandleAsync(BackToHomeEvent message, CancellationToken cancellationToken)
        {
            await ActivateItemAsync(IoC.Get<HomeViewModel>());
        }

        public async Task HandleAsync(ShowFilmDetailsEvent message, CancellationToken cancellationToken)
        {
            FilmDetailsViewModel filmDetailsVM = IoC.Get<FilmDetailsViewModel>();
            filmDetailsVM.Film = message.Film;
            
            await ActivateItemAsync(filmDetailsVM);
        }

        public async Task HandleAsync(ShowFilmScreeningsEvent message, CancellationToken cancellationToken)
        {
            CalendarViewModel calendarVM = IoC.Get<CalendarViewModel>();

            await calendarVM.LoadScreeningsByFilmId(message.FilmId);

            await ActivateItemAsync(calendarVM);
        }

        public async Task HandleAsync(OpenCalendarEvent message, CancellationToken cancellationToken)
        {
            await ActivateItemAsync(IoC.Get<CalendarViewModel>());
        }

        public async Task HandleAsync(ShowFilmsByTitleEvent message, CancellationToken cancellationToken)
        {
            RepetoireViewModel repetoireVM = IoC.Get<RepetoireViewModel>();

            await repetoireVM.SearchByTitle(message.Title);

            await ActivateItemAsync(repetoireVM);
        }

        public async Task HandleAsync(OpenScreeningViewEvent message, CancellationToken cancellationToken)
        {
            ScreeningViewModel screeningVM = IoC.Get<ScreeningViewModel>();
            await screeningVM.LoadData(message.ScreeningId);

            await ActivateItemAsync(screeningVM);
        }

        public async Task HandleAsync(OpenRoomViewEvent message, CancellationToken cancellationToken)
        {
            RoomViewModel roomVM = IoC.Get<RoomViewModel>();
            roomVM.Room = message.Room;

            await roomVM.ActivateRoomView();

            await ActivateItemAsync(roomVM);
        }
    }
}
