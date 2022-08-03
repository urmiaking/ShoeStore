using System.ComponentModel.DataAnnotations;
using ShoeStore.Models;

namespace ShoeStore.ViewModels;

public class ItemsViewModel
{
    public Item Item { get; set; }

    [Required(ErrorMessage = "وارد کردن عکس الزامی است")]
    public IFormFile File { get; set; }
}