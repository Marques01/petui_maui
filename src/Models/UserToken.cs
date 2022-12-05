using System.Text.Json.Serialization;

namespace Models
{
    public class UserToken
    {
        private string
            _token = string.Empty,
            _message = string.Empty;

        [JsonPropertyName("token")]
        public string Token { get => _token; set => _token = value; }

        [JsonPropertyName("expiration")]
        public DateTime Expiration { get; set; }

        [JsonPropertyName("message")]
        public string Message { get => _message; set => _message = value; }
    }
}
