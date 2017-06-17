using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailGetterFromWebPage
{
    interface IWebCodeGetter
    {
        string getHTMLCode(string url);
    }
}
