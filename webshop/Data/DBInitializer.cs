using webshop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webshop.Data
{
    public class DBInitializer
    {
        public static void Initialize(webshopContext context)
        {
            context.Database.EnsureCreated();


            if (context.Products.Any())
                return;

            /*            context.Employees.AddRange(
                            new Employee {  FirstName = "Tom", LastName="Peeters"}
                            );
            */
            context.Products.AddRange(
                new Product { Name = "Bresilienne taart", Price = 17, Omschr = "Een taart gevuld met vanille pudding, bestrooid met Bresilienne nootjes" },
                new Product { Name = "spinnetaart", Price = 20, Omschr = "Een taart met een glazuurlaagje in de vorm van een spinneweb" },
                new Product { Name = "fruittaart", Price = 25, Omschr = "Een slagroomtaart met kriekenvulling, belegd met fruit" }
                );

            context.SaveChanges();
        }
    }
}
