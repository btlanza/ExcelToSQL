using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelToSQL
{
    class SQLInteger : SQLTypeDef
    {

        // Public static properties
        public static readonly string[] Params = { };
        public static readonly SQLTypeID TypeID = SQLTypeID.INTEGER;

        // Method implementations
        public override SQLTypeID getTypeID()
        {
            return TypeID;
        }

        public override bool hasParam(string paramName)
        {
            return Params.Contains(paramName);
        }

        public override int getParam(string paramName)
        {
            return -1;
        }

        public override bool setParam(string paramName, int paramVal)
        {
            return false;
        }

        public override int getMinParamVal(string paramName)
        {
            return -1;
        }

        public override int getMaxParamVal(string paramName)
        {
            return -1;
        }

        public override Tuple<int, int> getParamValBounds(string paramName)
        {
            return new Tuple<int, int>(-1, -1);
        }

        public override string[] getParams()
        {
            return Params;
        }

        public override bool isValid(out string errorMsg)
        {
            errorMsg = "";
            return true;
        }

        public override string getSQLDefString()
        {
            return getSQLTypeName(TypeID);
        }

        public override bool isCompatibleDef(SQLTypeDef def)
        {
            if (this.getTypeID() == def.getTypeID()) return true;
            else return false;
        }

        public override bool setCompatibleParams(SQLTypeDef def)
        {
            return this.isCompatibleDef(def);
        }

        public override string getSQLInsertString(string str)
        {
            if(string.IsNullOrEmpty(str)) return null;
            int i;
            if(int.TryParse(str, out i)) return i.ToString();
            else return null;
        }

    }
}
