using System.ComponentModel.DataAnnotations;

namespace CleanArchitectureTemplate.WebAPI.Models.Shared
{
    public class DataTablesResponse
    {
        /// <summary>
        ///     Total number of records available
        /// </summary>
        [Required]
        public int TotalRecords { get; set; }
        /// <summary>
        ///     Data object
        /// </summary>
        [Required]
        public object Data { get; set; }

        /// <summary>
        ///     Current page index 
        /// </summary>
        [Required]
        public int Page { get; set; }
    }
}
