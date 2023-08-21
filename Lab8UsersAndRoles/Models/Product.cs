using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;

namespace Lab8UsersAndRoles.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        public float Price { get; set; }
    }
}
