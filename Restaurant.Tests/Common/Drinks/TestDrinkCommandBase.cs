using Restaraunt.Persistence;

namespace Restaurant.Tests.Common.Drinks
{
	public abstract class TestDrinkCommandBase : IDisposable
	{
		protected readonly ProductDbContext Context;
		public TestDrinkCommandBase()
		{
			Context = DrinksContextFactory.Create();
		}

		public void Dispose()
		{
			DrinksContextFactory.Destroy(Context);
		}
	}
}
