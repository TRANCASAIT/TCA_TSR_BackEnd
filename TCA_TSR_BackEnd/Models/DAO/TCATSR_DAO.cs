using System.Data;
using System.Data.SqlClient;
using static TCA_TSR_BackEnd.Models.Customer;
using static TCA_TSR_BackEnd.Models.User;

namespace TCA_TSR_BackEnd.Models.DAO
{
    public class TCATSR_DAO
    {
        #region State

        public static Result StoreState(StatePost _state)
        {
            Result result = new Result();
            int spOption = 1;
            using (var bl = new Business())
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
            List<State> states = null;
            using (var bl = new Business())
            {
                try
                {
                    DataTable dt = bl.AddParam("@SPOption", spOption)
                        .ProcedureDataTable(Business.DBConn.ServidorLocal, "[Request].[StateProcedures]");
                    if (dt.Rows.Count > 0)
                    {
                        states = new List<State>();
                        foreach (DataRow item in dt.Rows)
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
        public static Result StoreCity(CityPost _obj)
        {
            Result result = new Result();
            int spOption = 1;
            using (var bl = new Business())
            {
                try
                {
                    bl
                      .AddParam("@SpOption", spOption)
                      .AddParam("@Ciy_Name", _obj.City_Name)
                      .AddParam("@State_Id", _obj.State_Id)
                      .AddParam("@User_Logged", _obj.User_Logged)
                      .AddParam("@StatusOut", DBNull.Value, true, 100)
                      .AddParam("@MessageOut", DBNull.Value, true, 300)
                      .ProcedureQuery(Business.DBConn.ServidorLocal, "[Request].[CityProcedures]");

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

        public static Result UpdateCity(CityPut _obj)
        {
            Result result = new Result();
            var spOption = 2;
            using (var bl = new Business())
            {
                try
                {
                    bl
                        .AddParam("@City_Id", _obj.City_Id)
                        .AddParam("@City_Name", _obj.City_Name)
                        .AddParam("@State_Id", _obj.State_Id)
                        .AddParam("@User_Logged", _obj.User_Logged)
                        .AddParam("@StatusOut", DBNull.Value, true, 100)
                        .AddParam("@MessageOut", DBNull.Value, true, 300)
                        .AddParam("@SPOption", spOption)
                        .ProcedureQuery(Business.DBConn.ServidorLocal, "[Request].[CityProcedures]");

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

        public static List<City> GetCities()
        {
            var spOption = 3;
            List<City> cities = null;
            using (var bl = new Business())
            {
                try
                {
                    DataTable dt = bl.AddParam("@SPOption", spOption)
                        .ProcedureDataTable(Business.DBConn.ServidorLocal, "[Request].[CityProcedures]");
                    if (dt.Rows.Count > 0)
                    {
                        cities = new List<City>();
                        foreach (DataRow item in dt.Rows)
                        {
                            cities.Add(new City()
                            {
                                City_Id = Convert.ToInt32(item["City_Id"]),
                                State_Id = Convert.ToInt32(item["State_Id"]),
                                City_Name = item["City_Name"].ToString(),
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
            return cities;
        }


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
            List<CustomerType> customerTypes = null;
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
            List<UserType> userTypes = null;
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
            var spOption = 3;
            List<Status> status = null;
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

        public static Result StoreStop(StopsPost _obj)
        {
            Result result = new Result();
            int spOption = 1;
            using (var bl = new Business())
            {
                try
                {
                    bl
                      .AddParam("@SpOption", spOption)
                      .AddParam("@Stop_Number", _obj.Stop_Number)
                      .AddParam("@User_Logged", _obj.User_Logged)
                      .AddParam("@StatusOut", DBNull.Value, true, 100)
                      .AddParam("@MessageOut", DBNull.Value, true, 300)
                      .ProcedureQuery(Business.DBConn.ServidorLocal, "[Request].[StopsProcedures]");

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

        public static Result UpdateStop(StopsPut stopsPut)
        {
            Result result = new Result();
            var spOption = 2;
            using (var bl = new Business())
            {
                try
                {
                    bl
                        .AddParam("@Stop_Id", stopsPut.Stop_Id)
                        .AddParam("@Stop_Number", stopsPut.Stop_Number)
                        .AddParam("@User_Logged", stopsPut.User_Logged)
                        .AddParam("@StatusOut", DBNull.Value, true, 100)
                        .AddParam("@MessageOut", DBNull.Value, true, 300)
                        .AddParam("@SPOption", spOption)
                        .ProcedureQuery(Business.DBConn.ServidorLocal, "[Request].[StopsProcedures]");

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

        public static List<Stops> GetStops()
        {
            var spOption = 3;
            List<Stops> stops = null;
            using (var bl = new Business())
            {
                try
                {
                    DataTable dt = bl.AddParam("@SPOption", spOption)
                        .ProcedureDataTable(Business.DBConn.ServidorLocal, "[Request].[StopsProcedures]");
                    if (dt.Rows.Count > 0)
                    {
                        stops = new List<Stops>();
                        foreach (DataRow item in dt.Rows)
                        {
                            stops.Add(new Stops()
                            {
                                Stop_Id = Convert.ToInt32(item["Stop_Id"]),
                                Stop_Number = Convert.ToInt32(item["Stop_Number"]),
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
            return stops;
        }

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
            List<OperationType> operationTypes = null;
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
            using (var bl = new Business())
            {
                try
                {
                    bl
                      .AddParam("@OperationType_Id", operationTypePutState.OperationType_Id)
                      .AddParam("@Status", operationTypePutState.Status)
                      .AddParam("@User_Logged", operationTypePutState.User_Logged)
                      .AddParam("@SPOption", spOption)
                      .AddParam("@StatusOut", DBNull.Value, true, 100)
                      .AddParam("@MessageOut", DBNull.Value, true, 300)
                      .ProcedureQuery(Business.DBConn.ServidorLocal, "[Request].[OperationTypeProcedures]");

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


        //TODO
        #region User
        public static Result StoreUser(UserPost _obj)
        {
            Result result = new Result();
            int spOption = 1;
            using (var bl = new Business())
            {
                try
                {
                    bl
                      .AddParam("@SpOption", spOption)
                      .AddParam("@UserName", _obj.UserName)
                      .AddParam("@Name", _obj.Name)
                      .AddParam("@Last_Name", _obj.Last_Name)
                      .AddParam("@Email", _obj.Email)
                      .AddParam("@Password", _obj.Password)
                      .AddParam("@UserType_Id", _obj.UserType_Id)
                      .AddParam("@Customer_Id", _obj.Customer_Id)
                      .AddParam("@User_Logged", _obj.User_Logged)
                      .AddParam("@StatusOut", DBNull.Value, true, 100)
                      .AddParam("@MessageOut", DBNull.Value, true, 300)
                      .ProcedureQuery(Business.DBConn.ServidorLocal, "[Request].[UserProcedures]");

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

        public static Result UpdateUser(UserPut _obj)
        {
            Result result = new Result();
            var spOption = 2;
            using (var bl = new Business())
            {
                try
                {
                    bl
                      .AddParam("@SpOption", spOption)
                      .AddParam("@User_Id", _obj.User_Id)
                      .AddParam("@UserName", _obj.UserName)
                      .AddParam("@Name", _obj.Name)
                      .AddParam("@Last_Name", _obj.Last_Name)
                      .AddParam("@Email", _obj.Email)
                      .AddParam("@Password", _obj.Password)
                      .AddParam("@UserType_Id", _obj.UserType_Id)
                      .AddParam("@Customer_Id", _obj.Customer_Id)
                      .AddParam("@User_Logged", _obj.User_Logged)
                      .AddParam("@StatusOut", DBNull.Value, true, 100)
                      .AddParam("@MessageOut", DBNull.Value, true, 300)
                      .ProcedureQuery(Business.DBConn.ServidorLocal, "[Request].[UserProcedures]");

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

        public static List<User> GetUsers()
        {
            var spOption = 3;
            List<User> users = null;
            using (var bl = new Business())
            {
                try
                {
                    DataTable dt = bl.AddParam("@SPOption", spOption)
                        .ProcedureDataTable(Business.DBConn.ServidorLocal, "[Request].[UserProcedures]");
                    if (dt.Rows.Count > 0)
                    {
                        users = new List<User>();
                        foreach (DataRow item in dt.Rows)
                        {
                            users.Add(new User()
                            {
                                User_Id = Convert.ToInt32(item["User_Id"]),
                                UserName = item["UserName"].ToString(),
                                Name = item["Name"].ToString(),
                                Last_Name = item["Last_Name"].ToString(),
                                Customer_Name = item["Customer_Name"].ToString(),
                                UserType_Name = item["UserType_Name"].ToString(),
                                Email = item["Email"].ToString(),
                                Status = Convert.ToBoolean(item["Status"]),
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
            return users;
        }

        public static Result UpdateUserStatus(UserPutStatus userPutStatus)
        {
            Result result = new Result();
            var spOption = 4;
            using (var bl = new Business())
            {
                try
                {
                    bl
                      .AddParam("@User_Id", userPutStatus.User_Id)
                      .AddParam("@Status", userPutStatus.Status)
                      .AddParam("@User_Logged", userPutStatus.User_Logged)
                      .AddParam("@SPOption", spOption)
                      .AddParam("@StatusOut", DBNull.Value, true, 100)
                      .AddParam("@MessageOut", DBNull.Value, true, 300)
                      .ProcedureQuery(Business.DBConn.ServidorLocal, "[Request].[UserProcedures]");

                }
                catch (SqlException ex)
                {
                    result.State = Convert.ToInt32(bl.GetParamValue("@StatusOut"));
                    result.Message = bl.GetParamValue("@MessageOut").ToString();

                }
            }
            return result;
        }

        public static User GetUserLogin(string userName, string password)
        {
            var spOption = 5;
            User _user = new User();
            using (var bl = new Business())
            {
                DataTable dtHeader = bl
                                   .AddParam("@SpOption", spOption)
                                   .AddParam("@UserName", userName)
                                   .AddParam("@Password", password)
                                   .ProcedureDataTable(Business.DBConn.ServidorLocal, "[Request].[UserProcedures]");

                if (dtHeader.Rows.Count > 0)
                {
                    _user.User_Id = Convert.ToInt32(dtHeader.Rows[0]["User_Id"]);
                    _user.Email = dtHeader.Rows[0]["Email"].ToString();
                    _user.UserName = dtHeader.Rows[0]["UserName"].ToString();
                    _user.UserType_Name = dtHeader.Rows[0]["UserType_Name"].ToString();
                    _user.UserType_Id = Convert.ToInt32(dtHeader.Rows[0]["UserType_Id"]); 
                    _user.Status = Convert.ToBoolean(dtHeader.Rows[0]["Status"]);
                }
            }
            return _user;
        }

        #endregion


        #region Customer
        public static Result StoreCustomer(CustomerPost _obj)
        {
            Result result = new Result();
            int spOption = 1;
            using (var bl = new Business())
            {
                try
                {
                    bl
                      .AddParam("@SpOption", spOption)
                      .AddParam("@CustomerName", _obj.CustomerName)
                      .AddParam("@Name", _obj.Name)
                      .AddParam("@RFC", _obj.RFC)
                      .AddParam("@Street", _obj.Street)
                      .AddParam("@StreetExt", _obj.StreetExt)
                      .AddParam("@StreetInt", _obj.StreetInt)
                      .AddParam("@ZipCode", _obj.ZipCode)
                      .AddParam("@Suburb", _obj.Suburb)
                      .AddParam("@City_Id", _obj.City_Id)
                      .AddParam("@State_Id", _obj.State_Id)
                      .AddParam("@CustomerType_Id", _obj.CustomerType_Id)
                      .AddParam("@PhoneNumber", _obj.PhoneNumber)
                      .AddParam("@Email", _obj.Email)
                      .AddParam("@Password", _obj.Password)
                      .AddParam("@User_Logged", _obj.User_Logged)
                      .AddParam("@StatusOut", DBNull.Value, true, 100)
                      .AddParam("@MessageOut", DBNull.Value, true, 300)
                      .ProcedureQuery(Business.DBConn.ServidorLocal, "[Request].[CustomerProcedures]");

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

        public static Result UpdateCustomer(CustomerPut _obj)
        {
            Result result = new Result();
            var spOption = 2;
            using (var bl = new Business())
            {
                try
                {
                    bl
                      .AddParam("@SpOption", spOption)
                      .AddParam("@Customer_Id", _obj.Customer_Id)
                      .AddParam("@CustomerName", _obj.CustomerName)
                      .AddParam("@Name", _obj.Name)
                      .AddParam("@RFC", _obj.RFC)
                      .AddParam("@Street", _obj.Street)
                      .AddParam("@StreetExt", _obj.StreetExt)
                      .AddParam("@StreetInt", _obj.StreetInt)
                      .AddParam("@ZipCode", _obj.ZipCode)
                      .AddParam("@Suburb", _obj.Suburb)
                      .AddParam("@City_Id", _obj.City_Id)
                      .AddParam("@State_Id", _obj.State_Id)
                      .AddParam("@CustomerType_Id", _obj.CustomerType_Id)
                      .AddParam("@PhoneNumber", _obj.PhoneNumber)
                      .AddParam("@Email", _obj.Email)
                      .AddParam("@User_Logged", _obj.User_Logged)
                      .AddParam("@StatusOut", DBNull.Value, true, 100)
                      .AddParam("@MessageOut", DBNull.Value, true, 300)
                      .ProcedureQuery(Business.DBConn.ServidorLocal, "[Request].[CustomerProcedures]");

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

        public static List<Customer> GetCustomers()
        {
            var spOption = 3;
            List<Customer> customers = null;
            using (var bl = new Business())
            {
                try
                {
                    DataTable dt = bl.AddParam("@SPOption", spOption)
                        .ProcedureDataTable(Business.DBConn.ServidorLocal, "[Request].[CustomerProcedures]");
                    if (dt.Rows.Count > 0)
                    {
                        customers = new List<Customer>();
                        foreach (DataRow item in dt.Rows)
                        {
                            customers.Add(new Customer()
                            {
                                Customer_Id = Convert.ToInt32(item["Customer_Id"]),
                                CustomerName = item["CustomerName"].ToString(),
                                Name = item["Name"].ToString(),
                                RFC = item["RFC"].ToString(),
                                Street = item["Street"].ToString(),
                                StreetExt = item["StreetExt"].ToString(),
                                StreetInt = item["StreetInt"].ToString(),
                                ZipCode = item["ZipCode"].ToString(),
                                Suburb = item["Suburb"].ToString(),
                                PhoneNumber = item["PhoneNumber"].ToString(),
                                CustomerType_Name = item["CustomerType_Name"].ToString(),
                                State_Name = item["State_Name"].ToString(),
                                City_Name = item["City_Name"].ToString(),
                                Email = item["Email"].ToString(),
                                Status = Convert.ToBoolean(item["Status"]),
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
            return customers;
        }

        public static Result UpdateCustomerStatus(CustomerPutStatus customerPutStatus)
        {
            Result result = new Result();
            var spOption = 4;
            using (var bl = new Business())
            {
                try
                {
                    bl
                      .AddParam("@Customer_Id", customerPutStatus.Customer_Id)
                      .AddParam("@Status", customerPutStatus.Status)
                      .AddParam("@User_Logged", customerPutStatus.User_Logged)
                      .AddParam("@SPOption", spOption)
                      .AddParam("@StatusOut", DBNull.Value, true, 100)
                      .AddParam("@MessageOut", DBNull.Value, true, 300)
                      .ProcedureQuery(Business.DBConn.ServidorLocal, "[Request].[CustomerProcedures]");

                }
                catch (SqlException ex)
                {
                    result.State = Convert.ToInt32(bl.GetParamValue("@StatusOut"));
                    result.Message = bl.GetParamValue("@MessageOut").ToString();

                }
            }
            return result;
        }

        public static Customer GetCustomerLogin(string customerName, string password)
        {
            var spOption = 5;
            Customer _obj = new Customer();
            using (var bl = new Business())
            {
                DataTable dtHeader = bl
                                   .AddParam("@SpOption", spOption)
                                   .AddParam("@CustomerName", customerName)
                                   .AddParam("@Password", password)
                                   .ProcedureDataTable(Business.DBConn.ServidorLocal, "[Request].[CustomerProcedures]");

                if (dtHeader.Rows.Count > 0)
                {
                    _obj.Customer_Id = Convert.ToInt32(dtHeader.Rows[0]["Customer_Id"]);
                    _obj.Email = dtHeader.Rows[0]["Email"].ToString();
                    _obj.CustomerName = dtHeader.Rows[0]["CustomerName"].ToString();
                    _obj.CustomerType_Name = dtHeader.Rows[0]["CustomerType_Name"].ToString();
                    _obj.Status = Convert.ToBoolean(dtHeader.Rows[0]["Status"]);
                }
            }
            return _obj;
        }
        #endregion
    }
}
