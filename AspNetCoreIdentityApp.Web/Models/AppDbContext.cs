using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreIdentityApp.Web.Models
{
    public class AppDbContext:IdentityDbContext<AppUser, AppRole, string> //kullanici ve rol için primary key tipi / string identity kütüphanesi yeni kullanicilar olustururken build/random deðerler olusturur
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}
    }
    
}
