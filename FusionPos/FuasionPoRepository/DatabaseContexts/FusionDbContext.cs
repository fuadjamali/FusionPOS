using System;
using System.Data.Entity;
using FusionPosModels.EntityModels;

namespace FuasionPoRepository.DatabaseContexts
{
    public class FusionDbContext :DbContext
    {
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Outlet> Outlets { get; set; }


    }
}