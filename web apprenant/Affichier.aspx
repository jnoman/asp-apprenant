<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="Affichier.aspx.cs" Inherits="web_apprenant.Affichier" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <form>
            <div class="form-row">
                <div class="form-group col-md-4">
                  <label for="combo_specialité">Spécialité</label>
                  <asp:DropDownList class="form-control" ID="combo_specialité" runat="server" AutoPostBack="True" OnSelectedIndexChanged="combo_specialité_SelectedIndexChanged"></asp:DropDownList>
                </div>
                <div class="form-group col-md-8">
                    <asp:GridView ID="GridView1" runat="server"></asp:GridView>
                </div>
            </div>
        </form>
    </div>
</asp:Content>
