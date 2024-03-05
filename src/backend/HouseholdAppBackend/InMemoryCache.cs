using Newtonsoft.Json;

public class InMemoryCache
{
    public ReminderList Entries { get; } = new();

    public Reminder Add(string text)
    {
        var reminder = new Reminder(Guid.NewGuid(), text);
        Entries.Reminders.Add(reminder);
        return reminder;
    }

    public void Remove(Guid id) => Entries.Reminders.RemoveAll(e => e.Guid == id);
}

public record ReminderList()
{
    public List<Reminder> Reminders { get; } = new();
}

public static class ReminderListExtensions
{
    public static string ToJson(this ReminderList reminders) => JsonConvert.SerializeObject(reminders);
}

public record Reminder(Guid Guid, string Text);

public static class ReminderExtensions
{
    public static string ToJson(this Reminder reminder) => JsonConvert.SerializeObject(reminder);
}