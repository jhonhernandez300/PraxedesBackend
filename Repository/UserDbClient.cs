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
            return SqlHelper.ExtecuteProcedureReturnData<List<User>>(connString, "GetAllUsers", r => r.TranslateAsUserList());
        }

        public string SaveUser(User model, string connString)
        {

            SqlParameter[] param =
            {
                //@Date , @Name, @User must be identical to database
                new SqlParameter("@DateOfBirth", model.DateOfBirth),
                new SqlParameter("@UserNames", model.UserNames),
                new SqlParameter("@UserLastNames", model.UserLastNames),
                new SqlParameter("@UserPaltformName", model.UserPaltformName),
                new SqlParameter("@UserGender", model.UserGender),
                new SqlParameter("@UserDocumentNumber", model.UserDocumentNumber)
            };
            return SqlHelper.ExecuteProcedureReturnString(connString, "SaveUser", param);
        }

        public string DeleteUser(int id, string connString)
        {

            SqlParameter[] param =
            {
                new SqlParameter("@Id", id),
            };
            return SqlHelper.ExecuteProcedureReturnString(connString, "DeleteUser", param);
        }
        public string UpdateUser(User model, string connString)
        {

            SqlParameter[] param =
            {
                new SqlParameter("@Id", model.Id),
                new SqlParameter("@DateOfBirth", model.DateOfBirth),
                new SqlParameter("@UserNames", model.UserNames),
                new SqlParameter("@UserLastNames", model.UserLastNames),
                new SqlParameter("@UserPaltformName", model.UserPaltformName),
                new SqlParameter("@UserGender", model.UserGender),
                new SqlParameter("@UserDocumentNumber", model.UserDocumentNumber)
                //,outParam
            };
            return SqlHelper.ExecuteProcedureReturnString(connString, "UpdateUser", param);
            //  return (string)outParam.Value;
        }

    }
}
