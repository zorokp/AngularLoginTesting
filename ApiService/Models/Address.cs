using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiService.Models {
    public class Address {
        public virtual int Id { get; set; }
        [Required]
        public virtual string AddressLine1 { get; set; }
        public virtual string AddressLine2 { get; set; }
        [Required]
        public virtual string City { get; set; }
        [Required]
        public virtual string StateProvinceID { get; set; }
        [Required] 
        public virtual string PostalCode { get; set; }
        [Required] 
        public virtual string AddressType { get; set; }
    }
}
