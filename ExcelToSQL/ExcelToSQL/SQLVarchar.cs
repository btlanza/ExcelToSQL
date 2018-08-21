using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelToSQL
{
    class SQLVarchar : SQLTypeDef
    {

        // Public static properties
        public static readonly string[] Params = { "length" };
        public static readonly SQLTypeID TypeID = SQLTypeID.VARCHAR;
        public static readonly int[] MinParamsVals = { 1 };
        public static readonly int[] MaxParamsVals = { 4096 };

        // Private fields
        private Dictionary<string, int> paramsDict;

        // Constructors
        public SQLVarchar(int length)
        {
            paramsDict = new Dictionary<string, int>();
            foreach(string s in Params)
            {
                paramsDict.Add(s, -1);
            }

            paramsDict["length"] = length;
        }

        private SQLVarchar(Dictionary<string, int> dict)
        {
            paramsDict = new Dictionary<string, int>(dict);
        }

        public SQLVarchar(SQLVarchar obj) : this(obj.paramsDict) { }

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
            try
            {
                return paramsDict[paramName];
            }catch(KeyNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
                return -1;
            }
        }

        public override bool setParam(string paramName, int paramVal)
        {
            try
            {
                paramsDict[paramName] = paramVal;
                return true;
            }catch(KeyNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public override int getMinParamVal(string paramName)
        {
            int index = Array.IndexOf(Params, paramName);
            if(index != -1)
            {
                return MinParamsVals[index];
            }else return -1;
        }

        public override int getMaxParamVal(string paramName)
        {
            int index = Array.IndexOf(Params, paramName);
            if(index != -1)
            {
                return MaxParamsVals[index];
            }else return -1;
        }

        public override Tuple<int, int> getParamValBounds(string paramName)
        {
            int minVal = getMinParamVal(paramName);
            int maxVal = getMaxParamVal(paramName);
            return new Tuple<int, int>(minVal, maxVal);
        }

        public override string[] getParams()
        {
            return Params;
        }

        public override bool isValid(out string errorMsg)
        {
            int numParams = Params.Length;
            for(int i = 0; i < numParams; ++i)
            {
                Tuple<int, int> paramBounds = getParamValBounds(Params[i]);
                int paramVal = getParam(Params[i]);
                if(paramVal < paramBounds.Item1 || paramVal > paramBounds.Item2){
                    errorMsg = "Error: Value of parameter " + Params[i] + " outside of allowed bounds!";
                    return false;
                }
            }
            errorMsg = "";
            return true;
        }

        public override string getSQLDefString()
        {
            StringBuilder sqlSb = new StringBuilder(getSQLTypeName(TypeID));
            int numParams = Params.Length;
            for(int i = 0; i < numParams; ++i)
            {
                sqlSb.Append("(");
                sqlSb.Append(getParam(Params[i]).ToString());
                if(i != numParams - 1)
                {
                    sqlSb.Append(@", ");
                }
                else
                {
                    sqlSb.Append(@")");
                }
            }
            return sqlSb.ToString();
        }

        public override bool isCompatibleDef(SQLTypeDef def)
        {
            if (this.getTypeID() != def.getTypeID()) return false;
            if (def.getParam("length") > this.getParam("length")) return false;
            return true;
        }

        public override bool setCompatibleParams(SQLTypeDef def)
        {
            if(this.getTypeID() != def.getTypeID()) return false;
            if(def.getParam("length") > this.getParam("length"))
            {
                this.setParam("length", def.getParam("length"));
            }
            return true;
        }

        public override string getSQLInsertString(string str)
        {
            if(string.IsNullOrEmpty(str)) return null;
            if(str.Length > this.getParam("length")) return null;
            str = "'" + SQLTools.escapeSQLString(str) + "'";
            return str;
        }

    }
}
