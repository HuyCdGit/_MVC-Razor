using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppMVC.Models.Contacts
{
    public class ContactModel
    {
        [Key]
        public int Id {get; set;}

        [Column(TypeName = "nvarchar")]
        [StringLength(256, MinimumLength = 3, ErrorMessage = "{0} toi thieu la {2} den {1} ky tu")]
        [Required(ErrorMessage = "{0} phai nhap ho ten")]
        [Display(Name = "Ten User")]
        public string FullName {get; set;}

        [Required(ErrorMessage = "phai nhap {0}")]
        [StringLength(100)]
        [EmailAddress(ErrorMessage = "phai la {0}")]
        [Display(Name = "dia cho Email")]
        public string Email {get; set;}

        public DateTime DataSent {get; set;}
        
        [Display(Name = "Noi dung")]
        public string Message {get; set;}

        [StringLength(50)]
        [Phone(ErrorMessage = "phai la {0}")]
        [Required(ErrorMessage = "phai nhap {0  }")]
        [Display(Name = "So Dien Thoai")]
        public string Phone {get; set;}
    }
}