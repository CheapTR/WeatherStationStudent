﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Models;

namespace WeatherApp.Services
{
    public interface IWindDataService
    {
        public Task<WindDataModel> GetDataAsync();
    }
}
