<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMestre.Master" AutoEventWireup="true" CodeBehind="ControleProduto.aspx.cs" Inherits="SistemaHotel.ControleProduto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link rel="stylesheet" type="text/css" href="<%= ResolveUrl("~/layout/bower_components/bootstrap/css/bootstrap.min.css") %>" />
    <link rel="stylesheet" type="text/css" href="<%= ResolveUrl("~/layout/bower_components/sweetalert/css/sweetalert.css") %>" />
    <link rel="stylesheet" type="text/css" href="<%= ResolveUrl("~/layout/assets/icon/themify-icons/themify-icons.css") %>" />
    <link rel="stylesheet" type="text/css" href="<%= ResolveUrl("~/layout/assets/icon/icofont/css/icofont.css") %>" />
    <link rel="stylesheet" type="text/css" href="<%= ResolveUrl("~/layout/assets/icon/feather/css/feather.css") %>" />
    <link rel="stylesheet" type="text/css" href="<%= ResolveUrl("~/layout/assets/css/component.css") %>" />
    <link rel="stylesheet" type="text/css" href="<%= ResolveUrl("~/layout/assets/css/jquery.mCustomScrollbar.css") %>" />
    <link rel="stylesheet" type="text/css" href="<%= ResolveUrl("~/layout/assets/icon/icofont/css/icofont.css") %>" />
    <link rel="stylesheet" type="text/css" href="<%= ResolveUrl("~/layout/assets/icon/font-awesome/css/font-awesome.min.css") %>" />
    <link rel="stylesheet" type="text/css" href="<%= ResolveUrl("~/layout/css/style.css") %>" />
    <script type="text/javascript" src="<%= ResolveUrl("~/layout/bower_components/bootstrap/js/bootstrap.min.js") %>"></script>
    <script type="text/javascript" src="<%= ResolveUrl("~/layout/bower_components/datatables.net/js/jquery.dataTables.min.js") %>"></script>
    <script type="text/javascript" src="<%= ResolveUrl("~/layout/bower_components/datatables.net-buttons/js/dataTables.buttons.min.js") %>"></script>
    <script type="text/javascript" src="<%= ResolveUrl("~/layout/assets/pages/data-table/js/jszip.min.js") %>"></script>
    <script type="text/javascript" src="<%= ResolveUrl("~/layout/assets/pages/data-table/js/pdfmake.min.js") %>"></script>
    <script type="text/javascript" src="<%= ResolveUrl("~/layout/assets/pages/data-table/js/vfs_fonts.js") %>"></script>
    <script type="text/javascript" src="<%= ResolveUrl("~/layout/assets/pages/data-table/extensions/key-table/js/dataTables.keyTable.min.js") %>"></script>
    <script type="text/javascript" src="<%= ResolveUrl("~/layout/bower_components/datatables.net-buttons/js/buttons.print.min.js") %>"></script>
    <script type="text/javascript" src="<%= ResolveUrl("~/layout/bower_components/datatables.net-buttons/js/buttons.html5.min.js") %>"></script>
    <script type="text/javascript" src="<%= ResolveUrl("~/layout/bower_components/datatables.net-bs4/js/dataTables.bootstrap4.min.js") %>"></script>
    <script type="text/javascript" src="<%= ResolveUrl("~/layout/bower_components/datatables.net-responsive/js/dataTables.responsive.min.js") %>"></script>
    <script type="text/javascript" src="<%= ResolveUrl("~/layout/bower_components/datatables.net-responsive-bs4/js/responsive.bootstrap4.min.js") %>"></script>
    <script type="text/javascript" src="<%= ResolveUrl("~/layout/assets/js/bootstrap-growl.min.js") %>"></script>
    <script type="text/javascript" src="<%= ResolveUrl("~/layout/assets/js/modalEffects.js") %>"></script>
    <!-- layout padrao  -->
    <script type="text/javascript" src="<%= ResolveUrl("~/layout/plugins/bootstrap-notify/bootstrap-notify.js") %>"></script>
    <script type="text/javascript" src="<%= ResolveUrl("~/layout/js/script.js") %>"></script>

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
                "scrollY": '300px',
                "scrollCollapse": true,
                "paging": true,
                "pageLength": 10,
                "ordering": false,
                "info": false,
                dom: 'Bfrtip',
                buttons: [

                ]



            });
        })
    </script>

    <script src="Scripts/mascara.js"></script>

    <style>
        .modal-personalizado {
            min-width: 95%;
            margin-left: 70px;
        }

            .modal-personalizado.modal-content {
                min-height: 50vh;
            }

        .modal-body {
            max-height: calc(120vh - 210px);
            overflow-y: auto;
            overflow-x: auto;
        }
    </style>



</asp:Content>


