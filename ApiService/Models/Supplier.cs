using ApiService.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiService.Models {
    public class Supplier : ILoadentEntity {
        public virtual int Id { get; set; }
        [Required]
        public virtual string Name { get; set; }
        public virtual int AddressId { get; set; }
        [Required]
        public virtual Address Address { get; set; }
    }
}
