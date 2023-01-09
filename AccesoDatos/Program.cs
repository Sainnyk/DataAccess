using System.Data.SqlClient;
using AccesoDatos.Repositories;
using AccesoDatos.Models;

namespace AccesoDatos
{
    internal class Program
    {
        //CREAMOS NUESTRO REPOSITORIO
        //Se hace a nivel de clase para usar el objeto en distintos métodos.
        static RepositoryDepartamentos repo = new RepositoryDepartamentos(); //Se pone static para poder cogerlo en la parte de abajo

        static RepositoryDoctores repoDoctor = new RepositoryDoctores();



        static void Main(string[] args)
        {
            //LeerRegistroDept();
            //InsertarDept();
            //EliminarDeptParameters();
            //MostrarEmpleados();
            //ModificarSala();
            //EliminarEnfermos();
            //InsertDepartamentoRepo();
            //UpdateDepartamentoRepo();
            //DeleteDepartamentoRepo();
            //MostrarDepartamentos();
            //AppCrudDepartamentos();
            AppCrudDoctores();
        }
        static void AppCrudDoctores()
        {
            int opcion = -1;
            while (opcion != 5)
            {
                Console.WriteLine("-------------------CRUD DOCTORES---------------------");
                Console.WriteLine("----------------------------------------------------------");
                Console.WriteLine("1.- Insertar Doctor");
                Console.WriteLine("2.- Modificar Doctor");
                Console.WriteLine("3.- Eliminar Doctor");
                Console.WriteLine("4.- Mostrar todos los doctores");
                Console.WriteLine("5.- Incrementar salario");
                Console.WriteLine("6.- Salir de App");
                Console.WriteLine("Selecciona una opcion: ");
                opcion = int.Parse(Console.ReadLine());

                if (opcion == 1)
                {
                    InsertDoctorRepo();
                }
                else if (opcion == 2)
                {
                    UpdateDoctorRepo();
                }
                else if (opcion == 3)
                {
                    DeleteDoctorRepo();
                }
                else if (opcion == 4)
                {
                    MostrarDoctoresRepo();
                }else if (opcion == 5)
                {
                    AumentarSalarioRepo();
                }
                else if (opcion == 6)
                {
                    Console.WriteLine("Cerrando aplicación");
                }
                else
                {
                    Console.WriteLine("Opcion invalida");
                }
            }
        }
        static void AumentarSalarioRepo()
        {
            Console.WriteLine("Introduzca el SALARIO a incrementar");
            int salario = int.Parse(Console.ReadLine());
            Console.WriteLine("Introduzca el HOSPITAL a modificar");
            string hospital = Console.ReadLine();

            int modificados = repoDoctor.ModificarSalario(salario, hospital);

            Console.WriteLine("Registros modificados: " + modificados);
        }
        static void InsertDoctorRepo()
        {
            int id = repoDoctor.MaxIdDoctor();
            Console.WriteLine("El nuevo id sera: " + id);
            Console.WriteLine("Introduzca el NOMBRE del hospital: ");
            string hospital = Console.ReadLine();

            Console.WriteLine("Introduzca el APELLIDO del doctor: ");
            string apellido = Console.ReadLine();
            Console.WriteLine("Introduzca la ESPECIALIDAD del doctor: ");
            string especialidad = Console.ReadLine();
            Console.WriteLine("Introduzca el SALARIO del doctor: ");
            int salario = int.Parse(Console.ReadLine());

            int insertados = repoDoctor.InsertarDoctor(hospital, apellido,especialidad, salario);


            Console.WriteLine("Doctores insertados: " + insertados);
        }

