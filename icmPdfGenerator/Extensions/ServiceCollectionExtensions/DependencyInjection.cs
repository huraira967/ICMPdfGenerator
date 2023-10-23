using ICMPdfGenerator.Builder.documentPathBuilder;
using ICMPdfGenerator.DTOs.DTOModels.FacesheetDTOs;
using ICMPdfGenerator.DTOs.DTOModels.RATDTOs;
using ICMPdfGenerator.Models.Builder;
using ICMPdfGenerator.Models.ICMPdfElements;
using ICMPdfGenerator.Models.ICMPdfElements.CellElements;
using ICMPdfGenerator.PdfTemplates.PdfModuleTemplates;
using ICMPdfGenerator.PdfTemplates.PdfModuleTemplates.RAT;
using ICMPdfGenerator.PdfTemplates.PdfTemplateFactory;
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
                IPdfTemplateConfiguration configuration;
                var templateConfigurationFactory = provider.GetRequiredService<IPdfTemplateConfigurationsFactory>();
                var httpAccessor = provider.GetRequiredService<IHttpContextAccessor>();
                var pdfDocumentPathBuilder = provider.GetRequiredService<IPathBuilder>();
                string url = httpAccessor.HttpContext?.Request.GetDisplayUrl() ?? "";

                httpAccessor?.HttpContext?.Request.EnableBuffering(); //Enable Buffering to read request body stream multiple time

                if (url.Contains("rat"))
                {

                    string requestBody = new StreamReader(httpAccessor?.HttpContext?.Request.Body).ReadToEnd(); // do not dispose stream because this stream will be used multiple places
                    httpAccessor?.HttpContext?.Request.Body.Seek(0, SeekOrigin.Begin);  //after copying the stream set original stream to start as it never read before
                    var ratDTO = JsonConvert.DeserializeObject<RATPDFDTOModel>(requestBody);

                    configuration = templateConfigurationFactory.GetConfiguration<RATPdfTemplateConfigurations>();

                    DocumentPathAttributes pdfDocumentPath = new DocumentPathAttributes(ratDTO.UserId, ratDTO.FacilityId, configuration.ModuleId, ratDTO.Id, configuration.ModuleName);
                    configuration.DocumentPath = pdfDocumentPathBuilder.BuildPath(pdfDocumentPath);
                    var footr = new Paragraph();
                    footr.Add(new TextSegment("Powered by iCareManager"));
                    footr.Styles.TextAlignment = ICMProperties.Enums.TextAlignment.CENTER;
                    configuration.Footer = footr;

                }
                else if (url.Contains("facesheet"))
                {
                    string requestBody = new StreamReader(httpAccessor?.HttpContext?.Request.Body).ReadToEnd();
                    httpAccessor?.HttpContext?.Request.Body.Seek(0, SeekOrigin.Begin);

                    var facesheetDTO = JsonConvert.DeserializeObject<FacesheetPDFDTOModel>(requestBody);
                    configuration = templateConfigurationFactory.GetConfiguration<FacesheetPdfTemplateConfigurations>();

                    DocumentPathAttributes pdfDocumentPath = new DocumentPathAttributes(facesheetDTO.UserId, facesheetDTO.FacilityId, configuration.ModuleId, facesheetDTO.Id, configuration.ModuleName);
                    configuration.DocumentPath = pdfDocumentPathBuilder.BuildPath(pdfDocumentPath);

                }
                else
                {
                    configuration = templateConfigurationFactory.GetConfiguration<NoPdfTemplateConfigurations>();
                    DocumentPathAttributes pdfDocumentPath = new DocumentPathAttributes(0, 0, 0, 0, "NoModule");

                    configuration.DocumentPath = pdfDocumentPathBuilder.BuildPath(pdfDocumentPath);
                }

                return configuration;
            });

            return services;
        }

        public static IServiceCollection AddResolvePdfTemplate(this IServiceCollection services)
        {


            services.AddScoped(provider =>
            {
                IiCMPdfModulefTemplate pdfTemplate;
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
