namespace Parfois.API.Dtos;

public record class ItemDetailsDto(
    int id,
    int id_pedido,
    string descricao,
    decimal precoUnitario,
    int qtd
);
