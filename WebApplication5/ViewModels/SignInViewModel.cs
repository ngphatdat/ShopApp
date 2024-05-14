using System.Text.Json.Serialization;

namespace WebApplication5.ViewModels;

public class SignInViewModel
{
    [JsonPropertyName("user_name")]
    public string UserName { get; set; } = null!;
    [JsonPropertyName("password")]
    public string Password { get; set; } = null!;
}