using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelToSQL
{
    public abstract class SQLTypeDef
    {

        // Used to identify supported SQL types
        public enum SQLTypeID { BOOLEAN = 0, INTEGER = 1, DECIMAL = 2, VARCHAR = 3 };

        // Gets the string representation of the passed SQL type name
        public static string getSQLTypeName(SQLTypeID t)
        {
            return Enum.GetName(typeof(SQLTypeID), t);
        }

        // Gets the SQLTypeID corresponding to the passed string or -1
        public static SQLTypeID getSQLTypeFromName(string str)
        {
            str = str.ToUpper();
            if(str == "BOOLEAN") return SQLTypeID.BOOLEAN;
            else if(str == "INTEGER") return SQLTypeID.INTEGER;
            else if(str == "DECIAML") return SQLTypeID.DECIMAL;
            else if(str == "VARCHAR") return SQLTypeID.VARCHAR;
            else return (SQLTypeID)(-1);
        }

        /* Returns the SQLTypeID corresponding to the calling class. */
        public abstract SQLTypeID getTypeID();

        /* Checks whether or not the SQL type has a property with the given
           name, returning true if it does and false if it doesn't. */
        public abstract bool hasParam(string paramName);

        /* Gets the parameter with the given name, or returns -1 if the
           parameter doesn't exist for the calling type. */
        public abstract int getParam(string paramName);

        /* Sets the parameter with the given name, returning true if the
           operation is successful. Otherwise, returns false and no changes
           are made. */
        public abstract bool setParam(string paramName, int paramVal);

        /* Returns the minimum allowed value for the parameter of the passed
           name. */
        public abstract int getMinParamVal(string paramName);

        /* Returns the maximum allowed value for the parameter of the passed
           name. */
        public abstract int getMaxParamVal(string paramName);

        /* Returns a 2-Tuple of ints representing the minimum and maximum
           allowed values for the parameter with the given name. If the
           parameter doesn't exist, both ints will be -1. */
        public abstract Tuple<int, int> getParamValBounds(string paramName);

        /* Returns an array of strings representing the valid parameters for
           the calling type. */
        public abstract string[] getParams();

        /* Checks that the SQL type parameters are valid, returning true
           and setting errorMsg to an empty string if they are. Otherwise,
           returns false and sets errorMsg to a string giving the reason. */
        public abstract bool isValid(out string errorMsg);

        /* Returns a string representing the SQL attribute definition
           corresponding to the class data. */
        public abstract string getSQLDefString();

        /* Returns true if the given SQLTypeDef child instance is of the same
           type as the caller and it can be defined given the caller's
           parameters. That is, the caller's parameters must be at least as
           lenient as the passed object's parameters. Otherwise, returns false. */
        public abstract bool isCompatibleDef(SQLTypeDef def);

        /* Changes the parameters of the caller to the most lenient value out of
           the caller's and the passed object's parameters if this is possible
           (i.e. they still must be the same type). If they are incompatible types,
           returns false. */
        public abstract bool setCompatibleParams(SQLTypeDef def);

        /* Returns the string that would be used to insert the passed data into a
           database given the caller's type definition. */
        public abstract string getSQLInsertString(string str);

    }
}
