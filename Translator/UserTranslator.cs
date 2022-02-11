using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using PraxedesBackend.Models;
using PraxedesBackend.Utility;

namespace PraxedesBackend.Translator
{
    public static class UserTranslator
    {
        public static User TranslateAsUser(this SqlDataReader reader, bool isList = false)
        {
            if (!isList)
            {
                if (!reader.HasRows)
                    return null;
                reader.Read();
            }
            var item = new User();

            if (reader.IsColumnExists("Id"))
                item.Id = SqlHelper.GetNullableInt32(reader, "Id");

            if (reader.IsColumnExists("DateOfBirth"))
                item.DateOfBirth = SqlHelper.GetNullableDate(reader, "DateOfBirth");

            if (reader.IsColumnExists("UserNames"))
                item.UserNames = (SqlHelper.GetNullableString(reader, "UserNames"));

            if (reader.IsColumnExists("UserLastNames"))
                item.UserLastNames = SqlHelper.GetNullableString(reader, "UserLastNames");

            if (reader.IsColumnExists("UserPlatformName"))
                item.UserPlatformName = SqlHelper.GetNullableString(reader, "UserPlatformName");

            if (reader.IsColumnExists("UserPassword"))
                item.UserPassword = SqlHelper.GetNullableString(reader, "UserPassword");

            if (reader.IsColumnExists("UserGender"))
                item.UserGender = SqlHelper.GetNullableString(reader, "UserGender");

            if (reader.IsColumnExists("UserDocumentNumber"))
                item.UserDocumentNumber = SqlHelper.GetNullableInt32(reader, "UserDocumentNumber");

            return item;
        }

        public static List<User> TranslateAsUserList(this SqlDataReader reader)
        {
            var list = new List<User>();

            while (reader.Read())
            {
                list.Add(TranslateAsUser(reader, true));
            }
            return list;
        }

    }
}
