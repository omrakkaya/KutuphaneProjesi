using EmrinCoder.Utility;

namespace EmrinCoder.Models
{
    public class KiralamaRepository : Repository<Kiralama>, IKiralamaRepository

    {
        private readonly UygulamaDbContext _uygulamaDbContext;

        public KiralamaRepository(UygulamaDbContext uygulamaDbContext) : base(uygulamaDbContext)
        {
            _uygulamaDbContext = uygulamaDbContext;
        }

        public void Guncelle(Kiralama kiralama)
        {
            _uygulamaDbContext.Update(kiralama);
        }

        public void Kaydet()
        {
            _uygulamaDbContext.SaveChanges();
        }


    }
}
