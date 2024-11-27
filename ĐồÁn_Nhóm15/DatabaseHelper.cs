using ĐồÁn_Nhóm15;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;

public class DatabaseHelper
{
    private IMongoDatabase db;

    public DatabaseHelper(string databaseName)
    {
        var client = new MongoClient("mongodb+srv://thuanthen:thuanthennek@cluster0.o3wzx.mongodb.net/?retryWrites=true&w=majority&appName=Cluster0");
        db = client.GetDatabase(databaseName);
    }

    public List<User> SearchUsersByEmail(string email)
    {
        var collection = db.GetCollection<User>("Login"); // Đảm bảo tên collection đúng
        var filter = Builders<User>.Filter.Regex(u => u.email, new BsonRegularExpression(email, "i")); // Tìm kiếm không phân biệt hoa thường
        return collection.Find(filter).ToList();
    }

    public void InsertChatMessage(ChatMessage message)
    {
        var collection = db.GetCollection<ChatMessage>("Chatting");
        collection.InsertOne(message);

        // Log dữ liệu tin nhắn được lưu
        Console.WriteLine($"Inserted message from {message.User1} to {message.User2}: {message.Message} at {message.Timestamp}");
    }


    public List<User> GetAllUsers()
    {
        var collection = db.GetCollection<User>("Login");
        return collection.Find(new BsonDocument()).ToList();
    }
    public List<ChatMessage> GetChatHistory(string user1, string user2)
    {
        var collection = db.GetCollection<ChatMessage>("Chatting");
        var filter = Builders<ChatMessage>.Filter.Or(
            Builders<ChatMessage>.Filter.And(
                Builders<ChatMessage>.Filter.Eq(m => m.User1, user1),
                Builders<ChatMessage>.Filter.Eq(m => m.User2, user2)
            ),
            Builders<ChatMessage>.Filter.And(
                Builders<ChatMessage>.Filter.Eq(m => m.User1, user2),
                Builders<ChatMessage>.Filter.Eq(m => m.User2, user1)
            )
        );

        var result = collection.Find(filter).SortBy(m => m.Timestamp).ToList();

        // Log dữ liệu truy vấn
        //Console.WriteLine($"Querying chat history for {user1} and {user2}");
        //Console.WriteLine($"Number of messages found: {result.Count}");
        /*foreach (var message in result)
        {
            Console.WriteLine($"Message from {message.User1} to {message.User2}: {message.Message} at {message.Timestamp}");
        }*/

        return result;
    }
    public List<UserChat> GetUserChats(string currentUserEmail)
    {
        var collection = db.GetCollection<ChatMessage>("Chatting");
        var filter = Builders<ChatMessage>.Filter.Or(
            Builders<ChatMessage>.Filter.Eq(m => m.User1, currentUserEmail),
            Builders<ChatMessage>.Filter.Eq(m => m.User2, currentUserEmail)
        );

        var chatMessages = collection.Find(filter).SortByDescending(m => m.Timestamp).ToList();

        var userChats = chatMessages
            .GroupBy(m => m.User1 == currentUserEmail ? m.User2 : m.User1)
            .Select(g => new UserChat
            {
                UserEmail = g.Key,
                UserName = db.GetCollection<User>("Login").Find(u => u.email == g.Key).FirstOrDefault()?.name,
                LastMessage = g.FirstOrDefault()?.Message
            })
            .ToList();

        return userChats;
    }
    public class UserChat
    {
        public string UserEmail { get; set; }
        public string UserName { get; set; }
        public string LastMessage { get; set; }
    }


}
