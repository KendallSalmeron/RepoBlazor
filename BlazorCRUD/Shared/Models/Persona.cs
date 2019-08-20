using System.ComponentModel.DataAnnotations;


namespace BlazorCRUD.Shared.Models
{
    public class Persona
    {
        public int ID { get; set; }
        [Required]
        public string Nombre { get; set; }
    }
}
