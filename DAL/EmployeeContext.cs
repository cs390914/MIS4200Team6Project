﻿using MIS4200Team6.Models;
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
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<EmployeeContext,
          MIS4200Team6.Migrations.RECContext.Configuration>("DefaultConnection"));
            // this method is a 'constructor' and is called when a new context is created
            // the base attribute says which connection string to use
        }
        

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        // Include each object here. The value inside <> is the name of the class,
        // the value outside should generally be the plural of the class name
        // and is the name used to reference the entity in code
        public DbSet<Registrar> Register { get; set; }
        public DbSet<CoreValueLeaderBoard> coreValueLeaderBoards {get; set; }
        public object Regeistars { get; internal set; }
    }

}
