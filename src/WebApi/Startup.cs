using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using NerdStore.Vendas.Application.Events;
using PaymentHub.Application.AutoMapper;
using PaymentHub.Application.Commands;
using PaymentHub.Application.Events;
using PaymentHub.Core.Communication.Mediator;
using PaymentHub.Core.Messages.CommonMessages;

namespace PaymentHub.WebApi
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddControllers();

      services.AddAutoMapper(typeof(DomainToViewModelMappingProfile), typeof(DomainToViewModelMappingProfile));

      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "PaymentHub", Version = "v1" });
      });

      services.AddMediatR(typeof(Startup));

      // Mediator
      services.AddScoped<IMediatorHandler, MediatorHandler>();

      // Notifications
      services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();

      // Event Sourcing
      //services.AddSingleton<IEventStoreService, EventStoreService>();
      //services.AddSingleton<IEventSourcingRepository, EventSourcingRepository>();

      // TenantAppService 
      services.AddScoped<ITenantAppService, TenantAppService>();

      //Commands
      services.AddScoped<IRequestHandler<RegisterTenantCommand, bool>, TenantCommandHandler>();
      services.AddScoped<IRequestHandler<RejectTenantRegisterCommand, bool>, TenantCommandHandler>();
      services.AddScoped<IRequestHandler<RequestTenantCommand, bool>, TenantCommandHandler>();

      services.AddScoped<INotificationHandler<TenantRequestedEvent>,TenantEventHandler>();
      services.AddScoped<INotificationHandler<TenantRegisteredEvent>,TenantEventHandler>();
      services.AddScoped<INotificationHandler<TenantRegisterRejectedEvent>,TenantEventHandler>();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseHttpsRedirection();

      app.UseRouting();

      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });

      app.UseSwagger();

      app.UseSwaggerUI(c =>
      {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "PaymentHub V1");
      });
    }
  }
}
