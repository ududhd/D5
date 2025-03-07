using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Template;
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
List <person> repo = [];
app.MapGet("/", () => repo);
app.MapPost("/", (person o) => repo.Add(o));
app.MapPut("/", ([FromQuery] Guid Id, UpdateDTO dto) =>
{
    person buffer = repo.Find(x => x.Id == Id);
    buffer.weapon = dto.weapon;
    buffer.Name = dto.name;
    buffer.description = dto.description;
    buffer.lvl = dto.lvl;
});
app.MapDelete("/", ([FromQuery] Guid Id) =>
{
    person buffer = repo.Find(x => x.Id == Id);
    repo.Remove(buffer);
});
app.Run();
class person 
{
    public Guid Id { get; set; }
    public int number { get; set; }
    public string Name { get; set; }
    public string description { get; set; }

    public string weapon { get; set; }
    public int lvl { get; set; }
}
record UpdateDTO(string name, string description, string weapon, int lvl);