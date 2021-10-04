using System.Text.Json.Serialization;

namespace CleanArchitectureTemplate.Core.Entities.Base
{
    public abstract class BaseEntity
    {
        [JsonPropertyName("id")]
        public virtual string Id { get; set; }
    }
}
