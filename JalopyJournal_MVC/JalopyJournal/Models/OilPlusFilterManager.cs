using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JalopyJournal.Models
{
    public class OilPlusFilterManager
    {
        public static IQueryable<OilPlusFilter> AddSortToQuery(IQueryable<OilPlusFilter> oilPlusFilter, string sortOrder)
        {
            switch (sortOrder)
            {
                case "miles_desc":
                    oilPlusFilter = oilPlusFilter.OrderByDescending(s => s.Miles);
                    break;
                case "car_asc":
                    oilPlusFilter = oilPlusFilter.OrderBy(s => s.Car.Description);
                    break;
                case "car_desc":
                    oilPlusFilter = oilPlusFilter.OrderByDescending(s => s.Car.Description);
                    break;
                case "oiltype_asc":
                    oilPlusFilter = oilPlusFilter.OrderBy(s => s.OilType);
                    break;
                case "oiltype_desc":
                    oilPlusFilter = oilPlusFilter.OrderByDescending(s => s.OilType);
                    break;
                case "oilfilter_asc":
                    oilPlusFilter = oilPlusFilter.OrderBy(s => s.OilFilter);
                    break;
                case "oilfilter_desc":
                    oilPlusFilter = oilPlusFilter.OrderByDescending(s => s.OilFilter);
                    break;
                case "cost_asc":
                    oilPlusFilter = oilPlusFilter.OrderBy(s => s.Cost);
                    break;
                case "cost_desc":
                    oilPlusFilter = oilPlusFilter.OrderByDescending(s => s.Cost);
                    break;
                case "notes_asc":
                    oilPlusFilter = oilPlusFilter.OrderBy(s => s.Notes);
                    break;
                case "notes_desc":
                    oilPlusFilter = oilPlusFilter.OrderByDescending(s => s.Notes);
                    break;
                case "date_asc":
                    oilPlusFilter = oilPlusFilter.OrderBy(s => s.Date);
                    break;
                case "date_desc":
                    oilPlusFilter = oilPlusFilter.OrderByDescending(s => s.Date);
                    break;
                default: //miles
                    oilPlusFilter = oilPlusFilter.OrderBy(s => s.Miles);
                    break;
            }
            return oilPlusFilter;
        }
    }
}