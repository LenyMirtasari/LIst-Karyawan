using System;
using System.Collections.Generic;

namespace ListKaryawanAPI.Models.Karyawan;

public partial class TblTKaryawan
{
    public string Nrp { get; set; } = null!;

    public string? Nama { get; set; }

    public string? NoTlp { get; set; }

    public string? Email { get; set; }
}
