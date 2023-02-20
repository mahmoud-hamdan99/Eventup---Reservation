using EventReservation.Core.Data;
using EventReservation.Core.DTO;
using EventReservation.Core.Repository;
using EventReservation.Core.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EventReservation.Infra.Service
{
   public class HallService: IHallService
    {
        private readonly IHallRepository _hallRepository;
        public HallService(IHallRepository hallRepository)
        {
            _hallRepository = hallRepository;
        }

        public Hall CreateHall(Hall hall)
        {
            return _hallRepository.CreateHall(hall);
        }

        public bool DeleteHall(int id)
        {
            return _hallRepository.DeleteHall(id);
        }

        public List<HallReusltDto> GetAllHall()
        {
            return _hallRepository.GetAllHall();
        }

        public List<HallReusltDto> GetCheapestHall()
        {
            return _hallRepository.GetCheapestHall();
        }

        public List<HallReusltDto> GetHallByCapacity(int CAP)
        {
            return _hallRepository.GetHallByCapacity(CAP);
        }

        public List<HallReusltDto> GetHallByPrice(int price)
        {
            return _hallRepository.GetHallByPrice(price);
        }

        public HallReusltDto GetHallById(int id)
        {
            return _hallRepository.GetHallById(id);
        }

        public Location GetHallByLocationId(int id)
        {
            return _hallRepository.GetHallByLocationId(id);
        }

        public List<HallReusltDto> GetHallByName(string name)
        {
            return _hallRepository.GetHallByName(name);
        }

        public List<HallReusltDto> GetHallByUsage(string usage)
        {
            return _hallRepository.GetHallByUsage(usage);
        }

        public bool UpdateHall(Hall hall)
        {
            return _hallRepository.UpdateHall(hall);
        }

        public Task<List<Hall>> GetAllHallImage()
        {
            return _hallRepository.GetAllHallImage();
        }

        public List<HallReusltDto> GetBestRte()
        {
            return _hallRepository.GetBestRte();
        }
    }
}
