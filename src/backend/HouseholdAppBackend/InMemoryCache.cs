public class InMemoryCache
{
    readonly List<string> _list = new();

    public List<string> Entries => _list;

    public void Add(string entry)
    {
        _list.Add(entry);
    }
}