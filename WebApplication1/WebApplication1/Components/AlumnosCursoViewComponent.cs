using Microsoft.AspNetCore.Mvc;
using WebApplication1Modelos;
using WebApplication1Services;
namespace WebApplication1.Components
{
    public class AlumnosCursoViewComponent : ViewComponent
    {
        private readonly IAlumnoRepositorio alumnoRepositorio;
        public AlumnosCursoViewComponent(IAlumnoRepositorio alumnoRepositorio)
        {
            this.alumnoRepositorio = alumnoRepositorio;
        }

        public IViewComponentResult Invoke(Curso? curso = null)
        {
            var resultado = alumnoRepositorio.AlumnosPorCurso(curso);
            return View(resultado);
        }
    }
}
