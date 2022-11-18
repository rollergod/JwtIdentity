using JwtIdentity.Application.Common.Configs;
using JwtIdentity.Application.Common.Interfaces;
using Microsoft.Extensions.Options;
using RestSharp;
using RestSharp.Authenticators;

namespace JwtIdentity.Infrastructure.Services;

public class EmailService : IEmailService
{
    private readonly EmailConfig _emailConfig;

    public EmailService(IOptions<EmailConfig> emailConfig)
    {
        _emailConfig = emailConfig.Value;
    }

    public async Task<bool> SendEmailAsync(string toEmail, string message)
    {
        RestClient client = new RestClient("https://api.mailgun.net/v3");
        client.Authenticator =
            new HttpBasicAuthenticator("api",
                                       _emailConfig.API_KEY);

        RestRequest request = new RestRequest();

        request.AddParameter("domain",
                            "sandboxe9183e77d96f4124b103918ce9c052a2.mailgun.org",
                            type: ParameterType.UrlSegment);

        request.Resource = "{domain}/messages";
        request.AddParameter("from", "Excited User <mailgun@sandboxe9183e77d96f4124b103918ce9c052a2.mailgun.org>");
        request.AddParameter("to", "testemailsender29@gmail.com");
        request.AddParameter("subject", "Rollergod Project");
        request.AddParameter("text", "Text");
        request.AddParameter("html", message);

        request.Method = Method.Post;
        var response = await client.ExecuteAsync(request);

        return response.IsSuccessful;
    }
}