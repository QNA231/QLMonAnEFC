using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyMonAnEFC.Entities
{
    public class MonAn
    {
        public int MonAnId { get; set; }
        [Required]
        [MaxLength(20)]
        public string TenMon { get; set; }
        public double GiaBan { get; set; }
        public string GioiThieu { get; set; }
        [Required]
        public string CachLam { get; set; }
        public int LoaiMonAnId { get; set; }
        public LoaiMonAn LoaiMonAn { get; set; }
        public void NhapThongTIn(int LoaiMAId)
        {
            MonAnId = 0;
            Console.WriteLine("Nhap ten mon: ");
            TenMon = Console.ReadLine();
            Console.WriteLine("Nhap gia ban: ");
            GiaBan = double.Parse(Console.ReadLine());
            Console.WriteLine("Nhap gioi thieu: ");
            GioiThieu = Console.ReadLine();
            Console.WriteLine("Nhap cach lam: ");
            CachLam = Console.ReadLine();
            LoaiMonAnId = LoaiMAId;
        }
    }
}
