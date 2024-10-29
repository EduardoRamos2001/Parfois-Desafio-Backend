using System;
using Parfois.API.Dtos;
using Parfois.API.Entities;

namespace Parfois.API.Mapping;

public static class ItemMapping
{
    public static Item ToEntity(this CreateItemDto item)
    {
        return new Item()
        {
            id_pedido = item.id_pedido,
            descricao = item.descricao,
            precoUnitario = item.precoUnitario,
            qtd = item.qtd
        };
    }
    
    public static Item ToEntity(this UpdateItemDto item, int id)
    {
        return new Item()
        {
            id = id,
            id_pedido = item.id_pedido,
            descricao = item.descricao,
            precoUnitario = item.precoUnitario,
            qtd = item.qtd
        };
    }

    public static ItemSummaryDto ToItemSummaryDto(this Item item)
    {
        return new(
            item.id,
            item.id_pedido,
            item.descricao,
            item.precoUnitario,
            item.qtd
        );
    }

    public static ItemDetailsDto ToItemDetailsDto(this Item item)
    {
        return new(
            item.id,
            item.id_pedido,
            item.descricao,
            item.precoUnitario,
            item.qtd
        );
    }
}
