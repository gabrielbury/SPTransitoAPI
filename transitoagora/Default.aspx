<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SPTransitoAPI.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="/Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="row">
                <div class="col-sm-4 col-md-2 text-center">
                    <div class="h5">Zona Norte</div>
                    <div class="lentidao" id="zn"></div>
                </div>
                <div class="col-sm-4 col-md-2 text-center">
                    <div class="h5">Zona Leste</div>
                    <div class="lentidao" id="zl"></div>
                </div>
                <div class="col-sm-4 col-md-2 text-center">
                    <div class="h5">Centro</div>
                    <div class="lentidao" id="centro"></div>
                </div>
                <div class="col-sm-4 col-md-2 text-center">
                    <div class="h5">Zona Oeste</div>
                    <div class="lentidao" id="zo"></div>
                </div>
                <div class="col-sm-4 col-md-2 text-center">
                    <div class="h5">Zona Sul</div>
                    <div class="lentidao" id="zs"></div>
                </div>
                <div class="col-sm-4 col-md-2 text-center">
                    <div class="h5">Total</div>
                    <div class="lentidao" id="total"></div>
                </div>
            </div>
        </div>
    </form>
    <script src="/Scripts/jquery-2.2.0.min.js"></script>
    <script src="/Scripts/bootstrap.min.js"></script>
    <script>
        $(function () {
            $.ajax({
                url: "/servico/transito",
                async: true,
                success: function (result) {
                    $('#zn').html(result.Norte);
                    $('#zl').html(result.Leste);
                    $('#zo').html(result.Oeste);
                    $('#zs').html(result.Sul);
                    $('#centro').html(result.Centro);
                    $('#total').html(result.Total);
                }
            });
        });

    </script>
</body>
</html>
