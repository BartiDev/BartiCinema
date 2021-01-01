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
        private List<DescriptiveScreeningModel> _screenings;
        private List<FilmModel> _films = new List<FilmModel>();
        private FilmModel _selectedFilm;
        private readonly IScreeningEndpoint _screeningEndpoint;
        private readonly IEventAggregator _events;
        private readonly IFilmEndpoint _filmEndpoint;
        private string _searchedPhrase;
        private bool _isDropDownOpen;


        public string SecondButtonContent { get; set; }
        public string ThirdButtonContent { get; set; }
        public string FourthButtonContent { get; set; }
        public string FifthButtonContent { get; set; }
        public string SixthButtonContent { get; set; }
        public string SeventhButtonContent { get; set; }


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
        public List<DescriptiveScreeningModel> Screenings
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

            SetUpButtonsContent();

            IsDropDownOpen = false;
        }

        public void SetUpButtonsContent()
        {
            // Hardcoded date "now"
            DateTime now = new DateTime(2020, 3, 12);
            string today = now.ToShortDateString();

            SecondButtonContent = now.AddDays(1).DayOfWeek.ToString();
            ThirdButtonContent = now.AddDays(2).DayOfWeek.ToString();
            FourthButtonContent = now.AddDays(3).DayOfWeek.ToString();
            FifthButtonContent = now.AddDays(4).DayOfWeek.ToString();
            SixthButtonContent = now.AddDays(5).DayOfWeek.ToString();
            SeventhButtonContent = now.AddDays(6).DayOfWeek.ToString();
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

        public async Task ChooseScreeningsByDay(string button)
        {
            // Hardcoded date "now"
            DateTime now = new DateTime(2020, 3, 12);

            switch (button)
            {
                case "first":
                    Screenings = await _screeningEndpoint.GetByStartTime(now);
                    break;
                case "second":
                    Screenings = await _screeningEndpoint.GetByStartTime(now.AddDays(1));
                    break;
                case "third":
                    Screenings = await _screeningEndpoint.GetByStartTime(now.AddDays(2));
                    break;
                case "fourth":
                    Screenings = await _screeningEndpoint.GetByStartTime(now.AddDays(3));
                    break;
                case "fifth":
                    Screenings = await _screeningEndpoint.GetByStartTime(now.AddDays(4));
                    break;
                case "sixth":
                    Screenings = await _screeningEndpoint.GetByStartTime(now.AddDays(5));
                    break;
                case "seventh":
                    Screenings = await _screeningEndpoint.GetByStartTime(now.AddDays(6));
                    break;
            }
        }
    }
}
