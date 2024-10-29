using System;

namespace Parfois.API.Entities;

public class Pedido
{
    public int id { get; set; }
    public int pedido { get; set; }
    public string? status { get; set; } // Permite valores nulos
    public int itensAprovados { get; set; } = 0; // Caso não tenha valor, fica igual a 0
    public int valorAprovado { get; set; } = 0; // Caso não tenha valor, fica igual a 0
    public List<Item>? Items { get; set; }
}

