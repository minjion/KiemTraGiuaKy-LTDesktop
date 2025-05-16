using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Desktop_GiuaKi
{
    internal static class Program
    {
        public class NhanVien
        {
            public string MaSo { get; set; }
            public string HoTen { get; set; }
            public DateTime NgaySinh { get; set; }
            public string email { get; set; }
        }

        static List<NhanVien> danhSachNV = new List<NhanVien>();
        private static IEnumerable<string> lines;
        private static object lvNhanVien;
        private static object txtMaSo;
        private static object txtHoTen;
        private static object txtEmail;
        private static readonly object dtpNgaySinh;

  

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
