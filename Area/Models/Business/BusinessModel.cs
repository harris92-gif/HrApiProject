using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HrApiProject.Area.Models
{
    [Table("tblbusiness")]
    public class BusinessModel
    {
        [Key]
        
        public Guid BusinessId {get; set;}
        public string BusinessName { get; set; }
        public string BusinessLogo { get; set; }

        public string BusinessDefaultCurrency { get; set; }
        [NotMapped]
        public List<BusinessAddressDetails> BusinessAddressDetails  { get; set; }
        [NotMapped]
        public List<BusinessContactDetails> BusinessContactDetails { get; set; }

        public string BusinessOwner { get; set; }

    }


    public class BusinessContactDetails
    {
        	public string Email{get; set;}
            public string Mobile{get; set;}

        
    }
    public class BusinessAddressDetails
    {
        public string Street {get; set;}
        public string City {get; set;}
        public string Country{get; set;}
    }
}