using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingLabs
{
    class Document
    {
        private string _Name;
        private string _Author;
        private string _Tags;
        private string _Genre;
        private string _Location;

        public Document(string Name, string Author, string Tags, string Genre, string Location)
        {
            _Name = Name;
            _Author = Author;
            _Tags = Tags;
            _Genre = Genre;
            _Location = Location;
        }
        public virtual string GetInfo() {
            return $"{_Name}, {_Author}, {_Tags}, {_Genre}, {_Location}";
        }
    }
    
    class MSWord : Document
    {
        private string _Codepage;

        public MSWord(
            string Name,
            string Author,
            string Tags,
            string Genre,
            string Location,
            string Codepage) : base(Name, Author, Tags, Genre, Location)
        {
            _Codepage = Codepage;
        }

        public override string GetInfo()
        {
            return base.GetInfo() + $", {_Codepage}";
        }

    }

    class PDF : Document
    {
        private int _Dpi;

        public PDF(int Dpi,
                   string Name,
                   string Author,
                   string Tags,
                   string Genre,
                   string Location) : base(Name, Author, Tags, Genre, Location)
        {
            _Dpi = Dpi;
        }

        public override string GetInfo()
        {
            return base.GetInfo() + $", {_Dpi}";
        }
    }
    
    class MSExcel : Document
    {
        private int _ColumnsCount;
        private int _StrokesCount;
        public MSExcel(string Name,
                       string Author,
                       string Tags,
                       string Genre,
                       string Location,
                       int ColumnsCount,
                       int StrokesCount) : base(Name, Author, Tags, Genre, Location)
        {
            _ColumnsCount = ColumnsCount;
            _StrokesCount = StrokesCount;
        }

        public override string GetInfo()
        {
            return base.GetInfo() + $", {_ColumnsCount}, {_StrokesCount}";
        }
    }

    class TXT : Document
    {
        private string _Codepage;

        public TXT(
            string Name,
            string Author,
            string Tags,
            string Genre,
            string Location,
            string Codepage) : base(Name, Author, Tags, Genre, Location)
        {
            _Codepage = Codepage;
        }

        public override string GetInfo()
        {
            return base.GetInfo() + $", {_Codepage}";
        }
    }

    class HTML : Document
    {
        private string _Version;

        public HTML(string Name,
                    string Author,
                    string Tags,
                    string Genre,
                    string Location,
                    string Version) : base(Name, Author, Tags, Genre, Location)
        {
            _Version = Version;
        }

        public override string GetInfo()
        {
            return base.GetInfo();
        }
    }
}
