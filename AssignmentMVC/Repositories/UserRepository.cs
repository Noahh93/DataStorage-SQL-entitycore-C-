using AssignmentMVC.Models;
using System.Data.SqlClient;

namespace AssignmentMVC.Repositories
{
    public class UserRepository
    {
        private readonly ApplicationDBContext _context;
        public UserRepository()
        {
            _context = new ApplicationDBContext();
        }
        public List<User> GetAllUsers()
        {
            SqlConnection sqlConnection = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=Facebook;Integrated Security=True");
            SqlCommand sqlCommand = new SqlCommand($"select CU.id, CU.FirstName, CU.LastName, CU.Email, CU.Password, CU.image, CU.CountryID, C._name from CompanyUser as CU inner join Country as C on C.ID = CU.CountryID", sqlConnection);
            sqlConnection.Open();
            SqlDataReader reader = sqlCommand.ExecuteReader();  //Executes for reading purpose

            List<User> users = new List<User>();
            while (reader.Read())
            {
                User user = new User();
                user.Id = Convert.ToInt32(reader["id"]);
                user.Firstname = $"{reader["FirstName"]}";
                user.Lastname = $"{reader["Lastname"]}";
                user.Email = $"{reader["Email"]}";
                user.Password = $"{reader["Password"]}";

                user.CountryID = Convert.ToInt32(reader["CountryID"]);
                user.Country = new Country();
                user.Country.Name = $"{reader["_name"]}";

                user.Image = $"{reader["image"]}";

                users.Add(user);
            }
            sqlConnection.Close();
            return users;
        }
        public User GetUserByEmail(string email, int id)
        {
            SqlConnection sqlConnection = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=Facebook;Integrated Security=True");
            SqlCommand sqlCommand = new SqlCommand($"select id, firstname, lastname, email, password, image from CompanyUser where email = '{email}' or id = {id}", sqlConnection);
            sqlConnection.Open();
            SqlDataReader reader = sqlCommand.ExecuteReader();

            User user = new User();
            while (reader.Read())
            {
                user.Id = Convert.ToInt32(reader["id"]);
                user.Email = reader["email"].ToString();
                user.Firstname = reader["firstname"].ToString();
                user.Lastname = reader["lastname"].ToString();
                user.Image = reader["image"].ToString();
            }
            sqlConnection.Close();
            return user;
        }
        public User GetUserByEmailAndPassword(string email, string password)
        {
            SqlConnection sqlConnection = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=Facebook;Integrated Security=True");
            SqlCommand sqlCommand = new SqlCommand($"select id, firstname, lastname, email, password from CompanyUser where email = '{email}' and password = '{password}'", sqlConnection);
            sqlConnection.Open();
            SqlDataReader reader = sqlCommand.ExecuteReader();

            User user = new User();
            while (reader.Read())
            {
                user.Email = reader["email"].ToString();
                user.Password = reader["password"].ToString();
            }
            sqlConnection.Close();
            return user;
        }
        public bool SaveUser(User user)
        {
            try
            {
                _context.Users.Add(user);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }
        public List<User> SearchUserFirstLastNameEmail(string searchWord)
        {
            SqlConnection sqlConnection = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=Facebook;Integrated Security=True");
            SqlCommand sqlCommand = new SqlCommand($"select Cu.id, Cu.firstname, Cu.lastname, Cu.email, Cu.password, Cu.image, Cu.countryID, c._name from CompanyUser as CU inner join Country as C on CU.CountryID = C.ID where firstname like '%{searchWord}%' or lastname like '%{searchWord}%' or email like '%{searchWord}%'", sqlConnection);
            sqlConnection.Open();
            SqlDataReader reader = sqlCommand.ExecuteReader();


            List<User> users = new List<User>();
            while (reader.Read())
            {
                User user = new User();

                user.Id = Convert.ToInt32(reader["id"].ToString());
                user.Firstname = reader["firstname"].ToString();
                user.Lastname = reader["lastname"].ToString();
                user.Password = reader["password"].ToString();
                user.Email = reader["email"].ToString();
                user.CountryID = Convert.ToInt32(reader["Countryid"].ToString());
                user.Image = reader["image"].ToString();

                user.Country = new Country();
                user.Country.Name = reader["_name"].ToString();

                users.Add(user);
            }
            sqlConnection.Close();
            return users;
        }
        public bool UpdateUser(User user)
        {
            SqlConnection sqlConnection = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=Facebook;Integrated Security=True");
            SqlCommand sqlCommand = new SqlCommand($"update CompanyUser set firstname = '{user.Firstname}', lastname = '{user.Lastname}', password = '{user.Password}', image = '{user.Image}' where id = {user.Id}", sqlConnection);
            sqlConnection.Open();
            int rowsAffected = sqlCommand.ExecuteNonQuery(); //Executes for saving purpose
            sqlConnection.Close();
            if (rowsAffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
