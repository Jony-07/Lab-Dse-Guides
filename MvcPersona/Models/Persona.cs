using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace MvcPersona.Models
{
    public class Persona
    {
        public int ID { get; set; }
        public string DUI { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        [Display(Name = "Fecha de Nacimiento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]

        public DateTime FechaNacimiento { get; set; }
        public string Direccion { get; set; }
        public string Correo { get; set; }

    }
    public class PersonaDBContext : DbContext
    {
        public DbSet<Persona> Personas { get; set; }
    }

}