using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1Modelos;

namespace WebApplication1Services
{
    public class AlumnosRepositorio : IAlumnoRepositorio
    {
        List<Alumno> ListaAlumnos;
        public AlumnosRepositorio()
        {
            ListaAlumnos = new List<Alumno>()
            {
                new Alumno() { Id = 1, Name = "Diego Blas", CursoID = Curso.H2, Email = "diego.blas@zaragoza.salesianos.edu", Foto = "blas.jpg"},
                new Alumno() { Id = 2, Name = "Javier Burillo", CursoID = Curso.H2, Email = "javier.burillo@zaragoza.salesianos.edu", Foto = "burillo.jpg" },
                new Alumno() { Id = 3, Name = "Jon Fernandez", CursoID = Curso.H1, Email = "jon.fernandez@zaragoza.salesianos.edu", Foto = "fernandez.jpg" },
                new Alumno() { Id = 4, Name = "David Fron", CursoID = Curso.H1, Email = "david.fron@zaragoza.salesianos.edu", Foto = "fron.jpg" }

            };
        }

        public Alumno Add(Alumno alumnoNuevo)
        {
            alumnoNuevo.Id = ListaAlumnos.Max(a => a.Id) +1;
            ListaAlumnos.Add(alumnoNuevo);
            return alumnoNuevo;
        }

        public IEnumerable<Alumno> GetAllAlumnos()
        {
            return ListaAlumnos;
        }
        public Alumno GetAlumno(int id)
        {
            return ListaAlumnos.FirstOrDefault(alumno => alumno.Id == id);
        }
        
        public Alumno Update(Alumno alumnoActualizado)
        {
            Alumno alumno = ListaAlumnos.FirstOrDefault(a => a.Id == alumnoActualizado.Id);
            alumno.Name = alumnoActualizado.Name;
            alumno.Email = alumnoActualizado.Email;
            alumno.CursoID = alumnoActualizado.CursoID;
            alumno.Foto = alumnoActualizado.Foto;

            return alumno;
        }

        public Alumno Delete(int id)
        {
            Alumno alumnoBorrar = GetAlumno(id);
            if (alumnoBorrar != null)
            {
                ListaAlumnos.Remove(alumnoBorrar);
                
            }
            return alumnoBorrar;
        }

        public IEnumerable<CursoCuantos> AlumnosPorCurso(Curso? curso)
        {
            IEnumerable<Alumno> consulta = ListaAlumnos;

            if (curso.HasValue)
            {
                consulta = consulta.Where(a => a.CursoID == curso);
            }

            return consulta.GroupBy(a => a.CursoID).Select(g => new CursoCuantos() 
            {Clase = g.Key.Value,NumAlumnos = g.Count()}).ToList();
        }

        public IEnumerable<Alumno> Busqueda(string elementoABuscar)
        {
            if (string.IsNullOrEmpty(elementoABuscar))
            {
                return ListaAlumnos;
            }
            return ListaAlumnos.Where(a => a.Name.Contains(elementoABuscar) || a.Email.Contains(elementoABuscar));
        }
    }
}
