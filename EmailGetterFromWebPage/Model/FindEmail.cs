using EmailGetterFromWebPage.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EmailGetterFromWebPage.Model
{
    class FindEmail : IFindEmail
    {
        ArrayList resultArray = new ArrayList();
        
        public string FindEmailByRegex(string input)
        {
            Regex regex = new Regex("[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\\.[a-zA-Z0-9-.]+", RegexOptions.IgnoreCase);
            MatchCollection match = regex.Matches(input);

            StringBuilder sb = new StringBuilder();

            foreach (Match emailMatch in match)
            {
                sb.AppendLine(emailMatch.Value);
            }

            string result = sb.ToString();
            return result;
        }
    }
}
