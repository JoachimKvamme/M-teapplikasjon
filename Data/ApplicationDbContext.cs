using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Møteapplikasjon.Models;

namespace Møteapplikasjon.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Meeting> Meetings { get; set; }
        public DbSet<Person> Persons { get; set; }

        // Det under var Microsoft sin foretrukne filsti for databasen, men jeg vet ikke hvor databasen da oppstår
        // så jeg laget min egen filsti.

        // public string DbPath { get; }
        // public ApplicationDbContext()
        // {
        //     var folder = Environment.SpecialFolder.LocalApplicationData;
        //     var path = Environment.GetFolderPath(folder);
        //     DbPath = System.IO.Path.Join(path, "database.db");
        // }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        
            => optionsBuilder.UseSqlite("Data source=./database.db");
    }
    
}