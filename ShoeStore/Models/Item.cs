using System.ComponentModel.DataAnnotations;

namespace ShoeStore.Models;

public class Item
{
    public int Id { get; set; }

    [Display(Name = "نام محصول")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    public string Name { get; set; }

    [Display(Name = "رنگ")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    public string Color { get; set; }

    [Display(Name = "وزن")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    public string Weight { get; set; }

    [Display(Name = "جنس")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    public string Kind { get; set; }

    [Display(Name = "تعداد موجود در انبار")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    public string Amount { get; set; }

    [Display(Name = "قابلیت شست و شو")]
    public bool Washable { get; set; }

    [Display(Name = "گارانتی")]
    public bool HasWarranty { get; set; }

    [Display(Name = "قیمت")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    public int Price { get; set; }

    [Display(Name = "نام شرکت سازنده")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    public string CompanyName { get; set; }

    [Display(Name = "عکس")]
    public string ImageFileName { get; set; }
}