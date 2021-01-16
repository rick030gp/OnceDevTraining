using FluentValidation.AspNetCore;
using System.Reflection;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class IMvcBuilderExtensions
    {
        public static IMvcBuilder AddValidators(this IMvcBuilder builder)
        {
            builder.AddFluentValidation(v => v.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()));
            return builder;
        }
    }
}
