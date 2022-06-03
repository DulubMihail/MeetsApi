using Microsoft.EntityFrameworkCore;
using MeetsApi.Models;

namespace MeetsApi.Data
{
    public class MeetContext : DbContext
    {
     

        public DbSet<Meet> Meets { get; set; } = null!;
        public MeetContext(DbContextOptions<MeetContext> options)
            : base(options)
        {
            Database.EnsureCreated();   // создаем базу данных при первом обращении
        }
    }
    
       
        
}


        


