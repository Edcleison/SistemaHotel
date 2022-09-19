﻿<%@ Page Title="Atendimento" Language="C#" MasterPageFile="~/PaginaMestre.Master" AutoEventWireup="true" CodeBehind="Atendimento.aspx.cs" Inherits="SistemaHotel.Atendimento" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   <%-- <link href="CSS/bootstrap.css" rel="stylesheet" />
    <link href="CSS/dataTables.bootstrap4.min.css" rel="stylesheet" />
    <link href="CSS/jquery.dataTables.min.css" rel="stylesheet" />

    <script src="Scripts/jquery-3.5.1.js"></script>
    <script src="Scripts/jquery.dataTables.min.js"></script>
    <script src="Scripts/dataTables.bootstrap4.min.js.js"></script>--%>
    <script src="https://code.jquery.com/jquery-3.5.1.js"></script>
    <script src="https://cdn.datatables.net/1.12.1/js/jquery.dataTables.min.js"></script>
    <script src="https://cdn.datatables.net/buttons/2.2.3/js/dataTables.buttons.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jszip/3.1.3/jszip.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/pdfmake/0.1.53/pdfmake.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/pdfmake/0.1.53/vfs_fonts.js"></script>
    <script src="https://cdn.datatables.net/buttons/2.2.3/js/buttons.html5.min.js"></script>
    <script src="https://cdn.datatables.net/buttons/2.2.3/js/buttons.print.min.js"></script>

    <link href="https://cdn.datatables.net/1.12.1/css/jquery.dataTables.min.css" rel="stylesheet" />
    <link href="https://cdn.datatables.net/buttons/2.2.3/css/buttons.dataTables.min.css" rel="stylesheet" />

    <style>
        .green {
            background-color: lightseagreen !important;
        }

        .yellow {
            background-color: lightyellow !important;
        }

        .red {
            background-color: lightcoral !important;
        }
    </style>




    <script type="text/javascript">
        $(document).ready(function () {
            $('#example').DataTable({
                "language": {
                    "paginate": {
                        "previous": "<",
                        "next": ">",
                        "first": "<<",
                        "last": ">>",
                    },
                    "search": "Pesquisar:",

                },
                "createdRow": function (row, data, dataIndex) {
                    if (data[6] == "<center>Em Aberto</center>") {
                        $(row).addClass('yellow');

                    }
                    else if (data[6] == "<center>Finalizado</center>") {
                        $(row).addClass('green');

                    }
                    else {
                        $(row).addClass('red');
                    }
                },
                "scrollY": '500px',
                "scrollCollapse": true,
                "paging": true,
                "pageLength": 10,
                "ordering": false,
                "info": false,
                dom: 'Bfrtip',
                buttons: [

                ],
                



            });
        })
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1"  Style="font-family: Calibri" runat="server">
    
    <asp:Panel ID="PnlAtendimento" runat="server">
        <h5 class="p-3 mb-2 bg-dark text-white">Atendimento</h5>
        <hr />
        <div class="container">
            <div class="row">
                <div id="divTipo" runat="server" visible="false" class="col-sm">
                    <p><b>Tipo/Atendimento: </b>
                    <asp:DropDownList ID="ddlTipo" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlTipo_SelectedIndexChanged">
                    </asp:DropDownList>
                    </p>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-sm">
                <div id="Panel1" runat="server" visible="true">
                </div>
            </div>
        </div>
    </asp:Panel>
</asp:Content>
