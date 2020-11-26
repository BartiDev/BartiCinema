using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaDesktopUI.ViewModels
{
    public class LoginViewModel : Screen
    {
        private string _username = "";
        private string _password = "";

        public string Username
        {
            get { return _username; }
            set { _username = value; NotifyOfPropertyChange(() => Username); NotifyOfPropertyChange(() => CanLogIn); }
        }

        public string Password
        {
            get { return _password; }
            set { _password = value; NotifyOfPropertyChange(() => Password); NotifyOfPropertyChange(() => CanLogIn); }
        }

        public bool CanLogIn
        {
            get
            {
                bool output = true;

                if(string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password))
                {
                    output = false;
                }

                return output;
            }
        }

        public void LogIn()
        {

        }
    }
}
