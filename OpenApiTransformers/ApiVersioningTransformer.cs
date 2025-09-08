using Asp.Versioning.ApiExplorer;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.OpenApi.Models;

namespace SurveyBasket.OpenApiTransformers
{
    public sealed class ApiVersioningTransformer(ApiVersionDescription description) : IOpenApiDocumentTransformer
    {
        public ApiVersionDescription Description => description;
        public Task TransformAsync(OpenApiDocument document, OpenApiDocumentTransformerContext context, CancellationToken cancellationToken)
        {
            document.Info = new()
            {
                Title = "Survey Basket API",
                Version = description.ApiVersion.ToString(),
                Description = $"API Description.{(description.IsDeprecated ? "This API version has been deprecated." : string.Empty)}"
            };
            return Task.CompletedTask;
        }
    }
}
