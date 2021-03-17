using EFDAL.Models;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace EFDAL
{
    public partial class DB_Context : DbContext
    {
        public virtual DbSet<Lecturer> Lecturers { get; set; }
        public virtual DbSet<Lecture> Lectures { get; set; }
        public DB_Context()
            : base("name=Lectures")
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Lecture>().HasKey(key => key.ID);
            modelBuilder.Entity<Lecturer>().HasKey(key => key.ID);
        }


    }
}
