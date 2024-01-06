using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyMonAnEFC.Entities
{
    public class CongThuc
    {
        public int CongThucId { get; set; }
        public int NguyenLieuId { get; set; }
        public int MonAnId { get; set; }
        public int SoLuong { get; set; }
        public string DonViTinh { get; set; }
        public MonAn MonAn { get; set; }
        public NguyenLieu NguyenLieu { get; set; }
        public void NhapThongTIn(int monAnId, int nlId)
        {
            CongThucId = 0;
            NguyenLieuId = nlId;
            MonAnId = monAnId;
            Console.WriteLine("Nhap so luong: ");
            SoLuong = int.Parse(Console.ReadLine());
            Console.WriteLine("Nhap don vi tinh: ");
            DonViTinh = Console.ReadLine();
        }
    }
}
