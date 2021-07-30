namespace MovieReviewAPI.Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Members
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Members()
        {
            Roles = new HashSet<Roles>();
        }

        [Key]
        [StringLength(50)]
        public string Account { get; set; }

        [Required]
        [StringLength(100)]
        public string Passward { get; set; }

        [Required]
        [StringLength(20)]
        public string NickName { get; set; }

        public bool IsDelete { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Roles> Roles { get; set; }
    }
}
