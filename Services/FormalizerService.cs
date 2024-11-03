using Grpc.Core;
using OpenAI.Chat;

namespace FormalizadorGrpc.Services;

public class FormalizerService : Formalizer.FormalizerBase
{
    private readonly ILogger<FormalizerService> _logger;
    private readonly IConfiguration _configuration;

    public FormalizerService(ILogger<FormalizerService> logger, IConfiguration configuration)
    {
        _logger = logger;
        _configuration = configuration;
    }

    public override async Task<FormalizerReply> FormalizeText(FormalizerRequest request, ServerCallContext context)
    {
        var openAiToken = Environment.GetEnvironmentVariable("Tokens:OpenAiToken");
        
        if (string.IsNullOrEmpty(openAiToken))
        {
            openAiToken = _configuration["Tokens:OpenAiToken"];
        }
        ChatClient client = new(model: "gpt-4o-mini", apiKey: openAiToken);
        ChatCompletion completion =
            await client.CompleteChatAsync($"Transforme o seguinte texto em um texto bem formal: {request.Text}");
        
        return await Task.FromResult(new FormalizerReply
        {
            FormalizedText = completion.Content[0].Text
        });
    }
}