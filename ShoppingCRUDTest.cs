using NUnit.Framework;
using ShoppingSystemWeb.Controllers;
using ShoppingSystemWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingSystemWebTest
{
	[TestFixture]
	public class ShoppingCRUDTest : TestInitializer
	{
		[Test]
		public void Add_Product()
		{
			var factory = new ConnectionFactory();
			var context = factory.CreateContextForInMemory();
			var product = new Product
			{
				Title = "Bread",
				ExpiredDate = DateTime.Parse("2022-07-01"),
				Category = "Grosary",
				Price = 12.00M
			};
			context.Product.Add(product);
			context.SaveChanges();

			var productsCount = context.Product.Count();
			if (productsCount > 0)
			{
				Assert.AreEqual(productsCount, 1);	
			}
				
		}
	}
}
