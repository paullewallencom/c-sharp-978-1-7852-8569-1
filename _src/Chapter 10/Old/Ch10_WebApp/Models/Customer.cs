namespace Ch10_WebApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Customer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Customer()
        {
            Orders = new HashSet<Order>();
            CustomerDemographics = new HashSet<CustomerDemographic>();
        }

        [StringLength(5)]
        [Display(Name = "Customer ID")]
        public string CustomerID { get; set; }

        [Required]
        [StringLength(40)]
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }

        [StringLength(30)]
        [Display(Name = "Contact Name")]
        public string ContactName { get; set; }

        [StringLength(30)]
        [Display(Name = "Title")]
        public string ContactTitle { get; set; }

        [StringLength(60)]
        public string Address { get; set; }

        [StringLength(15)]
        public string City { get; set; }

        [StringLength(15)]
        public string Region { get; set; }

        [StringLength(10)]
        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; }

        [StringLength(15)]
        public string Country { get; set; }

        [StringLength(24)]
        public string Phone { get; set; }

        [StringLength(24)]
        public string Fax { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CustomerDemographic> CustomerDemographics { get; set; }
    }
}
