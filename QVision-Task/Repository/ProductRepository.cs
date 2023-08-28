using QVision_Task.Models;

namespace QVision_Task.Repository
{
    public class ProductRepository : IproductRepository
    {
        QvisionContext context;
        public ProductRepository(QvisionContext _context) { 
            this.context= _context;
        }

        public List<Product> GetAll()
        {
            return context.products.ToList();
        }
        public Product GetById(int id)
        {
            return context.products.FirstOrDefault(p=>p.Id==id);
        }

        public void AddProduct(Product product)
        {
            context.Add(product);
        }

        public void UpdateProduct(Product product, int id)
        {
            Product oldProd = context.products.SingleOrDefault(p=>p.Id==id);

            oldProd.Name= product.Name;
            oldProd.Description= product.Description;
            oldProd.Price= product.Price;
            oldProd.StockQuantity= product.StockQuantity;
            oldProd.ExpirationDate= product.ExpirationDate;

        }
        public void DeleteProduct(int id)
        {
            Product product = context.products.SingleOrDefault(p => p.Id == id);
            context.products.Remove(product);
        }

        public void Save()
        {
            context.SaveChanges();
        }

    }
}
