<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Livraria.Web.Views.Home.Index" Theme="Default" MasterPageFile="~/Site.Master" Title="Cadastro de livros" %>

<asp:Content ID="Content" runat="server" ContentPlaceHolderID="ContentPlaceHolder">
    <div id="mainForm" class="form" data-bean="BookController" data-control="Book">
        <h3><span>Formulário</span></h3>
        <div>
            <span class="label">Código:</span>
            <input data-type="number" data-field="Code" maxlength="11" data-readonly-edit="true" style="width: 50px">
            <br />
            <span class="label">Nome:</span>
            <input maxlength="45" data-field="Name" data-required="true" style="width: 250px">
            <br />
            <span class="label">Autor:</span>
            <input data-field="Author" maxlength="11" data-required="true" style="width: 250px">
            <br />
            <div class="buttons">
                <div data-form-mode="Insert" class="hidden">
                    <span class="buttonHolder">
                        <input type="button" value="Inserir" class="saveButton" data-action="Insert" />
                        <span class="ui-icon ui-icon-circle-plus"></span>
                    </span>
                    <span class="buttonHolder">
                        <input type="button" value="Buscar" class="findButton" data-action="Find" />
                        <span class="ui-icon ui-icon-circle-zoomin"></span>
                    </span>
                    <span class="buttonHolder">
                        <input type="button" value="Cancelar" class="cancelButton" data-action="Cancel" />
                        <span class="ui-icon ui-icon-circle-minus"></span>
                    </span>
                </div>
                <div data-form-mode="Edit" class="hidden">
                    <span class="buttonHolder">
                        <input type="button" value="Salvar" class="saveButton" data-action="Save" />
                        <span class="ui-icon ui-icon-circle-plus"></span>
                    </span>
                    <span class="buttonHolder">
                        <input type="button" value="Remover" class="deleteButton" data-action="Delete" />
                        <span class="ui-icon ui-icon-circle-close"></span>
                    </span>
                    <span class="buttonHolder">
                        <input type="button" value="Cancelar" class="cancelButton" data-action="Cancel" />
                        <span class="ui-icon ui-icon-circle-minus"></span>
                    </span>
                </div>
            </div>
        </div>
    </div>
    <div class="divHolder">
        <table id="mainGrid" class="grid" cellspacing="0" cellpadding="0">
            <colgroup>
                <col style="text-align: right; width: 10%">
                <col style="text-align: left;">
                <col style="text-align: left; width: 30%">
                <col style="text-align: center; width: 20px">
            </colgroup>
            <thead>
                <th>Código</th>
                <th>Nome</th>
                <th>Autor</th>
            </thead>
            <tbody>
            </tbody>
        </table>
    </div>
    <script>	
        $(function () {
            initialize($('#mainForm'), $('#mainGrid'), true);
        });
    </script>
</asp:Content>
