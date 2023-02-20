﻿using EventReservation.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventReservation.Core.Repository
{
    public interface ILocationRepository
    {
        List<Location>GetAllLocation();
        Location SetLocation(Location location);
        bool UpdateLocation(Location location);
        bool DeleteLocation(int locationId);
        Location GetLocationById(int locationId);
        Location GetlocationIdByAddress(string locationLan, string locationLat);
        List<Location> GetlocationIdByCity(string city);


        List<Location> GetlocationByCountry(string Country);
    }
}
