using ListKaryawanAPI.Models.Karyawan;
using ListKaryawanAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListKaryawanAPI.Contracts
{
    public interface IKaryawan
    {
        Task<(bool status, string error, List<LoadDataVM> data)> LoadDataAsync();
        Task<(bool status, string error)> UpdateAsync(UpdateVM req);
        Task<(bool status, string error)> DeleteAsync(string req);
        Task<(bool status, string error)> InsertAsync(DeleteVM req);
        Task<(bool status, string error, List<LoadDataVM> data)> ViewDataAsync();
        Task<(bool status, string error, LoadDataVM data)> ViewUpdateAsync(string nrp);
    }
}
