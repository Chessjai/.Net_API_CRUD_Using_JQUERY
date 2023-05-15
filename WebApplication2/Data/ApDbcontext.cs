using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication2.Models;

namespace WebApplication2.Data
{
    public class ApDbcontext:DbContext
    {
        public ApDbcontext():base("aspx")
        {

        }
        public DbSet<Employee> Employees { get; set; }
    }
}