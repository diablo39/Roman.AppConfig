namespace Roman.AppConfig.Api.Swagger
{
    [AttributeUsage(AttributeTargets.Parameter)]
    public sealed class SwaggerIgnorePropertyAttribute : Attribute
    {
        public string[] Names { get; set; }

        public SwaggerIgnorePropertyAttribute(params string[] names)
        {
            Names = names;
        }
    }
}