using Microsoft.Extensions.AI;

namespace MattEland.AI.Assistant.UnoClient.Presentation;

public partial record MainModel
{
    private readonly IChatClient _chat;

    public MainModel(IChatClient chat)
    {
        _chat = chat;
    }

    public string Title => "ELIZA Chat";

    public IState<string> Message => State<string>.Value(this, () => string.Empty);

    public async Task Chat()
    {
        string message = await Message;
        ChatResponse response = await _chat.GetResponseAsync(message!);
        await Response.UpdateAsync(r => r = response.Text);
    }

    public IState<string> Response => State<string>.Value(this, () => "Hello. I am ELIZA. How can I help you today?");
}
