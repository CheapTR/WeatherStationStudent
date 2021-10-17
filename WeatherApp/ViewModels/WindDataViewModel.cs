using System;
using System.Collections.Generic;
using System.Text;
using WeatherApp.Commands;

namespace WeatherApp.ViewModels
{
    public class WindDataViewModel : BaseViewModel
    {
        /// TODO : Ajoutez le code nécessaire pour réussir les tests et répondre aux requis du projet

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
            throw new NotImplementedException();
        }



    }
}
