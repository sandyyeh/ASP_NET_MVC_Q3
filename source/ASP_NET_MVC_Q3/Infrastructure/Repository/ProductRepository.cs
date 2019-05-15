using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ASP_NET_MVC_Q3.Data;
using ASP_NET_MVC_Q3.ViewModel;

namespace ASP_NET_MVC_Q3.Infrastructure
{
    public class ProductRepository : IProductRepository
    {
        private static int _index;
        List<Product> source = Product.Data;


        public ProductRepository()
        {
            if (_index == 0 && source != null && source.Count > 0)
            {
                _index = source.OrderBy(c => c.Id).Last().Id;
            }
        }

        public IEnumerable<Product> GetAll()
        {
            return source.OrderBy(c => c.Id);
        }

        public void Create(Product product)
        {
            _index++;

            source.Add(new Product() { Id = _index, Name = product.Name, CreateDate = DateTime.Now, Locale = product.Locale });

        }

        public void Delete(int id)
        {
            source.RemoveAll(c => c.Id == id);

        }

        public Product GetDetail(int id)
        {

            return source.Where(c => c.Id == id).FirstOrDefault();
        }


        public void Update(Product product)
        {
            var newValue = source.Where(c => c.Id == product.Id).FirstOrDefault();

            if (newValue != null)
            {
                newValue.Name = product.Name;
                newValue.Locale = product.Locale;
                newValue.UpdateDate = DateTime.Now;
            }

        }


    }
}
