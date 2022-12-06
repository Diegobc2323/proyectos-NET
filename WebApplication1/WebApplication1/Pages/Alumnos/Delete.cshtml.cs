using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1Modelos;
using WebApplication1Services;

namespace WebApplication1.Pages.Alumnos
{
    public class DeleteModel : PageModel
    {
        private readonly IAlumnoRepositorio alumnoRepositorio;
        [BindProperty] public Alumno alumno { get; set; }
        public DeleteModel(IAlumnoRepositorio alumnoRepositorio)
        {
            this.alumnoRepositorio = alumnoRepositorio;
        }

        public void OnGet(int id)
        {
            alumno = alumnoRepositorio.GetAlumno(id);

        }

        public IActionResult OnPost()
        {
            alumnoRepositorio.Delete(alumno.Id);
            return RedirectToPage("Index");
        }
    }
}
