var productos = [];
const controlador = "Compras";

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

            var vCantidad = document.getElementById("txtCantidadProducto").value;
            var vPrecioCompra = document.getElementById("txtPrecioCompraProducto").value;
            var vPrecioVenta = document.getElementById("txtPrecioVentaProducto").value;
            var vPrecioMayoreo = document.getElementById("txtPrecioVentaMayoreoProducto").value;

            if (parseInt(vCantidad) <= 0) {
                alert("La cantidad debe ser mayor a 0")
                vTemp = false;
            }

            if (parseFloat(vPrecioCompra) <= 0) {
                alert("El precio de compra debe ser mayor a 0")
                vTemp = false;
            }

            if (parseFloat(vPrecioVenta) <= 0) {
                alert("El precio de venta debe ser mayor a 0")
                vTemp = false;
            }

            if (parseFloat(vPrecioMayoreo) <= 0) {
                alert("El precio mayoreo debe ser mayor a 0")
                vTemp = false;
            }

            if ((parseFloat(vPrecioCompra) >= parseFloat(vPrecioVenta)) || (parseFloat(vPrecioCompra) >= parseFloat(vPrecioMayoreo))) {
                alert("El precio de compra debe ser menor que el precio de venta")
                vTemp = false;
            }


            if (vTemp) {
                var producto = {
                    IdProducto: vCodigo,
                    Descripcion: vDescripcion,
                    Cantidad: vCantidad,
                    PrecioCompra: vPrecioCompra,
                    PrecioVenta: vPrecioVenta,
                    PrecioMayoreo: vPrecioMayoreo,
                    SubTotal: vCantidad * vPrecioCompra,
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
            $("<td>").append(item.PrecioCompra),
            $("<td>").append(item.PrecioVenta),
            $("<td>").append(item.PrecioMayoreo),
            $("<td>").append(item.SubTotal),
        ).data("idproducto", item.IdProducto).appendTo("#tabla tbody")
    })

    MostrarPrecios(productos);
}

function MostrarPrecios(vProductos) {
    let total = vProductos.reduce(function (accumulator, item) {
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

$("#tabla tbody").on("click", ".btn-eliminar", function () {

    var idproducto = $(this).closest('tr').data("idproducto");

    const newArray = productos.filter(object => {
        return object.IdProducto !== idproducto;
    });

    productos = newArray;
    $(this).closest('tr').remove();

    MostrarPrecios(productos);

    //$("#txtPagoCon").val("");
    //$("#txtCambio").val("");
})

function AdicionarTabla() {

    var listDetalleCompra = []
    var total = 0;
    let vTemp = true;

    let tabla = document.getElementById("tabla");

    for (let i = 1, celda; i < tabla.rows.length; i++) {

        objDetalleCompra = {
            ProductoId: tabla.rows[i].cells[1].innerHTML,
            Cantidad: tabla.rows[i].cells[3].innerHTML,
            PrecioCompra: tabla.rows[i].cells[4].innerHTML,
            PrecioVenta: tabla.rows[i].cells[5].innerHTML,
            PrecioMayoreo: tabla.rows[i].cells[6].innerHTML,
            Subtotal: tabla.rows[i].cells[7].innerHTML
        }

        listDetalleCompra.push(objDetalleCompra);
    }

    if (document.getElementById("txtFecha").value == '') {
        alert("Por favor seleccione una fecha")
        vTemp = false;
    }

    if (document.getElementById("ProveedorId").value == 0) {
        alert("Por favor seleccione un proveedor")
        vTemp = false;
    }

    if (vTemp) {
        var oCompraVM = {
            oCompra: {
                FechaCompra: document.getElementById("txtFecha").value,
                ProveedorId: document.getElementById("ProveedorId").value,
                TipoComprobanteId: document.getElementById("TipoComprobanteId").value,
                NumeroComprobante: document.getElementById("txtNumeroComprobante").value,
                Subtotal: document.getElementById("txtSubtotal").value,
                Iva: document.getElementById("txtIva").value,
                Total: document.getElementById("txtTotal").value,
                IsActive: true
            },

            oDetalleCompra: listDetalleCompra
        }

        fetch(`/${controlador}/Create`, {
            method: "POST",
            headers: { 'Content-Type': 'application/json;charset=utf-8' },
            body: JSON.stringify(oCompraVM)
        })
            .then(response => response.text())
            .then(data => {
                alert("Compra Registrada")

                location.reload();
            });

    }

}

function LimpiarLista() {
    document.getElementById("ProductoId").value = 0;

    document.getElementById("txtCantidadProducto").value = 0;
    document.getElementById("txtPrecioCompraProducto").value = 0;
    document.getElementById("txtPrecioVentaProducto").value = 0;
    document.getElementById("txtPrecioVentaMayoreoProducto").value = 0;
}

