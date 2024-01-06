using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyMonAnEFC.IServices
{
    public interface IMonAnServices
    {
        void ThemMonAn(int LoaiMonAnId);
        void SuaMonAn(int MonAnId);
        void XoaMonAn(int MonAnId);
        void TimKiemTheoTen(string tenCanTim);
    }
}
