using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1Modelos;
using WebApplication1Services;

namespace WebApplication1.Pages.Alumnos
{
    public class EditModel : PageModel
    {
        public IAlumnoRepositorio alumnosRepositorio { get; }
        public IWebHostEnvironment WebHostEnvironment { get; }
        [BindProperty] public Alumno alumno { get; set; }

        public IFormFile Photo { get; set; }
               
        public EditModel(IAlumnoRepositorio alumnosRepositorio, IWebHostEnvironment webHostEnvironment)
        {
            this.alumnosRepositorio = alumnosRepositorio;
            WebHostEnvironment = webHostEnvironment;
        }
        public IActionResult OnGet(int? ID)
        {
            if (ID.HasValue)
            {
                alumno = alumnosRepositorio.GetAlumno(ID.Value);
            }
            else
            {
                alumno = new Alumno();
            }
            
            return Page();
        }

        public IActionResult OnPost(Alumno alumno)
        {
            if (ModelState.IsValid)
            {
                if (Photo != null)
                {
                    if (alumno.Foto != null)
                    {
                        string filePath = Path.Combine(WebHostEnvironment.WebRootPath, "images", alumno.Foto);
                        System.IO.File.Delete(filePath);
                    }
                    alumno.Foto = ProcessUploadedFile();
                }

                if (alumno.Id > 0)
                {
                    alumnosRepositorio.Update(alumno);
                }
                else
                {
                    alumnosRepositorio.Add(alumno);
                }

                return RedirectToPage("/Alumnos/Index");

            }else
            {
                return Page();
            }

        }

        private string ProcessUploadedFile()
        {
            if (Photo != null)
            {
                string upladsFolder = Path.Combine(WebHostEnvironment.WebRootPath, "images");
                string filePath = Path.Combine(upladsFolder, Photo.FileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    Photo.CopyTo(fileStream);
                }
            }
            return Photo.FileName;
        }

    }
}
