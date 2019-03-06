using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook
{
    public class PagesGroupData
    {
        private string nameGroup;
        private string headerGroup;
        private string footerGroup;

        public PagesGroupData(string name, string header, string footer)
        {
            this.nameGroup = name;
            this.headerGroup = header;
            this.footerGroup = footer;
        }

        public string NameGroup
        {
            get
            {
                return nameGroup;
            }
            set
            {
                nameGroup = value;
            }
        }

        public string HeaderGroup
        {
            get
            {
                return headerGroup;
            }
            set
            {
                headerGroup = value;
            }
        }

        public string FooterGroup
        {
            get
            {
                return footerGroup;
            }
            set
            {
                footerGroup = value;
            }
        }
    }
}
