using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyApi.Models;
using MyApi.Data.Mappings;

namespace MyApi.Data
{
    public class MyApiContext : DbContext
    {

        public MyApiContext(DbContextOptions<MyApiContext> options) : base(options)
        {

        }

        public DbSet<Editor> Editors { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new EditorMap());
        }
    }
}
