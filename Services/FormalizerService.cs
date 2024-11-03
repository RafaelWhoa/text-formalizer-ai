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
        ChatClient client = new(model: "gpt-4o-mini", apiKey: _configuration["Tokens:OpenAiToken"]);
        ChatCompletion completion =
            await client.CompleteChatAsync($"Transforme o seguinte texto em um texto bem formal: {request.Text}");
        
        return await Task.FromResult(new FormalizerReply
        {
            FormalizedText = completion.Content[0].Text
        });
    }
}