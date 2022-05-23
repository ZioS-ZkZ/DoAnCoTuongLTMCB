using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace CoTuong
{
    public  class playerSocket
    {
        public string ten { get; set; }
        public string ipAddress { get; set; }
        public bool chuPhong { get; set; }
        public Socket socket { get; set; }
        public Room room { get; set; }

    }
}
