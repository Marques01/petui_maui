using System.Text.Json.Serialization;

namespace Models
{
    public class ApplicationRoles
    {
        private Guid
            _id = default;

        private string
            _name = string.Empty;

        [JsonPropertyName("id")]
        public Guid Id { get => _id; set => _id = value; }

        [JsonPropertyName("name")]
        public string Name { get => _name; set => _name = value; }
    }
}
