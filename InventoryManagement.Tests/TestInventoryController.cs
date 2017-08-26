using System;
using InventoryManagement.Controllers;
using InventoryManagement.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Http;
using System.Net.Http;

namespace InventoryManagement.Tests
{
    [TestClass]
    public class TestInventoryController
    {
        [TestMethod]
        public void AddProductTestSuccess()
        {
            var controller = new InventoryController();

            Product product = new Product()
            {
                ProductName = "Test product",
                Quantity = 2
            };

            HttpResponseMessage response = controller.Add(product);
            Assert.AreEqual(201,(int) response.StatusCode);
        }

        [TestMethod]
        public void AddProductTestFail()
        {
            var controller = new InventoryController();

            Product product = null;
            HttpResponseMessage response = null;
            try
            {
                response = controller.Add(product);
            }
            catch (HttpResponseException ex)
            {
                Assert.AreEqual(400, (int) ex.Response.StatusCode );
            }
        }

        [TestMethod]
        public void UpdateProductTestSuccess()
        {
            var controller = new InventoryController();

            Product product = new Product()
            {
                ID = 2,
                ProductName = "Test product",
                Quantity = 2
            };

            HttpResponseMessage response = controller.Update(product);
            Assert.AreEqual(200, (int)response.StatusCode);
        }

        [TestMethod]
        public void UpdateProductTestFailNotFound()
        {
            var controller = new InventoryController();

            Product product = new Product()
            {
                ID = 25,
                ProductName = "Test product",
                Quantity = 2
            };

            HttpResponseMessage response = null;
            try
            {
                response = controller.Update(product);
            }
            catch (HttpResponseException ex)
            {
                Assert.AreEqual(404, (int)ex.Response.StatusCode);
            }
        }

        [TestMethod]
        public void UpdateProductTestFailBadRequest()
        {
            var controller = new InventoryController();

            Product product = null;
            HttpResponseMessage response = null;
            try
            {
                response = controller.Update(product);
            }
            catch (HttpResponseException ex)
            {
                Assert.AreEqual(400, (int)ex.Response.StatusCode);
            }
        }

        [TestMethod]
        public void SearchProductNoResultFoundTest()
        {
            var controller = new InventoryController();

            try
            {
                controller.Search("XXXY",0);
            }
            catch (HttpResponseException ex)
            {
                Assert.AreEqual(404, (int)ex.Response.StatusCode);
            }
        }

        [TestMethod]
        public void SearchProductResultsFoundTest()
        {
            var controller = new InventoryController();

            try
            {
                var results = controller.Search("APPLE", 0);
                Assert.IsNotNull(results);
            }
            catch (HttpResponseException ex)
            {
                //;
            }
        }
    }
}
