using Microsoft.EntityFrameworkCore;
using WpfApp1.Models;

namespace WpfApp1.DataBase;

public class StudentContext: DbContext
{
    public DbSet<Student> Students { get; set; }

    public StudentContext()
    {
        Database.Migrate();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source = LocalStorage.db");
    }
}