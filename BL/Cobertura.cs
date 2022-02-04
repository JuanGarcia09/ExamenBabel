using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace BL
{
    public class Cobertura
    {
        //ADO .Net
        public static BL.Result GetAll()
        {
            BL.Result result = new BL.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string query = "CoberturaGetAll";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;

                        DataTable tablaCobertura = new DataTable();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);

                        da.Fill(tablaCobertura);

                        result.Objects = new List<object>();

                        if (tablaCobertura.Rows.Count > 0)
                        {
                            foreach (DataRow row in tablaCobertura.Rows)
                            {
                                BL.CoberturaM cobertura = new BL.CoberturaM();
                                cobertura.IdCobertura = int.Parse(row[0].ToString());
                                cobertura.Nombre = row[1].ToString();
                                cobertura.Descripcion = row[2].ToString();
                                cobertura.FechaModificacion = row[3].ToString();

                                result.Objects.Add(cobertura);
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

        public static BL.Result GetById(int idCobertura)
        {
            BL.Result result = new Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string query = "CoberturaGetById";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("IdCobertura", SqlDbType.Int);
                        collection[0].Value = idCobertura;

                        cmd.Parameters.AddRange(collection);

                        DataTable tableCobertura = new DataTable();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(tableCobertura);

                        result.Objects = new List<object>();

                        if (tableCobertura.Rows.Count > 0)
                        {
                            DataRow row = tableCobertura.Rows[0];
                            
                            BL.CoberturaM cobertura = new BL.CoberturaM();
                            cobertura.IdCobertura= int.Parse(row[0].ToString());
                            cobertura.Nombre = row[1].ToString();
                            cobertura.Descripcion = row[2].ToString();
                            cobertura.FechaModificacion = row[3].ToString();

                            result.Object = cobertura;
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
        public static BL.Result Add(BL.CoberturaM cobertura)
        {
            BL.Result result = new Result();

            try
            {
                using (DL.ExamenBabelEntities3 context = new DL.ExamenBabelEntities3())
                {
                    int resultQuery = context.CoberturaAdd(cobertura.Nombre, cobertura.Descripcion);

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

        public static BL.Result Update(BL.CoberturaM cobertura)
        {
            BL.Result result = new BL.Result();

            try
            {
                using (DL.ExamenBabelEntities3 context = new DL.ExamenBabelEntities3())
                {
                    int resultQuery = context.CoberturaUpdate(cobertura.IdCobertura, cobertura.Nombre, cobertura.Descripcion);

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

        public static BL.Result Delete(int idCobertura)
        {
            BL.Result result = new Result();

            try
            {
                using (DL.ExamenBabelEntities3 context = new DL.ExamenBabelEntities3())
                {
                    int resultQuery = context.CoberturaDelete(idCobertura);

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
