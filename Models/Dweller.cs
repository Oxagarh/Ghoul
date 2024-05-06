using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ghoul.Models;

[Table("Users")]
public class Dweller
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Required Field")]
    [Display(Name = "Full Name")]
    public string FullName { get; set; }

    [Required(ErrorMessage = "Required Field")]
    [EmailAddress(ErrorMessage = "Invalid email address")]
    public string Email { get; set; }
}