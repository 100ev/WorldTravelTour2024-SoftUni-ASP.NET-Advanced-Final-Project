﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldTravelTour2024.Core.Contracts.Continent
{
    public interface IContinentService
    {
        public Task ExistAsync(int id);
        public Task<bool> ChangeItsVisitablePropertyBasedOnSeasonAsync(string season);
        public bool ContainsCountryAsync(string country);
    }
}
