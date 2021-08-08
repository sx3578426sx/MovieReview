namespace MovieReviewAPI.Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Movies
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Movies()
        {
            MovieComments = new HashSet<MovieComments>();
        }

        public Guid Id { get; set; }

        [Required]
        [StringLength(50)]
        public string MovieName { get; set; }

        [StringLength(200)]
        public string Category { get; set; }

        [MaxLength]
        public string MovieDescription { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ReleaseDate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MovieComments> MovieComments { get; set; }

        public virtual MovieImageFile MovieImageFile { get; set; }
    }
}
