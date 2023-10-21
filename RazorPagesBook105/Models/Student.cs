using System.ComponentModel.DataAnnotations;
namespace RazorPagesBook105.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(8)]
        [Required]
        [Display(Name = "读者号")]
        public string? readerNumber { get; set; }     // 读者号

        [Required]
        [Display(Name = "姓名")]
        public string? Name { get; set; }       // 姓名

        [Required]
        [Display(Name = "性别")]
        public string? Gender { get; set; }     // 性别

        [Display(Name = "生日")]
        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }      // 生日

        [Required]
        [Display(Name = "地址")]
        public string? Address { get; set; }        // 地址

        [Required]
        [MaxLength(11)]
        [Display(Name = "电话")]
        public string? Phone { get; set; }      // 电话
    }
}
