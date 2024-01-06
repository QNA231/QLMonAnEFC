using QuanLyMonAnEFC.Entities;
using QuanLyMonAnEFC.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyMonAnEFC.Services
{
    public class LoaiMonAnServices : ILoaiMonAnServices
    {
        private readonly AppDbContext DbContext;

        public LoaiMonAnServices()
        {
            DbContext = new AppDbContext();
        }

        public void ThemLoaiMonAn(LoaiMonAn lma)
        {
            LoaiMonAn loai = new LoaiMonAn();
            loai.NhapThongTin();
            DbContext.Add(loai);
            DbContext.SaveChanges();
            Console.WriteLine("Them loai mon an thanh cong!");
        }
        public void XoaLoaiMonAn(int LoaiId)
        {
            if(DbContext.LoaiMonAn.Any(x => x.LoaiMonAnId == LoaiId))
            {
                var loaiCanXoa = DbContext.LoaiMonAn.Find(LoaiId);
                var mon = DbContext.MonAn.Find(LoaiId);
                var ct = DbContext.CongThuc.Find(LoaiId);
                DbContext.Remove(mon);
                DbContext.Remove(ct);
                DbContext.Remove(loaiCanXoa);
                DbContext.SaveChanges();
                Console.WriteLine("Xoa loai mon an thanh cong!");
            }
            Console.WriteLine("Loai mon an khong ton tai!");
        }
    }
}
