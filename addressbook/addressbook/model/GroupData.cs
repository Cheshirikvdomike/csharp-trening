using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook
{
   public class GroupData:IEquatable<GroupData>, IComparable<GroupData>
    {
        private string nameGroup;
        private string headerGroup;
        private string footerGroup;
        public GroupData(string name, string header, string footer)
        {
            this.nameGroup = name;
            this.headerGroup = header;
            this.footerGroup = footer;
        }

        public int CompareTo(GroupData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return NameGroup.CompareTo(other.NameGroup);
        }

        public bool Equals(GroupData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return NameGroup == other.NameGroup;
        }

        public GroupData(string name)
        {
            this.nameGroup = name;
        }

        public override int GetHashCode()
        {
            return NameGroup.GetHashCode();
        }

        public override string ToString()
        {
            return "name="+NameGroup;
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
