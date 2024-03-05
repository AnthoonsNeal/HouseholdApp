namespace HouseholdAppBackend.SignalR;

public interface ITaskHub
{
    Task InitializeReminders(List<Reminder> items);

    Task AddReminder(Reminder items);
}