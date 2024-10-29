using System;
using Microsoft.EntityFrameworkCore;
using Parfois.API.Data;
using Parfois.API.Dtos;
using Parfois.API.Entities;
using Parfois.API.Mapping;

namespace Parfois.API.Endpoints;

public static class StatusEndpoints
{
    const string GetItemEndpointName = "GetStatus";
    public static RouteGroupBuilder MapStatusEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("api/status");

        // PUT /api/status/
        group.MapPut("/", async (UpdateStatusDto updatedStatus, ParfoisContext dbContext) => 
        {
            var existingPEdido = await dbContext.Pedidos.FindAsync(updatedStatus.id);

            if(existingPEdido is null) {
                return Results.NotFound();
            }

            dbContext.Entry(existingPEdido).CurrentValues.SetValues(updatedStatus.ToEntity(updatedStatus.id));

            await dbContext.SaveChangesAsync();

            return Results.NoContent();
        });

        return group;
    }
}