using EF.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace EF
{
    public class PopulationAndHouseholdDataContext : DbContext
    {

        public DbSet<ApprovaInfoEntity> ActualData { get; set; }
        public DbSet<RequestInfoEntity> EstimateData { get; set; }
        public DbSet<Code> Codes { get; set; }
        public DbSet<UserEntity> Users { get; set; }

        public string DbPath { get; private set; }

        public PopulationAndHouseholdDataContext()
        {

            DbPath = AppDomain.CurrentDomain.BaseDirectory;

            //if "bin" is present, remove all the path starting from "bin" word
            if (DbPath.Contains("bin"))
            {
                int index = DbPath.IndexOf("bin");
                DbPath = DbPath.Substring(0, index);
            }
        }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}Sqlite\\approvalManagementSystem.db");
    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //when Entity Class name and SQL table name not equal then need to match
            modelBuilder.Entity<ApprovaInfoEntity>().ToTable("ApprovelInfo");
            modelBuilder.Entity<RequestInfoEntity>().ToTable("RequestInfo");
            modelBuilder.Entity<UserEntity>().ToTable("Users");
        }

    }
}
