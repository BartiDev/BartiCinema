using Caliburn.Micro;
using CinemaDesktopUI.Library.API;
using CinemaDesktopUI.Library.Models;
using CustomerCinemaDesktopUI.EventModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerCinemaDesktopUI.ViewModels
{
    public class RepetoireViewModel : Screen
    {
        private List<FilmModel> _filmsToDisplay;
        private readonly IFilmEndpoint _filmEndpoint;
        private readonly IEventAggregator _events;
        private string _serachedPhrase = "";
        private List<FilmModel> _allFilms;
        private FilmModel _selectedFilm;


        public FilmModel SelectedFilm
        {
            get { return _selectedFilm; }
            set { _selectedFilm = value; NotifyOfPropertyChange(() => SelectedFilm); ShowFilmDetails(); }
        }

        public List<FilmModel> AllFilms
        {
            get { return _allFilms; }
            set { _allFilms = value; }
        }

        public string SearchedPhrase
        {
            get { return _serachedPhrase; }
            set { _serachedPhrase = value; NotifyOfPropertyChange(() => SearchedPhrase); SearchFilms(); }
        }

        public List<FilmModel> FilmsToDisplay
        {
            get { return _filmsToDisplay; }
            set { _filmsToDisplay = value; NotifyOfPropertyChange(() => FilmsToDisplay); }
        }

        public RepetoireViewModel(IFilmEndpoint filmEndpoint, IEventAggregator events)
        {
            _filmEndpoint = filmEndpoint;
            _events = events;
            
            //LoadFilms();
        }

        public async Task LoadFilms()
        {
            AllFilms = await _filmEndpoint.GetAll();
            FilmsToDisplay = new List<FilmModel>(AllFilms);
        }

        public void Home()
        {
            _events.PublishOnUIThreadAsync(new BackToHomeEvent());
        }

        private async Task SearchFilms()
        {
            if (AllFilms == null)
            {
                await LoadFilms();
            }

            if(string.IsNullOrWhiteSpace(SearchedPhrase))
            {
                FilmsToDisplay = new List<FilmModel>(AllFilms);
            }
            else
            {
                FilmsToDisplay = AllFilms.Where(x => x.Title.ToLower().Contains(SearchedPhrase.ToLower())).ToList();
            }
        }

        public async Task SearchByTitle(string title)
        {
            FilmsToDisplay = await _filmEndpoint.GetAllByTitle(title);
        }

        private void ShowFilmDetails()
        {
            _events.PublishOnUIThreadAsync(new ShowFilmDetailsEvent() { Film = SelectedFilm });
        }
    }
}
