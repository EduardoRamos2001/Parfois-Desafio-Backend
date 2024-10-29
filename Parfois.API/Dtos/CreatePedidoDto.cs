using System.ComponentModel.DataAnnotations;
using Parfois.API.Entities;

namespace Parfois.API.Dtos;
public record class CreatePedidoDto(  
    int id,
    int pedido,
    string status,
    int itensAprovados,
    int valorAprovado,
    List<Item>? Items
);
