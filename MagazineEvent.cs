using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkWithAccountsInTheBankingSystem
{
    struct MagazineEvent
    {
        public DateTime Key { get; set; }
        public string Value { get; set; }
        public MagazineEvent(DateTime Key,string Value)
        {
            this.Key = Key;
            this.Value = Value;
        }
    }
}
