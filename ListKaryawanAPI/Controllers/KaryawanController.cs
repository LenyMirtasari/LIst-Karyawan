using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ListKaryawanAPI.Contracts;
using ListKaryawanAPI.Tools;
using ListKaryawanAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ListKaryawanAPI.Models.Karyawan;
using Newtonsoft.Json;
using Azure;

namespace ListKaryawanAPI.Controllers
{
    
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class KaryawanController : ControllerBase
    {
        public readonly IKaryawan _repo;
        public KaryawanController(IKaryawan repo)
        {
            _repo = repo;
        }

        #region LOADDATA
        //[DisableCors]
        [HttpGet]
        public async Task<IActionResult> GetData()
        {
            var res = new GridKendo<LoadDataVM>();
            
                var _ = await _repo.LoadDataAsync();
                res.Data = _.data;
                return new OkObjectResult(res.Data);

        }
        #endregion

        #region LOAD SELECTED DATA
        //[DisableCors]
        [HttpGet]
        public async Task<IActionResult> DataKaryawan()
        {
            var res = new GridKendo<LoadDataVM>();
            var _ = await _repo.ViewDataAsync();
            res.Data = _.data;
            return new OkObjectResult(res.Data);

        }
        #endregion

        #region VIEW UPDATE
        //[DisableCors]
        [Route("{req}")]
        [HttpGet]
        public async Task<IActionResult> ViewUpdate(string req)
        {
            var res = new LoadDataVM();

            var _ = await _repo.ViewUpdateAsync(req);
            res = _.data;
            return new OkObjectResult(res);

        }
        #endregion

        #region UPDATE
        //[DisableCors]
        [HttpPut]
        public async Task<IActionResult> UpdateData(UpdateVM req)
        {
            var res = new ResponseKaryawan();
            try
            {
                var _ = await _repo.UpdateAsync(req);

                if (!_.status)
                {
                    res.success = false;
                    res.message = _.error;
                ;

                }
                else
                {
                    res.success = true;
                    res.message = "sukses";
           

                }
                return new OkObjectResult(res);
            }
            catch (Exception ex)
            {
                res.success = false;
                res.message = ex.Message == null ? ex.InnerException.ToString() : ex.Message.ToString();
                return new OkObjectResult(res);
            }


        }
        #endregion

        #region DELETE
        //[DisableCors]
        [Route("{req}")]
        [HttpDelete]
        public async Task<IActionResult> deleteData(string req)
        {
            var res = new ResponseKaryawan();
            try
            {
                var _ = await _repo.DeleteAsync(req);

                if (!_.status)
                {
                    res.success = false;
                    res.message = _.error;
                    ;

                }
                else
                {
                    res.success = true;
                    res.message = "sukses";


                }
                return new OkObjectResult(res);
            }
            catch (Exception ex)
            {
                res.success = false;
                res.message = ex.Message == null ? ex.InnerException.ToString() : ex.Message.ToString();
                return new OkObjectResult(res);
            }


        }
        #endregion

        #region INSERT
        //[DisableCors]
        [HttpPost]
        public async Task<IActionResult> InsertData(DeleteVM req)
        {
            var res = new ResponseKaryawan();
            try
            {
                var _ = await _repo.InsertAsync(req);

                if (!_.status)
                {
                    res.success = false;
                    res.message = _.error;
                    ;

                }
                else
                {
                    res.success = true;
                    res.message = "sukses";


                }
                return new OkObjectResult(res);
            }
            catch (Exception ex)
            {
                res.success = false;
                res.message = ex.Message == null ? ex.InnerException.ToString() : ex.Message.ToString();
                return new OkObjectResult(res);
            }


        }
        #endregion
    }
}
