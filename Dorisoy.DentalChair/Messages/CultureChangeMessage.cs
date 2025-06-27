
namespace Dorisoy.DentalChair.Messages;

public class CultureChangeMessage : ValueChangedMessage<string>
{
    public CultureChangeMessage(string value) : base(value)
    {
    }
}