        static void UpdateDoctorRepo()
        {
            Console.WriteLine("Inserte el ID del doctor a modificar: ");
            int iddoctor = int.Parse(Console.ReadLine());
            Console.WriteLine("Inserte el nuevo ID del hospital del doctor:");
            int iddhospital = int.Parse(Console.ReadLine());
            Console.WriteLine("Inserte el nuevo NOMBRE del doctor: ");
            string nombre = Console.ReadLine();
            Console.WriteLine("Inserte la nueva ESPECIALIDAD del doctor: ");
            string especialidad = Console.ReadLine();
            Console.WriteLine("Inserte el nuevo SALARIO: ");
            int salario = int.Parse(Console.ReadLine());

            int modificados = repoDoctor.UpdateDoctor(iddhospital,iddoctor,nombre,especialidad,salario);

            Console.WriteLine("Doctores modificados: " + modificados);
        }

        static void DeleteDoctorRepo()
        {
            Console.WriteLine("Inserte el ID del doctor a eliminar");
            int id = int.Parse(Console.ReadLine());

            int eliminados = repoDoctor.DeleteDoctor(id);

            Console.WriteLine("Doctores eliminados: "+ eliminados);
        }

        static void MostrarDoctoresRepo()
        {
            List<Doctor> doctores = repoDoctor.GetDoctores();

            foreach(Doctor doctor in doctores)
            {
                Console.WriteLine(doctor.IdHospital + " - " + doctor.IdDoctor + " - " + doctor.Apellido + " - " + doctor.Especialidad+ " - "+doctor.Salario);
            }
        }

