namespace LabRabbitMQ.Context;

public class AppDbContext : DbContext
{
    protected readonly IConfiguration Configuration;
    public AppDbContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    override protected void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
    }

    public DbSet<Product> Products {get;set;}
}
