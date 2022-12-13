using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace StudentMnagementSystem.Data_Access
{
    public class DataAccess
    {
        public void addData(SqlConnection sqlconnection)
        {
            Console.WriteLine("Enter id,name,standard,address");
            int id = int.Parse(Console.ReadLine());
            string name = Console.ReadLine();
            string standard = Console.ReadLine();
            string address = Console.ReadLine();

            string insertQuery = "insert into Student(id,Name,Address,Standard) values ('" + id + "','" + name + "','" + address + "','" + standard + "')";
            SqlCommand insertCommand = new SqlCommand(insertQuery, sqlconnection);

            insertCommand.ExecuteNonQuery();
            Console.WriteLine("Enter no of subjects");
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Enter subject id,name,marks obtained,max marks");
                int sId = int.Parse(Console.ReadLine());
                string sName = Console.ReadLine();

                int marks = int.Parse(Console.ReadLine());
                int max = int.Parse(Console.ReadLine());
                // string s2 = sId + "'," + "'," + sName + "'," + marks + "'," + max;
                string insertQuery2 = "insert into Subject(StudentId,SubId,SubName,ObtainedMarks,MaxMarks) values ('" + id + "','" + sId + "','" + sName + "','" + marks + "','" + max + "')";
                SqlCommand insertCommand2 = new SqlCommand(insertQuery2, sqlconnection);
                insertCommand2.ExecuteNonQuery();
            }
            
            Console.WriteLine("Data inserted");
        }

        public void getData(SqlConnection sqlconnection)
        {
            string selectAllQuery = "select * from Student";
            string selectAllQuery2 = "select * from Subject";
            SqlCommand selectAllCommand = new SqlCommand(selectAllQuery, sqlconnection);
            SqlCommand selectAllCommand2 = new SqlCommand(selectAllQuery2, sqlconnection);

            SqlDataReader dr = selectAllCommand.ExecuteReader();
            if (dr.Read() == false)
            {
                Console.WriteLine("No records exist");

            }
            Console.WriteLine("StudentId  " + "Name  " + "Address  " + "Standard");
            Console.WriteLine("-----------------------------------------------");
            while (dr.Read())
            {

                Console.WriteLine($" {dr[0]}     {dr[1]}     {dr[2]}     {dr[3]}");
            }
            dr.Close();
            SqlDataReader dr2 = selectAllCommand2.ExecuteReader();
            Console.WriteLine();
            Console.WriteLine("StudentId  " + "Sub Id  " + "Sub Name  " + "Marks obtained  " + "Max marks");

            Console.WriteLine("-----------------------------------------------");
            while (dr2.Read())
            {
                Console.WriteLine($" {dr2[0]}         {dr2[1]}         {dr2[2]}         {dr2[3]}       {dr2[4]}");
            }
            dr2.Close();
        }

        public void getDataById(SqlConnection sqlconnection)
        {
            int c2 = 0;
            Console.WriteLine("Enter id");
            int id2 = int.Parse(Console.ReadLine());
            string selectQueryId = "select * from Student where id=" + id2;
            string selectQueryId2 = "select * from Subject where StudentId=" + id2;
            SqlCommand selectIdCommand = new SqlCommand(selectQueryId, sqlconnection);
            SqlCommand selectIdCommand2 = new SqlCommand(selectQueryId2, sqlconnection);

            SqlDataReader dr3 = selectIdCommand.ExecuteReader();
            if (dr3.Read() == false)
            {
                Console.WriteLine("No records exist");

            }

            else
            {
                dr3.Close();
                SqlDataReader dr4 = selectIdCommand.ExecuteReader();
                Console.WriteLine("StudentId  " + "Name  " + "Address  " + "Standard");
                Console.WriteLine("-----------------------------------------------");
                while (dr4.Read())
                {

                    Console.WriteLine($" {dr4[0]}     {dr4[1]}     {dr4[2]}     {dr4[3]}");
                }
                dr4.Close();
                SqlDataReader dr6 = selectIdCommand2.ExecuteReader();
                Console.WriteLine();
                Console.WriteLine("StudentId  " + "Sub Id  " + "Sub Name  " + "Marks obtained  " + "Max marks");
                Console.WriteLine("-----------------------------------------------");
                while (dr6.Read())
                {
                    Console.WriteLine($" {dr6[0]}         {dr6[1]}         {dr6[2]}         {dr6[3]}       {dr6[4]}");
                }
                dr6.Close();
            }
        }

        public void updateData(SqlConnection sqlconnection)
        {

            int c3 = 0;
            Console.WriteLine("Enter id");
            int id3 = int.Parse(Console.ReadLine());
            string selectQuery3 = "select * from Student where id=" + id3;
            SqlCommand selectCommand2 = new SqlCommand(selectQuery3, sqlconnection);
            SqlDataReader dr5 = selectCommand2.ExecuteReader();
            if (dr5.Read() == false)
            {
                Console.WriteLine("Id doesn't exist");
                dr5.Close();
            }

            else
            {
                dr5.Close();
                Console.WriteLine("Enter student name,address,standard");
                string name2 = Console.ReadLine();
                string standard2 = Console.ReadLine();
                string address2 = Console.ReadLine();
                Console.WriteLine("Enter subject id,name,marks obtained,max marks");
                int subid = int.Parse(Console.ReadLine());
                string subname = Console.ReadLine();
                int marksob = int.Parse(Console.ReadLine());
                int maxmarks = int.Parse(Console.ReadLine());
                string updateQuery = $"update Student set name='{name2}',address='{address2}',standard='{standard2}' where id='{id3}'";
                string updateQuery2 = $"update Subject set SubId='{subid}',SubName='{subname}',ObtainedMarks='{marksob}' MaxMarks='{maxmarks}' where StudentId='{id3}'";
                SqlCommand updateCommand = new SqlCommand(updateQuery, sqlconnection);
                SqlCommand updateCommand2 = new SqlCommand(updateQuery2, sqlconnection);
                updateCommand.ExecuteNonQuery();
                Console.WriteLine("Data updated");
            }

        }
        public void deleteData(SqlConnection sqlconnection)
        {
            int c4 = 0;
            Console.WriteLine("Enter id");
            int id4 = int.Parse(Console.ReadLine());
            string deleteQuery = "delete from Student where id=" + id4;
            string deleteQuery2 = "delete from Subject where StudentId=" + id4;
            SqlCommand deleteCommand = new SqlCommand(deleteQuery, sqlconnection);
            SqlCommand deleteCommand2 = new SqlCommand(deleteQuery2, sqlconnection);
            c4 = deleteCommand.ExecuteNonQuery();
            deleteCommand2.ExecuteNonQuery();
            if (c4 == 0)
            {
                Console.WriteLine("Data for this id doesn't exist");
            }
            else
            {
                Console.WriteLine("Data deleted");
            }
        }
    }
}
