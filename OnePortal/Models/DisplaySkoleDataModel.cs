namespace OnePortal;
using System.ComponentModel.DataAnnotations;

public class DisplaySkoleDataModel
{
    [Required]
    [StringLength(4, ErrorMessage = "School prefix cannot be longer than 4 characters.")]
    [MinLength(2, ErrorMessage = "School prefix cannot be shorter than 2 characters.")]
    public string SkolePrefix { get; set; }

    [Required]
    [StringLength(255, ErrorMessage = "School name cannot be longer than 255 characters.")]
    [MinLength(2, ErrorMessage = "School name cannot be shorter than 2 characters.")]
    public string SkoleNavn { get; set; }

    [Required]
    [StringLength(255, ErrorMessage = "Technician group name cannot be longer than 255 characters.")]
    [MinLength(2, ErrorMessage = "Technician group name cannot be shorter than 2 characters.")]
    [EmailAddress(ErrorMessage = "Technician group name must be a valid email address.")]
    public string TeknikerGruppe { get; set; }

    [StringLength(10, ErrorMessage = "CVR number cannot be longer than 10 characters.")]
    [RegularExpression("^[0-9]*$", ErrorMessage = "CVR number must be numeric.")]
    public string CVR { get; set; }

    [StringLength(15, ErrorMessage = "EAN number cannot be longer than 15 characters.")]
    [RegularExpression("^[0-9]*$", ErrorMessage = "EAN number must be numeric.")]
    public string EAN { get; set; }
}
