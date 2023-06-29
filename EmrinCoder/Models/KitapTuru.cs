using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EmrinCoder.Models
{
    public class KitapTuru
    {
        [Key] //Primary key olduğunu belirtiyoruz.değişken ismini Id verdiğimiz  sürece [Key] dememize gerek yok otomatik primary olarak atanıyor
        public int Id { get; set; }

        [Required(ErrorMessage ="Kitap Türü Boş Bırakılamaz")] //Zorunlu alan olduğunu belirtiyoruz.
        [MaxLength(25)]
        [DisplayName("Kitap Türü Adı")]
     public string Ad { get; set; }
    }
}
