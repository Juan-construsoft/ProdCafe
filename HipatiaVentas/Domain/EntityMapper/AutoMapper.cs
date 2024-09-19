using AutoMapper;
using HipatiaVentas.Domain.Dtos;
using HipatiaVentas.Models;

namespace HipatiaVentas.Domain.EntityMapper
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<Caja, CajaDto>().ReverseMap();
            CreateMap<CrearCajaDto, Caja>();

            CreateMap<Cliente, ClienteDto>().ReverseMap();
            CreateMap<CrearClienteDto, Cliente>();

            CreateMap<Compra, CompraDto>().ReverseMap();
            CreateMap<CrearCompraDto, Compra>();

            CreateMap<DetalleCompra, DetalleCompraDto>().ReverseMap();
            CreateMap<CrearDetalleCompraDto, DetalleCompra>();

            //CreateMap<Departamento, DepartamentoDto>().ReverseMap();
            //CreateMap<DepartamentoDto, Departamento>();



            //CreateMap<MovimientoCaja, MovimientoCajaDto>().ReverseMap();
            //CreateMap<MovimientoCajaDto, MovimientoCaja>();

            //CreateMap<Municipio, MunicipioDto>().ReverseMap();
            //CreateMap<MunicipioDto, Municipio>();

            CreateMap<ParametroGeneral, ParametroGeneralDto>().ReverseMap();
            CreateMap<CrearParametroGeneralDto, ParametroGeneral>();

            CreateMap<Producto, ProductoDto>().ReverseMap();
            CreateMap<CrearProductoDto, Producto>();

            CreateMap<Proveedor, ProveedorDto>().ReverseMap();
            CreateMap<CrearProveedorDto, Proveedor>();

            CreateMap<RegistroTostion, RegistroTostionDto>().ReverseMap();
            CreateMap<CrearRegistroTostionDto, RegistroTostion>();

            CreateMap<TipoCategoria, TipoCategoriaDto>().ReverseMap();
            CreateMap<CrearTipoCategoriaDto, TipoCategoria>();

            CreateMap<Venta, VentaDto>().ReverseMap();
            CreateMap<CrearVentaDto, Venta>();

            CreateMap<DetalleVenta, DetalleVentaDto>().ReverseMap();
            CreateMap<CrearDetalleVentaDto, DetalleVenta>();

            CreateMap<RegistroCatacion, RegistroCatacionDto>().ReverseMap();
            CreateMap<CrearRegistroCatacionDto, RegistroCatacion>();

            
        }
    }
}
