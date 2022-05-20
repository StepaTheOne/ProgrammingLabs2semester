using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    abstract class Document
    {
        private string name;
        private string author;
        private string keyword;
        private string theme;
        private string path;

        public Document(string name, string author, string keyword, string theme,string path)
        {
            this.name = name;
            this.author = author;
            this.keyword = keyword;
            this.theme = theme;
            this.path = path;
        }
        public virtual string Info()
        {
            return $"{name}, {author}, {keyword}, {theme}, {path}";
        }
    }

    class MSWord : Document
    {
        private int pages;
        public MSWord(string name, string author, string keyword, 
            string theme, string path, int pages)
            :base(name, author, keyword, theme, path)
        {
            this.pages = pages;
        }

        public override string Info()
        {
            return base.Info()+$", {pages}";
        }
    }

    class PDF : Document
    {
        private int resolution;
        public PDF(string name, string author, string keyword,
           string theme, string path, int resolution)
           : base(name, author, keyword, theme, path)
        {
            this.resolution = resolution;
        }

        public override string Info()
        {
            return base.Info() +$"{resolution}";
        }
    }

    class MSExcel : Document
    {
        private int listsCount;
        public MSExcel(string name, string author, string keyword,
            string theme, string path, int listsCount)
            : base(name, author, keyword, theme, path)
        {
            this.listsCount = listsCount;
        }
        public override string Info()
        {
            return base.Info() + $"{listsCount}";
        }
    }

    class Txt : Document
    {
        private int lines;
        public Txt(string name, string author, string keyword,
            string theme, string path, int lines)
            : base(name, author, keyword, theme, path)
        {
            this.lines = lines;
        }
        public override string Info()
        {
            return base.Info() + $"{lines}";
        }
    }
    class HTML : Document
    {
        private string version;
        public HTML(string name, string author, string keyword,
            string theme, string path, string version)
            : base(name, author, keyword, theme, path)
        {
            this.version = version;
        }
        public override string Info()
        {
            return base.Info() + $"{version}";
        }
    }
}
