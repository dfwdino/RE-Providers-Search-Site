using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RE.Models
{
    public class ProviderCreateModel
    {
        public ProviderCreateModel()
        {
            Insurances = new List<Models.InsurancesCreateModel>();
            Services = new List<Models.ServicesCreateModel>();
            Types = new List<Models.TypesCreateModel>();
        }

        public int ID { get; set; }

        public string Name { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public Nullable<int> StateID { get; set; }
        
        public Nullable<double> Zip { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Website { get; set; }
        public Nullable<bool> SlidingScale { get; set; }
        public Nullable<bool> DiscountCashPay { get; set; }
        public bool Hide { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public string Notes { get; set; }
        public string IMGLocation { get; set; }

        public Nullable<int> GenderID { get; set; }
        public Nullable<int> NationalityID { get; set; }
        public Nullable<int> OwnerID { get; set; }

        [DataType(DataType.Upload)]
        public HttpPostedFileBase UploadedLocation { get; set; }

        public bool REVerified { get; set; }

        public virtual IList<Models.InsurancesCreateModel> Insurances { get; set; }
        public virtual IList<Models.ServicesCreateModel> Services { get; set; }
        public virtual IList<Models.TypesCreateModel> Types { get; set; }
        public virtual State State { get; set; }
        public virtual ListOfGender Gender { get; set; }
        public virtual ListOfNationality Nationality { get; set; }
        public virtual RE.User Owner { get; set; }

        //public IList<Provider> Providers { get; set; }

    }
}