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
    public class ShellViewModel : Conductor<object>, IHandle<OpenRepetoireEventModel>, IHandle<BackToHomeEventModel>
        ,IHandle<ShowFilmDetailsEvent>
    {
        private readonly IEventAggregator _events;

        public ShellViewModel(IEventAggregator events)
        {
            _events = events;

            _events.SubscribeOnPublishedThread(this);
            ActivateItemAsync(IoC.Get<HomeViewModel>());
        }


        public async Task HandleAsync(OpenRepetoireEventModel message, CancellationToken cancellationToken)
        {
            await ActivateItemAsync(IoC.Get<RepetoireViewModel>());
        }

        public async Task HandleAsync(BackToHomeEventModel message, CancellationToken cancellationToken)
        {
            await ActivateItemAsync(IoC.Get<HomeViewModel>());
        }

        public async Task HandleAsync(ShowFilmDetailsEvent message, CancellationToken cancellationToken)
        {
            await ActivateItemAsync(new FilmDetailsViewModel(message.film, _events));
        }
    }
}
