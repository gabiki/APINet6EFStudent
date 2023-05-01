﻿using databaseAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace databaseAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Student>? Students { get; set; }

    }
}
