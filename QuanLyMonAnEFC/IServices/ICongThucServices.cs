using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyMonAnEFC.IServices
{
    public interface ICongThucServices
    {
        void ThemCongThuc(int monAnId, int nlId);
        void SuaCongThuc(int monAnId, int ctId);
        void XoaCongThuc(int monAnId, int ctId);
        string UpdateCachLam(string tenMonAn);
    }
}
