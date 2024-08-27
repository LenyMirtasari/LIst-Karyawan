using System;
using System.Collections.Generic;

namespace ListKaryawanAPI.Models.Karyawan;

public partial class VwMBiodatum
{
    public string Nrp { get; set; } = null!;

    public string? Nama { get; set; }

    public string? Telepon { get; set; }

    public string? Email { get; set; }
}
