using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ExcelToSQL
{
    public static class SQLTools
    {

        /* Returns the input string with quotes escaped. */
        public static string escapeSQLString(string str)
        {
            str = Regex.Replace(str, "\n", "");
            str = Regex.Replace(str, "\r", "");
            return Regex.Replace(str, "'", "''");
        }

        /* Returns true if the input string is a valid SQL database,
           table or attribute name. Otherwise, returns false. */
        public static bool isValidSQLName(string str)
        {

            // Return false if the string is null or empty
            if(String.IsNullOrEmpty(str)) return false;

            // Return false if the first character is not a letter or underscore
            if(str[0] != '_' && !Char.IsLetter(str[0])) return false;

            // Loops through the rest of the string
            for(int i = 1; i < str.Length; ++i)
            {
                // Return false if the char at the index is not a '_', letter or number
                char c = str[i];
                if(c != '_' && !Char.IsNumber(c) && !Char.IsLetter(c))
                {
                    return false;
                }
            }

            // Returns true if all checks succeeded
            return true;

        }

    }
}
