﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Drawing;

namespace web_apprenant
{
    public partial class Modifier : System.Web.UI.Page
    {
        string[,] PaysVille = new string[,] { { "Maroc", "Casablanca" }, { "Maroc", "Marrakech" },{ "Maroc", "Tanger" },{ "Maroc", "Safi" },
                                             { "France", "Paris" },{ "France", "Marseille" },{ "France", "Lyon" },{ "France", "Toulouse" },
                                             { "Allemagne", "Berlin" },{ "Allemagne", "Hambourg" },{ "Allemagne", "Munich" },{ "Allemagne", "Cologne" }};
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                combo_specialité.Items.Add("jee");
                combo_specialité.Items.Add("C#");
                combo_specialité.Items.Add("back-end font-end");
                for (int i = 0; i < PaysVille.GetLength(0); i++)
                {
                    var trouve = 0;
                    foreach (var item in combo_pays.Items)
                    {
                        if (item.ToString().Equals(PaysVille[i, 0]))
                        {
                            trouve = 1;
                        }
                    }
                    if (trouve == 0)
                    {
                        combo_pays.Items.Add(PaysVille[i, 0]);
                    }
                }
                remplire_combo_id();
                divDisable.Visible = false;
            }
        }
        protected void combo_id_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!combo_pays.Text.Equals("Veuillez sélectionner"))
            {
                Connection cnx = new Connection();
                cnx.open_connection();
                SqlCommand cmd = new SqlCommand("select * from studentinfo where id=" + combo_id.Text, Connection.con);
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                txt_nom.Text = dr[1].ToString();
                txt_prenom.Text = dr[2].ToString();
                txt_addrese.Text = dr[3].ToString();
                txt_mail.Text = dr[4].ToString();
                combo_pays.Text = dr[5].ToString();
                combo_ville.Items.Clear();
                for (int i = 0; i < PaysVille.GetLength(0); i++)
                {
                    if (dr[5].ToString().Equals(PaysVille[i, 0]))
                    {
                        combo_ville.Items.Add(PaysVille[i, 1]);
                    }
                }
                combo_ville.Text = dr[6].ToString();
                combo_specialité.Text = dr[7].ToString();
                txt_tele.Text = dr[8].ToString();
                cnx.close_connection();
                divDisable.Visible = true;
            }
        }
        protected void txt_nom_TextChanged(object sender, EventArgs e)
        {
            valid_nom();
        }

        protected void txt_prenom_TextChanged(object sender, EventArgs e)
        {
            valid_prenom();
        }

        protected void txt_tele_TextChanged(object sender, EventArgs e)
        {
            valid_tele();
        }

        protected void txt_mail_TextChanged(object sender, EventArgs e)
        {
            valid_mail();
        }

        protected void txt_addrese_TextChanged(object sender, EventArgs e)
        {
            valid_addrese();
        }

        protected void combo_pays_SelectedIndexChanged(object sender, EventArgs e)
        {
            combo_ville.Items.Clear();
            if (!combo_pays.Text.Equals("Veuillez sélectionner"))
            {
                for (int i = 0; i < PaysVille.GetLength(0); i++)
                {
                    if (combo_pays.SelectedItem.ToString().Equals(PaysVille[i, 0]))
                    {
                        combo_ville.Items.Add(PaysVille[i, 1]);
                    }
                }
                valid_pays();
            }
        }

        protected void combo_ville_SelectedIndexChanged(object sender, EventArgs e)
        {
            valid_ville();
        }

        protected void combo_specialité_SelectedIndexChanged(object sender, EventArgs e)
        {
            valid_specialite();
        }
        protected void btn_modifier_Click(object sender, EventArgs e)
        {
            if (valid_nom() && valid_prenom() && valid_tele() && valid_mail() && valid_pays() && valid_ville() && valid_specialite() && valid_addrese())
            {
                Connection cnx = new Connection();
                cnx.open_connection();
                SqlCommand cmd = new SqlCommand("update studentinfo set nom='" + txt_nom.Text + "',prenom='" + txt_prenom.Text + "',addrese='" +
                    txt_addrese.Text + "',email='" + txt_mail.Text + "',pays='" + combo_pays.Text + "',ville='" + combo_ville.Text + "'," +
                    "specialite='" + combo_specialité.Text + "',tele='" + txt_tele.Text + "' where id=" + combo_id.Text, Connection.con);
                cmd.ExecuteNonQuery();
                cnx.close_connection();
                Page.RegisterStartupScript("myAlert", "<script language=JavaScript>window.alert('L`apprenant a bien modifier');</script>");
            }
            else
            {
                Page.RegisterStartupScript("myAlert", "<script language=JavaScript>window.alert('Vous devez bien remplir les informations');</script>");
            }
        }
        protected void btn_supprimer_Click(object sender, EventArgs e)
        {
            Connection cnx = new Connection();
            cnx.open_connection();
            SqlCommand cmd = new SqlCommand("delete from studentinfo where id=" + combo_id.Text, Connection.con);
            cmd.ExecuteNonQuery();
            txt_nom.Text = "";
            txt_prenom.Text = "";
            txt_addrese.Text = "";
            txt_mail.Text = "";
            combo_ville.Items.Clear();
            combo_ville.Items.Clear();
            txt_tele.Text = "";
            cnx.close_connection();
            remplire_combo_id();
            divDisable.Visible = false;
            Page.RegisterStartupScript("myAlert", "<script language=JavaScript>window.alert('L`apprenant a bien supprimer');</script>");
        }







        public void remplire_combo_id()
        {
            combo_id.Items.Clear();
            Connection cnx = new Connection();
            cnx.open_connection();
            SqlCommand cmd = new SqlCommand("select id from studentinfo", Connection.con);
            SqlDataReader dr = cmd.ExecuteReader();
            combo_id.Items.Add("Veuillez sélectionner");
            while (dr.Read())
            {
                combo_id.Items.Add(dr[0].ToString());
            }
            cnx.close_connection();
        }
        private Boolean valid_nom()
        {
            bool valid = false;
            string pattern = @"^[a-zA-ZÀ-ú\-\s]{3,}";
            Regex r = new Regex(pattern);
            Match m = r.Match(txt_nom.Text);
            if (m.Success)
            {
                valid = true;
                txt_nom.BorderColor = Color.Empty;
            }
            else
            {
                txt_nom.BorderColor = Color.Red;
            }
            return valid;
        }
        private Boolean valid_prenom()
        {
            bool valid = false;
            string pattern = @"^[a-zA-ZÀ-ú\-\s]{3,}";
            Regex r = new Regex(pattern);
            Match m = r.Match(txt_prenom.Text);
            if (m.Success)
            {
                valid = true;
                txt_prenom.BorderColor = Color.Empty;
            }
            else
            {
                txt_prenom.BorderColor = Color.Red;
            }
            return valid;
        }
        private Boolean valid_tele()
        {
            bool valid = false;
            string pattern = @"^(05|06|07)([0-9]){8}$";
            Regex r = new Regex(pattern);
            Match m = r.Match(txt_tele.Text);
            if (m.Success)
            {
                valid = true;
                txt_tele.BorderColor = Color.Empty;
            }
            else
            {
                txt_tele.BorderColor = Color.Red;
            }
            return valid;
        }
        private Boolean valid_addrese()
        {
            bool valid = false;
            string pattern = @"^\d+\s[A-z]+\s[A-z]+";
            Regex r = new Regex(pattern);
            Match m = r.Match(txt_addrese.Text);
            if (m.Success)
            {
                valid = true;
                txt_addrese.BorderColor = Color.Empty;
            }
            else
            {
                txt_addrese.BorderColor = Color.Red;
            }
            return valid;
        }
        private Boolean valid_mail()
        {
            bool valid = false;
            string pattern = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";
            Regex r = new Regex(pattern);
            Match m = r.Match(txt_mail.Text);
            if (m.Success)
            {
                valid = true;
                txt_mail.BorderColor = Color.Empty;
            }
            else
            {
                txt_mail.BorderColor = Color.Red;
            }
            return valid;
        }
        private Boolean valid_pays()
        {
            bool valid = false;
            if (!combo_pays.Text.Trim().Equals("") && !combo_pays.Text.Equals("Veuillez sélectionner"))
            {
                valid = true;
                combo_pays.BorderColor = Color.Empty;
            }
            else
            {
                combo_pays.BorderColor = Color.Red;
            }
            return valid;
        }
        private Boolean valid_ville()
        {
            bool valid = false;
            if (!combo_ville.Text.Trim().Equals(""))
            {
                valid = true;
                combo_ville.BorderColor = Color.Empty;
            }
            else
            {
                combo_ville.BorderColor = Color.Red;
            }
            return valid;
        }
        private Boolean valid_specialite()
        {
            bool valid = false;
            if (!combo_specialité.Text.Trim().Equals("") && !combo_specialité.Text.Equals("Veuillez sélectionner"))
            {
                valid = true;
                combo_specialité.BorderColor = Color.Empty;
            }
            else
            {
                combo_specialité.BorderColor = Color.Red;
            }
            return valid;
        }
    }
}