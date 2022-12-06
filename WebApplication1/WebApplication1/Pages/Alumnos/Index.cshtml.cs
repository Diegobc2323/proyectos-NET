using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1Modelos;
using WebApplication1Services;

namespace WebApplication1.Pages.Alumnos
{
    public class IndexModel : PageModel
    {
        public IAlumnoRepositorio AlumnosRepositorio { get; }
        public IEnumerable<Alumno> Alumnos { get; set; }

        [BindProperty(SupportsGet = true)] public String elementoABuscar { get; set; }
        public IndexModel(IAlumnoRepositorio alumnosRepositorio)
        {
            AlumnosRepositorio = alumnosRepositorio;
        }
        public void OnGet()
        {
            //Alumnos = AlumnosRepositorio.GetAllAlumnos();
            Alumnos = AlumnosRepositorio.Busqueda(elementoABuscar);
        }
    }
}
