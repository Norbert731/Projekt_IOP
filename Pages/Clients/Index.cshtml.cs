using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace Projekt_IOP.Pages.Clients
{
    public class IndexModel : PageModel
    {
        //public List<ClientInfo> listsClients = new List<ClientInfo>();
        public void OnGet()
		{   /*
            try
            {
                String ConnectionString = "Data Source=.\\sqlexpress;Initial Catalog=Contacts_DB;Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    String sql = "SELECT * FROM contacts";
                    using (SqlCommand command = new SqlCommand(sql, connection)) 
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ClientInfo clientInfo = new ClientInfo();
                                clientInfo.id = "" + reader.GetInt32(0);
                                clientInfo.first_name = reader.GetString(1);
                                clientInfo.last_name = reader.GetString(2);
                                clientInfo.email = reader.GetString(3);
                                clientInfo.gender = reader.GetString(4);
                                clientInfo.country = reader.GetString(5);
                                clientInfo.city = reader.GetString(6);


                                listsClients.Add(clientInfo);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception:" + ex.ToString());
            }*/
		}

    }
        /*
    public class ClientInfo
    {
        public String id;
        public String first_name;
        public String last_name;
        public String email;
        public String gender;
        public String country;
        public String city;

    }*/
}
