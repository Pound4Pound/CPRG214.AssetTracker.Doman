using System;
using System.Collections.Generic;
using System.Text;
using CPRG214.OfficeAssets.WebInterface.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CPRG214.OfficeAssets.WebInterface.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<AssetType> AssetTypes { get; set; }
        public DbSet<Assets> Assets { get; set; }
    }
}
