﻿using Caliburn.Micro;
using CinemaDesktopUI.Library.API;
using CustomerCinemaDesktopUI.Helpers;
using CustomerCinemaDesktopUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace CustomerCinemaDesktopUI
{
    class Bootstrapper : BootstrapperBase
    {
        public Bootstrapper()
        {
            Initialize();

            ConventionManager.AddElementConvention<PasswordBox>(
                PasswordBoxHelper.BoundPasswordProperty,
                "Password",
                "PasswordChanged");
        }

        private SimpleContainer _container = new SimpleContainer();

        protected override void Configure()
        {
            _container
                .Singleton<IWindowManager, WindowManager>()
                .Singleton<IEventAggregator, EventAggregator>();


            _container.Instance(_container)
                .PerRequest<IAPIHelper, APIHelper>()
                .PerRequest<IFilmEndpoint, FilmEndpoint>()
                .PerRequest<IScreeningEndpoint, ScreeningEndpoint>()
                .PerRequest<IRoomEndpoint, RoomEndpoint>()
                .PerRequest<ITicketEndpoint, TicketEndpoint>()
                .PerRequest<IBookingEndpoint, BookingEndpoint>();


            GetType().Assembly.GetTypes()
                .Where(type => type.IsClass)
                .Where(type => type.Name.EndsWith("ViewModel"))
                .ToList()
                .ForEach(viewModelType => _container.RegisterPerRequest(
                    viewModelType, viewModelType.ToString(), viewModelType));
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<ShellViewModel>();
        }

        protected override object GetInstance(Type service, string key)
        {
            return _container.GetInstance(service, key);
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return _container.GetAllInstances(service);
        }

        protected override void BuildUp(object instance)
        {
            _container.BuildUp(instance);
        }
    }
}
