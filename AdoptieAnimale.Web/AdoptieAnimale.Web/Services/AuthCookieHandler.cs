namespace AdoptieAnimale.Web.Services;

public class AuthCookieHandler : DelegatingHandler
{
    private readonly IHttpContextAccessor _http;

    public AuthCookieHandler(IHttpContextAccessor http)
    {
        _http = http;
    }

    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var ctx = _http.HttpContext;

        if (ctx != null && ctx.Request.Headers.TryGetValue("Cookie", out var cookie))
        {
            request.Headers.Add("Cookie", cookie.ToString());
        }

        return base.SendAsync(request, cancellationToken);
    }
}