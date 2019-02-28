﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace Attest.Models
{
    public class DataContext: DbContext
    {
        public DataContext()
        {
           
        }
        public DataContext(DbContextOptionsBuilder optionsBuilder)
        {
            OnConfiguring(optionsBuilder);
        }

       protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");
            var configuration = builder.Build();

            optionsBuilder.UseMySql(configuration["ConnectionStrings:DefaultConnection"]);

        }
      
        public DbSet<Users> Users { get; set; }
        public DbSet<FileModel> File { get; set; }
        public DbSet<Nauch_deyat> Naucn_deyat { get; set; }
        public DbSet<Zayavlen> Zayavlen { get; set; }
        public DbSet<Obrazovan> Obrazovan { get; set; }
        public object Files { get; internal set; }
    }
}
