using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Runtime.Remoting.Contexts;

namespace BL
{
    public class Plan
    {
        //ADO .Net
        public static BL.Result GetAll()
        {
            BL.Result result = new BL.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string query = "PlanGetAll";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;

                        DataTable tablaPlan = new DataTable();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);

                        da.Fill(tablaPlan);

                        result.Objects = new List<object>();

                        if (tablaPlan.Rows.Count > 0)
                        {
                            foreach (DataRow row in tablaPlan.Rows)
                            {
                                BL.PlanM plan = new BL.PlanM();
                                plan.IdPlan = int.Parse(row[0].ToString());
                                plan.Nombre = row[1].ToString();
                                plan.Descripcion = row[2].ToString();
                                plan.FechaModificacion = row[3].ToString();

                                result.Objects.Add(plan);
                            }

                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "No existen registros en la tabla de planes";
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

        public static BL.Result GetById(int idPlan)
        {
            BL.Result result = new Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string query = "PlanGetByid";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("IdPlan", SqlDbType.Int);
                        collection[0].Value = idPlan;

                        cmd.Parameters.AddRange(collection);

                        DataTable tablePlan= new DataTable();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(tablePlan);

                        result.Objects = new List<object>();

                        if (tablePlan.Rows.Count > 0)
                        {
                            DataRow row = tablePlan.Rows[0];

                            BL.PlanM plan = new BL.PlanM();
                            plan.IdPlan = int.Parse(row[0].ToString());
                            plan.Nombre = row[1].ToString();
                            plan.Descripcion = row[2].ToString();
                            plan.FechaModificacion = row[3].ToString();

                            result.Object = plan;
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "Error al obtener registro";
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

        //Entity Framework
        public static BL.Result Add(BL.PlanM plan)
        {
            BL.Result result = new Result();

            try
            {
                using (DL.ExamenBabelEntities3 context = new DL.ExamenBabelEntities3())
                {
                    int resultQuery = context.PlanAdd(plan.Nombre, plan.Descripcion);

                    if (resultQuery > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Error al agregar plan";
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

        public static BL.Result Update(BL.PlanM plan)
        {
            BL.Result result = new BL.Result();

            try
            {
                using (DL.ExamenBabelEntities3 context = new DL.ExamenBabelEntities3())
                {
                    int resultQuery = context.PlanUpdate(plan.IdPlan, plan.Nombre, plan.Descripcion);

                    if (resultQuery > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Error al actualizar registro";
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

        public static BL.Result Delete(int idPlan)
        {
            BL.Result result = new Result();

            try
            {
                using (DL.ExamenBabelEntities3 context = new DL.ExamenBabelEntities3())
                {
                    int resultQuery = context.PlanDelete(idPlan);

                    if (resultQuery > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Error al eliminar registro";
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
