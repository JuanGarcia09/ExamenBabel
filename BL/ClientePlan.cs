using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BL
{
    public class ClientePlan
    {
        public static BL.Result PlanesGetByIdCliente(int idCliente)
        {
            BL.Result result = new BL.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string query = "PlanGetByIdCliente";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[1];
                        collection[0] = new SqlParameter("IdCliente", SqlDbType.Int);
                        collection[0].Value = idCliente;

                        cmd.Parameters.AddRange(collection);

                        DataTable tablePlanes = new DataTable();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(tablePlanes);

                        result.Objects = new List<object>();

                         if (tablePlanes.Rows.Count > 0)
                        {
                        

                        foreach (DataRow row in tablePlanes.Rows)
                        {
                            BL.ClientePlanM clientePlan = new BL.ClientePlanM();                            
                            clientePlan.IdClientePlan = int.Parse(row[0].ToString());

                            clientePlan.Plan = new BL.PlanM();
                            clientePlan.Plan.IdPlan = int.Parse(row[1].ToString());
                            clientePlan.Plan.Nombre = row[2].ToString();
                            clientePlan.Plan.Descripcion = row[3].ToString();
                            clientePlan.Plan.FechaModificacion = row[4].ToString();

                            result.Objects.Add(clientePlan);
                        }

                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No tiene planes asignados";
                    }
                    }
                   
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;
        }

        public static BL.Result PlanesNoAsignadosByIdCliente(int idCliente)
        {
            BL.Result result = new BL.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    var query = "PlanNoAsignadoByIdCliente";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("IdCliente", SqlDbType.Int);
                        collection[0].Value = idCliente;

                        cmd.Parameters.AddRange(collection);

                        DataTable tablePlanesNoAsignados = new DataTable();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(tablePlanesNoAsignados);

                        result.Objects = new List<object>();

                        if (tablePlanesNoAsignados.Rows.Count > 0)
                        {                            
                            foreach (DataRow row in tablePlanesNoAsignados.Rows)
                            {
                                BL.ClientePlanM clientePlanItem = new BL.ClientePlanM();

                                clientePlanItem.Plan = new BL.PlanM();
                                clientePlanItem.Plan.IdPlan = int.Parse(row[0].ToString());
                                clientePlanItem.Plan.Nombre = row[1].ToString();
                                clientePlanItem.Plan.Descripcion = row[2].ToString();                                                                

                                result.Objects.Add(clientePlanItem);
                            }

                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "El cliente, ya tiene todos los planes asignados";
                        }
                    }
                    
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;
        }

        public static BL.Result PlanDeleteByIdClientePlan(int idClientePlan)
        {
            BL.Result result = new BL.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string query = "PlanDeleteByIdClientePlan";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("IdClientePlan",SqlDbType.Int);
                        collection[0].Value = idClientePlan;

                        cmd.Parameters.AddRange(collection);

                        cmd.Connection.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        cmd.Connection.Close();

                        if (rowsAffected > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "Error al eliminar el plan";
                        }
                    }                    
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;
        }

        public static BL.Result ClientePlanAdd(int idCliente, int idPlan)
        {
            BL.Result result = new BL.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string query = "ClientePlanAdd";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[2];

                        collection[0] = new SqlParameter("IdCliente", SqlDbType.Int);
                        collection[0].Value = idCliente;

                        collection[1] = new SqlParameter("IdPlan", SqlDbType.Int);
                        collection[1].Value = idPlan;

                        cmd.Parameters.AddRange(collection);

                        cmd.Connection.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        cmd.Connection.Close();

                        if (rowsAffected > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "Error al agregar plan al cliente";
                        }
                    }                   
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;
        }
    }
}
