using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using JalopyJournal.Models;

namespace JalopyJournal.DAL
{
    public class JJInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<JJContext>
    {
        private JJContext _context;

        private JJSeedHelper _jjSeedHelper;
        public JJSeedHelper JJSeedHelper
        {
            get { if (JJSeedHelper == null) { _jjSeedHelper = new JJSeedHelper(_context); } return _jjSeedHelper; }
            set { _jjSeedHelper = value; }
        }

        protected override void Seed(JJContext context)
        {
            //if (System.Diagnostics.Debugger.IsAttached == false)
            //    System.Diagnostics.Debugger.Launch();

            _context = context;
            Debug.WriteLine("Running JJInitializer.Seed");

            var carList = JJSeedHelper.AddCarData();
            JJSeedHelper.AddAirFilterData(carList);
            JJSeedHelper.AddFuelData(carList);
            JJSeedHelper.AddFuelAdditiveData(carList);
            JJSeedHelper.AddOilAdditiveData(carList);
            JJSeedHelper.AddOilPlusFilterData(carList);

            Debug.WriteLine("Finished JJInitializer.Seed");
        }

    }
}