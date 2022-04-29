using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;

namespace WebApplication1
{
    public partial class DataPullOffClassTBL : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Connection stuff
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True";

            SqlConnection con = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand("dbo.test", con);
            cmd.CommandType = CommandType.StoredProcedure;

            con.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            //Set up first row and first cell
            HtmlTableRow row = new HtmlTableRow();
            HtmlTableCell cell = new HtmlTableCell();

            //add text to cells then add to row
            cell.InnerText = "First Name";
            row.Cells.Add(cell);

            cell = new HtmlTableCell();
            cell.InnerText = "Last Name";
            row.Cells.Add(cell);

            //Add row to table
            tableContent.Rows.Add(row);

            while (dr.Read())
            {
                row = new HtmlTableRow();
                cell = new HtmlTableCell();

                //Grab the values from the database and add to cells
                cell.InnerText = "" + dr["fName"];
                row.Cells.Add(cell);

                cell = new HtmlTableCell();
                cell.InnerText = "" + dr["lName"];
                row.Cells.Add(cell);
                tableContent.Rows.Add(row);
            }
            con.Close();
        }
    }
}