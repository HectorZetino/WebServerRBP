using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebServiceRBP.Data.Configuration
{
    public class RaspberryPiDatabaseSettings : IRaspberryPiDatabaseSettings
    {
        public string RaspberryPiCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
    public interface IRaspberryPiDatabaseSettings {
        public string RaspberryPiCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
