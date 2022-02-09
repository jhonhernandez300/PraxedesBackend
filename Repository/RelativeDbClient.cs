using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using PraxedesBackend.Models;
using PraxedesBackend.Translator;
using PraxedesBackend.Utility;

namespace PraxedesBackend.Repository
{
    public class RelativeDbClient
    {
        public List<Relative> GetRelative(string connString)
        {
            return SqlHelper.ExtecuteProcedureReturnData<List<Relative>>(connString, "GetRelative", r => r.TranslateAsRelativeList());
        }

        public string SaveRelative(Relative model, string connString)
        {

            SqlParameter[] param =
            {
                //@Date , @Name, @Relative must be identical to database
                new SqlParameter("@DateOfBirth", model.DateOfBirth),
                new SqlParameter("@RelativeNames", model.RelativeNames),
                new SqlParameter("@RelativeLastNames", model.RelativeLastNames),                
                new SqlParameter("@RelativeGender", model.RelativeGender),
                new SqlParameter("@RelativeDocumentNumber", model.RelativeDocumentNumber),
                new SqlParameter("@InLaw", model.InLaw),
                new SqlParameter("@RelativeAge", model.RelativeAge)
            };
            return SqlHelper.ExecuteProcedureReturnString(connString, "SaveRelative", param);
        }

        public string DeleteRelative(int id, string connString)
        {

            SqlParameter[] param =
            {
                new SqlParameter("@Id", id),
            };
            return SqlHelper.ExecuteProcedureReturnString(connString, "DeleteRelative", param);
        }
        public string UpdateRelative(Relative model, string connString)
        {

            SqlParameter[] param =
            {
                new SqlParameter("@Id", model.Id),
                 new SqlParameter("@DateOfBirth", model.DateOfBirth),
                new SqlParameter("@RelativeNames", model.RelativeNames),
                new SqlParameter("@RelativeLastNames", model.RelativeLastNames),                
                new SqlParameter("@RelativeGender", model.RelativeGender),
                new SqlParameter("@RelativeDocumentNumber", model.RelativeDocumentNumber),
                new SqlParameter("@InLaw", model.InLaw),
                new SqlParameter("@RelativeAge", model.RelativeAge)
                //,outParam
            };
            return SqlHelper.ExecuteProcedureReturnString(connString, "UpdateRelative", param);
            //  return (string)outParam.Value;
        }

    }
}
