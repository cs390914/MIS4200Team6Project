using MIS4200Team6.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MIS4200Team6.DAL
{
    public class EmployeeContext: DbContext
    {
        public EmployeeContext() : base("name=DefaultConnection")
        {
            // this method is a 'constructor' and is called when a new context is created
            // the base attribute says which connection string to use
        }
        // Include each object here. The value inside <> is the name of the class,
        // the value outside should generally be the plural of the class name
        // and is the name used to reference the entity in code
        public DbSet<Register> Register { get; set; }
       
    }

}
