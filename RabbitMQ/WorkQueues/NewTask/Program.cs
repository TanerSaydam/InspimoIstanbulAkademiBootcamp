using RabbitMQ.Client;
using System.Text;

var factory = new ConnectionFactory { HostName = "localhost" };
var connection = factory.CreateConnection();
var channel = connection.CreateModel();

channel.QueueDeclare(
    queue: "task_queue",
    durable: true,
    exclusive: false,
    autoDelete: false,
    arguments: null);

var message = GetMessage(args);
var body = Encoding.UTF8.GetBytes(message);

var properties = channel.CreateBasicProperties();
properties.Persistent = true;

channel.BasicPublish(
    exchange: string.Empty,
    routingKey: "task_queue",
    basicProperties: properties,
    body: body);

Console.WriteLine(" [x] Message sent");

static string GetMessage(string[] args)
{
    string message = "Hello world!";
    if(args.Length > 0)
    {
        message = string.Join(" ", args);
    }
    return message;
}