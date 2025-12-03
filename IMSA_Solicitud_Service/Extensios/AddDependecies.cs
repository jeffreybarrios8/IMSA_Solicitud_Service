using IMSA_Solicitud_Service.Configuration;
using System.Runtime.CompilerServices;
using System.Web.Http.Dependencies;

namespace IMSA_Solicitud_Service.Extensios
{
    public static class AddDependecies
    {

        internal static void AddDependenciesConfiguration(this WebApplicationBuilder builder)
        {
            var depConfig = new DependecyConfiguration();
            builder.Configuration.AddJsonFile("dependencies.json", optional: false, reloadOnChange: true);
            builder.Configuration.GetSection("DependencyConfiguration").Bind(depConfig);
            builder.Services.AddSingleton(depConfig);
            foreach (var dep in depConfig.Dependencies)
            {
                var fromType = Type.GetType(dep.From);
                var toType = Type.GetType(dep.To);

                if (fromType == null || toType == null)
                {
                    throw new Exception($"Cannot resolve DI types: {dep.From} -> {dep.To}");
                }

                if (!Enum.TryParse(dep.DependencyType, true, out DependecyTpe dependencyTypeEnum))
                {
                    // Error si la cadena no corresponde a un valor válido del enum
                    throw new Exception($"Unknown DependencyType: {dep.DependencyType}. Valid options are Transient, Scoped, Singleton.");
                }

                switch (dependencyTypeEnum)
                {
                    case DependecyTpe.Transient:
                        builder.Services.AddTransient(fromType, toType);
                        break;

                    case DependecyTpe.Scoped:
                        builder.Services.AddScoped(fromType, toType);
                        break;

                    case DependecyTpe.Singleton:
                        builder.Services.AddSingleton(fromType, toType);
                        break;

                    default:
                        throw new Exception($"Unknown DependencyType: {dep.DependencyType}");
                }
            }
        }


    }
}
