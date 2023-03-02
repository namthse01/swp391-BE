using Org.BouncyCastle.Asn1.X509;

namespace WebApi.Constants
{
    public struct RouterConstants
    {
        private const string Base = "api/v{version:apiVersion}";
        public const string Account = "api/accounts";
        public const string Field = $"{Base}/fields";
        public const string Category = $"{Base}/categories";
    }
}