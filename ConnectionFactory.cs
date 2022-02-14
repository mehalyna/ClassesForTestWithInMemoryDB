using Microsoft.EntityFrameworkCore;
using ShoppingSystemWeb.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingSystemWebTest
{
	public class ConnectionFactory : IDisposable
	{
		private bool disposedValue = false;
		public ShoppingSystemWebContext CreateContextForInMemory()
		{
			var option = new DbContextOptionsBuilder<ShoppingSystemWebContext>()
				.UseInMemoryDatabase(databaseName:"ShoppingTest").Options;
			var context = new ShoppingSystemWebContext(option);
			if (context != null)
			{
				context.Database.EnsureDeleted();
				context.Database.EnsureCreated();
			}
			return context;

		}
		protected virtual void Dispose(bool disposing)
		{
			if (!disposedValue)
			{
				if (disposing)
				{ }
				disposedValue = true;
			}
		}
		public void Dispose()
		{ 
			Dispose(true);
		}
	}
}
