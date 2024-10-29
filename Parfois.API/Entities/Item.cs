using System;

namespace Parfois.API.Entities;

public class Item
{
    public int id { get; set; }
    public int id_pedido { get; set; }
    public required string descricao { get; set; }
    public required decimal precoUnitario { get; set; }
    public required int qtd { get; set; }
}
