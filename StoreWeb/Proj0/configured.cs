using MySql.Data.Entity;
using MySql.Data.MySqlClient;
//using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace Proj0
{
    public class MySQLDbConfiguration : DbConfiguration
    {
        public MySQLDbConfiguration()
        {
            SetProviderServices(MySqlProviderInvariantName.ProviderName, new MySqlProviderServices());
            //SetProviderFactory(MySqlProviderInvariantName.ProviderName, new MySqlClientFactory());
        }
    }
}
