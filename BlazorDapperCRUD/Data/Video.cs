using System;
using System.ComponentModel.DataAnnotations;

namespace BlazorDapperCRUD.Data
{
    public class Video
    {
        public int VideoId { get; set; }

        public string Title { get; set; } = string.Empty;

        public DateTime DatePublished { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime LastUpdatedDate { get; set; }

        public string CreatedBy { get; set; } = string.Empty;

        public string LastUpdatedBy { get; set; } = string.Empty;
    }
}
