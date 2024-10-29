using System;
using Parfois.API.Dtos;
using Parfois.API.Entities;

namespace Parfois.API.Mapping;

public static class PedidoMapping
{
    public static PedidoDto ToDto(this Pedido encomenda)
    {
        return new PedidoDto(
            encomenda.id,
            encomenda.pedido,
            encomenda.status ?? "Em espera",
            encomenda.itensAprovados,
            encomenda.valorAprovado
        );
    }

    public static Pedido ToEntity(this CreatePedidoDto encomenda)
    {
        return new Pedido()
        {
            id = encomenda.id,
            pedido = encomenda.pedido,
            status = encomenda.status,
            itensAprovados = encomenda.itensAprovados, 
            valorAprovado = encomenda.valorAprovado
        };
    }
    
    public static Pedido ToEntity(this UpdateStatusDto encomenda, int id)
    {
        return new Pedido()
        {
            id = encomenda.id,
            pedido = encomenda.pedido,
            status = encomenda.status,
            itensAprovados = encomenda.itensAprovados, 
            valorAprovado = encomenda.valorAprovado
        };
    }
    
    public static PedidoDto ToPedidoDto(this Pedido encomenda)
    {
        return new(
            encomenda.id,
            encomenda.pedido, 
            encomenda.status ?? "Em espera",
            encomenda.itensAprovados,
            encomenda.valorAprovado
        );
    }
}
