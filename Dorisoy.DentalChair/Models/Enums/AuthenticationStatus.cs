namespace Dorisoy.DentalChair.Models.Enums;

public enum AuthenticationStatus
{
    Unknown,
    Success,
    FallbackRequest,
    Failed,
    Canceled,
    TooManyAttempts,
    NotAvailable,
    Denied
}