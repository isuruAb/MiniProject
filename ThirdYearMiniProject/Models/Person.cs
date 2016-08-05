namespace ThirdYearMiniProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Persons")]
    public partial class Person
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Person()
        {
            Mpsses = new HashSet<Mpss>();
            Rds = new HashSet<Rd>();
            Srs = new HashSet<Sr>();
        }

        public int PersonId { get; set; }

        public int LocationId { get; set; }

        [Required]
        [StringLength(50)]
        public string PersonName { get; set; }

        [Required]
        [StringLength(50)]
        public string PersonAddress { get; set; }

        [Required]
        [StringLength(50)]
        public string Occupid { get; set; }

        [Required]
        [StringLength(50)]
        public string Nic { get; set; }

        [Required]
        [StringLength(50)]
        public string Password { get; set; }

        public virtual Location Location { get; set; }

        public virtual Login Login { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Mpss> Mpsses { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Rd> Rds { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sr> Srs { get; set; }
    }
}
