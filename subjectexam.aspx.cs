using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class subjectexam : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string sid = Request.QueryString["sid"];
        if(sid == null)
        {
            Response.Redirect("category.aspx");
        }
        examlistmethod(Convert.ToInt32(sid));
        subjectnamemethod(Convert.ToInt32(sid));
    }

    string s = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
    //method for examlist
    public void examlistmethod(int id)
    {

        using (SqlConnection con = new SqlConnection(s))
        {
            SqlCommand cmd = new SqlCommand("spExamserachcategory", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@subjectid", id);
            try
            {
                con.Open();
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    gridview_sujectexam.DataSource = rd;
                    gridview_sujectexam.DataBind();
                }
                else
                {
                    panel_examshow_warning.Visible = true;
                    lbl_examshowwarning.Text = "Sorry! There is no exam in this subject";
                }
            }
            catch (Exception ex)
            {
                panel_examshow_warning.Visible = true;
                lbl_examshowwarning.Text = "Something went wrong. Please try after sometime later</br> Contact you developer for this problem" + ex.Message;
            }
        }
    }
    //method for sujectlist
    public void subjectnamemethod(int id)
    {
        using (SqlConnection con = new SqlConnection(s))
        {
            SqlCommand cmd = new SqlCommand("select * from subject where subject_id = @subjectid", con);
            cmd.Parameters.AddWithValue("@subjectid", id);
            try
            {
                con.Open();
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    lbl_subjectexam.Text = rd["subject_name"].ToString();
                }
            }
            catch (Exception ex)
            {
                panel_examshow_warning.Visible = true;
                lbl_examshowwarning.Text = "Something went wrong. Please try after sometime later</br> Contact you developer for this problem " + ex.Message;
            }
        }
    }

    protected void lnkpopup_Click(object sender, EventArgs e)
    {
        string filePath = (sender as LinkButton).CommandArgument;
        string url = "N_Question.aspx?eid="+ filePath +"";
        string s = "window.open('" + url + "', 'Exam_Paper', 'width=1000,height=1200,left=0,top=0,resizable=no');";
        ClientScript.RegisterStartupScript(this.GetType(), "script", s, true);

        //string filePath = (sender as LinkButton).CommandArgument;
        //Response.ContentType = ContentType;
        //Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(filePath));
        //Response.WriteFile(filePath);
        //Response.End();
        //                Response.Redirect("URL_PostalBallots_Format725.aspx?a=" + ddlDist1.SelectedItem.Text + "&b=" + Session["dno"] + "");
        
    }
}