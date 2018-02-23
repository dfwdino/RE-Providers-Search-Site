
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace RE.Models
{
	public class InsurancesCreateModel
	{

		public InsurancesCreateModel()
		{
			
		}

        [Required]
        [DisplayName("Insureance ID")]
        public int InsureanceID { get; set; }

        [Required]
        [DisplayName("Provider ID")]
        public int ProviderID { get; set; }

        [Required]
        [DisplayName("Hide")]
        public bool Hide { get; set; }

        public List<int> SelectedInsurance { get; set; }

        public virtual ListOfInsuranceCompany ListOfInsuranceCompany { get; set; }
        public virtual Provider Provider { get; set; }

    }
}


