using QuanLyMonAnEFC.Entities;
using QuanLyMonAnEFC.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyMonAnEFC.Services
{
    public class MonAnServices : IMonAnServices
    {
        private readonly AppDbContext DbContext;

        public MonAnServices()
        {
            DbContext = new AppDbContext();
        }
        public void SuaMonAn(int MonAnId)
        {
            if (DbContext.MonAn.Any(x => x.MonAnId == MonAnId))
            {
                var monAnCanSua = DbContext.MonAn.Find(MonAnId);
                Console.WriteLine("Nhap ten mon an: ");
                monAnCanSua.TenMon = Console.ReadLine();
                Console.WriteLine("Nhap gia ban: ");
                monAnCanSua.GiaBan = double.Parse(Console.ReadLine());
                DbContext.Update(monAnCanSua);
                DbContext.SaveChanges();
                Console.WriteLine("Sua mon an thanh cong!");
            }
            else
            {
                Console.WriteLine("Khong ton  tai mon an!");
            }
        }

        public void ThemMonAn(int LoaiMonAnId)
        {
            MonAn mo = new MonAn();
            LoaiMonAn loai = DbContext.LoaiMonAn.FirstOrDefault(x => x.LoaiMonAnId == LoaiMonAnId);
            if(loai != null)
            {
                var monAnCanThem = DbContext.MonAn.Find(LoaiMonAnId);
                mo.NhapThongTIn(LoaiMonAnId);
                DbContext.Add(mo);
                DbContext.SaveChanges();
                Console.WriteLine("Them mon an thanh cong!");
            }
            else
            {
                Console.WriteLine("Them mon an that bai!");
            }
        }

        public void XoaMonAn(int MonAnId)
        {
            if(DbContext.MonAn.Any(x => x.MonAnId == MonAnId))
            {
                var monAnCanXoa = DbContext.MonAn.Find(MonAnId);
                var ct = DbContext.CongThuc.Find(MonAnId);
                if(ct != null)
                {
                    DbContext.Remove(ct);
                    DbContext.Remove(monAnCanXoa);
                    DbContext.SaveChanges();
                }
                else
                {
                    DbContext.Remove(monAnCanXoa);
                    DbContext.SaveChanges();
                }
                Console.WriteLine("Xoa mon an thanh cong!");
            }
            else
            {
                Console.WriteLine("Khong ton  tai mon an!");
            }
        }

        public void TimKiemTheoTen(string tenNhapVao)
        {
            var TenCanTim = DbContext.MonAn
                .Where(x => x.TenMon.ToLower() == tenNhapVao.ToLower())
                .Select(x => x.TenMon).ToList();
            if(TenCanTim.Count > 0)
            {
                Console.WriteLine("Mon can tim la: ");
                foreach(var t in TenCanTim)
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
