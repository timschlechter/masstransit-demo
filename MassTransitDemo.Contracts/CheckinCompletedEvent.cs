namespace MassTransitDemo.Contracts
{
    public interface CheckinCompletedEvent
    {
        string Id { get; set; }

        bool IsOk { get; set; }
    }
}