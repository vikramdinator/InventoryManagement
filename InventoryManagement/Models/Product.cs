using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryManagement.Models
{
    /// <summary>
    /// Model class for product
    /// </summary>
    public class Product
    {
        /// <summary>
        /// The name of the product
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// Quantity of the product
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Unique id of the product
        /// </summary>
        public int ID { get; set; }
    }
}