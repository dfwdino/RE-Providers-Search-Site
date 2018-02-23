
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace RE.Models
{
	public class ServicesCreateModel	{

		public ServicesCreateModel()
		{
			
		}

        [Required]
        [DisplayName("Provider ID")]
        public int ProviderID { get; set; }

        [Required]
        [DisplayName("Service ID")]
        public int ServiceID { get; set; }

        [Required]
        [DisplayName("Hide")]
        public int Hide { get; set; }

        public List<int> SelectedService { get; set; }

        public virtual ListOfService ListOfService { get; set; }
        public virtual Provider Provider { get; set; }

    }
}


