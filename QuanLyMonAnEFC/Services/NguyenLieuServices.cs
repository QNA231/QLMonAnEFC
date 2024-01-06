using QuanLyMonAnEFC.Entities;
using QuanLyMonAnEFC.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyMonAnEFC.Services
{
    public class NguyenLieuServices : INguyenLieuServices
    {
        private readonly AppDbContext DbContext;

        public NguyenLieuServices()
        {
            DbContext = new AppDbContext();
        }
        public void ThemNguyenLieu(NguyenLieu nl)
        {
            nl.NhapThongTIn();
            DbContext.Add(nl);
            DbContext.SaveChanges();
            Console.WriteLine("Them nguyen lieu thanh cong!");
        }

        public void XoaNguyenLieu(int nlId)
        {
            if (DbContext.NguyenLieu.Any(x => x.NguyenLieuId == nlId))
            {
                var nguyenLieucanXoa = DbContext.NguyenLieu.Find(nlId);
                DbContext.Remove(nguyenLieucanXoa);
                DbContext.SaveChanges();
                Console.WriteLine("Xoa nguyen lieu thanh cong!");
            }
            else
            {
                Console.WriteLine("Nguyen lieu khong ton tai!");
            }
        }

        public void TimKiemTheoNguyenLieu(string tenNguyenLieu)
        {
            var tenMonAn = DbContext.MonAn
                .Join(DbContext.CongThuc, ma => ma.MonAnId, ct => ct.MonAnId, (ma, ct) => new { MonAn = ma, CongThuc = ct })
                .Join(DbContext.NguyenLieu, ct => ct.CongThuc.NguyenLieuId, nl => nl.NguyenLieuId, (ct, nl) => new { CongThuc = ct, NguyenLieu = nl })
                .Where(x => x.NguyenLieu.TenNguyenLieu.ToLower() == tenNguyenLieu.ToLower())
                .Select(x => x.CongThuc.MonAn.TenMon).ToList();
            if (tenMonAn.Count > 0)
            {
                Console.WriteLine($"Mon an co chua nguyen lieu {tenNguyenLieu} la: ");
                foreach(var t in tenMonAn)
                {
                    Console.WriteLine(t);
                }
            }
            else
            {
                Console.WriteLine("Khong tim thay mon an!");
            }
        }
    }
}
