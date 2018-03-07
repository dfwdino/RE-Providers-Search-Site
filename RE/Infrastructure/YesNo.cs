using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RE.Infrastructure
{
    public class CustiomDropDown
    {
       public string Text { get; set; }
       public string Value { get; set; }
    }


    public class YesNoUnknowenList
    {
        public virtual IEnumerable<CustiomDropDown> GetYesNoList(){

        return new List<CustiomDropDown> { new CustiomDropDown { Text = "--- Select ---", Value = "" },
                                                    new CustiomDropDown { Text = "Unknown", Value = "" },
                                                    new CustiomDropDown { Text = "Yes", Value = true.ToString() },
                                                    new CustiomDropDown { Text = "No", Value = false.ToString()}
                                                 };
        }


    }


}