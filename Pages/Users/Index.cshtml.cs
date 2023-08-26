using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace TopUpSE_ASP_1.Pages.Users
{
	public class UserInfo
	{
		public string id;
		public string first_name;
		public string last_name;
		public string email;
		public string dob;
		public string address;
		public string created_at;
	}

	public class IndexModel : PageModel
    {

		public List<UserInfo> userInforList = new List<UserInfo>();

		public void OnPost()
		{
			Console.WriteLine("post reuqet");
		}

        public void OnGet()
        {

			try
			{
				String conString = "Data Source=DESKTOP-64CFU0S\\SQLEXPRESS;Initial Catalog=asp_web_app;Integrated Security=True";

				using (SqlConnection con = new SqlConnection(conString))
				{
					con.Open();

					String sql = "SELECT * FROM users";
					Console.WriteLine(sql);
					using (SqlCommand cmd = new SqlCommand(sql, con))
					{
						using (SqlDataReader reader = cmd.ExecuteReader())
						{

							while (reader.Read())
							{
								UserInfo ui = new UserInfo();
								ui.id = "" + reader.GetInt32(0);
								ui.first_name = reader.GetString(1);
								ui.last_name = reader.GetString(2);
								ui.email = reader.GetString(3);
								ui.dob = reader.GetString(4);
								ui.address = reader.GetString(5);
								ui.created_at = reader.GetString(6);
								userInforList.Add(ui);
							}
						}
					}
				}
			}
			catch(Exception e)
			{
				Console.WriteLine(e.ToString());
			}
        }
    }

	
}