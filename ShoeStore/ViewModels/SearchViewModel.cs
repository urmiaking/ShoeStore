using ShoeStore.Models;

namespace ShoeStore.ViewModels;

public class SearchViewModel
{
    public SearchViewModel()
    {
        Items = new List<Item>();
    }
    public List<Item> Items { get; set; }

    public int FromPrice { get; set; }
    public int ToPrice { get; set; }
}