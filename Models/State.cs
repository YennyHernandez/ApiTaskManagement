using System.ComponentModel.DataAnnotations;

namespace webApi.Models
{
    public class State
    {
        public int Id { get; set; }
        public required string StateName { get; set; } // Valor por defecto


    }
}