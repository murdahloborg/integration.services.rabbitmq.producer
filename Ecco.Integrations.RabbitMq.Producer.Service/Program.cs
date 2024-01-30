using Ecco.Integrations.RabbitMq.AppBuilders;

var builder = ProducerAppBuilder.CreateBuilder(args, true);

var app = builder.Build();

app.Run();