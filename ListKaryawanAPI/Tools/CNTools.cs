using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListKaryawanAPI.Tools
{
    public class CNTools
    {
        public Tuple<bool, string> isRoleAccessExist(int RoleId)
        {
            bool status = false;
            string message = "User tidak memiliki kewenangan!";
            if (RoleId.ToString() == GetConfig.AppSetting["Role:Administrator"] || RoleId.ToString() == GetConfig.AppSetting["Role:InputerNotaris"] || RoleId.ToString() == GetConfig.AppSetting["Role:CheckerNotaris"]
                || RoleId.ToString() == GetConfig.AppSetting["Role:ApproverNotaris"])
            {
                status = true;
                message = "";
            }

            return new Tuple<bool, string>(status, message);
        }
    }
}
