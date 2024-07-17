using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace SixEyeCinema1._3.Views.Home
{
  
    [BindableType]
        public class Booking 
        {


            public string Uname { get; set; }
            [Required]
            [EmailAddress]
            public string UserEmail { get; set; }
            //  public char phone[11] { get; set; }
            public DateTime dob { get; set; }
            public string tId { get; set; }
            public string scid { get; set; }
            public int tick { get; set; }

            public string Mname { get; set; }

            public string ErrorMessage { get; set; }

            //public void OnGet(string text)
            //{
            //    if (text != null)
            //    {
            //        TempData["Mname"] = text;
            //        Mname = text;
            //    }
            //    else
            //    {
            //        if (TempData.TryGetValue("Mname", out Object value))
            //        {
            //            Mname = value.ToString();
            //        }
            //        //else
            //        //{
            //        //    Mname = "Kung Fu Panda";
            //        //}

            //    }
            //}

            //public void setIt()
            //{

            //    if (TempData.TryGetValue("Mname", out Object value))
            //    {
            //        //if(value!=null)
            //        Mname = value.ToString();
            //    }
            //}



            //public IActionResult OnPost()
            //{
            //    TempData["Mname"] = TempData["Mname"];

            //    return Page();
            //}


        }


}