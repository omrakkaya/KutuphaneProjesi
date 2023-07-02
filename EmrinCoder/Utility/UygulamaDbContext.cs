using EmrinCoder.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;//Kütüphaneyi sonradan indirmemiz gerekiyor hazır gelmiyor.
using Microsoft.EntityFrameworkCore;

namespace EmrinCoder.Utility
{//normalde UygulamaDbContext DbContext 'ten kalıtım alır. fakat artık Scaffold Indetity kullanıldığı için IdentityDbContext den kalıtım alır.
    public class UygulamaDbContext : IdentityDbContext
    {
        public UygulamaDbContext(DbContextOptions<UygulamaDbContext> options) : base(options)
        {
        
        }
        
        public DbSet<KitapTuru> KitapTurleri { get; set; }

        public DbSet<Kitap> Kitaplar { get; set; }  

        public DbSet<Kiralama> Kiralamalar { get; set; }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

    }
}
