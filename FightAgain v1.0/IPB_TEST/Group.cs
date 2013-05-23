using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using IPB_TEST.Annotations;
using IcePhoenixAPI.Account;

namespace IPB_TEST
{
    public class Group
    {
        public String Name { get; set; }
        public ObservableCollection<IAccount> Accounts { get; set; }

        public Group(String name)
        {
            Name = name;
            Accounts = new ObservableCollection<IAccount>();
        }
    }
}
