using System.ComponentModel.DataAnnotations;

namespace BackendEmpleados.Models
{
    public class Empleados
    {
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Apellido { get; set; }

        [Required]
        public string Genero { get; set; }

        [Required]
        public string FechaNacimiento { get; set; }

        [Required]
        public int CargoId { get; set; }
    }

    public class Cargo
    {
        public int Id { get; set; }
        public string Cargo { get; set; }
        public List<Empleados> Empleado { get; set;
    }
}
