using WebApplication1Modelos;

namespace WebApplication1Services
{
    public interface IAlumnoRepositorio
    {
        IEnumerable<Alumno> GetAllAlumnos();
        Alumno GetAlumno(int id);
        Alumno Update(Alumno AlumnoModificado);

        Alumno Add(Alumno alumnoNuevo);

        Alumno Delete(int id);

        IEnumerable<CursoCuantos> AlumnosPorCurso(Curso? curso);

        IEnumerable<Alumno> Busqueda(string elementoABuscar);
    }
}
