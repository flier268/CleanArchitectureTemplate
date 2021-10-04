using Newtonsoft.Json;

namespace CleanArchitectureTemplate.Core.Entities.Base
{
    public abstract class BaseEntity
    {
        [JsonProperty(PropertyName = "id")]
        public virtual string Id { get; set; }
    }
}
