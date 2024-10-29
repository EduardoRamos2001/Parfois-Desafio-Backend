using System;
using System.ComponentModel.DataAnnotations;

namespace Parfois.API.Dtos;

public record class UpdateStatusDto(
    [Required]int id,
    [Required]int pedido,
    [Required]string status,
    [Required]int itensAprovados,
    [Required]int valorAprovado
);