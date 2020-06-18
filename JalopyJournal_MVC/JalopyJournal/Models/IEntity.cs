using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JalopyJournal.Models
{
    interface IEntity
    {
        int ID { get; set; }
        float Miles { get; set; }
        DateTime Date { get; set; }
        float Cost { get; set; }
        string Notes { get; set; }
        int CarID { get; set; } //foreign key
        Car Car { get; set; }
    }


}
