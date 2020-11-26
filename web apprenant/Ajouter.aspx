<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="Ajouter.aspx.cs" Inherits="web_apprenant.ajouter" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
          <div class="form-row">
            <div class="form-group col-md-6">
              <label for="txt_nom">Nom</label>
               <asp:TextBox class="form-control"  ID="txt_nom" runat="server" OnTextChanged="txt_nom_TextChanged" AutoPostBack="True"></asp:TextBox>
            </div>
            <div class="form-group col-md-6">
              <label for="txt_prenom">Prenom</label>
              <asp:TextBox class="form-control" ID="txt_prenom" runat="server" OnTextChanged="txt_prenom_TextChanged"></asp:TextBox>
            </div>
          </div>
          <div class="form-group">
            <label for="txt_tele">Téléphone</label>
            <asp:TextBox class="form-control" ID="txt_tele" runat="server" OnTextChanged="txt_tele_TextChanged"></asp:TextBox>
          </div>
          <div class="form-group">
            <label for="txt_mail">Email</label>
            <asp:TextBox class="form-control" ID="txt_mail" runat="server" OnTextChanged="txt_mail_TextChanged"></asp:TextBox>
          </div>
          <div class="form-group">
            <label for="txt_addrese">Address</label>
            <asp:TextBox class="form-control" ID="txt_addrese" runat="server" OnTextChanged="txt_addrese_TextChanged"></asp:TextBox>
          </div>
          <div class="form-row">
            <div class="form-group col-md-4">
              <label for="combo_pays">Pays</label>
              <asp:DropDownList class="form-control" ID="combo_pays" runat="server" AutoPostBack="True" OnSelectedIndexChanged="combo_pays_SelectedIndexChanged"></asp:DropDownList>
            </div>
            <div class="form-group col-md-4">
              <label for="combo_ville">Ville</label>
              <asp:DropDownList class="form-control" ID="combo_ville" runat="server" AutoPostBack="True" OnSelectedIndexChanged="combo_ville_SelectedIndexChanged"></asp:DropDownList>
            </div>
            <div class="form-group col-md-4">
              <label for="combo_specialité">Spécialité</label>
              <asp:DropDownList class="form-control" ID="combo_specialité" runat="server" OnSelectedIndexChanged="combo_specialité_SelectedIndexChanged"></asp:DropDownList>
            </div>
          </div>
           <asp:Button class="btn btn-primary" ID="btn_ajouter" runat="server" Text="Ajouter" OnClick="btn_ajouter_Click" />
       
    </div>
</asp:Content>
