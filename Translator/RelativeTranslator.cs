using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using PraxedesBackend.Models;
using PraxedesBackend.Utility;

namespace PraxedesBackend.Translator
{
    public static class RelativeTranslator
    {
        public static Relative TranslateAsRelative(this SqlDataReader reader, bool isList = false)
        {
            if (!isList)
            {
                if (!reader.HasRows)
                    return null;
                reader.Read();
            }
            var item = new Relative();

            if (reader.IsColumnExists("Id"))
                item.Id = SqlHelper.GetNullableInt32(reader, "Id");

            if (reader.IsColumnExists("DateOfBirth"))
                item.DateOfBirth = SqlHelper.GetNullableDate(reader, "DateOfBirth");

            if (reader.IsColumnExists("RelativeNames"))
                item.RelativeNames = (SqlHelper.GetNullableString(reader, "RelativeNames"));

            if (reader.IsColumnExists("RelativeLastNames"))
                item.RelativeLastNames = SqlHelper.GetNullableString(reader, "RelativeLastNames");            

            if (reader.IsColumnExists("RelativeGender"))
                item.RelativeGender = SqlHelper.GetNullableString(reader, "RelativeGender");

            if (reader.IsColumnExists("RelativeDocumentNumber"))
                item.RelativeDocumentNumber = SqlHelper.GetNullableInt32(reader, "RelativeDocumentNumber");

            if (reader.IsColumnExists("InLaw"))
                item.InLaw = SqlHelper.GetNullableString(reader, "InLaw");

            if (reader.IsColumnExists("RelativeAge"))
                item.RelativeAge = SqlHelper.GetNullableInt32(reader, "RelativeAge");

            return item;
        }

        public static List<Relative> TranslateAsRelativeList(this SqlDataReader reader)
        {
            var list = new List<Relative>();

            while (reader.Read())
            {
                list.Add(TranslateAsRelative(reader, true));
            }
            return list;
        }

    }
}
