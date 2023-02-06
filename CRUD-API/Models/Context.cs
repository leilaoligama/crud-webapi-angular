using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace crud_api.Models
{
    public class Context : DbContext
    {
       public DbSet<Pessoa> Pessoas { get; set; }

       public Context(DbContextOptions<Context> option) : base(option)
       {
        
       }

    }
}