using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PraxedesBackend.Models;
using PraxedesBackend.Translator;
using PraxedesBackend.Utility;
using Microsoft.Data.SqlClient;
namespace PraxedesBackend.Repository
{
    public class UserDbClient
    {
        public List<User> GetUser(string connString)
        {
            return SqlHelper.ExtecuteProcedureReturnData<List<User>>(connString, "SPGetAllUsers", r => r.TranslateAsUserList());
        }

        public string SaveUser(User model, string connString)
        {

            SqlParameter[] param =
            {
                //@Date , @Name, @User must be identical to database
                new SqlParameter("@DateOfBirth", model.DateOfBirth),
                new SqlParameter("@UserNames", model.UserNames),
                new SqlParameter("@UserLastNames", model.UserLastNames),
                new SqlParameter("@UserPlatformName", model.UserPlatformName),
                new SqlParameter("@UserPassword", model.UserPassword),
                new SqlParameter("@UserGender", model.UserGender),
                new SqlParameter("@UserDocumentNumber", model.UserDocumentNumber)
            };
            return SqlHelper.ExecuteProcedureReturnString(connString, "SPSaveUser", param);
        }

        public string DeleteUser(int id, string connString)
        {

            SqlParameter[] param =
            {
                new SqlParameter("@Id", id),
            };
            return SqlHelper.ExecuteProcedureReturnString(connString, "SPDeleteUser", param);
        }
        public string UpdateUser(User model, string connString)
        {

            SqlParameter[] param =
            {
                new SqlParameter("@Id", model.Id),
                new SqlParameter("@DateOfBirth", model.DateOfBirth),
                new SqlParameter("@UserNames", model.UserNames),
                new SqlParameter("@UserLastNames", model.UserLastNames),
                new SqlParameter("@UserPlatformName", model.UserPlatformName),
                new SqlParameter("@UserPassword", model.UserPassword),
                new SqlParameter("@UserGender", model.UserGender),
                new SqlParameter("@UserDocumentNumber", model.UserDocumentNumber)
                //,outParam
            };
            return SqlHelper.ExecuteProcedureReturnString(connString, "SPUpdateUser", param);
            //  return (string)outParam.Value;
        }

    }
}
