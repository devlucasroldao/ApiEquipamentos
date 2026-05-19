using Microsoft.EntityFrameworkCore;
using ApiEquipamentos;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=equipamentos.db"));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.EnsureCreated();
}

app.MapGet("/", () => "API de Equipamentos - Minimal API com .NET");

app.MapGet("/status", () => Results.Ok(new
{
    status = "online",
    mensagem = "API funcionando",
    dataHora = DateTime.Now
}));

app.MapGet("/equipamentos", async (AppDbContext db) =>
    await db.Equipamentos.ToListAsync());

app.MapGet("/equipamentos/{id}", async (int id, AppDbContext db) =>
{
    var equipamento = await db.Equipamentos.FindAsync(id);
    return equipamento is null ? Results.NotFound() : Results.Ok(equipamento);
});

app.MapPost("/equipamentos", async (Equipamento equipamento, AppDbContext db) =>
{
    db.Equipamentos.Add(equipamento);
    await db.SaveChangesAsync();
    return Results.Created($"/equipamentos/{equipamento.Id}", equipamento);
});

app.MapPut("/equipamentos/{id}", async (int id, Equipamento dados, AppDbContext db) =>
{
    var equipamento = await db.Equipamentos.FindAsync(id);
    if (equipamento is null) return Results.NotFound();

    equipamento.Nome = dados.Nome;
    equipamento.Tipo = dados.Tipo;
    equipamento.ValorPatrimonio = dados.ValorPatrimonio;
    equipamento.Ativo = dados.Ativo;
    equipamento.DataCadastro = dados.DataCadastro;

    await db.SaveChangesAsync();
    return Results.Ok(equipamento);
});

app.MapDelete("/equipamentos/{id}", async (int id, AppDbContext db) =>
{
    var equipamento = await db.Equipamentos.FindAsync(id);
    if (equipamento is null) return Results.NotFound();

    db.Equipamentos.Remove(equipamento);
    await db.SaveChangesAsync();
    return Results.NoContent();
});

// GET /equipamentos/ativos — Lista só os ativos
app.MapGet("/equipamentos/ativos", async (AppDbContext db) =>
    await db.Equipamentos.Where(e => e.Ativo).ToListAsync());

// GET /equipamentos/count — Conta quantos existem
app.MapGet("/equipamentos/count", async (AppDbContext db) =>
{
    var total = await db.Equipamentos.CountAsync();
    return Results.Ok(new { total });
});

// POST com validação — retorna 400 se nome estiver vazio
app.MapPost("/equipamentos/validado", async (Equipamento equipamento, AppDbContext db) =>
{
    if (string.IsNullOrWhiteSpace(equipamento.Nome))
        return Results.BadRequest("O nome do equipamento é obrigatório.");

    if (string.IsNullOrWhiteSpace(equipamento.Tipo))
        return Results.BadRequest("O tipo do equipamento é obrigatório.");

    if (equipamento.ValorPatrimonio <= 0)
        return Results.BadRequest("O valor patrimonial deve ser maior que zero.");

    db.Equipamentos.Add(equipamento);
    await db.SaveChangesAsync();
    return Results.Created($"/equipamentos/{equipamento.Id}", equipamento);
});

app.Run();