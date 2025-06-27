namespace Dorisoy.DentalChair.Messages
{
    public class StatusDataChangeMessage : ValueChangedMessage<byte[]>
    {
        public StatusDataChangeMessage(byte[] value) : base(value)
        {
        }
    }
}
