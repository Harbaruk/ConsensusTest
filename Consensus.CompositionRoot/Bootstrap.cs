using ConsensusTester.DataAccess.Infrastructure;
using ConsensusTester.Services.Blocks;
using ConsensusTester.Services.Transactions;
using Microsoft.Extensions.DependencyInjection;

namespace Consensus.CompositionRoot
{
    public class Bootstrap
    {
        public static void RegisterServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
            serviceCollection.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            serviceCollection.AddScoped<IBlockService, BlockService>();
            serviceCollection.AddScoped<ITransactionService, TransactionService>();
        }
    }
}