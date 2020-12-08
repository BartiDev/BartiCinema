﻿using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaDesktopUI.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {
        public ShellViewModel()
        {
            ActivateItemAsync(IoC.Get<LoginViewModel>());
        }
    }
}