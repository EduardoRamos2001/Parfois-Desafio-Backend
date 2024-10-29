namespace Parfois.API.Dtos;

public record class PedidoDto(
    int id,
    int pedido,
    string status,
    int itensAprovados,
    int valorAprovado
);

