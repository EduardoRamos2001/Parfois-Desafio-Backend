using System;
using Microsoft.EntityFrameworkCore;
using Parfois.API.Data;
using Parfois.API.Dtos;
using Parfois.API.Entities;
using Parfois.API.Mapping;

namespace Parfois.API.Endpoints;

public static class PedidosEndpoints
{
    
    const string GetPedidoEndpointName = "GetPedido";

    public static RouteGroupBuilder MapPedidosEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("api/pedido");

        // GET /api/pedido
        group.MapGet("/", async (ParfoisContext dbContext) => 
            await dbContext.Pedidos
                .Select(pedido => pedido.ToDto())
                .AsNoTracking()
                .ToListAsync()
        );
        
        // GET /api/pedido/{id}
        group.MapGet("/{id}", async (int pedido, ParfoisContext dbContext) => {
                Pedido? encomenda = await dbContext.Pedidos.FindAsync(pedido);

                return encomenda is null ? Results.NotFound() : Results.Ok(encomenda);
            }
        
        );

        // POST /api/pedido
        //CRIA O PEDIDO, SEM ITEMS
        group.MapPost("/", async (CreatePedidoDto newPedido, ParfoisContext dbContext) =>
        {
            if (await dbContext.Pedidos.AnyAsync(p => p.pedido == newPedido.pedido))
            {
                return Results.BadRequest($"Um pedido com o campo pedido '{newPedido.pedido}' já existe."); 
            }

            Pedido pedido = newPedido.ToEntity();

            dbContext.Pedidos.Add(pedido);
            await dbContext.SaveChangesAsync();

            return Results.CreatedAtRoute(GetPedidoEndpointName, new {id = pedido.id}, pedido.ToPedidoDto());
        });
        
        return group;
    }
    
}
