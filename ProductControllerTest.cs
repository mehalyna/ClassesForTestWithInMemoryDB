using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using ShoppingSystemWeb.Controllers;
using ShoppingSystemWeb.Data;
using ShoppingSystemWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ShoppingSystemWebTest
{
	public class ProductControllerTest
	{
		
		[Test]
		public async Task Create_New_Product_Test() 
		{
			using var factory = new ConnectionFactory();
			var context = factory.CreateContextForInMemory();

			var controller = new ProductsController(context);
			var product = new Product()
			{
				Id = 10,
				Title = "Valentine Cake",
				ExpiredDate = DateTime.Today.AddDays(4),
				Category = "C",
				Price = 100
			};

			var result = (RedirectToActionResult)await controller.Create(product);

			Assert.NotNull(result);
			Assert.AreEqual("Index", result.ActionName);
			Assert.AreEqual(10, context.Product.FirstOrDefault()?.Id);
		}
				
	}
}
