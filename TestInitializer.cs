using NUnit.Framework;
using ShoppingSystemWeb.Data;

namespace ShoppingSystemWebTest
{
	[TestFixture]
	public abstract class TestInitializer
	{
		protected ShoppingSystemWebContext? Context { get; set; }
		
		[SetUp]
		protected virtual void Initialize()
		{
			var factory = new ConnectionFactory();
			Context = factory.CreateContextForInMemory();
			TestContext.WriteLine("Initializing the DB");
		}

		[TearDown]
		protected virtual void CleanUp()
		{
			TestContext.WriteLine("Clean up of DB");
		}
	}
}