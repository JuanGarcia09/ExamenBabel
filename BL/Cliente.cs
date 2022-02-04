using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;

namespace BL
{
    public class Cliente
    {
    
        //ADO .net
        public static BL.Result GetAll()
        {
            BL.Result result = new BL.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string query = "ClienteGetAll";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;

                        DataTable tablaCliente = new DataTable();

                        SqlDataAdapter da = new SqlDataAdapter(cmd);

                        da.Fill(tablaCliente);

                        result.Objects = new List<Object>();

                        if (tablaCliente.Rows.Count > 0)
                        {                           
                            foreach (DataRow row in tablaCliente.Rows)
                            {
                                BL.ClienteM cliente = new BL.ClienteM();
                                cliente.IdCliente = int.Parse(row[0].ToString());
                                cliente.Nombre = row[1].ToString();
                                cliente.ApellidoPaterno = row[2].ToString();
                                cliente.ApellidoMaterno = row[3].ToString();
                                cliente.Sexo = row[4].ToString();
                                cliente.Email = row[5].ToString();
                                cliente.Telefono = row[6].ToString();
                                cliente.FechaModificacion = row[7].ToString();                                

                                result.Objects.Add(cliente);
                            }

                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "No existen registros en la tabla de clientes";
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

        public static BL.Result GetById(int idCliente)
        {
            BL.Result result = new BL.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string query = "ClienteGetById";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("IdCliente", SqlDbType.Int);
                        collection[0].Value = idCliente;

                        cmd.Parameters.AddRange(collection);

                        DataTable tablaCliente = new DataTable();

                        SqlDataAdapter da = new SqlDataAdapter(cmd);

                        da.Fill(tablaCliente);

                        if (tablaCliente.Rows.Count > 0)
                        {
                            DataRow Row = tablaCliente.Rows[0];

                            BL.ClienteM cliente = new BL.ClienteM();
                            cliente.IdCliente = int.Parse(Row[0].ToString());
                            cliente.Nombre = Row[1].ToString();
                            cliente.ApellidoPaterno = Row[2].ToString();
                            cliente.ApellidoMaterno = Row[3].ToString();
                            cliente.Sexo = Row[4].ToString();
                            cliente.Email = Row[5].ToString();
                            cliente.Telefono = Row[6].ToString();
                            cliente.FechaModificacion = Row[7].ToString();                            
                            result.Object = cliente;

                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "No existe registro del usuario";
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
        public static BL.Result Update(BL.ClienteM cliente)
        {
            BL.Result result = new BL.Result();

            try
            {
                using (DL.ExamenBabelEntities3 context = new DL.ExamenBabelEntities3())
                {
                    int resultQuery = context.ClienteUpdate(cliente.IdCliente, cliente.Nombre, cliente.ApellidoPaterno, cliente.ApellidoMaterno, cliente.Sexo, cliente.Email, cliente.Telefono);
                 
                        if (resultQuery > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "No se pudo actualizar el usuario";
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

        public static BL.Result Add(BL.ClienteM cliente)
        {
            BL.Result result = new BL.Result();

            try
            {
                using (DL.ExamenBabelEntities3 context = new DL.ExamenBabelEntities3())
                {                                     
                    int resulQuery = context.ClienteAdd(cliente.Nombre,cliente.ApellidoPaterno, cliente.ApellidoMaterno, cliente.Sexo, cliente.Email, cliente.Telefono);
                                         

                        if (resulQuery > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "No se pudo ingresar datos en la tabla clientes";
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
        
        public static BL.Result Delete(int idCliente)
        {
            BL.Result result = new BL.Result();

            try
            {
                using (DL.ExamenBabelEntities3 context = new DL.ExamenBabelEntities3())
                {
                    int resultQuery = context.ClienteDelete(idCliente);

              

                        if (resultQuery > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "No se pudo eliminar el usuario indicado";
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
