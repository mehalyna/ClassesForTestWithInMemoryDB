using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using ShoppingSystemWeb.Data;
using ShoppingSystemWeb.Models;
using ShoppingSystemWeb.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingSystemWebTest
{
	public class PaginatedListServiceTest
	{
		[Test]
        public async Task Should_Create_PaginatedList()
        {
            using var factory = new ConnectionFactory();
            var context = factory.CreateContextForInMemory();
            List<string> products = new() 
                { "Cheese", "Bread", "Cola", "Cake"
                , "Oat", "Corn", "Water", "Rice", "Milk", "Weat"};

            foreach (string product in products)
            {
                context.Product.AddRange(new List<Product>() { new Product() 
                { 
                    Title = product,  
                    Category = "Food"
                } });
            }
            context.SaveChanges();

            var querProduct = context.Product;

            var paginatedList = await PaginatedList<Product>
                .CreateAsync(querProduct.AsNoTracking(), 1, 10);

            Assert.NotNull(paginatedList);
            Assert.AreEqual(10, paginatedList.Count);
           
        }
    }
}
