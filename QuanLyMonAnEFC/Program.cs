using QuanLyMonAnEFC.Entities;
using QuanLyMonAnEFC.IServices;
using QuanLyMonAnEFC.Services;

static void Main()
{
    Console.InputEncoding = System.Text.Encoding.UTF8;
    Console.OutputEncoding = System.Text.Encoding.UTF8;
    ILoaiMonAnServices loaiMonAnServices = new LoaiMonAnServices();
    IMonAnServices monAnServices = new MonAnServices();
    INguyenLieuServices nguyenLieuServices = new NguyenLieuServices();
    ICongThucServices congThucServices = new CongThucServices();
    Console.Clear();
    Console.WriteLine("------------Quan ly mon an------------");
    Console.WriteLine("1. Them loai mon an");
    Console.WriteLine("2. Them mon an");
    Console.WriteLine("3. Them nguyen lieu");
    Console.WriteLine("4. Them cong thuc");
    Console.WriteLine("5. Sua mon an");
    Console.WriteLine("6. Sua cong thuc");
    Console.WriteLine("7. Xoa loai mon an");
    Console.WriteLine("8. Xoa mon an");
    Console.WriteLine("9. Xoa nguyen lieu");
    Console.WriteLine("10. Xoa cong thuc");
    Console.WriteLine("11. Tim kiem mon an theo ten");
    Console.WriteLine("12. Tim kiem mon an theo ten nguyen lieu");
    Console.WriteLine("----------------------------------------");
    Console.WriteLine("Chon: ");
    Console.WriteLine();
    string c = Console.ReadLine();
    switch (c)
    {
        case "1":
            LoaiMonAn loai = new LoaiMonAn();
            loaiMonAnServices.ThemLoaiMonAn(loai);
            break;
        case "2":
            Console.WriteLine("Nhap Id loai mon an can them mon an: ");
            int loaiId = int.Parse(Console.ReadLine());
            monAnServices.ThemMonAn(loaiId);
            
            break;
        case "3":
            NguyenLieu nl = new NguyenLieu();
            nguyenLieuServices.ThemNguyenLieu(nl);
            break;
        case "4":
            Console.WriteLine("Nhap Id mon an can them cong thuc: ");
            int monId = int.Parse(Console.ReadLine());
            Console.WriteLine("Nhap Id nguyen lieu se them vao cong thuc: ");
            int nlId = int.Parse(Console.ReadLine());
            congThucServices.ThemCongThuc(monId, nlId);
            break;
        case "5":
            Console.WriteLine("Nhap Id mon an can sua: ");
            int maId = int.Parse(Console.ReadLine());
            monAnServices.SuaMonAn(maId);
            break;
        case "6":
            Console.WriteLine("Nhap Id mon an can sua cong thuc: ");
            int moID = int.Parse(Console.ReadLine());
            Console.WriteLine("Nhap Id cong thuc can sua: ");
            int ctId = int.Parse(Console.ReadLine());
            congThucServices.SuaCongThuc(moID , ctId);
            break;
        case "7":
            Console.WriteLine("Nhap Id loai mon an can xoa: ");
            int loaiID = int.Parse(Console.ReadLine());
            loaiMonAnServices.XoaLoaiMonAn(loaiID);
            break;
        case "8":
            Console.WriteLine("Nhap Id mon an can xoa: ");
            int monAnId = int.Parse(Console.ReadLine());
            monAnServices.XoaMonAn(monAnId);
            break;
        case "9":
            Console.WriteLine("Nhap Id nguyen lieu can xoa: ");
            int nlID = int.Parse(Console.ReadLine());
            nguyenLieuServices.XoaNguyenLieu(nlID);
            break;
        case "10":
            Console.WriteLine("Nhap Id mon an can xoa cong thuc: ");
            int mID = int.Parse(Console.ReadLine());
            Console.WriteLine("Nhap Id cong thuc can xoa: ");
            int ctID = int.Parse(Console.ReadLine());
            congThucServices.XoaCongThuc(mID, ctID);
            break;
        case "11":
            Console.WriteLine("Nhap ten mon an can tim: ");
            string ten = Console.ReadLine();
            monAnServices.TimKiemTheoTen(ten);
            break;
        case "12":
            Console.WriteLine("Nhap ten nguyen lieu cua mon an can tim: ");
            string tennl = Console.ReadLine();
            nguyenLieuServices.TimKiemTheoNguyenLieu(tennl);
            break;
    }
}
Main();