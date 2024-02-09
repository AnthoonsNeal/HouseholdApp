public class InMemoryCache
{
    public List<Reminder> Entries { get; } = new();

    public Reminder Add(string text)
    {
        var reminder = new Reminder(Guid.NewGuid(), text);
        Entries.Add(reminder);
        return reminder;
    }

    public void Remove(Guid id) => Entries.RemoveAll(e => e.guid == id);
}

public record Reminder(Guid guid, string text);
