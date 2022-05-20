using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System.Text.RegularExpressions;

namespace WebApplication1
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void btnExport_Click(object sender, EventArgs e)
        {
            // this code is from https://github.com/MicahChubb/unitOutline/blob/main/unitOutline(PDF).aspx.cs //

            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=TestPage.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            this.Page.RenderControl(hw);
            StringReader sr = new StringReader(sw.ToString());
            Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 100f, 0f);
            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);

            //PdfReader pdfReader = new PdfReader(Server.MapPath("~/Files/") + "Test.pdf");
            //PdfWriter writer = PdfWriter.GetInstance(pdfDoc, new FileStream(Server.MapPath("~/Files/") + "OutPut.pdf", FileMode.Create));

            pdfDoc.Open();
            htmlparser.Parse(sr);
            /*
            for (int i = 1; i <= pdfReader.NumberOfPages; i++)
            {
                // Is aware of how many pages, doesn't copy pdf properly so ends up with lots of blanks
                PdfImportedPage page = writer.GetImportedPage(pdfReader, i);
                pdfDoc.Add(iTextSharp.text.Image.GetInstance(page));
            }*/


            pdfDoc.Close();

            Response.Write(pdfDoc);
            Response.End();
        }
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
                                cell.InnerHtml += string.Format("</ul><br /><i>{0}</i><ul>", subheading[1]);
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