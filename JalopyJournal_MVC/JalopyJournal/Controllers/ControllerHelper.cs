using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JalopyJournal.Controllers
{
    public class ControllerHelper
    {
        public static string GetSortName(string sortOrder)
        {
            string[] sortArray = null;
            var sortName = "miles";
            if (sortOrder.Length > 0)
                sortArray = sortOrder.Split('_');
            if (sortArray.Length > 0)
                sortName = sortArray[0];
            return sortName;
        }

        public static string GetSortOrder(string sortOrder)
        {
            string[] sortArray = null;
            var sortDirection = "asc";
            if (!string.IsNullOrEmpty(sortOrder))
            {
                if (sortOrder.Length > 0)
                    sortArray = sortOrder.Split('_');
                if (sortArray.Length > 1)
                    sortDirection = sortArray[1];
            }
            return sortDirection;
        }
    }
}