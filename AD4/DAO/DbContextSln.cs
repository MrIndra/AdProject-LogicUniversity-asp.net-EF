namespace AD4
{
    using AD4.Migrations;
    using AD4.Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class DbContextSln : DbContext
    {
        public DbContextSln() : base("name=DbModel")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DbContextSln, Configuration>());

        }

        public DbSet<Users> dbUsers { get; set; }
        public DbSet<Items> orderItems { get; set; }
    }
}