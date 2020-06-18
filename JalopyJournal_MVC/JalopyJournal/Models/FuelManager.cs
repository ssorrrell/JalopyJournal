using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JalopyJournal.Models
{
    public class FuelManager
    {
        public static IQueryable<Fuel> AddSortToQuery(IQueryable<Fuel> fuel, string sortOrder)
        {
            switch (sortOrder)
            {
                case "miles_desc":
                    fuel = fuel.OrderByDescending(s => s.Miles);
                    break;
                case "car_asc":
                    fuel = fuel.OrderBy(s => s.Car.Description);
                    break;
                case "car_desc":
                    fuel = fuel.OrderByDescending(s => s.Car.Description);
                    break;
                case "fueltype_asc":
                    fuel = fuel.OrderBy(s => s.FuelType);
                    break;
                case "fueltype_desc":
                    fuel = fuel.OrderByDescending(s => s.FuelType);
                    break;
                case "cost_asc":
                    fuel = fuel.OrderBy(s => s.Cost);
                    break;
                case "cost_desc":
                    fuel = fuel.OrderByDescending(s => s.Cost);
                    break;
                case "notes_asc":
                    fuel = fuel.OrderBy(s => s.Notes);
                    break;
                case "notes_desc":
                    fuel = fuel.OrderByDescending(s => s.Notes);
                    break;
                case "date_asc":
                    fuel = fuel.OrderBy(s => s.Date);
                    break;
                case "date_desc":
                    fuel = fuel.OrderByDescending(s => s.Date);
                    break;
                default: //miles
                    fuel = fuel.OrderBy(s => s.Miles);
                    break;
            }
            return fuel;
        }
    }
}