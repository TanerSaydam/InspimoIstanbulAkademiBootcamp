using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

var factory = new ConnectionFactory { HostName = "localhost" };
using var connection = factory.CreateConnection();
using var channel = connection.CreateModel();

channel.ExchangeDeclare(exchange: "logs", type: ExchangeType.Fanout);

Log log = new()
{
    Entity = args[0],
    Date = DateTime.Now,
    Message = args[1]
};
string message = JsonSerializer.Serialize(log);
var body = Encoding.UTF8.GetBytes(message);

channel.BasicPublish(
    exchange: "logs", 
    routingKey: string.Empty,
    basicProperties: null,
    body: body);

Console.WriteLine(" [x] Message send");

class Log
{
    public string Entity { get; set; } = string.Empty;
    public DateTime Date { get; set; }
    public string Message { get; set; } = string.Empty;
}