namespace Parfois.API.Dtos;

public record class ItemSummaryDto(
    int id,
    int id_pedido,
    string descricao,
    decimal precoUnitario,
    int qtd
);
