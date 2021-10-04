using System;
using System.ComponentModel.DataAnnotations;

namespace CleanArchitectureTemplate.WebAPI.Models.Attachment
{
    /// <summary>
    ///     Attachment
    /// </summary>
    public class AttachmentModel
    {
        public AttachmentModel()
        {
            this.Id = Guid.NewGuid();
        }

        [Required]
        public Guid Id { get; set; }

        public string FileName { get; set; }
        public string FileType { get; set; }
        public string FilePath { get; set; }
        public string OriginalFileName { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ContentType { get; set; }
    }
}
