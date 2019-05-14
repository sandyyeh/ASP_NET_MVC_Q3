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
        public static int Index;
        List<Product> source = Product.Data;
        List<SelectListItem> items = new List<SelectListItem>()
                        {
                            new SelectListItem(){Text = "Unite State", Value = "US"},
                            new SelectListItem(){Text = "Germany",Value = "DE"},
                            new SelectListItem(){Text = "Canada",Value = "CA"},
                            new SelectListItem(){Text = "Spain",Value = "ES"},
                            new SelectListItem(){Text = "France",Value = "FR"},
                            new SelectListItem(){Text = "Japan",Value = "JP"}
                        };

        public Product Create(Product product)
        {
            Index++;

            ProductViewModel viewModel = new ProductViewModel();
            viewModel.Name = product.Name;
            viewModel.Locale = product.Locale;
            viewModel.CreateDate = DateTime.Now;

            source.Add(new Product() { Id = Index, Name = viewModel.Name, CreateDate = viewModel.CreateDate, Locale = viewModel.Locale });

            return product;

        }

        public int Delete(int id)
        {
            source.RemoveAll(model => model.Id == id);
            return id;

        }

        public ProductViewModel Get(int id)
        {
            ProductViewModel viewModel = new ProductViewModel();
            for (int i = 0; i < source.Count; i++)
            {
                if (source[i].Id == id)
                {
                    viewModel.Locale = source[i].Locale;
                    viewModel.Name = source[i].Name;
                    viewModel.LocaleListItem = items;

                    return viewModel;
                }
            }
            return viewModel;

        }


        public ProductViewModel Update(ProductViewModel productViewModel)
        {
            var newValue = source.Where(m => m.Id == productViewModel.Id).FirstOrDefault();

            if (newValue != null)
            {
                newValue.Name = productViewModel.Name;
                newValue.Locale = productViewModel.Locale;
                newValue.UpdateDate = DateTime.Now;
            }

            return productViewModel;
        }

        public int GetIndex(int num)
        {
            Index = num;
            return Index;
        }
    }
}
