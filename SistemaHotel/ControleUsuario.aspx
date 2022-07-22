<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMestre.Master" AutoEventWireup="true" CodeBehind="ControleUsuario.aspx.cs" Inherits="SistemaHotel.ControleUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link href="CSS/bootstrap.css" rel="stylesheet" />
    <link href="CSS/dataTables.bootstrap4.min.css" rel="stylesheet" />
    <link href="CSS/jquery.dataTables.min.css.css" rel="stylesheet" />


    <script src="Scripts/jquery-3.5.1.js"></script>
    <script src="Scripts/jquery.dataTables.min.js"></script>
    <script src="Scripts/dataTables.bootstrap4.min.js.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            $('#example').DataTable({
                "language": {
                    "paginate": {
                        "previous": "Anterior:",
                        "next": "Próxima:",
                        "first": "Primeira:",
                        "last": "Última:",
                    },
                    "search": "Pesquisar:",

                },
                "paging": true,
                "pageLength": 3,
                "ordering": false,
                "info": false,
                dom: 'Bfrtip',
                buttons: [

                ]


            });
        })
    </script>

</asp:Content>


<asp:Content ID="Content12" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:LinkButton ID="novoUsuario" runat="server" PostBackUrl="~/NovoUsuario.aspx">[Novo Usuário]</asp:LinkButton>

    <asp:Panel ID="Panel3" runat="server" GroupingText="Controle de Usuários">
        <div class="col-12" align="center">
            <div id="Panel1" runat="server" visible="true">
            </div>
        </div>
    </asp:Panel>
    <hr />

</asp:Content>

