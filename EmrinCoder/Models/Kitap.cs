using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmrinCoder.Models
{
    public class Kitap
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("Kitap Adı")]
        public string KitapAdi { get; set; }

        [DisplayName("Kitap Türü")]
        public int KitapTuruId { get; set; }
        [ForeignKey("KitapTuruId")] 

        public KitapTuru KitapTuru { get; set; }


        public string Tanim { get; set; }

        [Required]
        public string Yazar { get; set; }


        [Required]
        [Range(10, 5000)]
        public double Fiyat { get; set; }

        public string ResimUrl { get; set; }    
    }
}
