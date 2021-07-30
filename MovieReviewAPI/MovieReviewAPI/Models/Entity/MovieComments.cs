namespace MovieReviewAPI.Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MovieComments
    {
        public long Id { get; set; }

        public Guid MovieId { get; set; }

        [StringLength(50)]
        public string Account { get; set; }

        [Required]
        [StringLength(50)]
        public string ReviewMessage { get; set; }

        public double ReviewScore { get; set; }

        public DateTime CreateTime { get; set; }

        public virtual Movies Movies { get; set; }
    }
}
