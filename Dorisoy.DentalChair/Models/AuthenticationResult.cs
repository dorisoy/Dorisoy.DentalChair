using Dorisoy.DentalChair.Models.Enums;

namespace Dorisoy.DentalChair.Models;

public class AuthenticationResult
{
    public AuthenticationStatus Status { get; set; }  
    public string ErrorMessage { get; set; }
}