<asp:Content ID="Content12" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <asp:Panel ID="Panel3" runat="server" GroupingText="Controle de Produtos">

        <div class="container">
            <div class="row">
                <div class="col-sm">
                    <asp:LinkButton ID="novoProduto" class="btn btn-primary" runat="server" OnClick="novoProduto_Click">Novo Produto</asp:LinkButton>
                </div>
            </div>
            <div class="row">
                <div class="col-sm">
                    <span>&nbsp;</span>
                </div>
            </div>
            <div id="divAdm" runat="server" class="row">
                <div class="col-sm">
                    <span>Listar Por: </span>
                </div>

                <div class="col-sm">
                    <asp:DropDownList ID="ddlTipo" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlTipo_SelectedIndexChanged">
                    </asp:DropDownList>

                </div>
            </div>
        </div>
        <div class="col-12" align="center">
            <div id="Panel1" runat="server" visible="true">
            </div>
        </div>
        <div class="modal-backdrop fade show" id="mdBack" runat="server" style="opacity: 0.2; display: block; filter: (alpha(opacity= 20))" visible="false"></div>
        <div class="modal fade show" id="mdProd" runat="server" tabindex="-1" role="dialog" aria-labelledby="mediumModalLabel" aria-hidden="true" style="opacity: 1; display: block; filter: (alpha(opacity= 100))" visible="false">
            <%--<div class="modal-dialog modal-lg" role="document">--%>
                 <div class="modal-dialog modal-personalizado" role="document">
                <div class="modal-content" visible="false" style="border-radius: 10px;">
                    <div class="modal-header">
                        <h5 class="modal-title">Novo Produto:</h5>
                        <asp:LinkButton type="button" runat="server" class="close" data-dismiss="modal" OnClick="lnkVoltar_Click" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </asp:LinkButton>
                    </div>
                    <div class="modal-body">
                        <div class="container">
                            <div class="row">
                                <div class="col-sm">
                                    <span>Nome: </span>
                                </div>
                                <div class="col-sm">
                                    <asp:TextBox runat="server" ID="txtNome"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm">
                                    <span>&nbsp;</span>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-sm">
                                    <span>Descricao: </span>
                                </div>
                                <div class="col-sm">
                                    <asp:TextBox runat="server" ID="txtDescricao" Rows="5" Columns="40" TextMode="MultiLine"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm">
                                    <span>&nbsp;</span>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-sm">
                                    <span>Preço: </span>
                                </div>
                                <div class="col-sm">
                                    <asp:TextBox runat="server" ID="txtPreco" onkeyup="formataValor(this,event);"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm">
                                    <span>&nbsp;</span>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-sm">
                                    <span>Tipo: </span>
                                </div>
                                <div class="col-sm">
                                    <asp:DropDownList ID="ddlTipoProdS" runat="server">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm">
                                    <span>&nbsp;</span>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-sm">
                                    <span>Foto: </span>
                                </div>
                                <div class="col-sm">
                                    <asp:FileUpload ID="fuProduto" runat="server" />
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm">
                                    <span>&nbsp;</span>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <asp:LinkButton ID="lnkSalvarProduto" class="btn btn-success" OnClick="lnkSalvarProduto_Click" runat="server">Salvar</asp:LinkButton>
                        <asp:LinkButton ID="lnkVoltar" class="btn btn-primary" runat="server" OnClick="lnkVoltar_Click">Voltar</asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>
        <div class="modal fade show" id="mdProdE" runat="server" tabindex="-1" role="dialog" aria-labelledby="mediumModalLabel" aria-hidden="true" style="opacity: 1; display: block; filter: (alpha(opacity= 100))" visible="false">
            <%--<div class="modal-dialog modal-lg" role="document">--%>
                 <div class="modal-dialog modal-personalizado" role="document">
                <div class="modal-content" visible="false" style="border-radius: 10px;">
                    <div class="modal-header">
                        <h5 class="modal-title">Editar Produto:</h5>
                        <asp:LinkButton type="button" runat="server" class="close" data-dismiss="modal" OnClick="lnkVoltar_Click" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </asp:LinkButton>
                    </div>
                    <div class="modal-body">
                        <div class="container">
                            <div class="row">
                                <div class="col-sm">
                                    <span>Nome: </span>
                                </div>
                                <div class="col-sm">
                                    <asp:TextBox runat="server" ID="txtNomeE"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm">
                                    <span>&nbsp;</span>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm">
                                    <span>Descricao: </span>
                                </div>
                                <div class="col-sm">
                                    <asp:TextBox runat="server" ID="txtDescricaoE" Rows="5" Columns="40" TextMode="MultiLine"></asp:TextBox></td>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm">
                                    <span>&nbsp;</span>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm">
                                    <span>Preço: </span>
                                </div>
                                <div class="col-sm">
                                    <asp:TextBox runat="server" ID="txtPrecoE"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm">
                                    <span>&nbsp;</span>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm">
                                    <span>Tipo: </span>
                                </div>
                                <div class="col-sm">
                                    <asp:DropDownList ID="ddlTipoProdE" runat="server">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm">
                                    <span>&nbsp;</span>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm">
                                    <span>Foto: </span>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm">
                                    <asp:FileUpload ID="fuProdE" runat="server" />
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <asp:LinkButton ID="lnkSalvarProdutoE" runat="server" class="btn btn-success" OnClick="lnkSalvarProdutoE_Click">Alterar</asp:LinkButton>
                            <asp:LinkButton ID="LinkButton3" class="btn btn-primary" runat="server" OnClick="lnkVoltar_Click">Voltar</asp:LinkButton>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </asp:Panel>
</asp:Content>

