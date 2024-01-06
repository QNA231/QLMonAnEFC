using QuanLyMonAnEFC.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyMonAnEFC.IServices
{
    public interface INguyenLieuServices
    {
        void ThemNguyenLieu(NguyenLieu nl);
        void XoaNguyenLieu(int nlId);
        void TimKiemTheoNguyenLieu(string tenNguyenLieu);
    }
}
