using System;
using Microsoft.EntityFrameworkCore;
using Parfois.API.Data;
using Parfois.API.Dtos;
using Parfois.API.Entities;
using Parfois.API.Mapping;

namespace Parfois.API.Endpoints;

public static class ItemsEndpoints
{
    const string GetItemEndpointName = "GetItem";

    public static RouteGroupBuilder MapItemsEndpoints(this WebApplication app) {
        var group = app.MapGroup("items")
            .WithParameterValidation();

        // GET /items
        group.MapGet("/", async (ParfoisContext dbContext) => await dbContext.Items
            .Select(item => item.ToItemSummaryDto())
            .AsNoTracking()
            .ToListAsync()
        );

        // GET /items/1
        group.MapGet("/{id}", async (int id, ParfoisContext dbContext) => {
                Item? item = await dbContext.Items.FindAsync(id);

                return item is null ? Results.NotFound() : Results.Ok(item);
            }
        ).WithName(GetItemEndpointName);

        // POST /items
        group.MapPost("/", async (CreateItemDto newItem, ParfoisContext dbContext) =>
        {
            Item item = newItem.ToEntity();

            dbContext.Items.Add(item);
            await dbContext.SaveChangesAsync();

            return Results.CreatedAtRoute(GetItemEndpointName, new {id = item.id}, item.ToItemDetailsDto());
        });

        // PUT /items/1
        group.MapPut("/{id}", async (int id, UpdateItemDto updatedItem, ParfoisContext dbContext) => 
        {
            var existingItem = await dbContext.Items.FindAsync(id);

            if(existingItem is null) {
                return Results.NotFound();
            }

            dbContext.Entry(existingItem).CurrentValues.SetValues(updatedItem.ToEntity(id));

            await dbContext.SaveChangesAsync();

            return Results.NoContent();
        });

        // DELETE /items/1
        group.MapDelete("/{id}", async (int id, ParfoisContext dbContext) => 
        {
            await dbContext.Items
                .Where(item => item.id == id)
                .ExecuteDeleteAsync();

            return Results.NoContent();
        });

        return group;
    }
}
