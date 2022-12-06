using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication1Modelos;

namespace WebApplication1Services
{
    public class AlumnoDbContext : DbContext
    {

        public AlumnoDbContext(DbContextOptions<AlumnoDbContext> options) : base(options)
        {

        }

        public DbSet<Alumno> Alumnos { get; set; } //Un objeto DbSet simula una tabla de una BBDD

    }
}
