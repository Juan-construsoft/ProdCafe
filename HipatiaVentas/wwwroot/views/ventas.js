let productos = [];
const controlador = "Ventas";

const vFecha = new Date();
const vNumeroComprobante = vFecha.getFullYear() + '' + (vFecha.getMonth() + 1) + '' + vFecha.getDate() + '' + vFecha
    .getHours() + '' + vFecha.getMinutes() + '' + vFecha.getSeconds();

$(document).ready(function () {

    $('#txtNumeroComprobante').val(vNumeroComprobante);

    MostrarPrecios();
    mostrarListaVacia();
})

function AgregarProducto() {

    var existe_codigo = false;

    const existe = productos.some(element => element.IdProducto === $("#ProductoId").val());

    if ($("#ProductoId").val() != 0) {

        if (existe) {
            alert('el producto ya existe');
        } else {

            let vTemp = true;

            var vCodigo = document.getElementById("ProductoId").value;
            var vCombo = document.getElementById("ProductoId");
            var vDescripcion = vCombo.options[vCombo.selectedIndex].text;

            let vStock = document.getElementById("txtStock").value;
            let vCantidad = document.getElementById("txtCantidadProducto").value;
            let vPrecioVenta = document.getElementById("txtPrecioVentaProducto").value;
            let vDescuento = document.getElementById("txtDescuento").value;

            if (Number(vStock) <= 0) {
                alert("El stock no puede estar en 0")
                vTemp = false;
            }

            if (Number(vCantidad) <= 0) {
                alert("La cantidad debe ser mayor a 0")
                vTemp = false;
            }

            if (Number(vCantidad) > Number(vStock)) {
                alert("La cantidad no puede ser mayor que el stock")
                vTemp = false;
            }

            if (Number(vPrecioVenta) <= 0) {
                alert("El precio de venta debe ser mayor a 0")
                vTemp = false;
            }

            if (Number(vDescuento) > Number(vPrecioVenta * vCantidad)) {
                alert("El descuento debe ser mayor o igual al precio de venta")
                vTemp = false;
            }

            if (vTemp) {
                var producto = {
                    IdProducto: vCodigo,
                    Descripcion: vDescripcion,
                    Cantidad: vCantidad,
                    PrecioVenta: vPrecioVenta,
                    Descuento: vDescuento,
                    SubTotal: (vCantidad * vPrecioVenta) - vDescuento,
                }

                productos.push(producto);

                LimpiarLista();
            }
        }
    }

    $("#tabla tbody").html("");

    $.each(productos, function (i, item) {

        $("<tr>").append(
            $("<td>").append(
                $("<button>").addClass("btn link-danger btn-eliminar").append(
                    $("<i>").addClass("ri-delete-bin-5-line")
                )
            ),
            $("<td hidden>").append(item.IdProducto),
            $("<td>").append(item.Descripcion),
            $("<td>").append(item.Cantidad),
            $("<td>").append(item.PrecioVenta),
            $("<td>").append(item.Descuento),
            $("<td>").append(item.SubTotal),
        ).data("idproducto", item.IdProducto).appendTo("#tabla tbody")
    })

    MostrarPrecios(productos);
}

function mostrarValores() {

    var vCodigo = document.getElementById("ProductoId").value;

    fetch(`/${controlador}/ProductoById`, {
        method: "POST",
        headers: { 'Content-Type': 'application/json;charset=utf-8' },
        body: JSON.stringify(vCodigo)
    })
        .then(response => response.json())
        .then(datos => {

            if (datos.mensage == "exitoso") {

                $('#txtStock').val(datos.data.stock);
                $('#txtPrecioVentaProducto').val(datos.data.precioVenta);
            }

            location.reload();
        });
}

function MostrarPrecios(productos) {
    let total = productos.reduce(function (accumulator, item) {
        return accumulator + item.SubTotal
    }, 0)

    //let base = total / 1.18;
    //let iva = total - base;

    let base = total;
    let iva = total - base;

    $("#txtSubtotal").val(base.toFixed(2))
    $("#txtIva").val(iva.toFixed(2))
    $("#txtTotal").val(total.toFixed(2))
}

function mostrarListaVacia() {
    if (productos.length === 0) {
        $("#tabla tbody").html("<tr><td colspan='5'><p class='text-warning text-center'>Ningún producto seleccionado</p></td></tr>");
    }
}

function LimpiarLista() {
    document.getElementById("ProductoId").value = 0;

    document.getElementById("txtCantidadProducto").value = 0;
    document.getElementById("txtStock").value = 0;
    document.getElementById("txtDescuento").value = 0;
    document.getElementById("txtPrecioVentaProducto").value = 0;
}

function AdicionarVenta() {
    var listDetalleVenta = []
    var total = 0;
    let vTemp = true;

    let tabla = document.getElementById("tabla");

    for (let i = 1, celda; i < tabla.rows.length; i++) {

        objDetalleVenta = {
            ProductoId: tabla.rows[i].cells[1].innerHTML,
            Cantidad: tabla.rows[i].cells[3].innerHTML,
            PrecioVenta: tabla.rows[i].cells[4].innerHTML,
            Descuento: tabla.rows[i].cells[5].innerHTML,
            Subtotal: tabla.rows[i].cells[6].innerHTML
        }

        listDetalleVenta.push(objDetalleVenta);
    }

    if (document.getElementById("txtFecha").value == '') {
        alert("Por favor seleccione una fecha")
        vTemp = false;
    }

    if (document.getElementById("ClienteId").value == 0) {
        alert("Por favor seleccione un cliente")
        vTemp = false;
    }

    if (document.getElementById("CajaId").value == 0) {
        alert("Por favor seleccione una caja")
        vTemp = false;
    }

    if (document.getElementById("TipoComprobanteId").value == 0) {
        alert("Por favor seleccione un comprobante")
        vTemp = false;
    }

    if (vTemp) {
        var oVentaVM = {
            oVenta: {
                FechaVenta: document.getElementById("txtFecha").value,
                ClienteId: document.getElementById("ClienteId").value,
                CajaId: document.getElementById("CajaId").value,
                TipoComprobanteId: document.getElementById("TipoComprobanteId").value,
                NumeroComprobante: document.getElementById("txtNumeroComprobante").value,
                Subtotal: document.getElementById("txtSubtotal").value,
                Iva: document.getElementById("txtIva").value,
                Total: document.getElementById("txtTotal").value,
                IsActive: true
            },

            oDetalleVenta: listDetalleVenta
        }

        console.log(oVentaVM);

        fetch(`/${controlador}/Create`, {
            method: "POST",
            headers: { 'Content-Type': 'application/json;charset=utf-8' },
            body: JSON.stringify(oVentaVM)
        })
            .then(response => response.text())
            .then(data => {
                alert("Venta Registrada")

                location.reload();
            });
    }
}

$("#tabla tbody").on("click", ".btn-eliminar", function () {

    var idproducto = $(this).closest('tr').data("idproducto");

    const newArray = productos.filter(object => {
        return object.IdProducto !== idproducto;
    });

    productos = newArray;
    $(this).closest('tr').remove();

    MostrarPrecios(productos);
})
