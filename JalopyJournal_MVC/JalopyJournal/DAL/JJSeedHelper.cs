using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using JalopyJournal.Models;

namespace JalopyJournal.DAL
{
    public class JJSeedHelper
    {
        private JJContext _context;

        public JJSeedHelper(JJContext context)
        {
            _context = context;
            Debug.WriteLine("Running JJSeedHelper Constructor");
        }

        public List<Car> AddCarData()
        {
            Debug.WriteLine("Starting Car..");
            var carList = new List<Car> {
                new Car() { Description = "Mustang" },
                new Car() { Description = "Fiero" },
                new Car() { Description = "El Camino" }
            };
            try
            {
                carList.ForEach(c => _context.Car.Add(c));
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error in Car");
                Debug.WriteLine(ex.Message);
                if (ex.InnerException != null) { Debug.WriteLine(ex.InnerException.Message); }
                Debug.WriteLine(ex.StackTrace);
            }
            Debug.WriteLine("Finished Car");
            return carList;
        }

        public List<AirFilter> AddAirFilterData(List<Car> carList)
        {
            Debug.WriteLine("Starting AirFilter..");
            var airFilterList = new List<AirFilter>
            {
                new AirFilter {
                    Car = carList.First<Car>(),
                    Cost = 1.00f,
                    Date = DateTime.Parse("2005-09-01"),
                    Miles = 1000,
                    FilterType = "Motorcraft"
                }, new AirFilter {
                    Car = carList.ElementAt<Car>(2),
                    Cost = 1.05f,
                    Date = DateTime.Parse("2005-08-01"),
                    Miles = 10500,
                    FilterType = "FRAM"
                }, new AirFilter {
                    Car = carList.ElementAt<Car>(2),
                    Cost = 1.25f,
                    Date = DateTime.Parse("2005-09-13"),
                    Miles = 16000,
                    FilterType = "FRAM"
                }, new AirFilter {
                    Car = carList.Last<Car>(),
                    Cost = 1.50f,
                    Date = DateTime.Parse("2006-09-21"),
                    Miles = 22000,
                    FilterType = "K&N"
                },
            };
            try
            {
                airFilterList.ForEach(a => _context.AirFilter.Add(a));
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error in AirFilter");
                Debug.WriteLine(ex.Message);
                if (ex.InnerException != null) { Debug.WriteLine(ex.InnerException.Message); }
                Debug.WriteLine(ex.StackTrace);
            }
            Debug.WriteLine("Finished AirFilter");
            return airFilterList;
        }

        public List<Fuel> AddFuelData(List<Car> carList)
        {
            Debug.WriteLine("Starting Fuel..");
            var fuelList = new List<Fuel>
            {
                new Fuel {
                    Car = carList.First<Car>(),
                    Cost = 22.50f,
                    Date = DateTime.Parse("2005-09-02"),
                    Miles = 1000,
                    Quantity = 10.907f,
                    Notes = "",
                    FuelType = FuelGrade.Eth_85_Octane,
                }, new Fuel {
                    Car = carList.First<Car>(),
                    Cost = 23.50f,
                    Date = DateTime.Parse("2005-12-01"),
                    Miles = 1600,
                    Quantity = 11.907f,
                    Notes = "",
                    FuelType = FuelGrade.Eth_85_Octane,
                }, new Fuel {
                    Car = carList.First<Car>(),
                    Cost = 23.75f,
                    Date = DateTime.Parse("2006-2-22"),
                    Miles = 2200,
                    Quantity = 11.457f,
                    Notes = "",
                    FuelType = FuelGrade.Eth_86_Octane,
                }, new Fuel {
                    Car = carList.First<Car>(),
                    Cost = 24.06f,
                    Date = DateTime.Parse("2006-5-20"),
                    Miles = 2800,
                    Quantity = 11.202f,
                    Notes = "",
                    FuelType = FuelGrade.Eth_86_Octane,
                }, new Fuel {
                    Car = carList.ElementAt<Car>(2),
                    Cost = 35.06f,
                    Date = DateTime.Parse("2005-8-13"),
                    Miles = 10500,
                    Quantity = 11.237f,
                    Notes = "",
                    FuelType = FuelGrade.Eth_87_Octane,
                }, new Fuel {
                    Car = carList.ElementAt<Car>(2),
                    Cost = 35.12f,
                    Date = DateTime.Parse("2005-9-14"),
                    Miles = 11565,
                    Quantity = 11.212f,
                    Notes = "",
                    FuelType = FuelGrade.Eth_87_Octane,
                }, new Fuel {
                    Car = carList.Last<Car>(),
                    Cost = 26.13f,
                    Date = DateTime.Parse("2006-9-20"),
                    Miles = 22005,
                    Quantity = 28.202f,
                    Notes = "",
                    FuelType = FuelGrade.Eth_86_Octane,
                },
            };
            try
            {
                fuelList.ForEach(f => _context.Fuel.Add(f));
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error in AddFuelData");
                Debug.WriteLine(ex.Message);
                if (ex.InnerException != null) { Debug.WriteLine(ex.InnerException.Message); }
                var validationException = ex as System.Data.Entity.Validation.DbEntityValidationException;
                if (validationException != null)
                {
                    foreach (var x in validationException.EntityValidationErrors)
                    {
                        foreach ( var y in x.ValidationErrors)
                        {
                            Debug.WriteLine(y.PropertyName + " " + y.ErrorMessage);
                        }
                    }
                }
                Debug.WriteLine(ex.StackTrace);
            }

            Debug.WriteLine("Finished Fuel");
            return fuelList;
        }

