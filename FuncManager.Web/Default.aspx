<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FuncManager.Web._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <div class="row my-4">
            <div class="col text-center">
                <h2>Gerenciador de Funcionários</h2>
            </div>
        </div>

        <div class="row">
            <div class="col">
                <asp:GridView runat="server" ID="gvFuncionarios" CssClass="table table-bordered table-sm text-center" AutoGenerateColumns="false">
                    <Columns>
                        <asp:BoundField DataField="NomeCompleto" HeaderText="Nome Completo" />
                        <asp:BoundField DataField="Salario" HeaderText="Salário" />
                        <asp:BoundField DataField="TerminoContrato" HeaderText="Fim do Contrato" DataFormatString="{0:dd/MM/yyyy}"/>
                        <asp:BoundField DataField="Departamento.Nome" HeaderText="Departamento" />

                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="btnEditar" runat="server" CommandArgument='<%# Eval("Id") %>' OnClick="btnEditar_Click" CssClass="btn btn-success btn-sm">Editar</asp:LinkButton>
                                <asp:LinkButton ID="btnExcluir" runat="server" CommandArgument='<%# Eval("Id") %>' OnClick="btnExcluir_Click" OnClientClick="return confirm('Deseja realmente remover?')" CssClass="btn btn-danger btn-sm">Excluir</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>

</asp:Content>
