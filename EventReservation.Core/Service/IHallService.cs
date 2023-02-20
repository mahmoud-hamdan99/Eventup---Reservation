using EventReservation.Core.Data;
using EventReservation.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EventReservation.Core.Service
{
    public interface IHallService
    {
        Hall CreateHall(Hall hall);
        bool UpdateHall(Hall hall);
        bool DeleteHall(int id);
        List<HallReusltDto> GetAllHall();
        HallReusltDto GetHallById(int id);
        List<HallReusltDto> GetHallByName(string name);
        List<HallReusltDto> GetCheapestHall();
        List<HallReusltDto> GetHallByCapacity(int CAP);
        List<HallReusltDto> GetHallByPrice(int price);
        Location GetHallByLocationId(int id);
        List<HallReusltDto> GetHallByUsage(string usage);
        List<HallReusltDto> GetBestRte();
        Task<List<Hall>> GetAllHallImage();
    }
}
