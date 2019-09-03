using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoginWebBackEnd.Model;
namespace LoginWebBackEnd.Model
{
    public class ProfileContext: DbContext
    {
        public ProfileContext(DbContextOptions<ProfileContext> option) : base(option)
        {

        }
        public DbSet<LoginData> loginData { get; set;}
    }
}
