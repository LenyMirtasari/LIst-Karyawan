using ListKaryawanAPI.Models.Karyawan;
using ListKaryawanAPI.ViewModels;
using ListKaryawanAPP.Base.Controllers;
using ListKaryawanAPP.Repositories.Data;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;

namespace ListKaryawanAPP.Controllers
{
    public class KaryawanController : BaseController<TblTKaryawan, KaryawanRepository, int>
    {
        private readonly KaryawanRepository repository;
        public KaryawanController(KaryawanRepository repository) : base(repository)
        {
            this.repository = repository;
        }

        public IActionResult ListKaryawan()
        {
            return View();
        }

        public IActionResult Karyawan()
        {
            return View();
        }

        [HttpPost]
        public JsonResult InsertKaryawan(DeleteVM req)
        {
            var result = repository.InsertData(req);
            return Json(result);
        }

        [HttpDelete]
        public JsonResult DeleteData(DeleteVM req)
        {
            var result = repository.DeleteData(req);
            return Json(result);
        }

        [HttpGet]
        public async Task<JsonResult> ListKaryawans()
        {
            var result = await repository.KaryawanList();
            return Json(result);
        }

        [HttpGet]
        public async Task<JsonResult> DataKaryawan()
        {
            var result = await repository.DataKaryawan();
            return Json(result);
        }

        [HttpGet]

        public async Task<JsonResult> DataUpdate(DeleteVM req)
        {
            var result = await repository.UpdateId(req);
            return Json(result);
        }

        [HttpPut]
        public JsonResult UpdateData([FromBody] LoadDataVM req)
        {
            var result = repository.UpdateData(req);
            return Json(result);
        }






    }
}
