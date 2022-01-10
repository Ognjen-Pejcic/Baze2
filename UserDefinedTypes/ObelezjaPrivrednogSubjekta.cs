using Microsoft.SqlServer.Server;
using System;
using System.Data.SqlTypes;
using System.Text;

namespace UserDefinedTypes
{
    [Serializable]
    [Microsoft.SqlServer.Server.SqlUserDefinedType(Format.Native,
     IsByteOrdered = true, ValidationMethodName = "ValidatePoint")]
    public struct ObelezjaPrivrednogSubjekta : INullable
    {
        private bool is_Null;
        private Int32 pib;
        private Int32 maticniBroj;
        public bool IsNull => is_Null;

        public static ObelezjaPrivrednogSubjekta Null
        {
            get
            {
                ObelezjaPrivrednogSubjekta obelezjaPrivrednogSubjekta = new ObelezjaPrivrednogSubjekta();
                obelezjaPrivrednogSubjekta.is_Null = true;
                return obelezjaPrivrednogSubjekta;
            }
        }

        public Int32 PIB
        {
            get
            {
                return pib;
            }
            set
            {
                Int32 temp = pib;
                pib = value;
                if (!ValidatePoint())
                {
                    pib = temp;
                    throw new ArgumentException("Neispravan format PIB-a");
                }
            }
        }

        public Int32 MaticniBroj
        {
            get
            {
                return maticniBroj;
            }
            set
            {
                Int32 temp = maticniBroj;
                maticniBroj = value;
                if (!ValidatePoint())
                {
                    maticniBroj = temp;
                    throw new ArgumentException("Neispravan format maticnog broja");
                }
            }
        }

        private bool ValidatePoint()
        {
            //PIB mora da bude izmedju 10000001 i 99999999, a maticni broj mora da ima tacno 8 cifara
            if ((pib >= 10000001 && pib <= 99999999) && (maticniBroj.ToString().Length == 8))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        [SqlMethod(OnNullCall = false)]
        public static ObelezjaPrivrednogSubjekta Parse(SqlString s)
        {
            // With OnNullCall=false, this check is unnecessary if   
            // Point only called from SQL.  
            if (s.IsNull)
                return Null;

            // Parse input string to separate out points.  
            ObelezjaPrivrednogSubjekta obelezjaPrivrednogSubjekta = new ObelezjaPrivrednogSubjekta();
            string[] xy = s.Value.Split(",".ToCharArray());
            obelezjaPrivrednogSubjekta.pib = Convert.ToInt32(xy[0]);
            obelezjaPrivrednogSubjekta.maticniBroj = Convert.ToInt32(xy[1]);

            // Call ValidatePoint to enforce validation  
            // for string conversions.  
            if (!obelezjaPrivrednogSubjekta.ValidatePoint())
                throw new ArgumentException("Nevalidne vrednosti");
            return obelezjaPrivrednogSubjekta;
        }

        [SqlMethod(OnNullCall = false)]
        public string Spojeno()
        {
            return $"PIB: {this.pib}\nMaticni broj: {this.maticniBroj}";
        }

        // Use StringBuilder to provide string representation of UDT.  
        public override string ToString()
        {
            // Since InvokeIfReceiverIsNull defaults to 'true'  
            // this test is unnecessary if Point is only being called  
            // from SQL.  
            if (this.IsNull)
                return "NULL";
            else
            {
                StringBuilder builder = new StringBuilder();
                builder.Append(this.pib);
                builder.Append(",");
                builder.Append(this.maticniBroj);
                return builder.ToString();
            }
        }

    }
}
