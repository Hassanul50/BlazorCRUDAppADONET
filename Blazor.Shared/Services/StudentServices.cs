using Blazor.Shared.Models;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Blazor.Shared.Services
{
    public class StudentServices
    {
        string ConnectionString = string.Empty;
        private readonly IConfiguration _configuration;
        public StudentServices(IConfiguration configuration)
        {
            ConnectionString = configuration.GetConnectionString("DefaultConnect");
        }
        public IEnumerable<StudentEntity> GetAllStudent()
        {
            List<StudentEntity> lstStudent = new List<StudentEntity>();

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("GetStudentsRecord", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    StudentEntity student = new StudentEntity();
                    student.StudentId = Convert.ToInt32(rdr["StudentId"]);
                    student.FirstName = rdr["FirstName"].ToString();
                    student.LastName = rdr["LastName"].ToString();
                    student.Email = rdr["Email"].ToString();
                    student.Gender = rdr["Gender"].ToString();
                    student.CreatedOn = Convert.ToDateTime(rdr["CreatedOn"].ToString());


                    lstStudent.Add(student);
                }
                con.Close();
            }
            return lstStudent;
        }

        //-- Func for creating new student record
        public void AddStudent(StudentEntity student)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("AddNewStudent", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@FirstName", student.FirstName);
                cmd.Parameters.AddWithValue("@LastName", student.LastName);
                cmd.Parameters.AddWithValue("@EmailAddress", student.EmailAddress);
                cmd.Parameters.AddWithValue("@Gender", student.Gender);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }


        public void UpdateStudent(StudentEntity student)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("UpdateStudentRecord", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@StudentID", student.StudentID);
                cmd.Parameters.AddWithValue("@FirstName", student.FirstName);
                cmd.Parameters.AddWithValue("@LastName", student.LastName);
                cmd.Parameters.AddWithValue("@EmailAddress", student.EmailAddress);
                cmd.Parameters.AddWithValue("@Gender", student.Gender);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }


        public void DeleteStudent(int? StudentID)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("DeleteStudentRecord", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StudentID", StudentID);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
