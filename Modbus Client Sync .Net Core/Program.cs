using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Modbus_Client_Sync_.Net_Core
{
    class SynchronousSocketModbusClient
    {
        public static void StartModbusClient()
        {
            // Data buffer for reposponce data from Modbus TCP server.  
            byte[] responseMsg = new byte[1024];

            // Connect to a remote Modbus server.  
            try
            {
                // Establish the remote Modbus server endpoint for the socket.  
                // This example uses port 502 on the Modbus server.
                // Modbus server IP address as string.
                string modbusServerIP = "127.0.0.1";
                // Convert string IP Address to IPAddress class.
                IPAddress ipAddress = IPAddress.Parse(modbusServerIP);
                
                //Create IP endpoint for the remote Modbus server using IP and port number. 
                IPEndPoint modbusServerEP = new IPEndPoint(ipAddress, 502);

                // Create a TCP/IP  socket.  
                Socket sender = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

                // Connect the socket to the Modbus server endpoint. Catch any errors.  
                try
                {
                    sender.Connect(modbusServerEP);

                    Console.WriteLine("Socket connected to Modbus server at: {0}", sender.RemoteEndPoint.ToString());

                    // Modbus request message byte structure.
                    // The following request message reads 5 holding registers 40000-40004 using Modbus function code 3, starting from address 0.
                    //                              TransactionID  ProtocolID     Msg Length     UnitID    FCcode    Data Addr   No of Registers
                    byte[] requestMsg = new byte[] { 0x00, 0x01,   0x00, 0x00,     0x00, 0x06,    0x01,     0x03,    0x00, 0x00,    0x00, 0x05 };

                    // Send the request data through the socket to the Modbus server.  
                    int bytesSent = sender.Send(requestMsg);

                    Console.WriteLine("Read first 5 holding registers 40000-40004...");

                    // Receive the response from the Modbus server.  
                    int bytesRec = sender.Receive(responseMsg);
                    Console.WriteLine("Total number of bytes received as response from Modbus server: {0}", bytesRec);

                    Console.WriteLine("Data received from Modbus server as response to Modbus request.");

                    // Print bytes array in a row.
                    for (int i=0; i<bytesRec; i++)
                    {
                        Console.Write("{0} ", responseMsg[i]);
                    }
                    Console.WriteLine("\n");

                    Console.WriteLine("Modbus response message structure.");

                    // Print sorted bytes in a column.
                    Console.WriteLine("Transation ID (2 bytes): {0} {1} ", responseMsg[0], responseMsg[1]);
                    Console.WriteLine("Protocol ID (2 bytes, always 0 0): {0} {1} ", responseMsg[2], responseMsg[3]);
                    Console.WriteLine("Message length (2 bytes): {0} {1} ", responseMsg[4], responseMsg[5]);
                    Console.WriteLine("Unit ID (1 byte): {0} ", responseMsg[6]);
                    Console.WriteLine("Modbus function code (1 byte): {0} ", responseMsg[7]);
                    Console.WriteLine("Byte count (1 byte): {0} ", responseMsg[8]);
                    Console.WriteLine("Holding register 40000 (2 bytes): {0} {1} ", responseMsg[9], responseMsg[10]);
                    Console.WriteLine("Holding register 40001 (2 bytes): {0} {1} ", responseMsg[11], responseMsg[12]);
                    Console.WriteLine("Holding register 40002 (2 bytes): {0} {1} ", responseMsg[13], responseMsg[14]);
                    Console.WriteLine("Holding register 40003 (2 bytes): {0} {1} ", responseMsg[15], responseMsg[16]);
                    Console.WriteLine("Holding register 40004 (2 bytes): {0} {1} ", responseMsg[17], responseMsg[18]);

                    Console.WriteLine("");

                    // Release the socket.  
                    sender.Shutdown(SocketShutdown.Both);
                    sender.Close();

                }
                catch (ArgumentNullException ane)
                {
                    Console.WriteLine("ArgumentNullException : {0}", ane.ToString());
                }
                catch (SocketException se)
                {
                    Console.WriteLine("SocketException : {0}", se.ToString());
                }
                catch (Exception e)
                {
                    Console.WriteLine("Unexpected exception : {0}", e.ToString());
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public static int Main(String[] args)
        {
            StartModbusClient();
            Console.WriteLine("\n");
            return 0;
        }
    }
}
