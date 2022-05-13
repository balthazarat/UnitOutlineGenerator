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
            cmd.Parameters.AddWithValue("ID", Request.QueryString["ID"]); // change ID to change what unit gets generated, this will need to be made dynamic to implement with the search feature. //
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
                    // This is where we have normal breaks in the paragraph section
                    if (i == 2)
                    {
                        string[] points = Convert.ToString(dr[headers[i]]).Split('`');
                        cell.InnerHtml = string.Format("<b>{0}</b>", headers[i]);
                        foreach (string p in points)
                        {
                            cell.InnerHtml += string.Format("<br /><br />{0}", p);
                        }
                    }
                    else if (i == 4 || i == 5)
                    {
                        //Splitting on the ~ for each bullet point
                        string[] points = Convert.ToString(dr[headers[i]]).Split('~');
                        //We set up a <ul> which is a bullet point list
                        cell.InnerHtml = string.Format("<b>{0}</b><ul>", headers[i]);
                        foreach (string p in points)
                        {
                            //If it contains * we have a subheading
                            if (p.Contains("*"))
                            {
                                string[] subheading = p.Split('*');
                                cell.InnerHtml += string.Format("<br /><i>{0}</i>", subheading[1]);
                                cell.InnerHtml += string.Format("<li>{0}</li>", subheading[2]);
                            }
                            else
                            {
                                //li is list item
                                cell.InnerHtml += string.Format("<li>{0}</li>", p);
                            }
                        }
                        //Close the list
                        cell.InnerHtml += "</ul>";
                    }
                    else
                    {
                        // We are bolding our headings with the <b> tag, adding a break, then adding the content under
                        //We are getting the heading info from the array and the data from our datareader
                        cell.InnerHtml = string.Format("<b>{0}</b><br />{1}", headers[i], dr[headers[i]]);
                    }         
                    row.Cells.Add(cell);
                    tableContent.Rows.Add(row);
                    cell = new HtmlTableCell();
                    row = new HtmlTableRow();
                }
            }
            con.Close();
        }
    }
}