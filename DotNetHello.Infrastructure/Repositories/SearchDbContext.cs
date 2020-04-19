using System;
using Microsoft.EntityFrameworkCore;
using DotNetHello.Core.Entities;

namespace DotNetHello.Infrastructure.Repositories
{
    public class SearchDbContext : DbContext
    {
        public SearchDbContext(DbContextOptions<SearchDbContext> options) : base(options)
        {

        }


        public DbSet<Search> SearchItems { get; set; }
    }
}
