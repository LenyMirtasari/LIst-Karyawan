using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ListKaryawanAPI.Contracts;
using ListKaryawanAPI.Tools;
using ListKaryawanAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using ListKaryawanAPI.Models.Karyawan;
using Newtonsoft.Json;
using System.Xml.Linq;
using System.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ListKaryawanAPI.Repositories
{
    public class KaryawanRepo : IKaryawan
    {
        private readonly DbIctLearningKptContext _context;
        private readonly IHttpContextAccessor _httpContext;

        public KaryawanRepo(DbIctLearningKptContext context, IHttpContextAccessor httpContext)
        {
            _context = context;
            _httpContext = httpContext;

        }

       


        #region VIEW KARYAWAN
        public async Task<(bool status, string error, List<LoadDataVM> data)> LoadDataAsync()
        {
           
        
            var data = new responseGridKendoRepo<LoadDataVM>();
            try
            {

                var list = await _context.VwListKaryawans.ToListAsync();
                var karyawan = new List<LoadDataVM>();
                if (list.Count>0)
                {
                    foreach (var item in list)
                    {
                        var _ = new LoadDataVM();
                        _.NRP = item.Nrp;
                        _.NAMA = item.Nama;
                        _.NO_TLP = item.NoTlp;
                        _.EMAIL = item.Email;
                        karyawan.Add(_);
                    }
                }
                

                if (list == null)
                {
                    return (true, "", new List<LoadDataVM>());
                }


                return (true, "", karyawan);
            }
            catch (Exception ex)
            {
               
                return (false, ex.Message.ToString(), new List<LoadDataVM>());
            }

        }

        #endregion

        #region VIEW SELECTED KARYAWAN
        public async Task<(bool status, string error, List<LoadDataVM> data)> ViewDataAsync()
        {


            var data = new responseGridKendoRepo<LoadDataVM>();
            try
            {

                var list = await _context.TblTKaryawans.ToListAsync();
                var karyawan = new List<LoadDataVM>();
                if (list.Count > 0)
                {
                    foreach (var item in list)
                    {
                        var _ = new LoadDataVM();
                        _.NRP = item.Nrp;
                        _.NAMA = item.Nama;
                        _.NO_TLP = item.NoTlp;
                        _.EMAIL = item.Email;
                        karyawan.Add(_);
                    }
                }


                if (list == null)
                {
                    return (true, "", new List<LoadDataVM>());
                }


                return (true, "", karyawan);
            }
            catch (Exception ex)
            {

                return (false, ex.Message.ToString(), new List<LoadDataVM>());
            }

        }

        #endregion

        #region VIEW UPDATE
        public async Task<(bool status, string error, LoadDataVM data)> ViewUpdateAsync(string nrp)
        {


            var data = new responseGridKendoRepo<LoadDataVM>();
            try
            {

                var list = await _context.TblTKaryawans.Where(x=> x.Nrp==nrp).FirstOrDefaultAsync();
                var _ = new LoadDataVM();
                if (list !=null)
                {
                  
                        _.NRP = list.Nrp;
                        _.NAMA = list.Nama;
                        _.NO_TLP = list.NoTlp;
                        _.EMAIL = list.Email;
            
                    
                }


                if (list == null)
                {
                    return (true, "", null);
                }


                return (true, "", _);
            }
            catch (Exception ex)
            {

                return (false, ex.Message.ToString(), null);
            }

        }

        #endregion

        #region UPDATE
        public async Task<(bool status, string error)> UpdateAsync(UpdateVM req)
        {

            try
            {
               
                SPKaryawan("[cusp_updateKaryawan]", new SqlParameter[]{
                new SqlParameter("@NRP", req.NRP),
                new SqlParameter("@Nama", req.NAMA),
                new SqlParameter("@NoTelp", req.NO_TLP),
                new SqlParameter("@Email", req.EMAIL)
                });
               
                return (true, "");

            }
            catch (Exception ex)
            {

                return (false, ex.Message.ToString());
            }
        }
        #endregion

        #region DELETE
        public async Task<(bool status, string error)> DeleteAsync(string req)
        {

            try
            {

                SPKaryawan("[cusp_deleteKaryawan]", new SqlParameter[]{
                  new SqlParameter("@NRP", req)
                  });

      

                return (true, "");

            }
            catch (Exception ex)
            {

                return (false, ex.Message.ToString());
            }
        }
        #endregion

        #region INSERT
        public async Task<(bool status, string error)> InsertAsync(DeleteVM req)
        {
            try
            {
                var _ = await _context.VwListKaryawans.Where(x => x.Nrp == req.NRP).FirstOrDefaultAsync();
                var data = await _context.TblTKaryawans.Where(x => x.Nrp == _.Nrp).FirstOrDefaultAsync();
                if (data != null)
                {
                    return (true, "Nrp no " + data.Nrp + " sudah ada");
                }
                TblTKaryawan insert = new TblTKaryawan();
                insert.Nrp = _.Nrp;
                insert.Nama = _.Nama;
                insert.NoTlp = _.NoTlp;
                insert.Email = _.Email;
                await _context.AddAsync(insert);
                await _context.SaveChangesAsync();
                return (true, "");

            }
            catch (Exception ex)
            {

                return (false, ex.Message.ToString());
            }
            
          
        }
        #endregion

        protected void SPKaryawan(string storedProcedureName, SqlParameter[] parameters)
        {
            var command = _context.Database.GetDbConnection().CreateCommand();

            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = storedProcedureName;
            command.Parameters.AddRange(parameters);
            _context.Database.OpenConnection();

            try
            {
                 command.ExecuteScalar();
            }
            catch (Exception)
            {
                _context.Database.CloseConnection();
                throw;
            }

            _context.Database.CloseConnection();
        }


    }
}
