namespace ProdutosApi.Infrastructure.Common
{
    public class BadRequestException
    : Exception
    {
        public readonly IDictionary<string, string> Errors;

        public BadRequestException(string field, string message)
        {
            Errors = new Dictionary<string, string>
            {
                { field, message }
            };
        }

        public BadRequestException(IDictionary<string, string> errors)
        {
            Errors = errors;
        }
    }
}