        public List<FuelAdditive> AddFuelAdditiveData(List<Car> carList)
        {
            Debug.WriteLine("Starting FuelAdditive..");
            var fuelAdditiveList = new List<FuelAdditive>
            {
                new FuelAdditive {
                    Car = carList.First<Car>(),
                    Cost = 9.00f,
                    Date = DateTime.Parse("2005-09-01"),
                    Miles = 1000,
                    AdditiveType = "Octane Booster"
                }, new FuelAdditive {
                    Car = carList.ElementAt<Car>(2),
                    Cost = 16.05f,
                    Date = DateTime.Parse("2005-08-01"),
                    Miles = 10500,
                    AdditiveType = "Octane Booster"
                }, new FuelAdditive {
                    Car = carList.ElementAt<Car>(2),
                    Cost = 8.25f,
                    Date = DateTime.Parse("2005-09-13"),
                    Miles = 16000,
                    AdditiveType = "MMO"
                }, new FuelAdditive {
                    Car = carList.ElementAt<Car>(2),
                    Cost = 9.50f,
                    Date = DateTime.Parse("2006-09-21"),
                    Miles = 22000,
                    AdditiveType = "Seafoam"
                },
            };
            try
            { 
                fuelAdditiveList.ForEach(f => _context.FuelAdditive.Add(f));
                _context.SaveChanges();
            }
             catch (Exception ex)
            {
                Debug.WriteLine("Error in FuelAdditive");
                Debug.WriteLine(ex.Message);
                if (ex.InnerException != null) { Debug.WriteLine(ex.InnerException.Message); }
                Debug.WriteLine(ex.StackTrace);
            }
            Debug.WriteLine("Finished FuelAdditive");
            return fuelAdditiveList;
        }

        public List<OilAdditive> AddOilAdditiveData(List<Car> carList)
        {
            Debug.WriteLine("Starting OilAdditive..");
            var oilAdditiveList = new List<OilAdditive>
            {
                new OilAdditive {
                    Car = carList.First<Car>(),
                    Cost = 9.05f,
                    Date = DateTime.Parse("2005-09-01"),
                    Miles = 1000,
                    AdditiveType = "Zinc"
                }, new OilAdditive {
                    Car = carList.ElementAt<Car>(2),
                    Cost = 12.05f,
                    Date = DateTime.Parse("2005-08-01"),
                    Miles = 10500,
                    AdditiveType = "Zinc"
                }, new OilAdditive {
                    Car = carList.ElementAt<Car>(2),
                    Cost = 14.25f,
                    Date = DateTime.Parse("2005-09-13"),
                    Miles = 16000,
                    AdditiveType = "MMO"
                }, new OilAdditive {
                    Car = carList.ElementAt<Car>(2),
                    Cost = 10.50f,
                    Date = DateTime.Parse("2006-09-21"),
                    Miles = 22000,
                    AdditiveType = "MMO"
                },
            };
            try
            { 
                oilAdditiveList.ForEach(o => _context.OilAdditive.Add(o));
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error in OilAdditive");
                Debug.WriteLine(ex.Message);
                if (ex.InnerException != null) { Debug.WriteLine(ex.InnerException.Message); }
                Debug.WriteLine(ex.StackTrace);
            }
            Debug.WriteLine("Finished OilAdditive");
            return oilAdditiveList;
        }

        public List<OilPlusFilter> AddOilPlusFilterData(List<Car> carList)
        {
            Debug.WriteLine("Starting OilPlusFilter..");
            var oilPlusFilterList = new List<OilPlusFilter>
            {
                new OilPlusFilter {
                    Car = carList.First<Car>(),
                    Cost = 9.05f,
                    Date = DateTime.Parse("2005-09-01"),
                    Miles = 1000,
                    OilFilter = "Motorcraft",
                    OilType = OilGrade._10W20
                }, new OilPlusFilter {
                    Car = carList.ElementAt<Car>(2),
                    Cost = 12.05f,
                    Date = DateTime.Parse("2005-08-01"),
                    Miles = 10500,
                    OilFilter = "FRAM",
                    OilType = OilGrade._10W30
                }, new OilPlusFilter {
                    Car = carList.ElementAt<Car>(2),
                    Cost = 14.25f,
                    Date = DateTime.Parse("2005-09-13"),
                    Miles = 16000,
                    OilFilter = "FRAM",
                    OilType = OilGrade._10W30
                }, new OilPlusFilter {
                    Car = carList.ElementAt<Car>(2),
                    Cost = 10.50f,
                    Date = DateTime.Parse("2006-09-21"),
                    Miles = 22000,
                    OilFilter = "ACDelco",
                    OilType = OilGrade._10W40
                },
            };
            try
            { 
                oilPlusFilterList.ForEach(o => _context.OilPlusFilter.Add(o));
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error in OilPlusFilter");
                Debug.WriteLine(ex.Message);
                if (ex.InnerException != null) { Debug.WriteLine(ex.InnerException.Message); }
                Debug.WriteLine(ex.StackTrace);
            }
            Debug.WriteLine("Finished OilPlusFilter");
            return oilPlusFilterList;
        }
    }
}