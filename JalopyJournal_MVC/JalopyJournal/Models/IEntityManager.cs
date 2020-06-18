using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JalopyJournal.Models
{
    interface IEntityManager
    {
        //IQueryable<Part> AddSortToQuery(IQueryable<Part> partQueryable, string sortOrder);
        IQueryable<IEntity> GetPartQueryable(int? carID, string sortOrder);
    }
}
