using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webApi.Models
{
    public class Tarea
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public int StateId { get; set; }

        public virtual required State State { get; set; }
       
    }
}