        static void AppCrudDepartamentos()
        {
            int opcion = -1;
            while (opcion != 4)
            {
                Console.WriteLine("-------------------CRUD DEPARTAMENTOs---------------------");
                MostrarDepartamentos();
                Console.WriteLine("----------------------------------------------------------");
                Console.WriteLine("1.- Insertar Departamento");
                Console.WriteLine("2.- Modificar Departamento");
                Console.WriteLine("3.- Eliminar Departamento");
                Console.WriteLine("4.- Salir de App");
                Console.WriteLine("Selecciona una opcion: ");
                opcion = int.Parse(Console.ReadLine());

                if (opcion == 1)
                {
                    InsertDepartamentoRepo();
                }
                else if (opcion == 2)
                {
                    UpdateDepartamentoRepo();
                }
                else if (opcion == 3)
                {
                    DeleteDepartamentoRepo();
                }
                else if (opcion == 4)
                {
                    Console.WriteLine("Cerrando aplicación");
                }
                else
                {
                    Console.WriteLine("Opcion invalida");
                }
            }

        }
        static void MostrarDepartamentos()
        {
            List<Departamento> departamentos = repo.GetDepartamentos();

            foreach (Departamento dept in departamentos)
            {
                Console.WriteLine(dept.IdDepartamento + " - " + dept.Nombre + " - " + dept.Localidad);
            }
        }
        static void UpdateDepartamentoRepo()
        {
            Console.WriteLine("Inserte un ID a modificar: ");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Inserte un NOMBRE nuevo para el departamento: ");
            string nombre = Console.ReadLine();
            Console.WriteLine("Inserte una nueva LOCALIDAD: ");
            string localidad = Console.ReadLine();

            int modificados = repo.UpdateDepartamento(id, nombre, localidad);
            Console.WriteLine("Departamentos modificados: "+ modificados);
        }
        static void DeleteDepartamentoRepo()
        {
            Console.WriteLine("Inserte el ID a eliminar:");
            int id = int.Parse(Console.ReadLine());

            int eliminados = repo.DeleteDepartamento(id);
            Console.WriteLine("Departamentos eliminados: " + eliminados);
        }
        static void InsertDepartamentoRepo()
        {
            Console.WriteLine("Inserte un ID: ");
            int iddept = int.Parse(Console.ReadLine());

            Console.WriteLine("Inserte un NOMBRE de departamento: ");
            string nombre = Console.ReadLine();

            Console.WriteLine("Inserte LOCALIDAD: ");
            string localidad = Console.ReadLine();

            int insertados = repo.InsertarDepartamento(iddept, nombre, localidad);
            Console.WriteLine("Departamentos insertados: "+ insertados);
        }
        static void MostrarEnfermos()
        {
            string connectionString = @"Data Source=LOCALHOST\SQLEXPRESS;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=SA";

            SqlConnection cn = new SqlConnection(connectionString);
            SqlCommand com = new SqlCommand();

            SqlDataReader reader;

            string sql = "SELECT INSCRIPCION, APELLIDO, DIRECCION FROM ENFERMO";

            //CONFIGURACION
            com.Connection = cn;
            com.CommandType = System.Data.CommandType.Text;
            com.CommandText = sql;

            cn.Open();
            reader = com.ExecuteReader();
            Console.WriteLine("---------ENFERMOS---------");
            while (reader.Read())
            {
                string inscripcion = reader["INSCRIPCION"].ToString();
                string apellido = reader["APELLIDO"].ToString();
                string direccion = reader["DIRECCION"].ToString();
                Console.WriteLine("INSCRIPCION: " + inscripcion + " - " + apellido + " - " + direccion + '\n');
            }

            reader.Close();
            cn.Close();
        }
        static void EliminarEnfermos()
        {
            MostrarEnfermos();
            string connectionString = @"Data Source=LOCALHOST\SQLEXPRESS;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=SA";

            SqlConnection cn = new SqlConnection(connectionString);
            SqlCommand com = new SqlCommand();

            Console.WriteLine("Inserte la inscripcion del enfermo a eliminar: ");
            int inscripcionEnfermo = int.Parse(Console.ReadLine());

            string sql = "DELETE FROM ENFERMO WHERE INSCRIPCION=@ID";
            SqlParameter pamid = new SqlParameter("@ID", inscripcionEnfermo);
            com.Parameters.Add(pamid);

            com.Connection = cn;
            com.CommandType = System.Data.CommandType.Text;
            com.CommandText = sql;

            cn.Open();
            int modificados = com.ExecuteNonQuery();
            Console.WriteLine("Enfermos eliminados: " + modificados);
               
            cn.Close();

            MostrarEnfermos();
        }
        static void ModificarSala()
        {
            string connectionString = @"Data Source=LOCALHOST\SQLEXPRESS;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=SA";

            //OBJETOS
            SqlConnection cn = new SqlConnection(connectionString);
            SqlCommand com = new SqlCommand();
            SqlDataReader reader;

            string sql = "SELECT DISTINCT SALA_COD, NOMBRE FROM SALA";
            com.Connection = cn;
            com.CommandType = System.Data.CommandType.Text;
            com.CommandText = sql;

            Console.WriteLine("-------------SALAS-------------");
            //ABRIMOS Y CERRAMOS
            cn.Open();
            reader = com.ExecuteReader();
            while(reader.Read())
            {
                string idSala = reader["SALA_COD"].ToString();
                string nombreSala = reader["NOMBRE"].ToString() ;
                Console.WriteLine("ID: " + idSala + " - " + nombreSala + '\n');
            }

            Console.WriteLine("Escoja un ID a modificar: ");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Escoja un nuevo nombre para la sala: ");
            string nombre = Console.ReadLine();

            sql = "UPDATE SALA SET NOMBRE=@NOMBRE WHERE SALA_COD =@ID ";
            SqlParameter pamid = new SqlParameter("@nombre",nombre);
            SqlParameter pamid2 = new SqlParameter("@ID", id);
            com.Parameters.Add(pamid);
            com.Parameters.Add(pamid2);

            com.CommandText = sql; //no es necesario, pero mejor ponerlo
            int modificados = com.ExecuteNonQuery();

            Console.WriteLine("Salas modificadas: " + modificados);

            com.Parameters.Clear();
            reader.Close();
            cn.Close();
        }
        static void MostrarEmpleados()
        {
            string connectionString = @"Data Source=LOCALHOST\SQLEXPRESS;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=SA";

            SqlConnection cn = new SqlConnection(connectionString);
            SqlCommand com = new SqlCommand();

            SqlDataReader lector;

            Console.WriteLine("Inserte el numero de departamento para mostrar los empleados: ");
            int numero = int.Parse(Console.ReadLine());

            //CONSULTA
            string sql = "SELECT APELLIDO, OFICIO, SALARIO FROM EMP WHERE DEPT_NO =@ID";

            //GUARDO EL PARAMETRO
            SqlParameter pamid = new SqlParameter("@ID", numero);
            com.Parameters.Add(pamid);

            //CONFIGURAMOS
            com.Connection = cn;
            com.CommandType = System.Data.CommandType.Text;
            com.CommandText = sql;

            //ABRIMOS Y CERRAMOS
            cn.Open();
            lector = com.ExecuteReader();

            while (lector.Read())
            {
                string nombre = lector["APELLIDO"].ToString();
                string oficio = lector["OFICIO"].ToString();
                string salario = lector["SALARIO"].ToString();
                Console.WriteLine(nombre + " - " + oficio + " - " + salario + '\n');
            }
            lector.Close();
            cn.Close();
            com.Parameters.Clear();
        }

