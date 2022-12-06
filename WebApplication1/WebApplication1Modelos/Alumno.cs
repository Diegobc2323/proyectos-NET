using System.ComponentModel.DataAnnotations;

namespace WebApplication1Modelos
{
    public class Alumno
    {
        public int Id { get; set; }



        [Required(ErrorMessage ="Obligatorio completar este campo")] 
        [MinLength(3, ErrorMessage ="El nombre tiene que tener como minimo 3 caracteres")]
        public string Name { get; set; }



        [Required(ErrorMessage = "Obligatorio completar este campo")] 
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@+[a-zA-Z0-9-]+\.+[a-zA-Z0-9-.]+$", ErrorMessage = "Formato invalido")]
        [Display(Name = "Email de casa")]
        public string Email { get; set; }
        public string Foto { get; set; }
        public Curso? CursoID { get; set; }
    }
}