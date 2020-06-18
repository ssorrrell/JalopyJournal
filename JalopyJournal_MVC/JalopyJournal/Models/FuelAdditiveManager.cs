using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JalopyJournal.Models
{
    public class FuelAdditiveManager
    {
        public static IQueryable<FuelAdditive> AddSortToQuery(IQueryable<FuelAdditive> fuelAdditive, string sortOrder)
        {
            switch (sortOrder)
            {
                case "miles_desc":
                    fuelAdditive = fuelAdditive.OrderByDescending(s => s.Miles);
                    break;
                case "car_asc":
                    fuelAdditive = fuelAdditive.OrderBy(s => s.Car.Description);
                    break;
                case "car_desc":
                    fuelAdditive = fuelAdditive.OrderByDescending(s => s.Car.Description);
                    break;
                case "additivetype_asc":
                    fuelAdditive = fuelAdditive.OrderBy(s => s.AdditiveType);
                    break;
                case "additivetype_desc":
                    fuelAdditive = fuelAdditive.OrderByDescending(s => s.AdditiveType);
                    break;
                case "cost_asc":
                    fuelAdditive = fuelAdditive.OrderBy(s => s.Cost);
                    break;
                case "cost_desc":
                    fuelAdditive = fuelAdditive.OrderByDescending(s => s.Cost);
                    break;
                case "notes_asc":
                    fuelAdditive = fuelAdditive.OrderBy(s => s.Notes);
                    break;
                case "notes_desc":
                    fuelAdditive = fuelAdditive.OrderByDescending(s => s.Notes);
                    break;
                case "date_asc":
                    fuelAdditive = fuelAdditive.OrderBy(s => s.Date);
                    break;
                case "date_desc":
                    fuelAdditive = fuelAdditive.OrderByDescending(s => s.Date);
                    break;
                default: //miles
                    fuelAdditive = fuelAdditive.OrderBy(s => s.Miles);
                    break;
            }
            return fuelAdditive;
        }
    }
}