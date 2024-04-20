using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;

namespace DataAccessLibrary;

public class CallerModel
{
    public int CallId { get; set; }
    public string SkolePrefix { get; set; }
    public string ADTelephoneNumber { get; set; }
    public string AlternativNumber1 { get; set; }
    public string AlternativNumber2 { get; set; }
    public string Email { get; set; }
    public string UPN { get; set; }
}
