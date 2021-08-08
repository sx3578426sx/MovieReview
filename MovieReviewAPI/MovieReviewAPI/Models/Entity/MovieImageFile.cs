namespace MovieReviewAPI.Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MovieImageFile")]
    public partial class MovieImageFile
    {
        [Key]
        public Guid MovieId { get; set; }

        public Guid? FileId { get; set; }

        public byte[] ImageFile { get; set; }

        [StringLength(50)]
        public string ImageFileName { get; set; }

        [StringLength(50)]
        public string FileType { get; set; }

        public virtual Movies Movies { get; set; }
    }
}
