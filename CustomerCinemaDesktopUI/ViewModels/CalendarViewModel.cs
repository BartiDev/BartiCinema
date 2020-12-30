using Caliburn.Micro;
using CinemaDesktopUI.Library.API;
using CinemaDesktopUI.Library.Models;
using CustomerCinemaDesktopUI.EventModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CustomerCinemaDesktopUI.ViewModels
{
    public class CalendarViewModel : Screen
    {
        private List<ScreeningModel> _screenings;
        private List<FilmModel> _films = new List<FilmModel>();
        private FilmModel _selectedFilm;
        private readonly IScreeningEndpoint _screeningEndpoint;
        private readonly IEventAggregator _events;
        private readonly IFilmEndpoint _filmEndpoint;
        private string _searchedPhrase;
        private bool _isDropDownOpen;


        public FilmModel SelectedFilm
        {
            get { return _selectedFilm; }
            set 
            {
                if (value != null)
                {
                    _selectedFilm = value; 
                    NotifyOfPropertyChange(() => SelectedFilm); 
                    LoadScreeningsByFilmId(_selectedFilm.Id);
                }
            }
        }
        public bool IsDropDownOpen
        {
            get { return _isDropDownOpen; }
            set { _isDropDownOpen = value; NotifyOfPropertyChange(() => IsDropDownOpen); }
        }
        public string SearchedPhrase
        {
            get { return _searchedPhrase; }
            set 
            { 
                _searchedPhrase = value; 
                NotifyOfPropertyChange(() => SearchedPhrase); 
                LoadFilms(); 
                DropDownComboBox();
                NotifyOfPropertyChange(() => CanViewAll);
            }
        }
        public List<FilmModel> Films
        {
            get { return _films; }
            set { _films = value; NotifyOfPropertyChange(() => Films); }
        }
        public List<ScreeningModel> Screenings
        {
            get { return _screenings; }
            set { _screenings = value; NotifyOfPropertyChange(() => Screenings); }
        }


        public CalendarViewModel(IScreeningEndpoint screeningEndpoint, IEventAggregator events,
            IFilmEndpoint filmEndpoint)
        {
            _screeningEndpoint = screeningEndpoint;
            _events = events;
            _filmEndpoint = filmEndpoint;

            IsDropDownOpen = false;
        }

        public async Task LoadScreeningsByFilmId(int filmId)
        {
            Screenings = await _screeningEndpoint.GetByFilmId(filmId);
        }

        public async Task LoadFilms()
        {
            Films.Clear();
            Films = await _filmEndpoint.GetFiveByTitle(SearchedPhrase);
        }

        public void Home()
        {
            _events.PublishOnUIThreadAsync(new BackToHomeEventModel());
        }

        public void DropDownComboBox()
        {
            if (string.IsNullOrWhiteSpace(SearchedPhrase))
            {
                IsDropDownOpen = false;
            }
            else
            {
                IsDropDownOpen = true;
            }
        }

        public bool CanViewAll
        {
            get
            {
                if (string.IsNullOrWhiteSpace(SearchedPhrase))
                {
                    return false;
                }
                else
                {
                    return true;
                }   
            }
        }

        public void ViewAll()
        {
            _events.PublishOnUIThreadAsync(new ShowFilmsByTitleEvent() { Title = SearchedPhrase });
        }
    }
}
