using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ConsensusTester.Extensions
{
    public static class OptionExtension
    {
        public static IServiceCollection ConfigureFromSection<TOptions>(this IServiceCollection services, IConfiguration config)
              where TOptions : class
        {
            string typeName = typeof(TOptions).Name;
            int index = typeName.LastIndexOf("Options");
            string sectionName = index >= 0 ? typeName.Substring(0, index) : typeName;
            return services.Configure<TOptions>(config.GetSection(sectionName));
        }
    }
}