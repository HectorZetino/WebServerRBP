using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebServiceRBP.Data.Configuration
{
    public class dbDatabaseSettings : IdbDatabaseSettings
    {
        public string dbCollectionName { get ; set ; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
    public interface IdbDatabaseSettings
    {
        public string dbCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
    
}
