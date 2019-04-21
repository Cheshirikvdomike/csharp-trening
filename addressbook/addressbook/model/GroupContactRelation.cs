﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB.Mapping;

namespace addressbook
{
    [Table (Name= "address_in_groups")]
   public class GroupContactRelation
    {
        [Column(Name = "group_id")]
        public string GroupID { get; }
        [Column(Name = "sid")]
        public string ContactID { get; }
    }
}
