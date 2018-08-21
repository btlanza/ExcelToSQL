using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ExcelToSQL.SQLTypeDefFactory;


namespace ExcelToSQL
{
    public static class ColumnFactory
    {

        /* Returns a list of columns by taking the passed 2D cell data
           string array and separating the column names and data. */
        public static List<Column> getColumnsFromCells(string[,] cellData)
        {

            int numRows = cellData.GetLength(0);
            int numColumns = cellData.GetLength(1);

            List<Column> columns = new List<Column>(numColumns);
            
            for(int i = 0; i < numColumns; ++i)
            {

                string colName = cellData[0, i];
                string[] tmpCells = new string[numRows - 1];

                for(int j = 1; j < numRows; ++j)
                {
                    tmpCells[j - 1] = cellData[j, i];
                }

                SQLTypeDef tempDef = getColumnTypeDef(tmpCells);
                columns.Add(new Column(colName, tmpCells, tempDef));

            }

            return columns;
        }

        /* Returns a new SQLTypeDef instance recommended for the array of cell
           data passed. */
        public static SQLTypeDef getColumnTypeDef(string[] cellData)
        {

            int numCells = cellData.Length;
            SQLTypeDef[] cellTypes = new SQLTypeDef[numCells];
            SQLTypeDef columnType = getNew((SQLTypeDef.SQLTypeID)0);

            for(int i = 0; i < numCells; ++i)
            {
                cellTypes[i] = getNew(cellData[i]);

                if(cellTypes[i] != null)
                {

                    int columnTypeID = (int)columnType.getTypeID();
                    int cellTypeID = (int)cellTypes[i].getTypeID();

                    if(columnTypeID < cellTypeID)
                    {
                        columnType = getCopy(cellTypes[i]);
                    }else if(columnTypeID == cellTypeID)
                    {
                        columnType.setCompatibleParams(cellTypes[i]);
                    }

                }
                
            }

            return columnType;

        }

    }
}
