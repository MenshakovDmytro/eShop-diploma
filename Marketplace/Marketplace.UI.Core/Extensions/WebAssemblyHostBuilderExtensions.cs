﻿using System.Diagnostics.CodeAnalysis;
using Infrastructure.Services;
using Infrastructure.Services.Interfaces;
using Marketplace.UI.Core.Services;
using Marketplace.UI.Core.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Marketplace.UI.Core.Extensions
{
    [ExcludeFromCodeCoverage]
    public static class WebAssemblyHostBuilderExtensions
    {
        public static void AddServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddHttpClient();
            serviceCollection.AddTransient<IJsonSerializer, JsonSerializer>();
            serviceCollection.AddTransient<IHttpClientService, HttpClientService>();

            serviceCollection.AddTransient<IBoardGameService, BoardGameService>();
            serviceCollection.AddTransient<IBrandService, BrandService>();
            serviceCollection.AddTransient<ICategoryService, CategoryService>();
            serviceCollection.AddTransient<IMechanicService, MechanicService>();
            serviceCollection.AddTransient<IBasketService, BasketService>();

            serviceCollection.AddTransient<IUriBuilderService, UriBuilderService>();
        }
    }
}