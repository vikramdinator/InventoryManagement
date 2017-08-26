using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using InventoryManagement.Models;

namespace InventoryManagement.Controllers
{
    public class InventoryController : ApiController
    {
        public static List<Product> Products = new List<Product>()
        {
            new Product() { ID = 1, ProductName = "Sony Xperia",  Quantity = 5 },
            new Product() { ID = 2, ProductName = "Samsung S8",  Quantity = 23 },
            new Product() { ID = 3, ProductName = "Apple iPhone 7",  Quantity = 15 },
            new Product() { ID = 4, ProductName = "Apple iPad 3",  Quantity = 2 }
        };

        /// <summary>
        /// To add the product into the inventory
        /// </summary>
        /// <param name="product">the product is the input</param>
        /// <returns>returns added or not</returns>
        /// http://localhost:57203/api/inventory/add
        [HttpPost]
        public HttpResponseMessage Add(Product product)
        {
            if(product == null)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            Products.Add(product);
            return new HttpResponseMessage(HttpStatusCode.Created);
        }

        /// <summary>
        /// To update the product
        /// </summary>
        /// <param name="product">the product to be updated</param>
        /// <returns>return success or not</returns>
        /// http://localhost:57203/api/inventory/Update
        [HttpPost]
        public HttpResponseMessage Update(Product product)
        {
            if (product == null)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            Product productToUpdate = Products.Find(m => m.ID == product.ID);
            if (productToUpdate == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            
            //productToUpdate.Quantity += product.Quantity;
            productToUpdate.Quantity = product.Quantity;
            productToUpdate.ProductName = product.ProductName;
            return new HttpResponseMessage(HttpStatusCode.OK);
        }


        /// <summary>
        /// Search the product based product name and quantity
        /// </summary>
        /// <param name="searchtext">the name of the product</param>
        /// <param name="quantity">the quantity of the product</param>
        /// <returns>the list of the products</returns>
        /// http://localhost:57203/api/inventory/search/?searchtext=Apple
        /// http://localhost:57203/api/inventory/search/?searchtext=Apple&quantity=2
        [HttpGet]
        public IEnumerable<Product> Search(string searchtext="", int quantity = 0)
        {
            var result = Products.Where(p => p.ProductName.Contains(searchtext) && p.Quantity >= quantity);

            if (result.ToList().Count > 0)
                return result;
            else
                throw new HttpResponseException(HttpStatusCode.NotFound);
        }
    }
}
