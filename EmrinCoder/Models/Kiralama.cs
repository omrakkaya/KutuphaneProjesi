using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmrinCoder.Models
{
    public class Kiralama
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("Öğrenci No")]
        public int OgrenciId { get; set; }

        [ValidateNever]
        [DisplayName("Kitap Adı")]
        public int KitapId { get; set; }
        [ForeignKey("KitapId")]

        [ValidateNever]
        public Kitap Kitap { get; set; }    

    }
}
