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
        Product Create(Product product);

        ProductViewModel Update(ProductViewModel productViewModel);

        int Delete(int id);

        ProductViewModel Get(int categoryID);

        int GetIndex(int num);
    }
}