        static void EliminarDeptParameters()
        {
            string connectionString = @"Data Source=LOCALHOST\SQLEXPRESS;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=SA";

            SqlConnection cn = new SqlConnection(connectionString);
            SqlCommand com = new SqlCommand();

            //PEDIMOS AL USUARIO EL ID DEL DEPT A ELIMINAR
            Console.WriteLine("Introduzca el ID Departamento a eliminar: ");
            int numero = int.Parse(Console.ReadLine());
            //CONSULTA CON EL PARAMETRO- Me lo invento
            string sql = "DELETE FROM DEPT WHERE DEPT_NO=@IDDEPARTAMENTO";
            //CREAMOS UN NUEVO PARAMETRO LLAMADO @IDDEPARTAMENTO
            SqlParameter pamid = new SqlParameter("@IDDEPARTAMENTO", numero);
            //AÑADIMOS AL COMANDO EL NUEVO PARAMENTRO
            com.Parameters.Add(pamid);
            //CONFIGURAMOS EL COMANDO NORMALMENTE
            com.Connection= cn;
            com.CommandType = System.Data.CommandType.Text;
            com.CommandText = sql;
            //ENTRAR Y SALIR
            cn.Open();
            int eliminados = com.ExecuteNonQuery();
            Console.WriteLine("Registros eliminados: " + eliminados);
            cn.Close();
            com.Parameters.Clear();
        }
        static void InsertarDept()
        {
            //CADENA DE CONEXION
            string connectionString = @"Data Source=LOCALHOST\SQLEXPRESS;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=SA";
            
            //OBJETOS PARA ACCESO DE DATOS- Excepto DataReader PORQUE NO VAMOS A LEER NINGUN REGISTRO (en las de accion no se necesita lector)
            SqlConnection cn = new SqlConnection(connectionString);
            SqlCommand com = new SqlCommand();

            //REALIZAMOS NUESTRA CONSULTA
            string sql = "INSERT INTO DEPT VALUES (88,'INFORMATICA','OVIEDO')";

            //CONFIGURAMOS NUESTRO COMANDO
            //INDICAMOS LA CONEXION QUE VA A USAR
            com.Connection = cn;
            //INDICAMOS EL TIPO DE CONSULTA QUE VAMOS A REALIZAR
            com.CommandType = System.Data.CommandType.Text;
            //CONSULTA SQL
            com.CommandText = sql;

            //ENTRAMOS Y SALIMOS
            cn.Open();
            int insertados = com.ExecuteNonQuery();
            Console.WriteLine("Registros modificados: "+ insertados);
            cn.Close();
        }

