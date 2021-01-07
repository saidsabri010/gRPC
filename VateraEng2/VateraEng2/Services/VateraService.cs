using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using System.Data.SqlClient;
using MySqlConnector;
using System.Data;


namespace VateraEng2
{

    public class VateraService : Vatera.VateraBase
    {
     

        MySqlConnection sqlcon =
        new MySqlConnection("datasource=localhost;port=3306;AllowUserVariables=True;database=api_data;username=root;password=");

        static readonly List<string> sessions = new List<string>();
        //static readonly List<Product> Products = new List<Product>();

        public override async Task Display(Empty vmi, IServerStreamWriter<Data2> responseStream, ServerCallContext context)
        {
            Data2 ss = new Data2();
            await responseStream.WriteAsync(ss);
        }

        public override Task<Result> Add(Data data, ServerCallContext context)
        {
            bool exist = true;
            lock (sessions)
            {
                if (!sessions.Contains(data.Uid))
                {
                    exist = false;

                }
            }
            if (!exist)
                return Task.FromResult(new Result { Success = "Please, log in" });
            sqlcon.Open();
            string query = "INSERT INTO cars(name,model,price) " +
                            "VALUES(@Name,@Model,@Price)";
            MySqlCommand cmd = new MySqlCommand(query, sqlcon);
            cmd.Parameters.AddWithValue("@Name", data.Name);
            cmd.Parameters.AddWithValue("@Model", data.Model);
            cmd.Parameters.AddWithValue("@Price", data.Price);
            cmd.ExecuteNonQuery();

            return Task.FromResult(new Result { Success = "Added successfully!" });
        }
        public override Task<Result> Update(Data data, ServerCallContext context)
        {
            bool exist = true;
            lock (sessions)
            {
                if (!sessions.Contains(data.Uid))
                {
                    exist = false;

                }
            }
            if (!exist)
                return Task.FromResult(new Result { Success = "Please, log in" });
            sqlcon.Open();

            string query = "UPDATE cars SET name =@Name,price=@Price WHERE model =@Model";
            MySqlCommand cmd = new MySqlCommand(query, sqlcon);
            cmd.Parameters.AddWithValue("@Name", data.Name);
            cmd.Parameters.AddWithValue("@Model", data.Model);
            cmd.Parameters.AddWithValue("@Price", data.Price);
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            sqlcon.Close();
            return Task.FromResult(new Result { Success = "Updated successfully!" });
        }


        public override Task<Result> Delete(Data data, ServerCallContext context)
        {
            bool exist = true;
            lock (sessions)
            {
                if (!sessions.Contains(data.Uid))
                {
                    exist = false;

                }
            }
            if (!exist)
                return Task.FromResult(new Result { Success = "Please, log in" });

            sqlcon.Open();

            string query = "DELETE FROM cars WHERE model = @Model";
            MySqlCommand cmd = new MySqlCommand(query, sqlcon);
            cmd.Parameters.AddWithValue("@Model", data.Model);
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);


            //foreach (DataRow item in dt.Rows)
            //{
               
            //    if (data.Model != item[0].ToString())
            //    {
            //        return Task.FromResult(new Result { Success = "no duplicate!" });
            //    }
            //}
            sqlcon.Close();
            return Task.FromResult(new Result { Success = "Deleted successfully!" });
        }
        public override Task<Result> Logout(Session_Id id, ServerCallContext context)
        {
            lock (sessions)
            {
                sessions.Remove(id.Id);
            }
            return Task.FromResult(new Result { Success = "Loged out" }); ;

        }


        public override Task<Session_Id> Login(User user, ServerCallContext context)
        {
            MySqlConnection sqlcon =
            new MySqlConnection("datasource=localhost;port=3306;AllowUserVariables=True;database=api_data;username=root;password=");
            sqlcon.Open();

            string query = "INSERT INTO userinfo(Username, Password) " +
                "VALUES(@id,@pass)";
            MySqlCommand command = new MySqlCommand(query, sqlcon);
            command.Parameters.AddWithValue("@id", user.Name.Trim());
            command.Parameters.AddWithValue("@pass", user.Passwd.Trim());
            MySqlDataAdapter sda = new MySqlDataAdapter(command);
            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);
            string id = "";
            if (user.Name.Length != 0 && user.Passwd.Length != 0)
            {
                id = Guid.NewGuid().ToString();
                lock (sessions)
                {
                    sessions.Add(id);
                }
                return Task.FromResult(new Session_Id { Id = id });
            }
            else
                return Task.FromResult(new Session_Id { Id = null });
        }


        public class Cars
        {
            public string Name { get; set; }
            public string Model { get; set; }
            public int Price { get; set; }
           
        }
    }
}