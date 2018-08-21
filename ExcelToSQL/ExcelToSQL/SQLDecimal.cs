using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelToSQL
{
    class SQLDecimal : SQLTypeDef
    {

        // Public static properties
        public static readonly string[] Params = { "precision", "scale" };
        public static readonly SQLTypeID TypeID = SQLTypeID.DECIMAL;
        public static readonly int[] MinParamsVals = { 2, 1 };
        public static readonly int[] MaxParamsVals = { 38, 37 };

        // Private fields
        private Dictionary<string, int> paramsDict;

        // Constructors
        public SQLDecimal(int precision, int scale)
        {
            paramsDict = new Dictionary<string, int>();
            foreach(string s in Params)
            {
                paramsDict.Add(s, -1);
            }
            paramsDict["precision"] = precision;
            paramsDict["scale"] = scale;
        }

        public SQLDecimal(Dictionary<string, int> dict)
        {
            paramsDict = new Dictionary<string, int>(dict);
        }

        public SQLDecimal(SQLDecimal obj) : this(obj.paramsDict) { }

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
            }
            catch (KeyNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public override int getMinParamVal(string paramName)
        {
            int index = Array.IndexOf(Params, paramName);
            if (index != -1)
            {
                return MinParamsVals[index];
            }
            else return -1;
        }

        public override int getMaxParamVal(string paramName)
        {
            int index = Array.IndexOf(Params, paramName);
            if (index != -1)
            {
                return MaxParamsVals[index];
            }
            else return -1;
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
                if(paramVal < paramBounds.Item1 || paramVal > paramBounds.Item2)
                {
                    errorMsg = "Error: Value of the parameter " + Params[i] + " outside of allowed bounds!";
                    return false;
                }
            }
            if(getParam(Params[1]) >= getParam(Params[0]))
            {
                errorMsg = "Error: Param " + Params[1] + " cannot be larger than " + Params[0];
                return false;
            }
            errorMsg = "";
            return true;
        }

        public override string getSQLDefString()
        {
            StringBuilder sqlSb = new StringBuilder(getSQLTypeName(TypeID));
            int numParams = Params.Length;
            sqlSb.Append("(");
            for (int i = 0; i < numParams; ++i)
            {
                sqlSb.Append(getParam(Params[i]).ToString());
                if(i != numParams - 1)
                {
                    sqlSb.Append(", ");
                }
                else
                {
                    sqlSb.Append(")");
                }
            }
            return sqlSb.ToString();
        }

        public override bool isCompatibleDef(SQLTypeDef def)
        {
            
            if (this.getTypeID() != def.getTypeID()) return false;

            int thisPrecision = this.getParam("precision");
            int thisScale = this.getParam("scale");
            int defPrecision = def.getParam("precision");
            int defScale = def.getParam("scale");

            thisPrecision -= thisScale;
            defPrecision -= defScale;

            if(thisPrecision < defPrecision) return false;
            if(thisScale < defScale) return false;

            return true;

        }

        public override bool setCompatibleParams(SQLTypeDef def)
        {
            
            if (this.getTypeID() != def.getTypeID()) return false;

            int thisPrecision = this.getParam("precision");
            int thisScale = this.getParam("scale");
            int defPrecision = def.getParam("precision");
            int defScale = def.getParam("scale");

            thisPrecision -= thisScale;
            defPrecision -= defScale;

            int maxPrecision = (thisPrecision > defPrecision) ? thisPrecision : defPrecision;
            int maxScale = (thisScale > defScale) ? thisScale : defScale;

            this.setParam("precision", maxPrecision + maxScale);
            this.setParam("scale", maxScale);

            return true;

        }

        public override string getSQLInsertString(string str)
        {
            if(string.IsNullOrEmpty(str)) return null;
            decimal d;
            if(decimal.TryParse(str, out d)) return d.ToString();
            else return null;
        }

    }
}
