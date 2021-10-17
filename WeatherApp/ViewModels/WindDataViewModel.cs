﻿using System;
using System.Collections.Generic;
using System.Text;
using WeatherApp.Commands;
using WeatherApp.Models;
using WeatherApp.Services;

namespace WeatherApp.ViewModels
{
    public class WindDataViewModel : BaseViewModel
    {
        /// TODO : Ajoutez le code nécessaire pour réussir les tests et répondre aux requis du projet

        public IWindDataService WindDataService;
        public WindDataModel CurrendData;

        public void SetWindDataService(IWindDataService obj)
        {
            WindDataService = obj;
        }

        public DelegateCommand<string> GetDataCommand { get; private set; }

        public double KPHtoMPS(double kph)
        {
            return Math.Round(kph * 1000 / 3600, 2);
        }

        public double MPStoKPH(double mps)
        {
            return Math.Round(mps * 3600 / 1000, 2);
        }
        public bool CanGetData()
        {
            if (WindDataService != null)
                return true;

            return false;
        }



    }
}
