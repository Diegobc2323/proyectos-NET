using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1Modelos;
using WebApplication1Services;

namespace WebApplication1.Pages.Alumnos
{
    public class DetailsModel : PageModel
    {
        public IAlumnoRepositorio AlumnosRepositorio { get; }
        public Alumno alumno { get; set; }
        public DetailsModel(IAlumnoRepositorio alumnosRepositorio)
        {
            AlumnosRepositorio = alumnosRepositorio;
        }
        public void OnGet(int ID)
        {
            alumno = AlumnosRepositorio.GetAlumno(ID);
        }
    }
}
