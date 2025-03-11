namespace Database;
using Microsoft.EntityFrameworkCore;
public class ZooManagementDBContext:DbContext{
    public ZooManagementDBContext(): base(){}
    public DbSet<Animal> Animal { get; set;}
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
            optionsBuilder.UseSqlite(@"Server=localhost;Port=5432;Database=zoomanagement;User Id=zoo;Password=zoo;");
    }

}