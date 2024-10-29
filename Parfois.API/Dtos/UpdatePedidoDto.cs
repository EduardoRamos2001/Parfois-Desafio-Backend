using System.ComponentModel.DataAnnotations;

namespace Parfois.API.Dtos;

public record class UpdatePedidoDto(    
    int id,
    int pedido,
    string status,
    int itensAprovados,
    int valorAprovado
);