using JalopyJournal.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace JalopyJournal.Models
{
    public class AirFilterManager
    {
        protected readonly JJContext db = new JJContext();

        public static IQueryable<AirFilter> AddSortToQuery(IQueryable<AirFilter> airFilter, string sortOrder)
        {
            //IQueryable<AirFilter> airFilter = (IQueryable<AirFilter>)partQueryable;
            switch (sortOrder)
            {
                case "miles_desc":
                    airFilter = airFilter.OrderByDescending(s => s.Miles);
                    break;
                case "car_asc":
                    airFilter = airFilter.OrderBy(s => s.Car.Description);
                    break;
                case "car_desc":
                    airFilter = airFilter.OrderByDescending(s => s.Car.Description);
                    break;
                case "filtertype_asc":
                    airFilter = airFilter.OrderBy(s => s.FilterType);
                    break;
                case "filtertype_desc":
                    airFilter = airFilter.OrderByDescending(s => s.FilterType);
                    break;
                case "cost_asc":
                    airFilter = airFilter.OrderBy(s => s.Cost);
                    break;
                case "cost_desc":
                    airFilter = airFilter.OrderByDescending(s => s.Cost);
                    break;
                case "notes_asc":
                    airFilter = airFilter.OrderBy(s => s.Notes);
                    break;
                case "notes_desc":
                    airFilter = airFilter.OrderByDescending(s => s.Notes);
                    break;
                case "date_asc":
                    airFilter = airFilter.OrderBy(s => s.Date);
                    break;
                case "date_desc":
                    airFilter = airFilter.OrderByDescending(s => s.Date);
                    break;
                default: //miles
                    airFilter = airFilter.OrderBy(s => s.Miles);
                    break;
            }
            return airFilter;
        }
    }
}