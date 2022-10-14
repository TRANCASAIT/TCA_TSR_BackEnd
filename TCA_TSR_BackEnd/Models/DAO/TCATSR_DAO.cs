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
                      .AddParam("@User_Logged", _state.User_Logged)
                      .AddParam("@StatusOut", DBNull.Value, true, 100)
                      .AddParam("@MessageOut", DBNull.Value, true, 300)
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

        public static Result UpdateState(StatePut statePut)
        {
            Result result = new Result();
            var spOption = 2;
            using (var bl = new Business())
            {
                try
                {
                    bl
                        .AddParam("@State_Id", statePut.State_Id)
                        .AddParam("@State_Name", statePut.State_Name)
                        .AddParam("@User_Logged", statePut.User_Logged)
                        .AddParam("@StatusOut", DBNull.Value, true, 100)
                        .AddParam("@MessageOut", DBNull.Value, true, 300)
                        .AddParam("@SPOption", spOption)
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
            var spOption = 3;
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
        public static Result StoreCustomerType(CustomerTypePost _obj)
        {
            Result result = new Result();
            int spOption = 1;
            using (var bl = new Business())
            {
                try
                {
                    bl
                      .AddParam("@SpOption", spOption)
                      .AddParam("@CustomerType_Name", _obj.CustomerType_Name)
                      .AddParam("@User_Logged", _obj.User_Logged)
                      .AddParam("@StatusOut", DBNull.Value, true, 100)
                      .AddParam("@MessageOut", DBNull.Value, true, 300)
                      .ProcedureQuery(Business.DBConn.ServidorLocal, "[Request].[CustomerTypeProcedures]");

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

        public static Result UpdateCustomerType(CustomerTypePut _obj)
        {
            Result result = new Result();
            var spOption = 2;
            using (var bl = new Business())
            {
                try
                {
                    bl
                        .AddParam("@CustomerType_Id", _obj.CustomerType_Id)
                        .AddParam("@CustomerType_Name", _obj.CustomerType_Name)
                        .AddParam("@User_Logged", _obj.User_Logged)
                        .AddParam("@StatusOut", DBNull.Value, true, 100)
                        .AddParam("@MessageOut", DBNull.Value, true, 300)
                        .AddParam("@SPOption", spOption)
                        .ProcedureQuery(Business.DBConn.ServidorLocal, "[Request].[CustomerTypeProcedures]");

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

        public static List<CustomerType> GetCustomerTypes()
        {
            var spOption = 3;
            List<CustomerType> customerTypes = new List<CustomerType>();
            using (var bl = new Business())
            {
                try
                {
                    DataTable dt = bl.AddParam("@SPOption", spOption)
                        .ProcedureDataTable(Business.DBConn.ServidorLocal, "[Request].[CustomerTypeProcedures]");
                    if (dt.Rows.Count > 0)
                    {
                        customerTypes = new List<CustomerType>();
                        foreach (DataRow item in dt.Rows)
                        {
                            customerTypes.Add(new CustomerType()
                            {
                                CustomerType_Id = Convert.ToInt32(item["CustomerType_Id"]),
                                CustomerType_Name = item["CustomerType_Name"].ToString(),
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
            return customerTypes;
        }

        #endregion


        #region UserType

        public static Result StoreUserType(UserTypePost _obj)
        {
            Result result = new Result();
            int spOption = 1;
            using (var bl = new Business())
            {
                try
                {
                    bl
                      .AddParam("@SpOption", spOption)
                      .AddParam("@UserType_Name", _obj.UserType_Name)
                      .AddParam("@User_Logged", _obj.User_Logged)
                      .AddParam("@StatusOut", DBNull.Value, true, 100)
                      .AddParam("@MessageOut", DBNull.Value, true, 300)
                      .ProcedureQuery(Business.DBConn.ServidorLocal, "[Request].[UserTypeProcedures]");

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

        public static Result UpdateUserType(UserTypePut _obj)
        {
            Result result = new Result();
            var spOption = 2;
            using (var bl = new Business())
            {
                try
                {
                    bl
                        .AddParam("@UserType_Id", _obj.UserType_Id)
                        .AddParam("@UserType_Name", _obj.UserType_Name)
                        .AddParam("@User_Logged", _obj.User_Logged)
                        .AddParam("@StatusOut", DBNull.Value, true, 100)
                        .AddParam("@MessageOut", DBNull.Value, true, 300)
                        .AddParam("@SPOption", spOption)
                        .ProcedureQuery(Business.DBConn.ServidorLocal, "[Request].[UserTypeProcedures]");

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

        public static List<UserType> GetUserTypes()
        {
            var spOption = 3;
            List<UserType> userTypes = new List<UserType>();
            using (var bl = new Business())
            {
                try
                {
                    DataTable dt = bl.AddParam("@SPOption", spOption)
                        .ProcedureDataTable(Business.DBConn.ServidorLocal, "[Request].[UserTypeProcedures]");
                    if (dt.Rows.Count > 0)
                    {
                        userTypes = new List<UserType>();
                        foreach (DataRow item in dt.Rows)
                        {
                            userTypes.Add(new UserType()
                            {
                                UserType_Id = Convert.ToInt32(item["UserType_Id"]),
                                UserType_Name = item["UserType_Name"].ToString(),
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
            return userTypes;
        }

        #endregion


        #region Status
        public static Result StoreStatus(StatusPost _status)
        {
            Result result = new Result();
            int spOption = 1;
            using (var bl = new Business())
            {
                try
                {
                    bl
                      .AddParam("@SpOption", spOption)
                      .AddParam("@Status_Description", _status.Status_Description)
                      .AddParam("@User_Logged", _status.User_Logged)
                      .AddParam("@StatusOut", DBNull.Value, true, 100)
                      .AddParam("@MessageOut", DBNull.Value, true, 300)
                      .ProcedureQuery(Business.DBConn.ServidorLocal, "[Request].[StatusProcedures]");

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

        public static List<Status> GetStatus()
        {
            var spOption = 2;
            List<Status> status = new List<Status>();
            using (var bl = new Business())
            {
                try
                {
                    DataTable dt = bl.AddParam("@SPOption", spOption)
                        .ProcedureDataTable(Business.DBConn.ServidorLocal, "[Request].[StatusProcedures]");
                    if (dt.Rows.Count > 0)
                    {
                        status = new List<Status>();
                        foreach (DataRow item in dt.Rows)
                        {
                            status.Add(new Status()
                            {
                                Status_Id = Convert.ToInt32(item["State_Id"]),
                                Status_Description = item["State_Name"].ToString(),
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
            return status;
        }

        public static Result UpdateStatus(StatusPut statusPut)
        {
            Result result = new Result();
            var spOption = 3;
            using (var bl = new Business())
            {
                try
                {
                    bl
                        .AddParam("@Status_Id", statusPut.Status_Id)
                        .AddParam("@Status_Description", statusPut.Status_Description)
                        .AddParam("@User_Logged", statusPut.User_Logged)
                        .AddParam("@StatusOut", DBNull.Value, true, 100)
                        .AddParam("@MessageOut", DBNull.Value, true, 300)
                        .AddParam("@SPOption", spOption)
                        .ProcedureQuery(Business.DBConn.ServidorLocal, "[Request].[StatusProcedures]");

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
        #endregion


        #region STOPs

        #endregion


        #region OperationType

        public static Result StoreOperationType(OperationTypePost _obj)
        {
            Result result = new Result();
            int spOption = 1;
            using (var bl = new Business())
            {
                try
                {
                    bl
                      .AddParam("@SpOption", spOption)
                      .AddParam("@OperationType_Name", _obj.OperationType_Name)
                      .AddParam("@User_Logged", _obj.User_Logged)
                      .AddParam("@StatusOut", DBNull.Value, true, 100)
                      .AddParam("@MessageOut", DBNull.Value, true, 300)
                      .ProcedureQuery(Business.DBConn.ServidorLocal, "[Request].[OperationTypeProcedures]");

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

        public static Result UpdateOperationType(OperationTypePut _obj)
        {
            Result result = new Result();
            var spOption = 2;
            using (var bl = new Business())
            {
                try
                {
                    bl
                        .AddParam("@OperationType_Id", _obj.OperationType_Id)
                        .AddParam("@OperationType_Name", _obj.OperationType_Name)
                        .AddParam("@User_Logged", _obj.User_Logged)
                        .AddParam("@StatusOut", DBNull.Value, true, 100)
                        .AddParam("@MessageOut", DBNull.Value, true, 300)
                        .AddParam("@SPOption", spOption)
                        .ProcedureQuery(Business.DBConn.ServidorLocal, "[Request].[OperationTypeProcedures]");

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

        public static List<OperationType> GetOperationTypes()
        {
            var spOption = 3;
            List<OperationType> operationTypes = new List<OperationType>();
            using (var bl = new Business())
            {
                try
                {
                    DataTable dt = bl.AddParam("@SPOption", spOption)
                        .ProcedureDataTable(Business.DBConn.ServidorLocal, "[Request].[OperationTypeProcedures]");
                    if (dt.Rows.Count > 0)
                    {
                        operationTypes = new List<OperationType>();
                        foreach (DataRow item in dt.Rows)
                        {
                            operationTypes.Add(new OperationType()
                            {
                                OperationType_Id = Convert.ToInt32(item["OperationType_Id"]),
                                OperationType_Name = item["OperationType_Name"].ToString(),
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
            return operationTypes;
        }

        public static Result UpdateOperationTypeStatus(OperationTypePutState operationTypePutState)
        {
            Result result = new Result();
            var spOption = 4;
            using(var bl = new Business())
            {
                try
                {
                    bl
                      .AddParam("@OperationType_Id",operationTypePutState.OperationType_Id)
                      .AddParam("@Status",operationTypePutState.Status)
                      .AddParam("@User_Logger",operationTypePutState.User_Logged)
                      .AddParam("@SPOption",spOption)
                      .AddParam("@StatusOut",DBNull.Value, true, 100)
                      .AddParam("@MessageOut",DBNull.Value, true, 300)
                      .ProcedureQuery(Business.DBConn.ServidorLocal, "[Request].[OperationTypeProcedures]")

                }
                catch (SqlException ex)
                {
                    result.State = Convert.ToInt32(bl.GetParamValue("@StatusOut"));
                    result.Message = bl.GetParamValue("@MessageOut").ToString();
                    
                }
            }
            return result;
        }

        #endregion


        #region User

        #endregion


        #region Customer

        #endregion
    }
}
