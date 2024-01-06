using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyMonAnEFC.Entities
{
    public class NguyenLieu
    {
        public int NguyenLieuId { get; set; }
        [Required]
        [MaxLength(20)]
        public string TenNguyenLieu { get; set; }
        public string GhiChu { get; set; }
        public void NhapThongTIn()
        {
            Console.WriteLine("Nhap ten nguyen lieu: ");
            TenNguyenLieu = Console.ReadLine();
            Console.WriteLine("Nhap ghi chu: ");
            GhiChu = Console.ReadLine();
        }
    }
}
