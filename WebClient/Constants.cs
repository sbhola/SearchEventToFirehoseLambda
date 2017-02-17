namespace WebClient
{
    internal static class Constants
    {
        internal static class HttpMethod
        {
            internal static readonly string GET = "GET";
            internal static readonly string POST = "POST";
            internal static readonly string PUT = "PUT";
            internal static readonly string DELETE = "DELETE";
            internal static readonly string PATCH = "PATCH";
        }

        internal static class Headers
        {
            internal static readonly string ContentType = "content-type";

            internal static readonly string OskiTenantId = "oski-tenantId";

        }

        internal static class HeaderValues
        {
            internal static readonly string ContentType = "application/json";
            internal static readonly string OskiTenantId = "Demo";
        }
    }
}