using System.Data;
using System.Data.SqlClient;

namespace TCA_TSR_BackEnd.Models.DAO
{
    public class TCATSR_DAO
    {
        #region State

        public static Result StoreState(StatePost _state)
        {
            Result result = new Result();
            int spOption = 1;
            using(var bl = new Business())
            {
                try
                {
                    bl
                      .AddParam("@SpOption", spOption)
                      .AddParam("@State_Name", _state.State_Name)
                      .ProcedureQuery(Business.DBConn.ServidorLocal, "[Request].[StateProcedures]");

                    if (bl.Exception != null)
                    {
                        result.State = 1;
                        result.Message = bl.Exception;
                    }
                    else
                    {
                        result.State = Convert.ToInt32(bl.GetParamValue("@StatusOut"));
                        result.Message = bl.GetParamValue("@MessageOut").ToString();
                    }

                }
                catch (SqlException ex)
                {
                    result.State = ex.State;
                    result.Message = ex.Message;
                }
            }
            return result;
        }

        public static List<State> GetStates()
        {
            var spOption = 2;
            List<State> states = new List<State>();
            using(var bl = new Business())
            {
                try
                {
                    DataTable dt = bl.AddParam("@SPOption", spOption)
                        .ProcedureDataTable(Business.DBConn.ServidorLocal, "[Request].[StateProcedures]");
                    if(dt.Rows.Count > 0)
                    {
                        states = new List<State>();
                        foreach(DataRow item in dt.Rows)
                        {
                            states.Add(new State()
                            {
                                State_Id = Convert.ToInt32(item["State_Id"]),
                                State_Name = item["State_Name"].ToString(),
                                Creation_Date = item["Creation_Date"].ToString()
                            });
                        }
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return states;
        }

        #endregion


        #region City


        #endregion


        #region CustomerType


        #endregion


        #region UserType


        #endregion


        #region Status

        #endregion


        #region STOPs

        #endregion


        #region OperationType

        #endregion

        #region User

        #endregion


        #region Customer

        #endregion
    }
}
