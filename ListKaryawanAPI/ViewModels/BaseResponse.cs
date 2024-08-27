using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListKaryawanAPI.ViewModels
{
    public class BaseResponse<T>
    {
        public bool success { get; set; }
        public string message { get; set; }
        public T data { get; set; }
    }
    public class BaseResponseGridKendo<T>
    {
        public bool success { get; set; }
        public string message { get; set; }
        public List<T> Data { get; set; }
        public int Total { get; set; }
    }
    public class GridKendo<T>
    {
  
        public List<T> Data { get; set; }

    }


    public class ResponseKaryawan
    {
        public bool success { get; set; }
        public string message { get; set; }
    }

    public class responseRepo { 
        public int code { get; set; }
        public string msg { get; set; }

    }

    public class responseRepo<T> {
        public int code { get; set; }
        public string msg { get; set; }
        public T data { get; set; }
    }

    public class responseGridKendoRepo<T>
    {
        public int code { get; set; }
        public string msg { get; set; }
        public List<T> Data { get; set; }
    }

    public class crawler { 
        //public int Code { get; set; }
        //public string Captcha { get; set; }
        //public string Duration { get; set; }
        //public text Text { get; set; }
        //public capture Capture { get; set; }
        public person Person { get; set; }

    }

    public class person { 
        public string NIK { get; set; }
        public string NO_KK { get; set; }
        public string NAMA_LENGKAP { get; set; }
        public string TEMPAT_LAHIR { get; set; }
        public string TANGGAL_LAHIR { get; set; }
        public string JENIS_KELAMIN { get; set; }
        public string STATUS_KEL { get; set; }
        public string AGAMA { get; set; }
        public string STATUS_KAWIN { get; set; }
        public string PEND_AKHIR { get; set; }
        public string PEKERJAAN { get; set; }
        public string GOLONGAN_DARAH { get; set; }
        public string ALAMAT { get; set; }
        public string RT { get; set; }
        public string RW { get; set; }
        public string DUSUN { get; set; }
        public string KELURAHAN { get; set; }
        public string KECAMATAN { get; set; }
        public string KTMADYA_KAB { get; set; }
        public string PROVINSI { get; set; }
        public string KODE_POS { get; set; }
        public string NO_AKTA_LAHIR { get; set; }
        public string NO_AKTA_KAWIN { get; set; }
        public string TGL_KAWIN { get; set; }
        public string NO_AKTA_CERAI { get; set; }
        public string TGL_CERAI { get; set; }
        public string NIK_AYAH { get; set; }
        public string NAMA_AYAH { get; set; }
        public string NIK_IBU { get; set; }
        public string NAMA_IBU { get; set; }
        public string FOTO { get; set; }
    }
    public class capture {
        public string Captcha { get; set; }
        public string Before { get; set; }
        public string After { get; set; }
    }
    public class text { 
        public string Title { get; set; }
        public string Content { get; set; }
    }

    public class ResponseAuthRepo
    {
        public int code { get; set; }
        public string msg { get; set; }
        public string token { get; set; }
        public string refresh { get; set; }
    }

    public class ResponseAuth
    {
        public bool success { get; set; }
        public string message { get; set; }
        public string token { get; set; }
        public string refresh { get; set; }
    }

    public class BasePaginationResponse<T>
    {
        public bool success { get; set; }
        public string message { get; set; }
        public int count { get; set; }
        public T data { get; set; }
    }

    public class NavbarList { 
        public IEnumerable<Navbar> Data { get; set; }
    }

    public class Navbar { 
        public int Id { get; set; }
        public string Nama { get; set; }
    }
}
