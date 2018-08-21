using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using static ExcelToSQL.SQLTypeDef;

namespace ExcelToSQL
{
    public static class SQLTypeDefFactory
    {

        /* Returns a new SQLTypeDef instance of the child class with the given SQLTypeID. */
        public static SQLTypeDef getNew(SQLTypeID typeID, params int[] typeParams)
        {
            switch (typeID)
            {
                case SQLTypeID.BOOLEAN:
                    return new SQLBoolean();
                case SQLTypeID.INTEGER:
                    return new SQLInteger();
                case SQLTypeID.DECIMAL:
                    if(typeParams.Length >= 2)
                    {
                        return new SQLDecimal(typeParams[0], typeParams[1]);
                    }else return new SQLDecimal(16, 4);
                case SQLTypeID.VARCHAR:
                    if(typeParams.Length >= 1)
                    {
                        return new SQLVarchar(typeParams[0]);
                    }else return new SQLVarchar(256);
                default:
                    return null;
            }
        }

        /* Returns a SQLTypeDef fitting for the passed cell data example. */
        public static SQLTypeDef getNew(string dataStr)
        {
            SQLTypeDef def = getSQLBoolean(dataStr);
            if(def != null) return def;
            def = getSQLInteger(dataStr);
            if(def != null) return def;
            def = getSQLDecimal(dataStr);
            if(def != null) return def;
            def = getSQLVarchar(dataStr);
            return def;
        }

        /* Returns a new SQLTypeDef based on the SQLTypeID and cell data example passed.
           Returns null if the data and given type are incompatible. */
        public static SQLTypeDef getNew(SQLTypeID typeID, string dataStr)
        {
            switch (typeID)
            {
                case SQLTypeID.BOOLEAN:
                    return getSQLBoolean(dataStr);
                case SQLTypeID.INTEGER:
                    return getSQLInteger(dataStr);
                case SQLTypeID.DECIMAL:
                    return getSQLDecimal(dataStr);
                case SQLTypeID.VARCHAR:
                    return getSQLVarchar(dataStr);
                default:
                    return null;
            }
        }

        /* Returns a copy of the passed SQLTypeDef subclass/implementation instance. */
        public static SQLTypeDef getCopy(SQLTypeDef obj)
        {
            SQLTypeID typeID = obj.getTypeID();
            switch (typeID)
            {
                case SQLTypeID.BOOLEAN:
                    return new SQLBoolean();
                case SQLTypeID.INTEGER:
                    return new SQLInteger();
                case SQLTypeID.DECIMAL:
                    return new SQLDecimal((SQLDecimal)obj);
                case SQLTypeID.VARCHAR:
                    return new SQLVarchar((SQLVarchar)obj);
                default:
                    return null;
            }
        }

        /* Returns the ID of the first compatible type for the passed data in order
           from least to greatest in respect to the SQLTypeID's int equivalent. */
        public static SQLTypeID getCompatibleType(string dataStr)
        {
            
            // BOOLEAN type test
            string dataStrUpper = dataStr.ToUpper();
            if(dataStrUpper == "TRUE" || dataStrUpper == "FALSE")
            {
                return SQLTypeID.BOOLEAN;
            }

            // INTEGER type test
            int dataInt;
            if(int.TryParse(dataStr, out dataInt)){
                return SQLTypeID.INTEGER;
            }

            // DECIMAL type test
            decimal decStr;
            if(decimal.TryParse(dataStr, out decStr))
            {
                return SQLTypeID.DECIMAL;
            }

            // VARCHAR type test
            return SQLTypeID.VARCHAR;

        }
        
        /* Returns a new SQLBoolean object if the passed cell data string can be
           represented as a BOOLEAN. Otherwise, returns null. */
        public static SQLTypeDef getSQLBoolean(string dataStr)
        {

            if (dataStr == null) return null;
            string dataStrUpper = dataStr.ToUpper();
            if(dataStrUpper == "TRUE" || dataStrUpper == "FALSE")
            {
                return new SQLBoolean();
            }
            else
            {
                return null;
            }

        }

        /* Returns a new SQLInteger object if the passed cell data string can be
           represented as an INTEGER. Otherwise, returns null. */
        public static SQLTypeDef getSQLInteger(string dataStr)
        {

            if (dataStr == null) return null;
            int dataInt;
            if(int.TryParse(dataStr, out dataInt))
            {
                return new SQLInteger();
            }
            else
            {
                return null;
            }

        }

        /* Returns a new SQLDecimal object if the passed cell data string an be
           represented as a DECIMAL. Otherwise, returns null. */
        public static SQLTypeDef getSQLDecimal(string dataStr)
        {

            if (string.IsNullOrEmpty(dataStr)) return null;
            decimal dataDec;
            if(decimal.TryParse(dataStr, out dataDec))
            {
                string decStr = dataDec.ToString();
                string noSignStr;
                if(decStr[0] == '-') noSignStr = decStr.Substring(1);
                else noSignStr = dataStr;

                string[] decLeftRight = noSignStr.Split(new char[]{ '.' }, StringSplitOptions.RemoveEmptyEntries);

                if(decLeftRight.Length != 2)
                {
                    return null;
                }

                int scale = decLeftRight[1].Length;
                int precision = decLeftRight[0].Length + scale;

                return new SQLDecimal(precision, scale);

            }
            else
            {
                return null;
            }

        }
           
        /* Returns a new SQLVarchar object if the passed cell data string can be
           represented as a VARCHAR. Otherwise, returns null. */
        public static SQLTypeDef getSQLVarchar(string dataStr)
        {
            if (dataStr == null) return null;
            int dataStrLen = dataStr.Length;
            int escapedStrLen = Regex.Replace(dataStr, "'", "").Length;
            return new SQLVarchar(dataStrLen + (escapedStrLen - dataStrLen));
        }

    }
}
