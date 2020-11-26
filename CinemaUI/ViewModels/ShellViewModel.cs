using Caliburn.Micro;
using CinemaDesktopUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaUI.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {
        public ShellViewModel()
        {
            ActivateItemAsync(IoC.Get<LoginViewModel>());
        }
    }
}
