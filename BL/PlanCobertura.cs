using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BL
{
    public class PlanCobertura
    {
        public static BL.Result CoberturaGetByIdPlan(int idPlan)
        {
            BL.Result result = new BL.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string query = "CoberturaGetByIdPlan";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[1];
                        collection[0] = new SqlParameter("IdPlan", SqlDbType.Int);
                        collection[0].Value = idPlan;

                        cmd.Parameters.AddRange(collection);

                        DataTable tableCoberturas = new DataTable();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(tableCoberturas);

                        result.Objects = new List<object>();

                        if (tableCoberturas.Rows.Count > 0)
                        {


                            foreach (DataRow row in tableCoberturas.Rows)
                            {
                                BL.PlanCoberturaM planCobertura = new BL.PlanCoberturaM();
                                planCobertura.IdPlanCobertura= int.Parse(row[0].ToString());

                                planCobertura.Cobertura = new BL.CoberturaM();
                                planCobertura.Cobertura.IdCobertura = int.Parse(row[1].ToString());
                                planCobertura.Cobertura.Nombre = row[2].ToString();
                                planCobertura.Cobertura.Descripcion = row[3].ToString();
                                planCobertura.Cobertura.FechaModificacion = row[4].ToString();

                                result.Objects.Add(planCobertura);
                            }

                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "No tiene coberturas asignados";
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

        public static BL.Result CoberturasNoAsignadasByIdPlan(int idPlan)
        {
            BL.Result result = new BL.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    var query = "CoberturaNoAsignadaByIdPlan";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;
                        
                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("IdPlan", SqlDbType.Int);
                        collection[0].Value = idPlan;

                        cmd.Parameters.AddRange(collection);

                        DataTable tableCoberturaNoAsignada = new DataTable();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(tableCoberturaNoAsignada);

                        result.Objects = new List<object>();

                        if (tableCoberturaNoAsignada.Rows.Count > 0)
                        {
                            foreach (DataRow row in tableCoberturaNoAsignada.Rows)
                            {
                                BL.PlanCoberturaM planCoberturaItem = new BL.PlanCoberturaM();

                                planCoberturaItem.Cobertura = new BL.CoberturaM();
                                planCoberturaItem.Cobertura.IdCobertura = int.Parse(row[0].ToString());
                                planCoberturaItem.Cobertura.Nombre = row[1].ToString();
                                planCoberturaItem.Cobertura.Descripcion = row[2].ToString();

                                result.Objects.Add(planCoberturaItem);
                            }

                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "El plan, ya tiene todas las coberturas asignadas";
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

        public static BL.Result CoberturaDeleteByIdPlanCobertura(int idPlanCobertura)
        {
            BL.Result result = new BL.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string query = "CoberturaDeleteByIdPlanCobertura";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("IdPlanCobertura", SqlDbType.Int);
                        collection[0].Value = idPlanCobertura;

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
                            result.ErrorMessage = "Error al eliminar la cobertura";
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

        public static BL.Result PlanCoberturaAdd(int idPlan, int idCobertura)
        {
            BL.Result result = new BL.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string query = "PlanCoberturaAdd";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[2];

                        collection[0] = new SqlParameter("IdPlan", SqlDbType.Int);
                        collection[0].Value = idPlan;

                        collection[1] = new SqlParameter("IdCobertura", SqlDbType.Int);
                        collection[1].Value = idCobertura;

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
                            result.ErrorMessage = "Error al agregar cobertura al plan";
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
