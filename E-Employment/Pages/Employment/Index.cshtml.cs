using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace E_Employment.Pages.Employment
{
    public class IndexModel : PageModel
    {
        public List<EmploymentInfo> listEmployment = new List<EmploymentInfo>();
     
        public void OnGet()
        {
            try
            {
                String connectionString = "Data Source=MSI;Initial Catalog=EMPLOYMENT;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                using (SqlConnection connection = new SqlConnection(connectionString)) { 
                    connection.Open();
                    String sql = "SELECT ENTITY_ID, ENTITY_GIVEN_NAMES, ENTITY_LAST_NAME, ENTITY_TELEPHONE, ENTITY_EMAIL, ENTITY_DOB  FROM ENTITY";
                    using (SqlCommand command = new SqlCommand(sql, connection)) {
                        using (SqlDataReader reader = command.ExecuteReader()) {
                            while (reader.Read()) { 
                                EmploymentInfo employmentinfo = new EmploymentInfo();
                                employmentinfo.ENTITY_ID = "" + reader.GetInt32(0);
                                employmentinfo.ENTITY_GIVEN_NAMES = reader.GetString(1);
                                employmentinfo.ENTITY_LAST_NAME = reader.GetString(2);
                                employmentinfo.ENTITY_TELEPHONE = reader.GetString(3);
                                employmentinfo.ENTITY_EMAIL = reader.GetString(4);
                                employmentinfo.ENTITY_DOB = reader.GetDateTime(5).ToString();

                                listEmployment.Add(employmentinfo);
                            }
                        }
                    }
                }
            }
            catch (Exception ex) {
                Console.WriteLine("Exception : " + ex.ToString());
            }
        }
    }
    public class EmploymentInfo
    {
        public String ENTITY_ID;
        public String ENTITY_GIVEN_NAMES;
        public String ENTITY_LAST_NAME;
        public String ENTITY_EMAIL;
        public String ENTITY_TELEPHONE;
        public String ENTITY_DOB;


      
    }
}
