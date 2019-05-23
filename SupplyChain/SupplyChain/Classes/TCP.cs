using Newtonsoft.Json;
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

        public static readonly int WebServerPort = 13001;
        public static readonly int MinerPort = 13000;
        public static List<string> minerIPs = new List<string>();

        public static void Send(string ip, string message) {
            try {
                TcpClient tcpClient = new TcpClient(ip, MinerPort);
                NetworkStream stream = tcpClient.GetStream();

                ASCIIEncoding asen = new ASCIIEncoding();
                byte[] ba = asen.GetBytes(message);

                stream.Write(ba, 0, ba.Length);

                tcpClient.Close();
                stream.Flush();
                stream.Close();
            }
            catch (Exception e) {
                Console.WriteLine("----------Can't connect to miner----------\n\n" + e.StackTrace);
            }
        }

        public static void SendAllMiners(string message) {
            try {
                minerIPs.ForEach(mp => {

                    TcpClient tcpClient = new TcpClient(mp, MinerPort);
                    NetworkStream stream = tcpClient.GetStream();

                    ASCIIEncoding asen = new ASCIIEncoding();
                    byte[] ba = asen.GetBytes(message);

                    stream.Write(ba, 0, ba.Length);

                    tcpClient.Close();
                    stream.Flush();
                    stream.Close();
                });
            }
            catch (Exception e) {
                Console.WriteLine("----------Can't connect to miners----------\n\n" + e.StackTrace);
            }
        }

        private static void ListenerMethod() {
            TcpListener listener = new TcpListener(IPAddress.Any, WebServerPort);
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
                Send(ip, "minersList" + JsonSerialize(new { list = minerIPs }));
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
                VerifyResult.currentProduct = product;
                VerifyResult.verifyResultPageInstance.finish = true;
                return;
            }

            if (message.StartsWith("exit")) {
                minerIPs.Remove(ip);
                return;
            }

            if (message.StartsWith("BlockID")) {
                ProductInfoPage.lastBlockID = message.Substring(7);
                ProductInfoPage.waitBlockID = false; // signal
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
