using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ProyectoTomaAsistencia.Models
{
    public class AsistenciaDbContext : DbContext
    {
        public AsistenciaDbContext (DbContextOptions<AsistenciaDbContext> options)
            : base(options)
        {
        }

        public DbSet<ProyectoTomaAsistencia.Models.AsistenciaModel> AsistenciaModel { get; set; }
    }
}
