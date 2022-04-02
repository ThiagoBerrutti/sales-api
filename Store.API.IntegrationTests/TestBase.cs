﻿using Microsoft.Extensions.DependencyInjection;
using Store.API.IntegrationTests.Auth;
using StoreAPI;
using StoreAPI.Dtos;
using StoreAPI.Infra;
using StoreAPI.Persistence;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Xunit;

namespace Store.API.IntegrationTests
{
    public class TestBase : IClassFixture<TestWebApplicationFactory<Startup>>
    {
        private readonly IServiceScope Scope;
        public TestWebApplicationFactory<Startup> Factory { get; }
        public IServiceProvider ServiceProvider { get; set; }
        public HttpClient Client { get;}
        public StoreDbContext Context { get; }
        public TestHelpers Helpers { get; }

        public TestBase(TestWebApplicationFactory<Startup> factory)
        {
            Factory = factory;
            Client = Factory.CreateClient();
            Scope = Factory.Services.CreateScope();
            ServiceProvider = Scope.ServiceProvider;

            Context = ServiceProvider.GetRequiredService<StoreDbContext>();
            Helpers = new TestHelpers(Client,Context);
        }
    }
}