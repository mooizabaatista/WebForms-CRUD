<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddOrEdit.aspx.cs" Inherits="FuncManager.Web.AddOrEdit" %>



<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">

        <div class="row mb-3">
            <div class="col text-center">
                <asp:Label runat="server" ID="lblTitulo" CssClass="fs-4 fw-bold"></asp:Label>
            </div>
        </div>

        <div class="row mb-3">
            <div class="col col-md-8">
                <div class="form-group">
                    <label for="txtNomeCompleto" class="form-label">Nome Completo</label>
                    <asp:TextBox runat="server" CssClass="form-control w-100" ID="txtNomeCompleto" ClientIDMode="Static"></asp:TextBox>
                </div>
            </div>
            <div class="col col-md-4">
                <div class="form-group">
                    <label for="txtSalario" class="form-label">Salário</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="txtSalario" ClientIDMode="Static"></asp:TextBox>
                </div>
            </div>
        </div>

        <div class="row mb-3">
            <div class="col col-md-4">
                <div class="form-group">
                    <label for="txtTerminoContrato" class="form-label">Término do Contrato</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="txtTerminoContrato" ClientIDMode="Static" TextMode="Date"></asp:TextBox>
                </div>
            </div>
            <div class="col col-md-8">
                <div class="form-group">
                    <label for="ddlDepartamentos" class="form-label">Departamento</label>
                    <asp:DropDownList runat="server" ID="ddlDepartamentos" ClientIDMode="Static" CssClass="form-control"></asp:DropDownList>
                </div>
            </div>
        </div>

        <div class="row">
            <div class="col">
                <div class="d-flex gap-2">
                    <asp:Button runat="server" ID="btnSubmit" OnClick="btnSubmit_Click" CssClass="btn btn-success btn-sm " Text="Adicionar" />
                    <asp:LinkButton runat="server" PostBackUrl="~/Default.aspx" CssClass="btn btn-danger btn-sm">Voltar</asp:LinkButton>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
