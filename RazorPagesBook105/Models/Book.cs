using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorPagesBook105.Models;
public class Book
{
    [Key]
    public int Id { get; set; }

    [Display(Name = "书名")]
    [StringLength(60, MinimumLength = 3)]
    [Required]
    public string? Title { get; set; }      // 书名

    [Display(Name = "作者")]
    [Required]
    public string? Writer { get; set; }     // 作者

    [Display(Name = "出版社")]
    [Required]
    public string? Press { get; set; }      // 出版社

    [Required]
    [MaxLength(8)]
    public string? ISBN { get; set; }      // 国际标准书号

    [Range(1, 100)]
    [Display(Name = "价格")]
    [Column(TypeName = "decimal(18, 2)")]
    public decimal Price { get; set; }      // 价格

    [Display(Name = "状态")]
    public bool State { get; set; }     // 状态

    [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$")]
    [StringLength(5)]
    [Required]
    public string Rating { get; set; } = string.Empty;

}