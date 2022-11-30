<%@ Page Title="Resumo de Pedidos" Language="C#" MasterPageFile="~/PaginaMestre.Master" AutoEventWireup="true" CodeBehind="AcompanhamentoCliente.aspx.cs" Inherits="SistemaHotel.AcompanhamentoCliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <%--    <link href="CSS/bootstrap.min.css" rel="stylesheet"  />--%>
    <%--    <script src="Scripts/bootstrap.min.js" ></script>--%>

    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.1.3/dist/css/bootstrap.min.css" integrity="sha384-MCw98/SFnGE8fJT3GXwEOngsV7Zt27NXFoaoApmYm81iuXoPkFOJwJ8ERdknLPMO" crossorigin="anonymous">
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.1.3/dist/js/bootstrap.min.js" integrity="sha384-ChfqqxuZUCnJSK3+MXmPNIyE6ZbWh2IMqE241rYiqJxyMiZ6OW/JmZQ5stwEULTy" crossorigin="anonymous"></script>

    <link href="https://cdn.datatables.net/1.13.1/css/jquery.dataTables.min.css" rel="stylesheet" />
    <link href="https://cdn.datatables.net/buttons/2.3.2/css/buttons.dataTables.min.css" rel="stylesheet" />

    <script src="https://code.jquery.com/jquery-3.5.1.js"></script>
    <script src="https://cdn.datatables.net/1.13.1/js/jquery.dataTables.min.js"></script>
    <script src="https://cdn.datatables.net/buttons/2.3.2/js/dataTables.buttons.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jszip/3.1.3/jszip.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/pdfmake/0.1.53/pdfmake.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/pdfmake/0.1.53/vfs_fonts.js"></script>
    <script src="https://cdn.datatables.net/buttons/2.3.2/js/buttons.html5.min.js"></script>



    <style>
        .green {
            background-color: #90ee90 !important;
        }

        .yellow {
            background-color: #ffffe0 !important;
        }

        .red {
            background-color: #ffbdb9 !important;
        }

        #circulo_yellow {
            background: lightyellow;
            border-radius: 50%;
            width: 100px;
            height: 100px;
        }

        #circulo_green {
            background: lightseagreen;
            border-radius: 50%;
            width: 100px;
            height: 100px;
        }

        #circulo_red {
            background: lightcoral;
            border-radius: 50%;
            width: 100px;
            height: 100px;
        }
    </style>





    <script type="text/javascript">
        $(document).ready(function () {
            $('#example').DataTable({
                "language": {
                    "emptyTable": "Não foram encontrados registros",
                    "zeroRecords": "Não foram encontrados resultados",
                    "paginate": {
                        "previous": "<",
                        "next": ">",
                        "first": "<<",
                        "last": ">>",
                    },
                    "search": "Pesquisar:",

                },
                "scrollY": '500px',
                "scrollCollapse": true,
                "paging": true,
                "pageLength": 10,
                "ordering": true,
                "info": false,
                dom: 'Bfrtip',
                buttons: [{
                    extend: 'pdf',
                    orientation: 'landscape',
                    pageSize: 'LEGAL'
                }

                ],
                "createdRow": function (row, data, dataIndex) {
                    if (data[8] == "<center>Em Aberto</center>") {
                        $(row).addClass('yellow');

                    }
                    else if (data[8] == "<center>Finalizado</center>") {
                        $(row).addClass('green');

                    }
                    else {
                        $(row).addClass('red');
                    }
                },

            });
        })
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Panel ID="PnlAtendimento" runat="server" Style="font-family: Calibri">
        <h5 class="p-3 mb-2 bg-dark text-white">Resumo de Pedidos</h5>
        <hr />
        <div class="container">
            <div class="row">
                <div runat="server" class="col-5">
                    <p>
                        <b>Tipo: </b>
                        <asp:DropDownList ID="ddlTipo" class="form-control" runat="server">
                        </asp:DropDownList>
                    </p>
                </div>
                <div runat="server" class="col-5">
                    <p>
                        <b>Status: </b>
                        <asp:DropDownList ID="ddlStatus" class="form-control" runat="server">
                        </asp:DropDownList>
                    </p>
                </div>
                <div class="col-sm">
                    <asp:LinkButton ID="lnkPesquisar" class="btn btn-dark" OnClick="lnkPesquisar_Click" runat="server">Pesquisar</asp:LinkButton>
                </div>
            </div>
            <div class="row">
                <div class="col-1">
                    <span>Legenda: </span>
                </div>
                <div class="col-4">
                    <div class="border border-dark" style="background-color: lightgrey">
                        <div class="row">
                            <div class="col-sm">
                                <span id="circulo_yellow" style="background-color: #ffffe0">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span> Em Aberto</span>
                            </div>
                            <div class="col-sm">
                                <span id="circulo_green" style="background-color: #90ee90">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span> Finalizado</span>
                            </div>
                            <div class="col-sm">
                                <span id="circulo_red" style="background-color: #ffbdb9">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span> Recusado</span>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <hr />
        <div class="row">
            <div class="col-sm">
                <div id="Panel1" runat="server" visible="true">
                </div>
            </div>
        </div>
        <hr />
        <div class="row">
            <div class="col-sm">
                <span>&nbsp;</span>
            </div>
            <div class="col-sm">
                <span>&nbsp;</span>
            </div>
            <div class="col-sm">
                <span>&nbsp;</span>
            </div>
            <hr />
            <div class="col-sm">
                <h5>Total:
                    <asp:Label ID="lblTotal" runat="server" Font-Size="Large"></asp:Label></h5>
            </div>
        </div>

    </asp:Panel>

</asp:Content>
