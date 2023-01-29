using Microsoft.EntityFrameworkCore;
using WebEscuelaMVC.Models;

namespace WebEscuelaMVC.Data
{
    public class DBEscuelaContext: DbContext
    {
        public DBEscuelaContext(DbContextOptions<DBEscuelaContext> options) : base(options) { }

        public DbSet<Aula> Aulas { get; set; }
    }
}
