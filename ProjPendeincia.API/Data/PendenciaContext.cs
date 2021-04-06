using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjPendeincia.API.Models;

    public class PendenciaContext : DbContext
    {
        public PendenciaContext (DbContextOptions<PendenciaContext> options) : base(options)
        {
        }

        //public DbSet<ProjPendeincia.API.Models.Pendencia> Pendencia { get; set; }
        public DbSet<Pendencia> Pendencia { get; set; }
    }
