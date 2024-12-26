using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace ServerCaroGame
{
    //class ServerCaroGame
    //{
    //    private static List<TcpClient> clients = new List<TcpClient>();
    //    private static int currentPlayerIndex = 0; // Dùng để luân phiên giữa hai client

    //    static void Main(string[] args)
    //    {
    //        TcpListener server = new TcpListener(IPAddress.Any, 12346);
    //        server.Start();
    //        Console.WriteLine("Server is running...");

    //        while (true)
    //        {
    //            TcpClient client = server.AcceptTcpClient();
    //            clients.Add(client);
    //            Console.WriteLine("A client has connected.");
    //            Thread clientThread = new Thread(() => HandleClient(client));
    //            clientThread.Start();

    //            // Khi đủ hai client kết nối, bắt đầu trò chơi
    //            if (clients.Count == 2)
    //            {
    //                Console.WriteLine("Starting game between two clients.");
    //                SendMessageToClient(clients[0], "TURN:1");
    //                SendMessageToClient(clients[1], "WAIT:2");
    //            }
    //        }
    //    }

    //    private static void HandleClient(TcpClient client)
    //    {
    //        NetworkStream stream = client.GetStream();
    //        byte[] buffer = new byte[1024];

    //        while (true)
    //        {
    //            try
    //            {
    //                int bytesRead = stream.Read(buffer, 0, buffer.Length);
    //                if (bytesRead > 0)
    //                {
    //                    string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
    //                    Console.WriteLine($"Received: {message}");

    //                    if (message.StartsWith("MOVE"))
    //                    {
    //                        // Chuyển nước đi tới client khác và điều khiển lượt chơi
    //                        foreach (var otherClient in clients)
    //                        {
    //                            if (otherClient != client)
    //                            {
    //                                SendMessageToClient(otherClient, message);
    //                            }
    //                        }

    //                        // Chuyển lượt chơi
    //                        currentPlayerIndex = (currentPlayerIndex + 1) % 2;
    //                        SendMessageToClient(clients[currentPlayerIndex], "TURN:" + (currentPlayerIndex + 1));
    //                        SendMessageToClient(clients[(currentPlayerIndex + 1) % 2], "WAIT:" + ((currentPlayerIndex + 1) % 2 + 1));
    //                    }
    //                    else if (message.StartsWith("RESET"))
    //                    {
    //                        // Gửi lệnh RESET: đến tất cả các client
    //                        foreach (var c in clients)
    //                        {
    //                            SendMessageToClient(c, "RESET:");
    //                        }

    //                        // Luân phiên người bắt đầu trò chơi mới
    //                        currentPlayerIndex = (currentPlayerIndex + 1) % 2;

    //                        // Gửi lệnh TURN: và WAIT: cho các client
    //                        SendMessageToClient(clients[currentPlayerIndex], "TURN:" + (currentPlayerIndex + 1));
    //                        SendMessageToClient(clients[(currentPlayerIndex + 1) % 2], "WAIT:" + ((currentPlayerIndex + 1) % 2 + 1));

    //                        Console.WriteLine($"Game đã được reset. Người chơi {(currentPlayerIndex + 1)} sẽ bắt đầu trò chơi mới.");
    //                    }
    //                }
    //            }
    //            catch (Exception ex)
    //            {
    //                Console.WriteLine($"Error: {ex.Message}");
    //                clients.Remove(client);
    //                client.Close();
    //                break;
    //            }
    //        }
    //    }

    //    private static void SendMessageToClient(TcpClient client, string message)
    //    {
    //        byte[] data = Encoding.UTF8.GetBytes(message);
    //        NetworkStream stream = client.GetStream();
    //        stream.Write(data, 0, data.Length);
    //    }
    //}

    class ServerCaroGame
    {
        //// Map mã trận đấu tới danh sách client trong phòng
        //private static Dictionary<string, List<TcpClient>> matchRooms = new Dictionary<string, List<TcpClient>>();
        //private static object lockObj = new object(); // Để đồng bộ truy cập matchRooms

        private static Dictionary<string, MatchRoom> matchRooms = new Dictionary<string, MatchRoom>();
        private static object lockObj = new object(); // Để đồng bộ truy cập matchRooms

        static void Main(string[] args)
        {
            TcpListener server = new TcpListener(IPAddress.Any, 12346);
            server.Start();
            Console.WriteLine("Server is running...");

            while (true)
            {
                TcpClient client = server.AcceptTcpClient();
                Console.WriteLine("A client has connected.");
                Thread clientThread = new Thread(() => HandleClient(client));
                clientThread.Start();
            }
        }

        //private static void HandleClient(TcpClient client)
        //{
        //    NetworkStream stream = client.GetStream();
        //    byte[] buffer = new byte[1024];
        //    string currentMatchCode = null;
        //    string mySymbol = "";

        //    try
        //    {
        //        while (true)
        //        {
        //            int bytesRead = stream.Read(buffer, 0, buffer.Length);
        //            if (bytesRead == 0)
        //                break; // Client ngắt kết nối

        //            string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
        //            Console.WriteLine($"Received: {message}");

        //            string[] parts = message.Split(':');
        //            string command = parts[0];

        //            if (command == "JOIN")
        //            {
        //                string matchCode = parts[1];
        //                bool joinSuccess = false;

        //                lock (lockObj)
        //                {
        //                    if (!matchRooms.ContainsKey(matchCode))
        //                    {
        //                        matchRooms[matchCode] = new List<TcpClient>();
        //                    }

        //                    if (matchRooms[matchCode].Count < 2)
        //                    {
        //                        matchRooms[matchCode].Add(client);
        //                        currentMatchCode = matchCode;
        //                        joinSuccess = true;

        //                        if (matchRooms[matchCode].Count == 1)
        //                        {
        //                            // Người chơi đầu tiên tham gia phòng
        //                            SendMessageToClient(client, "JOIN_WAIT:");
        //                        }
        //                        else if (matchRooms[matchCode].Count == 2)
        //                        {
        //                            // Hai người chơi đã tham gia, bắt đầu trò chơi
        //                            SendMessageToClient(matchRooms[matchCode][0], "JOIN_SUCCESS:");
        //                            SendMessageToClient(matchRooms[matchCode][1], "JOIN_SUCCESS:");

        //                            // Phân loại quân cờ và lượt đi
        //                            SendMessageToClient(matchRooms[matchCode][0], "TURN:1"); // Người chơi đầu tiên là "X" và đi trước
        //                            SendMessageToClient(matchRooms[matchCode][1], "TURN:2"); // Người chơi thứ hai là "O"
        //                        }
        //                    }
        //                    else
        //                    {
        //                        // Phòng đã đầy
        //                        SendMessageToClient(client, "JOIN_FULL:");
        //                    }
        //                }

        //                if (!joinSuccess)
        //                {
        //                    // Nếu không thể tham gia phòng, đóng kết nối
        //                    client.Close();
        //                    break;
        //                }
        //            }
        //            else if (command == "MOVE")
        //            {
        //                if (currentMatchCode == null)
        //                    continue; // Không thuộc phòng nào

        //                lock (lockObj)
        //                {
        //                    List<TcpClient> roomClients = matchRooms[currentMatchCode];
        //                    foreach (var otherClient in roomClients)
        //                    {
        //                        if (otherClient != client)
        //                        {
        //                            SendMessageToClient(otherClient, message);
        //                        }
        //                    }

        //                    // Xác định lượt tiếp theo
        //                    int currentPlayerIndex = roomClients.IndexOf(client);
        //                    int nextPlayerIndex = (currentPlayerIndex + 1) % roomClients.Count;

        //                    string turnMessage = $"TURN:{nextPlayerIndex + 1}";
        //                    string waitMessage = $"WAIT:{currentPlayerIndex + 1}";

        //                    SendMessageToClient(roomClients[nextPlayerIndex], turnMessage);
        //                    SendMessageToClient(roomClients[currentPlayerIndex], waitMessage);
        //                }
        //            }
        //            else if (command == "RESET")
        //            {
        //                if (currentMatchCode == null)
        //                    continue;

        //                lock (lockObj)
        //                {
        //                    List<TcpClient> roomClients = matchRooms[currentMatchCode];
        //                    foreach (var c in roomClients)
        //                    {
        //                        SendMessageToClient(c, "RESET:");
        //                    }

        //                    // Luân phiên người bắt đầu nếu cần thiết
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Error: {ex.Message}");
        //    }
        //    finally
        //    {
        //        // Khi client ngắt kết nối, loại bỏ khỏi phòng
        //        if (currentMatchCode != null)
        //        {
        //            lock (lockObj)
        //            {
        //                if (matchRooms.ContainsKey(currentMatchCode))
        //                {
        //                    matchRooms[currentMatchCode].Remove(client);
        //                    if (matchRooms[currentMatchCode].Count == 0)
        //                    {
        //                        matchRooms.Remove(currentMatchCode);
        //                    }
        //                    else
        //                    {
        //                        // Thông báo cho client còn lại rằng đối thủ đã ngắt kết nối
        //                        SendMessageToClient(matchRooms[currentMatchCode][0], "RESET:");
        //                    }
        //                }
        //            }
        //        }

        //        client.Close();
        //    }
        //}

        private static void HandleClient(TcpClient client)
        {
            NetworkStream stream = client.GetStream();
            byte[] buffer = new byte[1024];
            string currentMatchCode = null;

            try
            {
                while (true)
                {
                    int bytesRead = stream.Read(buffer, 0, buffer.Length);
                    if (bytesRead == 0)
                        break; // Client ngắt kết nối

                    string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    Console.WriteLine($"Received: {message}");

                    string[] parts = message.Split(':');
                    string command = parts[0];

                    if (command == "JOIN")
                    {
                        string matchCode = parts[1];
                        bool joinSuccess = false;

                        lock (lockObj)
                        {
                            if (!matchRooms.ContainsKey(matchCode))
                            {
                                matchRooms[matchCode] = new MatchRoom();
                            }

                            MatchRoom room = matchRooms[matchCode];

                            if (room.Clients.Count < 2)
                            {
                                room.Clients.Add(client);
                                currentMatchCode = matchCode;
                                joinSuccess = true;

                                if (room.Clients.Count == 1)
                                {
                                    // Người chơi đầu tiên tham gia phòng
                                    SendMessageToClient(client, "JOIN_WAIT:");
                                }
                                else if (room.Clients.Count == 2)
                                {
                                    // Hai người chơi đã tham gia, bắt đầu trò chơi
                                    SendMessageToClient(room.Clients[0], "JOIN_SUCCESS:");
                                    SendMessageToClient(room.Clients[1], "JOIN_SUCCESS:");

                                    // Gửi lệnh TURN cho người chơi bắt đầu
                                    SendMessageToClient(room.Clients[room.StartingPlayer - 1], $"TURN:{room.StartingPlayer}");
                                    SendMessageToClient(room.Clients[(room.StartingPlayer) % 2], $"WAIT:{room.StartingPlayer}");
                                }
                            }
                            else
                            {
                                // Phòng đã đầy
                                SendMessageToClient(client, "JOIN_FULL:");
                            }
                        }

                        if (!joinSuccess)
                        {
                            // Nếu không thể tham gia phòng, đóng kết nối
                            client.Close();
                            break;
                        }
                    }
                    else if (command == "MOVE")
                    {
                        if (currentMatchCode == null)
                            continue; // Không thuộc phòng nào

                        lock (lockObj)
                        {
                            MatchRoom room = matchRooms[currentMatchCode];
                            foreach (var otherClient in room.Clients)
                            {
                                if (otherClient != client)
                                {
                                    SendMessageToClient(otherClient, message);
                                }
                            }

                            // Xác định lượt tiếp theo
                            int currentPlayerIndex = room.Clients.IndexOf(client);
                            int nextPlayerIndex = (currentPlayerIndex + 1) % room.Clients.Count;

                            string turnMessage = $"TURN:{(nextPlayerIndex + 1)}";
                            string waitMessage = $"WAIT:{(currentPlayerIndex + 1)}";

                            SendMessageToClient(room.Clients[nextPlayerIndex], turnMessage);
                            SendMessageToClient(room.Clients[currentPlayerIndex], waitMessage);
                        }
                    }
                    else if (command == "RESET")
                    {
                        if (currentMatchCode == null)
                            continue;

                        lock (lockObj)
                        {
                            MatchRoom room = matchRooms[currentMatchCode];
                            foreach (var c in room.Clients)
                            {
                                SendMessageToClient(c, "RESET:");
                            }

                            // Luân phiên người bắt đầu
                            room.ToggleStartingPlayer();

                            // Gửi lệnh TURN cho người chơi mới bắt đầu
                            SendMessageToClient(room.Clients[room.StartingPlayer - 1], $"TURN:{room.StartingPlayer}");
                            SendMessageToClient(room.Clients[(room.StartingPlayer) % 2], $"WAIT:{room.StartingPlayer}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            finally
            {
                // Khi client ngắt kết nối, loại bỏ khỏi phòng
                if (currentMatchCode != null)
                {
                    lock (lockObj)
                    {
                        if (matchRooms.ContainsKey(currentMatchCode))
                        {
                            MatchRoom room = matchRooms[currentMatchCode];
                            room.Clients.Remove(client);
                            if (room.Clients.Count == 0)
                            {
                                matchRooms.Remove(currentMatchCode);
                            }
                            else
                            {
                                // Thông báo cho client còn lại rằng đối thủ đã ngắt kết nối
                                SendMessageToClient(room.Clients[0], "RESET:");
                            }
                        }
                    }
                }

                client.Close();
            }
        }

        private static void SendMessageToClient(TcpClient client, string message)
        {
            try
            {
                byte[] data = Encoding.UTF8.GetBytes(message);
                NetworkStream stream = client.GetStream();
                stream.Write(data, 0, data.Length);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending message: {ex.Message}");
            }
        }
    }
}