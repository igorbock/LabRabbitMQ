namespace LabRabbitMQ.Services;

public class ProductService : IProductService
{
    private readonly AppDbContext _context;
    private readonly IRabbitMQProducer _rabbitMQProducer;
    public ProductService(AppDbContext dbContext, IRabbitMQProducer rabbitMQProducer)
    {
        _context = dbContext;
        _rabbitMQProducer = rabbitMQProducer;
    }
    public IEnumerable<Product> GetProductList()
    {
        return _context.Products.ToList();
    }
    public Product GetProductById(int id)
    {
        return _context.Products.Where(x => x.Id == id).FirstOrDefault()!;
    }
    public Product AddProduct(Product product)
    {
        var result = _context.Products.Add(product);
        _context.SaveChanges();
        _rabbitMQProducer.SendProductMessageAsync(product);
        return result.Entity;
    }
    public Product UpdateProduct(Product product)
    {
        var result = _context.Products.Update(product);
        _context.SaveChanges();
        _rabbitMQProducer.SendProductMessageAsync(result.Entity);
        return result.Entity;
    }
    public bool DeleteProduct(int Id)
    {
        var filteredData = _context.Products.Where(x => x.Id == Id).FirstOrDefault();
        var result = _context.Products.Remove(filteredData!);
        _context.SaveChanges();
        _rabbitMQProducer.SendProductMessageAsync(filteredData!);
        return result != null ? true : false;
    }
}
