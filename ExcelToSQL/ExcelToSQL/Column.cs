using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ExcelToSQL.SQLTypeDef;
using static ExcelToSQL.SQLTools;
using static ExcelToSQL.SQLTypeDefFactory;

namespace ExcelToSQL
{
    public class Column
    {

        // Private fields passed to constructor
        private string name;                // The name of the column
        private string[] data;              // The column's cell string data array
        private SQLTypeDef typeDef;         // The type definition for the column

        // Boolean determining if NULL entries are allowed
        private bool notNull = false;

        // Flags calculated on constructor call
        private bool hasNull;               // True iff at least 1 column cell data string is empty
        private bool hasValidName;          // True iff the name of the column is a valid SQL name

        // Expose flags as readonly Properties
        public bool HasNull
        {
            get {
                return hasNull;
            }
        }

        public bool HasValidName
        {
            get {
                return hasValidName;
            }
        }

        // Expose NotNull property
        public bool NotNull
        {
            get {
                return notNull;
            }
            set {
                notNull = value;
            }
        }

        // Constructor
        public Column(string name, string[] data, SQLTypeDef typeDef)
        {

            this.name = name;
            this.data = new string[data.Length];
            Array.Copy(data, this.data, data.Length);
            this.typeDef = getCopy(typeDef);
            this.setFlags();

        }

        /* Sets the column's flags */
        private void setFlags()
        {

            // Check for valid name
            if (isValidSQLName(this.name)) this.hasValidName = true;
            else this.hasValidName = false;

            // Check is any cell string data is null or empty
            foreach(string cellData in this.data)
            {
                if (String.IsNullOrEmpty(cellData))
                {
                    this.hasNull = true;
                    break;
                }

                if(getNew(this.typeDef.getTypeID(), cellData) == null){
                    this.hasNull = true;
                    break;
                }

                this.hasNull = false;
            }

        }

        /* Sets the name of the column to the passed string and returns true
           iff it contains a valid SQL name. Otherwise, returns false. */
        public bool setName(string name)
        {
            if (isValidSQLName(name))           // From SQLTools.cs
            {
                this.name = name;
                this.hasValidName = true;
                return true;
            }
            else
            {
                return false;
            }
        }

        /* Gets the current name of the column. */
        public string getName()
        {
            return this.name;
        }

        /* Sets the SQLTypeDef of the column to the passed one. */
        public void setTypeDef(SQLTypeDef def)
        {
            this.typeDef = getCopy(def);
        }

        /* Gets a copy of the current column SQLTypeDef. */
        public SQLTypeDef getTypeDef()
        {
            return getCopy(this.typeDef);
        }

        /* Returns the SQLTypeID of the column. */
        public SQLTypeID getTypeID()
        {
            return this.typeDef.getTypeID();
        }

        /* Returns the number of cells in the column. */
        public int getNumCells()
        {
            return data.Length;
        }

        /* Returns the string at the given index in the collection with the
           column SQLTypeDef applied. */
        public string this[int i]
        {
            get {
                if(i > -1 && i < data.Length)
                {
                    return typeDef.getSQLInsertString(data[i]);
                }else return null;
                
            }
        }

        /* Returns the string used to define the column in a table create
           statement. */
        public string getSQLDefString()
        {
            StringBuilder sb = new StringBuilder(typeDef.getSQLDefString());
            if(NotNull) sb.Append("NOT NULL");
            return sb.ToString();
        }

    }
}
