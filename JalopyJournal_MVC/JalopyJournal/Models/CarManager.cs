using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JalopyJournal.Models
{
    public class CarManager
    {
        public static IQueryable<Car> AddSortToQuery(IQueryable<Car> car, string sortOrder)
        {
            switch (sortOrder)
            {
                case "description_desc":
                    car = car.OrderByDescending(s => s.Description);
                    break;
                default: //description
                    car = car.OrderBy(s => s.Description);
                    break;
            }
            return car;
        }
    }
}