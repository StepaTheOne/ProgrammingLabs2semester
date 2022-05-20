using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class Menu
    {
        private Menu _Instance;
        public Menu Instance
        {
            get
            {
                if(_Instance == null)
                {
                    _Instance = new Menu();
                    return _Instance;
                }
                else
                {
                    return null;
                }
            }
        }

        public void ShowMenu()
        {
            Console.WriteLine("Доступные документы:");
            Console.WriteLine("1 - MSWord");
            Console.WriteLine("2 - PDF");
            Console.WriteLine("3 - MSExcel");
            Console.WriteLine("4 - Txt");
            Console.WriteLine("5 - HTML");
            Console.Write("Выберите документ:");

            string choice = Console.ReadLine();
            
            switch (choice)
            {
                case "1":
                    Console.WriteLine(word.Info());
                    break;
                case "2":
                    Console.WriteLine(pdf.Info());
                    break;
                case "3":
                    Console.WriteLine(excel.Info());
                    break;
                case "4":
                    Console.WriteLine(txt.Info());
                    break;
                case "5":
                    Console.WriteLine(html.Info());
                    break;
                default:
                    Console.WriteLine($"Варианта {choice} нет...");
                    break;

            }


        }
        MSWord word = new MSWord("Doc", "Satan", "Programming", "Horror", "D:\\HowToGetOOP", 40);
        PDF pdf = new PDF("Pdf", "Hades", "", "Cringe", "D:\\Please", 100000);
        MSExcel excel = new MSExcel("Table", "", "", "Math", "D:\\Help", 3);
        Txt txt = new Txt("Note", "Oleg Fedorovich", "Fear", "Philosophy", "D:\\Me", 15);
        HTML html = new HTML("Site", "Подпись неразборчива", "JS", "Programming", "127.0.0.1", "5.0");
    }

    
}
