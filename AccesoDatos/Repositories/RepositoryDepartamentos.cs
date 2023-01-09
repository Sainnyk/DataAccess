using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Reflection.Metadata.Ecma335;
using AccesoDatos.Models;

namespace AccesoDatos.Repositories
{
    public class RepositoryDepartamentos
    {
        //DECLARAMOS los objetos que vamos a usar
        //Como son variables DENTRO de un metodo, van en minuscula.
        string connectionString;
        SqlConnection cn;
        SqlCommand com;
        SqlDataReader reader;


        //Se INSTANCIA los objetos declarados con el constructor

        public RepositoryDepartamentos()
        {
            this.connectionString = @"Data Source=LOCALHOST\SQLEXPRESS;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=SA";
            this.cn = new SqlConnection(connectionString);
            this.com = new SqlCommand();

            this.com.Connection = this.cn;
            this.com.CommandType = System.Data.CommandType.Text;
        }

        //Creamos los métodos para las consultas necesarias
        public int InsertarDepartamento(int id, string nombre, string localidad)
        {
            string sql = "INSERT INTO DEPT VALUES (@ID,@NOMBRE,@LOCALIDAD)";

            SqlParameter pamid = new SqlParameter("@ID", id);
            SqlParameter pamnombre = new SqlParameter("@NOMBRE", nombre);
            SqlParameter pamlocalidad = new SqlParameter("@LOCALIDAD", localidad);

            this.com.Parameters.Add(pamid);
            this.com.Parameters.Add(pamnombre);
            this.com.Parameters.Add(pamlocalidad);

            this.com.CommandText = sql;

            this.cn.Open();
            int insertados = com.ExecuteNonQuery();
            this.cn.Close();
            this.com.Parameters.Clear();
            
            return insertados;
        }

        public int DeleteDepartamento(int id)
        {
            string sql = "DELETE FROM DEPT WHERE DEPT_NO=@ID";
            SqlParameter pamid = new SqlParameter("@ID", id);
            this.com.Parameters.Add(pamid);
            this.com.CommandText = sql;

            this.cn.Open();
            int eliminados =this.com.ExecuteNonQuery();
            this.cn.Close();
            this.com.Parameters.Clear();
            return eliminados;
        }

        public int UpdateDepartamento(int id, string nombre, string localidad)
        {
            string sql = "UPDATE DEPT SET DNOMBRE =@NOMBRE, LOC=@LOCALIDAD WHERE DEPT_NO=@ID";
            SqlParameter pamid = new SqlParameter("@ID", id);
            SqlParameter pamnombre = new SqlParameter("@NOMBRE", nombre);
            SqlParameter pamlocalidad = new SqlParameter("@LOCALIDAD", localidad);

            this.com.Parameters.Add(pamid);
            this.com.Parameters.Add(pamnombre);
            this.com.Parameters.Add(pamlocalidad);

            this.com.CommandText = sql;

            this.cn.Open();
            int modificados = this.com.ExecuteNonQuery();
            this.cn.Close();
            this.com.Parameters.Clear();

            return modificados;
        }

        public List<Departamento> GetDepartamentos()
        {
            string sql = "SELECT * FROM DEPT";
            this.com.CommandText = sql;

            this.cn.Open();
            this.reader = this.com.ExecuteReader();
            //CREAMOS LA COLECCION PARa DEVOLVER LOS DATOs
            List<Departamento> lista = new List<Departamento>();

            while (reader.Read())
            {
                //Por cada vuelta de bucle (por cada registro, fila) creamos un objeto departamento y damos valor a sus propiedades
                Departamento dept = new Departamento();
                dept.IdDepartamento = int.Parse(this.reader["DEPT_NO"].ToString());
                dept.Nombre = this.reader["DNOMBRE"].ToString();
                dept.Localidad = this.reader["LOC"].ToString();

                //Agregamos cada departamento a la coleccion
                lista.Add(dept);
            }
            this.reader.Close();
            this.cn.Close();
            return lista;
        }
    }
}
