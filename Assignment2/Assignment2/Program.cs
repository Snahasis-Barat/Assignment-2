// See https://aka.ms/new-console-template for more information

using StudentMnagementSystem.Data_Access;
using System.Data.SqlClient;
class Program
{
    static void Main(string[] args)
    {
        DataAccess ob= new DataAccess();
        SqlConnection sqlconnection;
        string connectionString = "Server=DESKTOP-27ECLDH;Database=StudentManagementSystem;Trusted_Connection=True";
        sqlconnection= new SqlConnection(connectionString);
        sqlconnection.Open();
        Console.WriteLine("Connection created");
        //Console.ReadKey();

        //DataAccess ob = new DataAccess();
        Console.WriteLine("Enter your choice");
        Console.WriteLine("1.Add data");
        Console.WriteLine("2.Get all data");
        Console.WriteLine("3.Get data by id");
        Console.WriteLine("4.Update data by id");
        Console.WriteLine("5.Delete data by Id");
        int ch = 1000; 
        while (ch != 0)
        {
            ch = int.Parse(Console.ReadLine());
            switch (ch)
            {
                case 1:
                   
                    ob.addData(sqlconnection);
                    //  ob.AddData();
                    break;
                case 2:
                    //  ob.getData();
                    ob.getData(sqlconnection);
                    break;
                case 3:
                   
                    ob.getDataById(sqlconnection);
                    break;
                case 4:
                    
                     ob.updateData(sqlconnection);
                    break;
                case 5:
                    
                    ob.deleteData(sqlconnection);
                    break;
                default:
                    //Console.WriteLine("Thank you");
                    break;
            }
        }

    }
}
