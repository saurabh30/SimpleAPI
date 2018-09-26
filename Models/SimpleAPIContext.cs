using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SimpleAPI.Models
{
    public class SimpleAPIContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
    }
}