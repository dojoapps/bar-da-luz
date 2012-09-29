using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

namespace BarDaLuz.Db
{
    public class BarDaLuzContext : DbContext
    {
        public BarDaLuzContext()
            : base(GetConnectionString())
        { }
        
        public DbSet<Product> Products { get; set; }
        public DbSet<Tab> Tabs { get; set; }
        public DbSet<ProductTab> ProductsTabs { get; set; }

        private static string GetConnectionString()
        {
            try
            {
                if (!HttpContext.Current.Request.IsLocal)
                {
                    var uriString = ConfigurationManager.AppSettings["SQLSERVER_URI"];
                    var uri = new Uri(uriString);
                    var connectionString = new SqlConnectionStringBuilder
                    {
                        DataSource = uri.Host,
                        InitialCatalog = uri.AbsolutePath.Trim('/'),
                        UserID = uri.UserInfo.Split(':').First(),
                        Password = uri.UserInfo.Split(':').Last(),
                    }.ConnectionString;

                    return connectionString;
                }
            }
            catch (Exception)
            {

            }

            return "name=SQLSERVER_CONNECTION_STRING";
        }
    }
}
