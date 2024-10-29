using System;
using Microsoft.EntityFrameworkCore;
using Parfois.API.Entities;

namespace Parfois.API.Data;

public class ParfoisContext(DbContextOptions<ParfoisContext> options) : DbContext(options)
{
    public DbSet<Pedido> Pedidos => Set<Pedido>();
    public DbSet<Item> Items => Set<Item>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Item>()
            .Property(i => i.precoUnitario)
            .HasConversion<double>();
            
        // Dados inicias para pedidos
        modelBuilder.Entity<Pedido>().HasData(
            new { id = 1, pedido = 1, status = "Em espera", itensAprovados = 0, valorAprovado = 0 },
            new { id = 2, pedido = 2, status = "Em espera", itensAprovados = 0, valorAprovado = 0 },
            new { id = 3, pedido = 3, status = "Em espera", itensAprovados = 0, valorAprovado = 0 },
            new { id = 4, pedido = 4, status = "Em espera", itensAprovados = 0, valorAprovado = 0 },
            new { id = 5, pedido = 5, status = "Em espera", itensAprovados = 0, valorAprovado = 0 }
        );

        // Dados iniciais para itens        
        modelBuilder.Entity<Item>().HasData(
            new { id = 1, id_pedido = 1, descricao = "Item 01", precoUnitario = 1m, qtd = 1 },
            new { id = 2, id_pedido = 1, descricao = "Item 02", precoUnitario = 1.25m, qtd = 3 },
            new { id = 3, id_pedido = 2, descricao = "Item 03", precoUnitario = 1.75m, qtd = 1 },
            new { id = 4, id_pedido = 3, descricao = "Item 04", precoUnitario = 1.5m, qtd = 2 },
            new { id = 5, id_pedido = 4, descricao = "Item 05", precoUnitario = 2.25m, qtd = 4 }
        );
    }
   
}