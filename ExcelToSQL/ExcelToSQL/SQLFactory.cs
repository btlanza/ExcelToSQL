using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ExcelToSQL
{
    public static class SQLFactory
    {
        public static List<string> getSQLLines(string tableName, List<Column> columns)
        {
            List<string> inserts = new List<string>();

            StringBuilder sbTableCreate = new StringBuilder("CREATE TABLE ");
            sbTableCreate.Append(tableName);
            sbTableCreate.Append("(");

            foreach(Column column in columns)
            {
                sbTableCreate.Append(column.getName());
                sbTableCreate.Append(" ");
                sbTableCreate.Append(column.getSQLDefString());
                sbTableCreate.Append(", ");
            }

            sbTableCreate.Length--; sbTableCreate.Length--;

            sbTableCreate.Append(");");
            inserts.Add(sbTableCreate.ToString());

            // Insert statements
            int numColumns = columns.Count;
            int numRows = columns[0].getNumCells();

            for(int i = 0; i < numRows; ++i)
            {
                StringBuilder sbInsert = new StringBuilder("INSERT INTO ");
                sbInsert.Append(tableName);
                sbInsert.Append(" VALUES (");
                for (int j = 0; j < numColumns; ++j)
                {
                    string tempStr = columns[j][i];
                    if(tempStr != null)
                    {
                        sbInsert.Append(tempStr);
                    }else sbInsert.Append("NULL");
                    sbInsert.Append(", ");
                }
                sbInsert.Length -= 2;
                sbInsert.Append(");");
                inserts.Add(sbInsert.ToString());
            }

            return inserts;
        }

        public static List<string> getSQLLines(string tableName, List<Column>columns, List<List<int>> primaryKeys)
        {
            List<string> inserts = getSQLLines(tableName, columns);
            if(inserts == null || inserts[0] == null) return null;
            int newLen = inserts[0].LastIndexOf(")");
            if(newLen <= 0) return null;
            StringBuilder sb = new StringBuilder(inserts[0].Substring(0, newLen));
            sb.Append(", ");

            foreach(List<int> key in primaryKeys)
            {
                sb.Append("PRIMARY KEY (");
                foreach(int colIndex in key)
                {
                    sb.Append(columns[colIndex].getName());
                    sb.Append(", ");
                }
                sb.Length--; sb.Length--;
                sb.Append("), ");
            }
            sb.Length--; sb.Length--;
            sb.Append(");");
            inserts[0] = sb.ToString();

            return inserts;
        }

        public static bool writeLinesToFile(string filename, List<string> lines)
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                foreach(string line in lines)
                {
                    writer.WriteLine(line);
                }
            }
            return true;
        }

    }
}
