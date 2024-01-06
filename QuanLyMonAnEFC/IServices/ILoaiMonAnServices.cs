using QuanLyMonAnEFC.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyMonAnEFC.IServices
{
    public interface ILoaiMonAnServices
    {
        void ThemLoaiMonAn(LoaiMonAn lma);
        void XoaLoaiMonAn(int LoaiId);
    }
}
