using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RE.Models
{
    public class JSONUsersViewModel
    {

        public int ID { get; set; }
        public string LoginName { get; set; }
        public bool Disable { get; set; }
        public string UserTypeName { get; set; }

    }
}