using Dapper;
using EventReservation.Core.Common;
using EventReservation.Core.Data;
using EventReservation.Core.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventReservation.Core.Repository
{
   public class HallRepository: IHallRepository
    {
        private readonly IDbContext _dbContext;

        public HallRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;

        }
        public Hall CreateHall(Hall hall)
        {
            var parmeter = new DynamicParameters();

            parmeter.Add("HNAME", hall.Name, dbType: DbType.String, direction: ParameterDirection.Input);
            parmeter.Add("HCAP", hall.Capacity, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parmeter.Add("HWAIT", hall.Waiters, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parmeter.Add("HSALE", hall.Sale, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parmeter.Add("HRATE", hall.Rate, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parmeter.Add("HPRICE", hall.Reservationprice, dbType: DbType.Double, direction: ParameterDirection.Input);
            parmeter.Add("HLOC", hall.Locationid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parmeter.Add("HUSAGE", hall.Usage, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.QueryFirstOrDefault<Hall>("HALL_F_PACKAGE.CREATEHALL", parmeter, commandType: CommandType.StoredProcedure);
            if (result == null)
                return null;

            return result;
        }

        public bool UpdateHall(Hall hall)
        {
            var parmeter = new DynamicParameters();

            parmeter.Add("ID", hall.Hallid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parmeter.Add("HNAME", hall.Name, dbType: DbType.String, direction: ParameterDirection.Input);
            parmeter.Add("HCAP", hall.Capacity, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parmeter.Add("HWAIT", hall.Waiters, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parmeter.Add("HSALE", hall.Sale, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parmeter.Add("HRATE", hall.Rate, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parmeter.Add("HPRICE", hall.Reservationprice, dbType: DbType.Double, direction: ParameterDirection.Input);
            parmeter.Add("HLOC", hall.Locationid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parmeter.Add("HUSAGE", hall.Usage, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.ExecuteAsync("HALL_F_PACKAGE.UPDATEHALL", parmeter, commandType: CommandType.StoredProcedure);
            if (result == null)
                return false;

            return true;
        }

        public bool DeleteHall(int id)
        {
            var parmeter = new DynamicParameters();
            parmeter.Add("ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            _dbContext.Connection.ExecuteAsync("HALL_F_PACKAGE.DELETEHALL", parmeter, commandType: CommandType.StoredProcedure);

            return true;
        }

        public List<HallReusltDto> GetAllHall()
        {
            IEnumerable<HallReusltDto> result = _dbContext.Connection.Query<HallReusltDto>("HALL_F_PACKAGE.GETALLHALL", commandType: CommandType.StoredProcedure);

            return result.ToList();
        }

        public HallReusltDto GetHallById(int id)
        {
            var parmeter = new DynamicParameters();
            parmeter.Add("ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            IEnumerable<HallReusltDto> result = _dbContext.Connection.Query<HallReusltDto>("HALL_F_PACKAGE.GETHALLBYID", parmeter, commandType: CommandType.StoredProcedure);


            return result.FirstOrDefault();
        }

        public List<HallReusltDto> GetHallByName(string name)
        {
            var parmeter = new DynamicParameters();
            parmeter.Add("HNAME", name, dbType: DbType.String, direction: ParameterDirection.Input);

            IEnumerable<HallReusltDto> result = _dbContext.Connection.Query<HallReusltDto>("HALL_F_PACKAGE.GETHALLBYNAME", parmeter, commandType: CommandType.StoredProcedure);


            return result.ToList();
        }

        public List<HallReusltDto> GetCheapestHall()
        {

            IEnumerable<HallReusltDto> result = _dbContext.Connection.Query<HallReusltDto>("HALL_F_PACKAGE.CHEAPESTHALL", commandType: CommandType.StoredProcedure);

            return result.ToList();
        }

        public List<HallReusltDto> GetHallByCapacity(int CAP)
        {
            var parmeter = new DynamicParameters();
            parmeter.Add("HCAP", CAP, dbType: DbType.Int32, direction: ParameterDirection.Input);

            IEnumerable<HallReusltDto> result = _dbContext.Connection.Query<HallReusltDto>("HALL_F_PACKAGE.GETHALLBYCAPACITY", parmeter, commandType: CommandType.StoredProcedure);


            return result.ToList();
        }

        public List<HallReusltDto> GetHallByPrice(int price)
        {
            var parmeter = new DynamicParameters();
            parmeter.Add("PRICE", price, dbType: DbType.Int32, direction: ParameterDirection.Input);

            IEnumerable<HallReusltDto> result = _dbContext.Connection.Query<HallReusltDto>("HALL_F_PACKAGE.GETHALLBYPRICE", parmeter, commandType: CommandType.StoredProcedure);


            return result.ToList();
        }

        public Location GetHallByLocationId(int id)
        {
            var parmeter = new DynamicParameters();
            parmeter.Add("ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.QueryFirstOrDefault<Location>("HALL_F_PACKAGE.GETHALLBYLOCATIONID", parmeter, commandType: CommandType.StoredProcedure);
            if (result == null)
                return null;


            return result;
        }

        public List<HallReusltDto> GetHallByUsage(string usage)
        {
            var parmeter = new DynamicParameters();
            parmeter.Add("HUSAGE", usage, dbType: DbType.String, direction: ParameterDirection.Input);

            IEnumerable<HallReusltDto> result = _dbContext.Connection.Query<HallReusltDto>("HALL_F_PACKAGE.GETHALLBYUSAGE", parmeter, commandType: CommandType.StoredProcedure);


            return result.ToList();
        }

        public async Task<List<Hall>> GetAllHallImage()
        {
            var result = await _dbContext.Connection.QueryAsync<Hall, Image, Hall>
            ("HALL_F_PACKAGE.GETALLHALL", (Hall, Image) =>
            {
                Hall.Image = Hall.Image ?? new List<Image>();
                Hall.Image.Add(Image);
                return Hall;
            },
            splitOn: "imageid",
            param: null,
            commandType: CommandType.StoredProcedure
            );

            var FinalResult = result.AsList<Hall>().GroupBy(p => p.Hallid)
            .Select(g =>
            {
                Hall hall = g.First();
                hall.Image = g.Where(g => g.Image.Any() && g.Image.Count() > 0)
                    .Select(p => p.Image.Single()).GroupBy(image => image.Imageid).Select(image => new Image
                    { 
                        Imageid= image.First().Imageid,
                        
                        Imageurl = image.First().Imageurl


                    }).ToList();
                return hall ;
            }).ToList();



            return FinalResult;
        }

        public List<HallReusltDto> GetBestRte()
        {
            IEnumerable<HallReusltDto> result = _dbContext.Connection.Query<HallReusltDto>("HALL_F_PACKAGE.GETBESTRATE", commandType: CommandType.StoredProcedure);

            return result.ToList();
        }
    }
}
