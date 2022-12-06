using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication1Modelos;
using Microsoft.Data.SqlClient;

namespace WebApplication1Services
{
    public class AlumnosRepositorioBd : IAlumnoRepositorio
    {
        private readonly AlumnoDbContext context;

        public AlumnosRepositorioBd(AlumnoDbContext context)
        {
            this.context = context;
        }
        public Alumno Add(Alumno alumnoNuevo)
        {

            context.Database.ExecuteSqlRaw("InsertarAlumno {0}, {1}, {2}, {3}", alumnoNuevo.Name, alumnoNuevo.Email, alumnoNuevo.Foto, alumnoNuevo.CursoID);
            
            return alumnoNuevo;
        }
        
        
        public IEnumerable<Alumno> Busqueda(string elementoABuscar)
        {
            if (string.IsNullOrEmpty(elementoABuscar))
            {
                return context.Alumnos;
            }
            return context.Alumnos.Where(a => a.Name.Contains(elementoABuscar) || a.Email.Contains(elementoABuscar));
        }

        public Alumno Delete(int id)
        {
            Alumno alumnoBorrar = GetAlumno(id);
            if (alumnoBorrar != null)
            {
                context.Alumnos.Remove(alumnoBorrar);
                context.SaveChanges();

            }
            return alumnoBorrar;
        }

        public IEnumerable<CursoCuantos> AlumnosPorCurso(Curso? curso)
        {
            IEnumerable<Alumno> consulta = context.Alumnos;

            if (curso.HasValue)
            {
                consulta = consulta.Where(a => a.CursoID == curso);
            }


            return consulta.GroupBy(a => a.CursoID).Select(g => new CursoCuantos()
            { Clase = g.Key.Value, NumAlumnos = g.Count() }).ToList();
        }
        public IEnumerable<Alumno> GetAllAlumnos()
        {
            return context.Alumnos.FromSqlRaw<Alumno>("SELECT * FROM ALUMNOS").ToList();
        }

        public Alumno GetAlumno(int id)
        {
            SqlParameter parameter = new SqlParameter("@Id", id);
            return context.Alumnos.FromSqlRaw<Alumno>("GetAlumnoById {0}", parameter).ToList().FirstOrDefault();

            
        }

        public Alumno Update(Alumno AlumnoModificado)
        {
            var alumno = context.Alumnos.Attach(AlumnoModificado);
            alumno.State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            return AlumnoModificado;
        }
    }
}

