﻿using GuestBook.Mapper;
using GuestBook.Models;
using GuestBook.Models.Contracts;
using GuestBook.Repositories;
using GuestBook.Services;
using GuestBook.Services.Filters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GuestBook
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = Configuration["Data:Database:ConnectionString"];
            services.AddDbContext<DomainContext>(opt => opt.UseSqlServer(connectionString));

            services.AddMvc();

            services.AddScoped<IContractMapper, ContractMapper>();

            AddRepositores(services);

            AddServices(services);

            AddFilters(services);

            AddControllerServices(services);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }

        private void AddRepositores(IServiceCollection services)
        {
            AddEF7Repository<User>(services);
            AddEF7Repository<Restaurant>(services);
            AddEF7Repository<Review>(services);
        }

        private void AddServices(IServiceCollection services)
        {
            /*services.AddScoped<IEndpointService<UserContract, EditUserContract, UserFilterContract, User>, UserEndpointService>();
            services.AddScoped<UserEndpointService>();

            services.AddScoped<IEndpointService<RestaurantContract, EditRestaurantContract, RestaurantFilterContract, Restaurant>, RestaurantEndpointService>();
            services.AddScoped<RestaurantEndpointService>();

            services.AddScoped<IEndpointService<ReviewContract, EditReviewContract, ReviewFilterContract, Review>, ReviewEndpointService>();
            services.AddScoped<ReviewEndpointService>();*/
        }

        private void AddFilters(IServiceCollection services)
        {
            services.AddScoped<IEndpointFilter<UserFilterContract, User>, UserEndpointFilter>();
            services.AddScoped<UserEndpointFilter>();

            services.AddScoped<IEndpointFilter<RestaurantFilterContract, Restaurant>, RestaurantEndpointFilter>();
            services.AddScoped<RestaurantEndpointFilter>();

            services.AddScoped<IEndpointFilter<ReviewFilterContract, Review>, ReviewEndpointFilter>();
            services.AddScoped<ReviewEndpointFilter>();
        }

        private void AddControllerServices(IServiceCollection services)
        {
            /*services.AddScoped(opt => new UserEndpointService(
                opt.GetService<EF7Repository<User>>(),
                opt.GetService<IContractMapper>(),
                opt.GetService<UserEndpointFilter>()));

            services.AddScoped(opt => new RestaurantEndpointService(
                opt.GetService<EF7Repository<Restaurant>>(),
                opt.GetService<IContractMapper>(),
                opt.GetService<RestaurantEndpointFilter>(),
                opt.GetService<EF7Repository<Review>>(),
                opt.GetService<EF7Repository<User>>()));

            services.AddScoped(opt => new ReviewEndpointService(
                opt.GetService<EF7Repository<Review>>(),
                opt.GetService<IContractMapper>(),
                opt.GetService<ReviewEndpointFilter>(),
                opt.GetService<EF7Repository<User>>(),
                opt.GetService<EF7Repository<Restaurant>>()));*/
        }

        private void AddEF7Repository<T>(IServiceCollection services)
            where T : class, IModel
        {
            services.AddScoped<IRepository<T>>(p => new EF7Repository<T>(p.GetService<DomainContext>()));
        }
    }
}
