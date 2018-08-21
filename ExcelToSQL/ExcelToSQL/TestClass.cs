/*
 * Benjamin Lanza 
 * TestClass.cs
 * This class is used to test various parts
 * of the whole program.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ExcelToSQL.SQLTypeDef;
using static ExcelToSQL.SQLTypeDefFactory;
using static ExcelToSQL.SQLBoolean;
using static ExcelToSQL.SQLInteger;
using static ExcelToSQL.SQLDecimal;
using static ExcelToSQL.SQLVarchar;

namespace ExcelToSQL
{
    class TestClass
    {
        public static void run()
        {
            string[] decStrs = new string[3];
            decStrs[0] = "31.234"; decStrs[1] = "315.267"; decStrs[2] = "1234.5678";
            SQLTypeDef[] decs = new SQLTypeDef[3];
            for(int i = 0; i < decs.Length; i++)
            {
                decs[i] = getSQLDecimal(decStrs[i]);
                if(decs[i] == null)
                {
                    Console.WriteLine("null at " + i.ToString());
                }
                else
                {
                    Console.WriteLine(decs[i].getSQLDefString() + " at " + i.ToString());
                }
            }
        }
    }
}
