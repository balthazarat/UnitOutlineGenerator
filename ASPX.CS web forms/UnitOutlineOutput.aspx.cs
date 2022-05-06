using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Data;

namespace WebApplication1
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True";

            SqlConnection con = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand("dbo.unitOut", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("ID", 1);

            con.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())

            {

                HtmlTableRow row = new HtmlTableRow();

                HtmlTableCell cell = new HtmlTableCell();

                // this array helps us make everything fairly optimised...

                string[] headers = { "Course", "Unit", "Unit Description", "Accreditation", "Unit Goals", "Content Descriptors" };

                for (int i = 0; i < 6; i++)

                {

                    // We are bolding our headings with the <b> tag, adding a break, then adding the content under

                    //We are getting the heading info from the array and the data from our datareader

                    cell.InnerHtml = string.Format("<b>{0}</b><br />{1}", headers[i], dr[headers[i]]);

                    row.Cells.Add(cell);

                    tableContent.Rows.Add(row);

                    cell = new HtmlTableCell();

                    row = new HtmlTableRow();
                }
                con.Close();
            }
        }
    }
}