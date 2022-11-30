using ASPMVC.Models;
using System.Collections.Generic;


namespace ASPMVC.Services{
public class ProductService : List<ProductModel>
{
    public ProductService()
    {
        this.AddRange(new ProductModel[]
        {
            new ProductModel()
            {
                Id = 1, Name = "Nokia",Price = 1000,
            },
            new ProductModel()
            {
                Id = 2, Name = "Phone13",Price = 10000,
            },
            new ProductModel()
            {
                Id = 3, Name = "Xiaomi",Price = 5000,
            },
            new ProductModel()
            {
                Id = 4, Name = "Samsung",Price = 9000,
            },

        });
    }
    
}
}
