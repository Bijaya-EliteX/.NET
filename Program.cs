using PizzaStore.DB;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c=>{
    c.SwaggerDoc("Bijaya",new OpenApiInfo{ Title = "PizzaStore API",Description="Making the Pizzas you love",Version="Bijaya"});
});
var app = builder.Build();

if (app.Environment.IsDevelopment()){
    app.UseSwagger();
    app.UseSwaggerUI(c=>{
        c.SwaggerEndpoint("/swagger/Bijaya/swagger.json","PizzaStore API V1");
    });
}

app.MapGet("/", () => "Hello World!");

app.MapGet("/pizzas/{id}",(int id)=> PizzaDB.GetPizza(id));
app.MapGet("/Pizzas",()=>PizzaDB.GetPizzas());
app.MapPost("/pizzas",(Pizza pizza)=> PizzaDB.CreatePizza(pizza));
app.MapPut("/pizzas",(Pizza pizza)=>PizzaDB.UpdatePizza(pizza));
app.MapDelete("/pizzas/{id}",(int id)=> PizzaDB.RemovePizza(id));

app.Run();
