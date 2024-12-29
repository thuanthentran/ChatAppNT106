using System.Collections.Concurrent;
using System.Net.Sockets;
using System.Net;
using System.Text.Json;
using System.Text;
using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;
namespace Server
{
    class Server
    {
        private TcpListener _listener;
        private readonly ConcurrentDictionary<string, TcpClient> _clients = new();
        private readonly IMongoCollection<BsonDocument> _collection;

        public Server(string dbConnectionString, int port)
        {
            _listener = new TcpListener(IPAddress.Parse("10.0.55.155"), 12345);
            var client = new MongoClient(dbConnectionString);
            var database = client.GetDatabase("NMM");
            _collection = database.GetCollection<BsonDocument>("Chatting");
        }

        public void Start()
        {
            _listener.Start();
            Console.WriteLine("Server started...");

            while (true)
            {
                var client = _listener.AcceptTcpClient();
                var thread = new Thread(HandleClient);
                thread.Start(client);
            }
        }

        private async void HandleClient(object obj)
        {
            var client = (TcpClient)obj;
            var stream = client.GetStream();
            var buffer = new byte[1024];
            string email = null;

            try
            {
                // Đọc email từ client ngay khi kết nối
                int bytesRead = stream.Read(buffer, 0, buffer.Length);
                var emailJson = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                var emailObj = JsonConvert.DeserializeObject<dynamic>(emailJson);
                email = emailObj.User1;

                if (string.IsNullOrEmpty(email))
                {
                    Console.WriteLine("Client did not provide email.");
                    client.Close();
                    return;
                }

                // Xác thực và lưu trữ client vào dictionary
                if (!_clients.ContainsKey(email))
                {
                    _clients[email] = client;
                    Console.WriteLine($"Client {email} connected.");
                }

                // Tiếp tục xử lý các tin nhắn từ client
                while (true)
                {
                    if (!stream.DataAvailable) continue;
                    bytesRead = stream.Read(buffer, 0, buffer.Length);
                    if (bytesRead == 0) break;

                    var messageJson = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    var messageObj = JsonConvert.DeserializeObject<dynamic>(messageJson);

                    email = messageObj.User1;
                    if (!_clients.ContainsKey(email))
                    {
                        _clients[email] = client;
                        Console.WriteLine($"Client {email} connected.");
                    }
                    SaveMessageToDatabase(messageObj);

                    var recipientEmail = (string)messageObj.User2;
                    if (_clients.TryGetValue(recipientEmail, out var recipientClient))
                    {
                        Console.WriteLine(recipientEmail);
                        var recipientStream = recipientClient.GetStream();
                        recipientStream.Write(buffer, 0, bytesRead);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            finally
            {
                if (email != null) _clients.TryRemove(email, out _);
                client.Close();
            }
        }

        private void SaveMessageToDatabase(dynamic message)
        {
            var document = new BsonDocument
            {
                { "User1", message.User1.ToString() },
                { "User2", message.User2.ToString() },
                { "Message", message.Message.ToString() },
                { "Timestamp", BsonDateTime.Create((DateTime)message.Timestamp) }
            };

            _collection.InsertOne(document);
        }
    }

    class Program
    {
        static void Main()
        {
            var server = new Server("mongodb+srv://thuanthen:thuanthennek@cluster0.o3wzx.mongodb.net/?retryWrites=true&w=majority&appName=Cluster0", 12345);
            server.Start();
        }
    }
}