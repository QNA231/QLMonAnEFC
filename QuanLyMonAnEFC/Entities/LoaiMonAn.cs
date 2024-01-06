using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyMonAnEFC.Entities
{
    public class LoaiMonAn
    {
        public int LoaiMonAnId { get; set; }
        [Required]
        [MaxLength(20)]
        public string TenLoai { get; set; }
        public string MoTa { get; set; }
        public IEnumerable<MonAn> MonAn { get; set; }
        public void NhapThongTin()
        {
            LoaiMonAnId = 0;
            Console.WriteLine("Nhap ten loai: ");
            TenLoai = Console.ReadLine();
            Console.WriteLine("Nhap mo ta: ");
            MoTa = Console.ReadLine();
        }
    }
}
