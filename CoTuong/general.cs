using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace CoTuong
{
	internal class MatchInfo
	{
		public string ID { get; set; }
		public string Enemy { get; set; }
		public string Result { get; set; }
		public string NumGo { get; set; }
		public string TotalTime { get; set; }

	}
	internal class PlayerInfo
	{
		public string FullName { get; set; }
		public string Sex { get; set; }
		public string BirthYear { get; set; }
		public string UserName { get; set; }
		public string Password { get; set; }
	}
	public class playerSocket
	{
		public string ten { get; set; }
		public string ipAddress { get; set; }
		public bool chuPhong { get; set; }
		public Socket socket { get; set; }
		public Room room { get; set; }

	}
    public class Room
    {
        public int _sophong;
        public int _siso;
        public playerSocket _plnguoichoi1;
        public playerSocket _plnguoichoi2;
        public Room()
        {
            _siso = _sophong = 0;
            plnguoichoi1 = null;
            plnguoichoi2 = null;
        }
        public int sophong
        {
            get { return this._sophong; }
            set { this._sophong = value; }
        }
        public int siso
        {
            get { return this._siso; }
            set { this._siso = value; }
        }
        public playerSocket plnguoichoi1
        {
            get { return this._plnguoichoi1; }
            set { this._plnguoichoi1 = value; }
        }
        public playerSocket plnguoichoi2
        {
            get { return this._plnguoichoi2; }
            set { this._plnguoichoi2 = value; }
        }
    }
}
