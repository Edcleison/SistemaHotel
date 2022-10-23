<%@ Page Title="Pedidos em Aberto" Language="C#" MasterPageFile="~/PaginaMestre.Master" AutoEventWireup="true" CodeBehind="Atendimento.aspx.cs" Inherits="SistemaHotel.Atendimento" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

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

    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script>
        $(document).ready(function () {
            setTimeout(function () {
                $(".alert").fadeOut("slow", function () {
                    $(this).alert('close');
                });
            }, 3000);
        });
    </script>
    <script>
        $(document).ready(function () {
            $(".close").click(function () {
                $(".alert").hide();
            });
        });
    </script>

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
                "ordering": true,
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
                    <asp:DropDownList ID="ddlTipo" class="form-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlTipo_SelectedIndexChanged">
                    </asp:DropDownList>
                    </p>
                </div>
            </div>
           <div class="row">
                <div class="col-1">
                    <span>Legenda: </span>
                </div>
                <div class="col-2">
                    <div class="border border-dark" style="background-color: lightgrey">
                        <div class="row">
                            <div class="col-sm">
                                <span id="circulo_yellow" style="background-color: #ffffe0">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span> Em Aberto</span>
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
    </asp:Panel>
</asp:Content>
