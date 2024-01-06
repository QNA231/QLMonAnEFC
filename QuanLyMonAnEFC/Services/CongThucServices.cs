using QuanLyMonAnEFC.Entities;
using QuanLyMonAnEFC.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyMonAnEFC.Services
{
    public class CongThucServices : ICongThucServices
    {
        private readonly AppDbContext DbContext;

        public CongThucServices()
        {
            DbContext = new AppDbContext();
        }
        public void SuaCongThuc(int monAnId, int ctId)
        {
            if (DbContext.MonAn.Any(x => x.MonAnId == monAnId))
            {
                if (DbContext.CongThuc.Any(x => x.CongThucId == ctId))
                {
                    var congThucCanSua = DbContext.CongThuc.Find(ctId);
                    DbContext.Update(congThucCanSua);
                    DbContext.SaveChanges();
                    Console.WriteLine("Sua cong thuc thanh cong!");
                }
            }
            else
            {
                Console.WriteLine("Khong ton tai cong thuc!");
            }
        }

        public void ThemCongThuc(int monAnId, int nlId)
        {
            CongThuc ct = new CongThuc();
            MonAn mo = DbContext.MonAn.FirstOrDefault(x => x.MonAnId == monAnId);
            NguyenLieu nl = DbContext.NguyenLieu.FirstOrDefault(x => x.NguyenLieuId == nlId);
            if (mo != null)
            {
                ct.NhapThongTIn(mo.MonAnId, nl.NguyenLieuId);
                DbContext.Add(ct);
                DbContext.SaveChanges();
                mo.CachLam = UpdateCachLam(mo.TenMon);
                //mo.CachLam += ct.NguyenLieu.TenNguyenLieu + " " + ct.SoLuong + " " + ct.DonViTinh;
                DbContext.MonAn.Update(mo);
                DbContext.SaveChanges();
                Console.WriteLine("Them cong thuc cho mon an thanh cong!");
            }
            else
            {
                Console.WriteLine("Mon an khong ton tai!");
            }
        }

        public void XoaCongThuc(int monAnId, int ctId)
        {
            if (DbContext.MonAn.Any(x => x.MonAnId == monAnId))
            {
                if (DbContext.CongThuc.Any(x => x.CongThucId == ctId))
                {
                    var congThucCanXoa = DbContext.CongThuc.Find(ctId);
                    DbContext.Remove(congThucCanXoa);
                    DbContext.SaveChanges();
                    Console.WriteLine("Xoa cong thuc thanh cong!");
                }
            }
            else
            {
                Console.WriteLine("Khong ton tai cong thuc!");
            }
        }
        public string UpdateCachLam(string tenMonAn)
        {
            var cachLam = DbContext.MonAn
                .Join(DbContext.CongThuc, ma => ma.MonAnId, ct => ct.MonAnId, (ma, ct) => new { MonAn = ma, CongThuc = ct })
                .Join(DbContext.NguyenLieu, ct => ct.CongThuc.NguyenLieuId, nl => nl.NguyenLieuId, (ct, nl) => new { CongThuc = ct, NguyenLieu = nl })
                .Where(x => x.CongThuc.MonAn.TenMon.ToLower() == tenMonAn.ToLower())
                .Select(x => new {x.NguyenLieu.TenNguyenLieu, x.CongThuc.CongThuc.SoLuong, x.CongThuc.CongThuc.DonViTinh}).ToList();
            if(cachLam.Count >= 0)
            {
                string result = "";
                foreach(var cach in cachLam)
                {
                    result += $"{cach.TenNguyenLieu} : {cach.SoLuong} {cach.DonViTinh} \t";
                }
                return result;
            }
            else
            {
                return "Mon an chua co cach lam!!";
            }
        }
    }
}
