using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LPLProject.Models
{
    public class LplContext : DbContext
    {
        public LplContext() : base("Name=DbConnect")
        {

        }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<Manager> Managers { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<AddEmployee> AddEmployees { get; set; }
        public virtual DbSet<Task> Tasks { get; set; }
        public virtual DbSet<User> Users { get; set; }

    }

}