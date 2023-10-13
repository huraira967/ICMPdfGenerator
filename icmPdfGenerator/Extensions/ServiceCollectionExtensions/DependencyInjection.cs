using ICMPdfGenerator.Builder.documentPathBuilder;
using ICMPdfGenerator.DTOs.DTOModels.FacesheetDTOs;
using ICMPdfGenerator.DTOs.DTOModels.RATDTOs;
using ICMPdfGenerator.Models.Builder;
using ICMPdfGenerator.PdfTemplates.PdfModuleTemplates;
using ICMPdfGenerator.PdfTemplates.PdfModuleTemplates.RAT;
using ICMPdfGenerator.PdfTemplates.PdfTemplateFactory;
using ICMPdfGenerator.TemplateConfigurations;
using ICMPdfGenerator.TemplateConfigurations.TemplateConfigurationsFactory;
using Microsoft.AspNetCore.Http.Extensions;
using Newtonsoft.Json;

namespace ICMPdfGenerator.Extensions.ServiceCollectionExtensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddResolveTemplateConfiguration(this IServiceCollection services)
        {            
            

            services.AddScoped(provider =>
            {
                ITemplateConfiguration configuration;
                var templateConfigurationFactory = provider.GetRequiredService<ITemplateConfigurationsFactory>();
                var httpAccessor = provider.GetRequiredService<IHttpContextAccessor>();
                var pdfDocumentPathBuilder = provider.GetRequiredService<IPdfDocumentPathBuilder>();
                string url = httpAccessor.HttpContext?.Request.GetDisplayUrl() ?? "";
                
                httpAccessor?.HttpContext?.Request.EnableBuffering(); //Enable Buffering to read request body stream multiple time

                if (url.Contains("rat"))
                {
                    
                    string requestBody = new StreamReader(httpAccessor?.HttpContext?.Request.Body).ReadToEnd(); // do not dispose stream because this stream will be used multiple places
                    httpAccessor?.HttpContext?.Request.Body.Seek(0, SeekOrigin.Begin);  //after copying the stream set original stream to start as it never read before
                    var ratDTO = JsonConvert.DeserializeObject<RATPDFDTOModel>(requestBody);

                    configuration = templateConfigurationFactory.GetConfiguration<RATTemplateConfigurations>();

                    PdfDocumentPath pdfDocumentPath = new PdfDocumentPath(ratDTO.UserId, ratDTO.FacilityId, configuration.ModuleId, ratDTO.Id,configuration.ModuleName);
                    configuration.DocumentPath = pdfDocumentPathBuilder.GetDocumentPath(pdfDocumentPath);
                    
                }
                else if(url.Contains("facesheet"))
                {
                    string requestBody = new StreamReader(httpAccessor?.HttpContext?.Request.Body).ReadToEnd();
                    httpAccessor?.HttpContext?.Request.Body.Seek(0, SeekOrigin.Begin);

                    var facesheetDTO = JsonConvert.DeserializeObject<FacesheetPDFDTOModel>(requestBody);
                    configuration = templateConfigurationFactory.GetConfiguration<FacesheetTemplateConfigurations>();

                    PdfDocumentPath pdfDocumentPath = new PdfDocumentPath(facesheetDTO.UserId, facesheetDTO.FacilityId, configuration.ModuleId, facesheetDTO.Id, configuration.ModuleName);
                    configuration.DocumentPath = pdfDocumentPathBuilder.GetDocumentPath(pdfDocumentPath);

                }
                else
                {
                    
                   configuration = templateConfigurationFactory.GetConfiguration<NoTemplateConfigurations>();
                    PdfDocumentPath pdfDocumentPath = new PdfDocumentPath(0, 0, 0, 0, "NoModule");

                    configuration.DocumentPath =  pdfDocumentPathBuilder.GetDocumentPath(pdfDocumentPath);
                }
                
                return configuration;
            });

            return services;
        }

        public static IServiceCollection AddResolvePdfTemplate(this IServiceCollection services)
        {


            services.AddScoped(provider =>
            {
                IPdfModulefTemplate pdfTemplate;
                var templateConfigurationFactory = provider.GetRequiredService<IPdfTemplateFactory>();
                 var httpAccessor = provider.GetRequiredService<IHttpContextAccessor>();
                string url = httpAccessor.HttpContext?.Request.GetDisplayUrl() ?? "";


                if (url.Contains("rat"))
                {
                    pdfTemplate = templateConfigurationFactory.GetModuleTemplate<RATModuleTemplate>();

                }
                else if (url.Contains("facesheet"))
                {
                    pdfTemplate = templateConfigurationFactory.GetModuleTemplate<RATModuleTemplate>();
                }
                else
                {
                    pdfTemplate = templateConfigurationFactory.GetModuleTemplate<RATModuleTemplate>();
                }
                return pdfTemplate;
            });

            return services;
        }
    }
}
