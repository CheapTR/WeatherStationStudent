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
            return kph * 1000 / 3600;
        }

        public double MPStoKPH(double mps)
        {
            return mps * 3600 / 1000;
        }
        public bool CanGetData(object obj)
        {
            throw new NotImplementedException();
        }



    }
}