        static void LeerRegistroDept()
        {
            //1º.- DECLARAMOS NUESTRA CADENA DE CONEXION A SQL SERVER.
            //SI LA CADENA TIENE CARACTERES ESPECIALES, COMO POR EJEMPLO LA CONTRABARRA \, DEBEMOS INCLUIR UN @ FUERA DE LA CADENA
            //PARA QUE RECUPERE LOS LITERALES.
            //SI LA CADENA TIENE PASSWORD, DEBEMOS ESCRIBIR EL PASSWORD DE FORMA MANUAL
            string connectionString = @"Data Source=LOCALHOST\SQLEXPRESS;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=SA";

            //2.º- DECLARAMOS LOS OBJETOS A UTILIZAR
            //2.1.-EL OBJETO CONNECTION SIEMPRE DEBE LLEVAR LA CADENA DE CONEXION EN SU CONSTRUCTOR
            SqlConnection cn = new SqlConnection(connectionString);
            //2.2.-INSTANCIAMOS EL COMANDO, QUE ES EL ENCARGADO DE LAS CONSULTAS
            SqlCommand com = new SqlCommand();
            //3º.-COMO VAMOS A LEER DATOS, DECLARAMOS UN CURSOR.
            //UN CURSOR NUNCA SE INSTANCIA, SOLAMENTE PODEMOS CREARLO A PARTIR DE NUESTRA CONSULTA DE SELECCION Y UN COMANDO
            SqlDataReader lector;
            //4º.-DECLARAMOS NUESTRA CONSULTA
            string sql = "select * from DEPT";
            //5º.-CONFIGURAMOS NUESTRO COMMAND
            //INDICAMOS AL COMANDO LA CONEXION A UTILIZAR
            com.Connection = cn;
            //6º.-DEBEMOS INDICAR EL TIPO DE CONSULTA
            com.CommandType = System.Data.CommandType.Text;
            //7º.-INDICAMOS LA PROPIA CONSULTA
            com.CommandText = sql;

            //UNA VEZ FINALIZADA LA CONFIGURACION, DEBEMOS EJECUTAR LA CONSULTA, PARA ELLO, ABRIMOS LA CONEXION.
            //SIEMPRE SERA ENTERAR Y SALIR.
            cn.Open();
            //EJECUTAMOS LA CONSULTA MEDIANTE EL COMANDO.
            //AL SER UNA CONSULTA DE SELECCION, SE USA EL METODO ExecuteReader() QUE NOS DEVUELVE UN DataReader (cursor/lector)
            lector = com.ExecuteReader(); //Ahora hay info aquí dentro
            //PARA LEER EL READER CONTIENE UN METODO Read() QUE LEE UNA FILA Y DEVUELVE true/false SI HA PODIDO LEER.
            //CADA VEZ QUE EJECUTAMOS Read() SE MUEVE UNA FILA. SOLAMENTE PODEMOS IR HACIA DELANTE.
            //Read() es boolean, por lo que si necesitamos recorrer todos los registros, debemos usar un bucle condicional.
            while(lector.Read())
            {
                //AQUI IREMOS RECUPERANDO COLUMNA A COLUMNA CADA DATO DE LA FILA
                string nombre = lector["DNOMBRE"].ToString();
                string localidad = lector["LOC"].ToString();
                Console.Write(nombre + " - " + localidad + '\n' );
            }
            lector.Read();
            //PARA LEER LOS DATOS DE UNA COLUMNA SE USA lector["NOMBRECOLUMNA"], O TAMBIEN PODEMOS USAR lector[indiceColumna]
            //RECUPERAMOS EL NOMBRE
            //string nombre = lector["DNOMBRE"].ToString(); //hay que castear segun el tipo de informacion que haya en la columna de la bbdd
            //Console.WriteLine(nombre);
            //UNA VEZ QUE HEMOS LEIDO, SIEMPRE SE CIERRA EL CURSOR Y LA CONEXION
            lector.Close();
            cn.Close();

        }
    }
}