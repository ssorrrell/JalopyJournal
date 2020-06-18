using System.Data.Entity;
using System.Data.Entity.SqlServer;

namespace JalopyJournal.DAL
{
    public class JJConfiguration : DbConfiguration
    {
        public JJConfiguration()
        {
            SetExecutionStrategy("System.Data.SqlClient", () => new SqlAzureExecutionStrategy());
        }
    }
}