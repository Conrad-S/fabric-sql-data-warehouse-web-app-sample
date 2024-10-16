using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWebApp.Models
{
    public class YourEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)] // No auto-generation
        public int Id { get; set; }
        public string Field1 { get; set; } = string.Empty; // Add default value
        public string Field2 { get; set; } = string.Empty; // Add default value
    }
}