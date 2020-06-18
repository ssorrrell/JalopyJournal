using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JalopyJournal.Models
{
    public class OilAdditiveManager
    {
        public static IQueryable<OilAdditive> AddSortToQuery(IQueryable<OilAdditive> oilAdditive, string sortOrder)
        {
            switch (sortOrder)
            {
                case "miles_desc":
                    oilAdditive = oilAdditive.OrderByDescending(s => s.Miles);
                    break;
                case "car_asc":
                    oilAdditive = oilAdditive.OrderBy(s => s.Car.Description);
                    break;
                case "car_desc":
                    oilAdditive = oilAdditive.OrderByDescending(s => s.Car.Description);
                    break;
                case "additivetype_asc":
                    oilAdditive = oilAdditive.OrderBy(s => s.AdditiveType);
                    break;
                case "additivetype_desc":
                    oilAdditive = oilAdditive.OrderByDescending(s => s.AdditiveType);
                    break;
                case "cost_asc":
                    oilAdditive = oilAdditive.OrderBy(s => s.Cost);
                    break;
                case "cost_desc":
                    oilAdditive = oilAdditive.OrderByDescending(s => s.Cost);
                    break;
                case "notes_asc":
                    oilAdditive = oilAdditive.OrderBy(s => s.Notes);
                    break;
                case "notes_desc":
                    oilAdditive = oilAdditive.OrderByDescending(s => s.Notes);
                    break;
                case "date_asc":
                    oilAdditive = oilAdditive.OrderBy(s => s.Date);
                    break;
                case "date_desc":
                    oilAdditive = oilAdditive.OrderByDescending(s => s.Date);
                    break;
                default: //miles
                    oilAdditive = oilAdditive.OrderBy(s => s.Miles);
                    break;
            }
            return oilAdditive;
        }
    }
}