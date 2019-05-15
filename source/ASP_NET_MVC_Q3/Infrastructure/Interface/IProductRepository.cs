using ASP_NET_MVC_Q3.Data;
using ASP_NET_MVC_Q3.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_NET_MVC_Q3.Infrastructure
{
    public interface IProductRepository
    {     
        void Create(Product product);

        void Update(Product product);

        void Delete(int id);

        Product GetDetail(int id);

        IEnumerable<Product> GetAll();

    }
}
