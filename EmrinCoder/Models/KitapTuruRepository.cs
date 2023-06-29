using EmrinCoder.Utility;

namespace EmrinCoder.Models
{
    public class KitapTuruRepository : Repository<KitapTuru>, IKitapTuruRepository//Repository sınıfından miras aldık ve IKitapTuruRepository interface'ini implement ettik.
    {
        private UygulamaDbContext _uygulamaDbContext;//UygulamaDbContext sınıfından _uygulamaDbContext adında bir değişken tanımladık.

        public KitapTuruRepository(UygulamaDbContext uygulamaDbContext) : base(uygulamaDbContext)//Constructor Class
        {
            _uygulamaDbContext = uygulamaDbContext;//_uygulamaDbContext değişkenine uygulamaDbContext değerini atadık.
        }
        public void Guncelle(KitapTuru kitapTuru)
        {
            _uygulamaDbContext.Update(kitapTuru);
        }

        public void Kaydet()
        {
            _uygulamaDbContext.SaveChanges();
        }
    }
}
