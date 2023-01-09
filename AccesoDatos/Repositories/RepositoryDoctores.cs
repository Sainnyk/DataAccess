using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.Models;


namespace AccesoDatos.Repositories
{
    public class RepositoryDoctores
    {
        string connectionString;
        SqlConnection cn;
        SqlCommand com;
        SqlDataReader reader;

        //CONSTRUCTOR

        public RepositoryDoctores()
        {
            this.connectionString = @"Data Source=LOCALHOST\SQLEXPRESS;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=SA";
            this.cn = new SqlConnection(this.connectionString);
            this.com = new SqlCommand();

            this.com.Connection = cn;
            this.com.CommandType = System.Data.CommandType.Text;
        }

        public int InsertarDoctor(int idhospital, int iddoctor,string apellido,string especialidad, int salario)
        {
            string sql = "INSERT INTO DOCTOR VALUES(@IDH,@IDD,@APELLIDO,@ESPECIALIDAD,@SALARIO)";
            SqlParameter pamidhospital = new SqlParameter("@IDH",idhospital);
            SqlParameter pamiddoctor = new SqlParameter("@IDD", iddoctor);
            SqlParameter pamapellido = new SqlParameter("@APELLIDO", apellido);
            SqlParameter pamespecialidad = new SqlParameter("@ESPECIALIDAD", especialidad);
            SqlParameter pamsalario = new SqlParameter("@SALARIO",salario);

            this.com.Parameters.Add(pamidhospital);
            this.com.Parameters.Add(pamiddoctor);
            this.com.Parameters.Add(pamapellido);
            this.com.Parameters.Add(pamespecialidad);
            this.com.Parameters.Add(pamsalario);

            this.com.CommandText = sql;

            this.cn.Open();
            int insertados = this.com.ExecuteNonQuery();
            this.cn.Close();
            this.com.Parameters.Clear();

            return insertados;
        }

        public int UpdateDoctor(int idhospital, int iddoctor, string apellido, string especialidad, int salario)
        {
            string sql = "UPDATE DOCTOR SET HOSPITAL_COD =@IDH, APELLIDO= @APELLIDO, ESPECIALIDAD=@ESP, SALARIO = @SALARIO WHERE DOCTOR_NO=@IDD";
            SqlParameter pamidh = new SqlParameter("@IDH", idhospital);
            SqlParameter pamidd = new SqlParameter("@IDD", iddoctor);
            SqlParameter pamapellido = new SqlParameter("@APELLIDO", apellido);
            SqlParameter pamespecialidad = new SqlParameter("@ESP", especialidad);
            SqlParameter pamsalario = new SqlParameter("@SALARIO", salario);

            this.com.Parameters.Add(pamidh);
            this.com.Parameters.Add(pamidd);
            this.com.Parameters.Add(pamapellido);
            this.com.Parameters.Add(pamespecialidad);
            this.com.Parameters.Add(pamsalario);

            this.com.CommandText = sql;

            this.cn.Open();
            int modificados = this.com.ExecuteNonQuery();
            this.cn.Close();
            this.com.Parameters.Clear();
            return modificados;
        }

        public int DeleteDoctor(int iddoctor)
        {
            string sql = "DELETE FROM DOCTOR WHERE DOCTOR_NO=@ID";
            SqlParameter pamid = new SqlParameter("@ID", iddoctor);
            this.com.Parameters.Add(pamid);

            this.com.CommandText = sql;
          
            this.cn.Open();
            int eliminados = this.com.ExecuteNonQuery();
            this.cn.Close();
            this.com.Parameters.Clear();

            return eliminados;
        }

        public List<Doctor> GetDoctores()
        {
            List<Doctor> doctores = new List<Doctor>();
            string sql = "SELECT * FROM DOCTOR";

            this.com.CommandText = sql;

            this.cn.Open();
            this.reader = this.com.ExecuteReader();

            while (reader.Read())
            {
                Doctor doctor = new Doctor();
                doctor.IdHospital = int.Parse(this.reader["HOSPITAL_COD"].ToString());
                doctor.IdDoctor = int.Parse(this.reader["DOCTOR_NO"].ToString()) ;
                doctor.Salario = int.Parse(this.reader["SALARIO"].ToString());
                doctor.Apellido = this.reader["APELLIDO"].ToString();
                doctor.Especialidad = this.reader["ESPECIALIDAD"].ToString();

                doctores.Add(doctor);
            }
            this.cn.Close();
            this.reader.Close();

            return doctores;
        }
    }
}
