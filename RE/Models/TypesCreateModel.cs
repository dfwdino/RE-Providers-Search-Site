
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace RE.Models
{
	public class TypesCreateModel
	{

		public TypesCreateModel()
		{
			
		}

        [Required]
        [DisplayName("Type ID")]
        public int TypeID { get; set; }

        [Required]
        [DisplayName("Provider ID")]
        public int ProviderID { get; set; }

        [Required]
        [DisplayName("Hide")]
        public bool Hide { get; set; }

        public List<int> SelectedType { get; set; }

        public virtual ListOfType ListOfType { get; set; }
        public virtual Provider Provider { get; set; }

    }
}


