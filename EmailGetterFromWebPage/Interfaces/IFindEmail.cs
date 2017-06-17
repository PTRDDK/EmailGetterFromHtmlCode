using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailGetterFromWebPage.Interfaces
{
    interface IFindEmail
    {
        string FindEmailByRegex(string input);
    }
}
