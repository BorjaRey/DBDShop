using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DBDShopLib;
using System.Collections.Generic;

namespace Tests
{
    [TestClass]
    public class DBDShopTests
    {
        [TestMethod]
        public void AddAndTestData()
        {
            //Connect to the test database
            Client client= new Client("eSQ5HjQqMG ", "eSQ5HjQqMG ", "RRcl8SrkxR");
            //Get all the existing products
            List<Product> products = client.GetProducts();
            
            //Delete all the products
            client.DeleteProducts(products);
            //Check we deleted all the products
            products = client.GetProducts();
            Assert.IsTrue(products.Count == 0);

            //Insert test data
            client.InsertTestData();
            //Check they were correctly inserted
            products= client.GetProducts();
            Assert.IsTrue(products.Count == 2);
        }
        [TestMethod]
        public void MyOhterTest()
        {
            //Connect to the test database
            Client cliente = new Client("eSQ5HjQqMG ", "eSQ5HjQqMG ", "RRcl8SrkxR");

            //Get all the existing products
            List<Product> products = cliente.GetProducts();
            cliente.InsertTestData();
            Assert.IsTrue(products.Count == 2);
            cliente.DeleteProducts(products);
            Assert.IsTrue(products.Count == 0);
        }
    }
}
