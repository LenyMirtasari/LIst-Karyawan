using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ListKaryawanAPI.ViewModels
{
    public class LoadDataVM
    {
        public string NRP    { get; set; }
        public string NAMA { get; set; }
        public string NO_TLP { get; set; }
        public string EMAIL { get; set; }
       
    }

    public class UpdateVM
    {
        public string NRP { get; set; }
        public string NAMA { get; set; }
        public string NO_TLP { get; set; }
        public string EMAIL { get; set; }

    }

    public class DeleteVM
    {
        public string NRP { get; set; }

    }

    public class InsertVM
    {
        public List<DeleteVM> NRP { get; set; }

    }

    public class RegisterVM
    {
        [Required(ErrorMessage = "Please enter your name")]
        public string Nama { get; set; }

        [Required(ErrorMessage = "Please enter your address")]
        public string Alamat { get; set; }

        [Required(ErrorMessage = "Please enter your phone number")]
        public string NoTelp { get; set; }
    }


}
