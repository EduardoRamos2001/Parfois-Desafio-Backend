using System.ComponentModel.DataAnnotations;

namespace Parfois.API.Dtos;

public record class CreateItemDto(
    [Required] int id_pedido,
    [Required][StringLength(50)] string descricao,
    [Required] int precoUnitario,
    [Range(1, 500)] int qtd
);