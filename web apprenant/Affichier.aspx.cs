using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace web_apprenant
{
    public partial class Affichier : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                combo_specialité.Items.Add("Veuillez sélectionner");
                combo_specialité.Items.Add("Tous les spécialité");
                combo_specialité.Items.Add("jee");
                combo_specialité.Items.Add("C#");
                combo_specialité.Items.Add("back-end font-end");
            }
        }

        protected void combo_specialité_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!combo_specialité.Text.Equals("Veuillez sélectionne"))
            {
                string req = "select * from studentinfo ";
                if (!combo_specialité.Text.Equals("Tous les spécialité"))
                {
                    req += "where CONVERT(VARCHAR, specialite)='" + combo_specialité.Text + "'";
                }
                Connection cnx = new Connection();
                cnx.open_connection();
                SqlCommand cmd = new SqlCommand(req, Connection.con);
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                GridView1.DataSource = dt;
                GridView1.DataBind();
                cnx.close_connection();
            }
            else
            {
                combo_specialité.Visible = false;
            }
        }
    }
}