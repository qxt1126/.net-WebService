using Newtonsoft.Json;
using PCLdemo1.Myclass;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;

namespace PCLdemo1
{
   
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    public class PCLWebService : System.Web.Services.WebService
    {

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public void searchForLicence(string licencenum)
        {
            JavaScriptSerializer ser = new JavaScriptSerializer();
            BoatsInfo[] licences = null;
            try
            {
                using (SqlConnection connection = new SqlConnection(DBconnect.ConnectionString))
                {
                    //SqlDataAdapter sda = new SqlDataAdapter("Select * from TMP_Renew where Licence_num", connection);
                    SqlDataAdapter sda = new SqlDataAdapter("Select TOP (1000) * from TMP_Renew where Licence_num = " + "'"+ licencenum + "'", connection);
                    sda.SelectCommand.CommandType = System.Data.CommandType.Text;
                    DataTable datatable = new DataTable();
                    sda.Fill(datatable);
                    licences = new BoatsInfo[datatable.Rows.Count];
                    int Count = 0;
                    for (int i =0; i<datatable.Rows.Count; i++)
                    {
                        licences[Count] = new BoatsInfo();
                        licences[Count].Licence_num = Convert.ToString(datatable.Rows[i]["Licence_num"]);
                        licences[Count].app_id = Convert.ToString(datatable.Rows[i]["app_id"]);
                        licences[Count].app_type_cd = Convert.ToString(datatable.Rows[i]["app_type_cd"]);
                        licences[Count].channel_cd = Convert.ToString(datatable.Rows[i]["channel_cd"]);
                        licences[Count].expiry_date = Convert.ToString(datatable.Rows[i]["expiry_date"]);
                        licences[Count].created_date = Convert.ToString(datatable.Rows[i]["created_date"]);
                        licences[Count].modified_date = Convert.ToString(datatable.Rows[i]["modified_date"]);
                        licences[Count].correspondence_type_cd = Convert.ToString(datatable.Rows[i]["correspondence_type_cd"]);
                        licences[Count].owner_id = Convert.ToString(datatable.Rows[i]["owner_id"]);
                        licences[Count].ent_name = Convert.ToString(datatable.Rows[i]["ent_name"]);
                        licences[Count].last_name = Convert.ToString(datatable.Rows[i]["last_name"]);
                        licences[Count].email_address = Convert.ToString(datatable.Rows[i]["email_address"]);
                        licences[Count].postal_zip_code = Convert.ToString(datatable.Rows[i]["postal_zip_code"]);
                        licences[Count].country_name = Convert.ToString(datatable.Rows[i]["country_name"]);
                        Count++;
                    }
                    datatable.Clear();
                    connection.Close();
                }
            }catch(Exception ex)
            {

            }

            var JSonData = new
            {
            getBoatsInfo = licences
            };
            HttpContext.Current.Response.Write(JsonConvert.SerializeObject(JSonData, Formatting.Indented));
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public void lookup()
        {
            JavaScriptSerializer ser = new JavaScriptSerializer();
            BoatsInfo[] licences = null;
            try
            {
                using (SqlConnection connection = new SqlConnection(DBconnect.ConnectionString))
                {
                    //SqlDataAdapter sda = new SqlDataAdapter("Select * from TMP_Renew where Licence_num", connection);
                    SqlDataAdapter sda = new SqlDataAdapter("Select TOP (10) * from TMP_Renew ", connection);
                    sda.SelectCommand.CommandType = System.Data.CommandType.Text;
                    DataTable datatable = new DataTable();
                    sda.Fill(datatable);
                    licences = new BoatsInfo[datatable.Rows.Count];
                    int Count = 0;
                    for (int i = 0; i < datatable.Rows.Count; i++)
                    {
                        licences[Count] = new BoatsInfo();
                        licences[Count].Licence_num = Convert.ToString(datatable.Rows[i]["Licence_num"]);
                        licences[Count].app_id = Convert.ToString(datatable.Rows[i]["app_id"]);
                        licences[Count].app_type_cd = Convert.ToString(datatable.Rows[i]["app_type_cd"]);
                        licences[Count].channel_cd = Convert.ToString(datatable.Rows[i]["channel_cd"]);
                        licences[Count].expiry_date = Convert.ToString(datatable.Rows[i]["expiry_date"]);
                        licences[Count].created_date = Convert.ToString(datatable.Rows[i]["created_date"]);
                        licences[Count].modified_date = Convert.ToString(datatable.Rows[i]["modified_date"]);
                        licences[Count].correspondence_type_cd = Convert.ToString(datatable.Rows[i]["correspondence_type_cd"]);
                        licences[Count].owner_id = Convert.ToString(datatable.Rows[i]["owner_id"]);
                        licences[Count].ent_name = Convert.ToString(datatable.Rows[i]["ent_name"]);
                        licences[Count].last_name = Convert.ToString(datatable.Rows[i]["last_name"]);
                        licences[Count].email_address = Convert.ToString(datatable.Rows[i]["email_address"]);
                        licences[Count].postal_zip_code = Convert.ToString(datatable.Rows[i]["postal_zip_code"]);
                        licences[Count].country_name = Convert.ToString(datatable.Rows[i]["country_name"]);
                        Count++;
                    }
                    datatable.Clear();
                    connection.Close();
                }
            }
            catch (Exception ex)
            {

            }

            var JSonData = new
            {
                getBoatsInfo = licences
            };
            HttpContext.Current.Response.Write(JsonConvert.SerializeObject(JSonData, Formatting.Indented));
        }
        
    }
}
