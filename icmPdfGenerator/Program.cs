using ICMPdfGenerator.Adapter;
using ICMPdfGenerator.Brokers.PdfBroker;
using ICMPdfGenerator.Builder.documentPathBuilder;
using ICMPdfGenerator.Extensions.ServiceCollectionExtensions;
using ICMPdfGenerator.PdfTemplates.PdfTemplateFactory;
using ICMPdfGenerator.Services.PdfFoundationService;
using ICMPdfGenerator.Services.PdfProcessing;
using ICMPdfGenerator.TemplateConfigurations.TemplateConfigurationsFactory;
using Microsoft.AspNetCore.Server.Kestrel.Core;

namespace icmPdfGenerator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddHttpContextAccessor();
            builder.Services.Configure<KestrelServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });

            builder.Services.AddScoped<IPdfBroker, PdfBroker>();            
            builder.Services.AddSingleton<ITemplateConfigurationsFactory, TemplateConfigurationsFactory>();
            builder.Services.AddTransient<IPdfDocumentPathBuilder, PdfDocumentPathBuilder>();
            builder.Services.AddSingleton<IItext7Adapter, Itext7Adapter>();
            builder.Services.AddScoped<IPdfFoundationService, PdfFoundationService>();
            builder.Services.AddSingleton<IPdfTemplateFactory,  PdfTemplateFactory>();
            builder.Services.AddScoped<IPdfProcessingService, PdfProcessingService>();
            builder.Services.AddResolveTemplateConfiguration();
            builder.Services.AddResolvePdfTemplate();




            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}