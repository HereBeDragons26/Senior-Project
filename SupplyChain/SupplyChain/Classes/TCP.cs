﻿using Newtonsoft.Json;
using SupplyChain.Model;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace SupplyChain.Classes {
    public class TCP {

        static Thread listenerThread = null;

        public static readonly int PORT = 13000;
        public static List<string> minerIPs = new List<string>();

        public static void Send(string ip, string message) {
            TcpClient tcpClient = new TcpClient(ip, PORT);
            NetworkStream stream = tcpClient.GetStream();

            ASCIIEncoding asen = new ASCIIEncoding();
            byte[] ba = asen.GetBytes(message);

            stream.Write(ba, 0, ba.Length);

            tcpClient.Close();
            stream.Flush();
            stream.Close();
        }

        public static void SendAllMiners(string message) {
            minerIPs.ForEach(mp => {

                TcpClient tcpClient = new TcpClient(mp, PORT);
                NetworkStream stream = tcpClient.GetStream();

                ASCIIEncoding asen = new ASCIIEncoding();
                byte[] ba = asen.GetBytes(message);

                stream.Write(ba, 0, ba.Length);

                tcpClient.Close();
                stream.Flush();
                stream.Close();
            });
        }

        private static void ListenerMethod() {

            TcpListener listener = new TcpListener(IPAddress.Any, PORT);
            listener.Start();
            Socket client = null;

            while (true) {
                try {
                    client = listener.AcceptSocket();
                    String ip = ((IPEndPoint)client.RemoteEndPoint).Address.ToString();
                    byte[] bytes = new byte[1024];

                    int size = client.Receive(bytes);
                    string str = "";
                    for (int i = 0; i < size; i++)
                        str += Convert.ToChar(bytes[i]);

                    new Thread(() => Interpreter(str, ip)).Start();

                }
                catch (Exception e) {
                    Console.WriteLine(e.ToString());
                }
            }
        }

        public static void StartListener() {
            if (listenerThread != null) return;
            listenerThread = new Thread(new ThreadStart(ListenerMethod)) {
                Name = "UdpConnection.ListenThread"
            };
            listenerThread.Start();
        }

        private static void Interpreter(string message, string ip) {

            message = message.Replace("Blockchain", "SupplyChain");

            // received miners list
            if (message.StartsWith("connectToNetwork")) {
                Send(ip, "minersList" + JsonSerialize(new { miners = minerIPs }));
                return;
            }

            if (message.StartsWith("addMeNow")) {
                if (minerIPs.Contains(ip)) return;
                minerIPs.Add(ip);
                SendAllMiners("newMinerJoined" + ip);
                return;
            }

            if (message.StartsWith("verifyReturn")) {
                message = message.Substring(12);
                Product product = (Product) JsonDeserialize(message);
                VerifyResult.verifyResultPageInstance.printProductInTable(product);
                VerifyResult.verifyResultPageInstance.finish = true;
                return;
            }

        }

        public static string JsonSerialize(object graph) {
            return JsonConvert.SerializeObject(graph,
                Formatting.None,
                new JsonSerializerSettings {
                    TypeNameHandling = TypeNameHandling.Objects
                });
        }

        public static object JsonDeserialize(string seralized) {
            return JsonConvert.DeserializeObject(seralized,
                new JsonSerializerSettings {
                    TypeNameHandling = TypeNameHandling.Objects
                });
        }
    }
}
