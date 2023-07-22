using Restaraunt.Persistence;

namespace Restaurant.Tests.Common.Burgers
{
    public abstract class TestBurgerCommandBase : IDisposable
    {
        protected readonly ProductDbContext Context;
        public TestBurgerCommandBase()
        {
            Context = BurgersContextFactory.Create();
        }

        public void Dispose()
        {
            BurgersContextFactory.Destroy(Context);
        }
    }
}
