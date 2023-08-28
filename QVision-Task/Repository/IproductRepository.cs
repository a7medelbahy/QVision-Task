using QVision_Task.Models;

namespace QVision_Task.Repository
{
    public interface IproductRepository
    {
        List<Product> GetAll();

        Product GetById(int id);

        void AddProduct(Product product);

        void UpdateProduct(Product product,int id);

        void DeleteProduct(int id);

        void Save();
    }
}
