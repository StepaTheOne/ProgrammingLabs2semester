using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingLabs
{
    class Menu
    {
        public Menu Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new Menu();
                }
                return _Instance;
            }
        }
        private Menu _Instance;

        public void Show()
        {
            Console.WriteLine("Введите тип файла.");
            Console.WriteLine("1 - Excel");
            Console.WriteLine("2 - Txt.");
            Console.WriteLine("3 - Document");
            Console.WriteLine("4 - PDF");
            Console.WriteLine("5 - MS Word");
            Console.WriteLine("6 - HTML");

            String Case = Console.ReadLine();
            switch (Case)
            {
                case "1":
                    Console.WriteLine(Excel.GetInfo());
                    break;
                case "2":
                    Console.WriteLine(Txt.GetInfo());
                    break;
                case "3":
                    Console.WriteLine(Document.GetInfo());
                    break;
                case "4":
                    Console.WriteLine(Pdf.GetInfo());
                    break;
                case "5":
                    Console.WriteLine(MSword.GetInfo());
                    break;
                case "6":
                    Console.WriteLine(Html.GetInfo());
                    break;
                default:
                    Console.WriteLine("Ya tupaya mashina");
                    break;
            }
        }

        Document Document = new Document("Habr", "Leonid", "Programming", "Education", "www.habr.com");
        MSExcel Excel = new MSExcel("Table", "Tgnat", "Economy", "Table", "C:\\", 10, 10);
        TXT Txt = new TXT("Txt", "Blake", "LabaPoProge", "Education", "C:\\", "UTF-8");
        PDF Pdf = new PDF(170000, "Blake", "LabaPoProge", "Education", "C:\\", "UTF-8");
        MSWord MSword = new MSWord("Txt", "Blake", "LabaPoProge", "Education", "C:\\", "UTF-8");
        HTML Html = new HTML("HTML", "Ya", "EtoTag", "site", "Google server", "1.0");
    }
}
