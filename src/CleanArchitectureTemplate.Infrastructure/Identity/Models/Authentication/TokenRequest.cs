using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace CleanArchitectureTemplate.Infrastructure.Identity.Models.Authentication
{
    public class TokenRequest
    {
        /// <summary>
        /// The username of the user logging in.
        /// </summary>
        [Required]
        [JsonProperty("username")]
        public string Username { get; set; }

        /// <summary>
        /// The password for the user logging in.
        /// </summary>
        [Required]
        [JsonProperty("password")]
        public string Password { get; set; }
    }
}
