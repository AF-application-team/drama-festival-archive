using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using AF_Models;

namespace AF_DataAccessLayer
{
    class AF_Context : DbContext
    {
        public AF_Context() : base("AF_Context") { }

        public DbSet<Award> Awards { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Festival> Festivals { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Person> Person { get; set; }
        public DbSet<Play> Plays { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<RelationFestivalPersonPosition> RelationsFestivalPersonPosition { get; set; }
        public DbSet<RelationPersonAward> RelationsPersonAward { get; set; }
        public DbSet<RelationPersonPlayJob> RelationsPersonPlayJob { get; set; }
        public DbSet<RelationPersonPlayRole> RelationsPersonPlayRole { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}
