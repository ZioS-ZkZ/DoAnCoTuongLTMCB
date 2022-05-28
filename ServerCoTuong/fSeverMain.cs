using CoTuong;
using System.Net;
using System.Net.Sockets;
using System.Text;


namespace ServerCoTuong
{
    public partial class fSeverMain : Form
    {
        public fSeverMain()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
        }
        Socket skListen, skClient;
        IPEndPoint ipe;
        List<playerSocket> listNguoiChoi = new List<playerSocket>();
        List<Room> listPhong = new List<Room>();
        Thread thClient;
        
        private void btStarServer_Click(object sender, EventArgs e)
        {
            try
            {
                ipe = new IPEndPoint(IPAddress.Any, 9999);
                skListen = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                skListen.Bind(ipe);

                Thread threadListen = new Thread(LangNgheClient);
                threadListen.IsBackground = true;
                threadListen.Start();

                btStarServer.Enabled = false;

                txtTerminal.SelectionColor = Color.Red;
                txtTerminal.AppendText("Đang Lắng Nghe Kết Nối Từ Client");
                txtTerminal.ScrollToCaret();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void LangNgheClient()
        {
            while (true)
            {
                try
                {
                    skListen.Listen(10);
                    skClient = skListen.Accept();
                    playerSocket player = new playerSocket();
                    player.socket = skClient;
                    player.ipAddress = player.socket.RemoteEndPoint.ToString();
                    listNguoiChoi.Add(player);

                    thClient = new Thread(receive);
                    thClient.IsBackground = true;
                    thClient.Start(player);

                    txtTerminal.SelectionColor = Color.Blue;
                    txtTerminal.AppendText("\nChấp Nhận kết nối từ " + player.socket.RemoteEndPoint.ToString());
                    txtTerminal.ScrollToCaret();
                }
                catch
                {

                }
            }
        }
        string mess;
        string[] itemMess;
        byte[] dataNhan = new byte[1024*500000];
        private void receive(object obj)
        {
            playerSocket player = (playerSocket)obj;
            while (true)
            {
                try
                {
                    player.socket.Receive(dataNhan);
                    mess = (string)VanCo.Deseriliaze(dataNhan);
                    itemMess = mess.Split('|');
                    XulyMessage(itemMess[0], mess, player);
                }
                catch
                {
                    txtTerminal.SelectionColor = Color.Blue;
                    txtTerminal.AppendText("\n" + player.socket.RemoteEndPoint.ToString() + " Đã Đóng Kết Nối");
                    txtTerminal.ScrollToCaret();
                    listNguoiChoi.Remove(player);
                    break;
                }
            }
        }
        private void XulyMessage(string s, string data, playerSocket player)
        {
            switch (s)
            {
                case "NAMECLIENT":
                    setNameClient(data, player);
                    break;
                case "TAOPHONGMOI":
                    taophongmoi(data, player);
                    break;
                case "LAYDANHSACHPHONG":
                    laydanhsachphong(player);
                    break;
                case "VAOPHONGGAME":
                    vaophong(data, player);
                    break;
                case "CHATPHONG":
                    chatphong(data, player);
                    break;
                case "THOATKHOIPHONGGAME":
                    thoatphonggame(data, player);
                    break;
                case "NEWGAME":
                    if (player.room.siso == 2)
                    {
                        player.room.plnguoichoi1.socket.Send(VanCo.Serialize(data));
                        player.room.plnguoichoi2.socket.Send(VanCo.Serialize(data));
                    }
                    else
                        player.room.plnguoichoi1.socket.Send(VanCo.Serialize("CHUADUNGUOICHOI|,"));
                    break;
                case "DANHCO":
                    player.room.plnguoichoi1.socket.Send(VanCo.Serialize(data));
                    player.room.plnguoichoi2.socket.Send(VanCo.Serialize(data));
                    break;
                case "SETOCOTRONG":
                    player.room.plnguoichoi1.socket.Send(VanCo.Serialize(data));
                    player.room.plnguoichoi2.socket.Send(VanCo.Serialize(data));
                    break;
                case "DATQUANCO":
                    player.room.plnguoichoi1.socket.Send(VanCo.Serialize(data));
                    player.room.plnguoichoi2.socket.Send(VanCo.Serialize(data));
                    break;
                case "ANQUANCO":
                    player.room.plnguoichoi1.socket.Send(VanCo.Serialize(data));
                    player.room.plnguoichoi2.socket.Send(VanCo.Serialize(data));
                    break;
                case "DOILUOTDI":
                    player.room.plnguoichoi1.socket.Send(VanCo.Serialize(data));
                    player.room.plnguoichoi2.socket.Send(VanCo.Serialize(data));
                    break;
                case "INLICHSU":
                    player.room.plnguoichoi1.socket.Send(VanCo.Serialize(data));
                    player.room.plnguoichoi2.socket.Send(VanCo.Serialize(data));
                    break;
                case "DOWIN":
                    player.room.plnguoichoi1.socket.Send(VanCo.Serialize(data));
                    player.room.plnguoichoi2.socket.Send(VanCo.Serialize(data));
                    break;
                case "DENWIN":
                    player.room.plnguoichoi1.socket.Send(VanCo.Serialize(data));
                    player.room.plnguoichoi2.socket.Send(VanCo.Serialize(data));
                    break;
                case "HOA":
				case "DOen":
					player.room.plnguoichoi1.socket.Send(VanCo.Serialize(data));
                    player.room.plnguoichoi2.socket.Send(VanCo.Serialize(data));
                    break;
				case "REQUESTDRAW":
                    if(player.room.siso == 2)
                    {
                        string requester = data.Split(',')[1];
                        if (player.room.plnguoichoi1.ten != requester)
                            player.room.plnguoichoi1.socket.Send(VanCo.Serialize(data));
                        else if (player.room.plnguoichoi2.ten != requester)
                            player.room.plnguoichoi2.socket.Send(VanCo.Serialize(data));
                    }
                    else
                    {
                        player.room.plnguoichoi1.socket.Send(VanCo.Serialize("CHUADUNGUOICHOI|,"));
                    }
					break;
                case "REQUESTNEWGAME":
                    if (player.room.siso == 2)
                    {
                        string requester = data.Split(',')[1];
                        if (player.room.plnguoichoi1.ten != requester)
                            player.room.plnguoichoi1.socket.Send(VanCo.Serialize(data));
                        else if (player.room.plnguoichoi2.ten != requester)
                            player.room.plnguoichoi2.socket.Send(VanCo.Serialize(data));
                    }
                    else
                    {
                        player.room.plnguoichoi1.socket.Send(VanCo.Serialize("CHUADUNGUOICHOI|,"));
                    }
                    break;
            }
        }
        private void setNameClient(string mess, playerSocket player)
        {
            itemMess = mess.Split(',');
            player.ten = itemMess[1];
        }
        private void taophongmoi(string mess, playerSocket player)
        {
            Room room = new Room();
            room.sophong = listPhong.Count + 1;
            room.siso = 1;
            room.plnguoichoi1 = player;
            listPhong.Add(room);
            player.room = room;
        }
        private void laydanhsachphong(playerSocket player)
        {
            string danhsachphong = "DANHSACHPHONGGAME|,";
            foreach (Room r in listPhong)
                danhsachphong += r.sophong + "\t(" + r.siso + "/2),";
            player.socket.Send(VanCo.Serialize(danhsachphong));

        }
        private void vaophong(string mess, playerSocket player)
        {
            itemMess = mess.Split(',');
            int idphong = int.Parse(itemMess[1]);
            playerSocket plr = timphong(idphong);
            Room r = plr.room;
            if (r.siso == 1)
            {
                r.siso = 2;
                r.plnguoichoi2 = player;
                player.room = r;
                plr.room = r;
                plr.socket.Send(VanCo.Serialize("NGUOICHOIMOIVAOPHONG|," + r.plnguoichoi2.ten + ","));
				player.socket.Send(VanCo.Serialize("TENCHUPHONG|," + r.plnguoichoi1.ten));
            }
            else
                player.socket.Send(VanCo.Serialize("PHONGDADAY|,"));
        }
        private playerSocket timphong(int idphong)
        {
            foreach (playerSocket player in listNguoiChoi)
                if(player.room != null)
                    if (player.room.sophong == idphong )
                        return player;
            return null;
        }
        private void chatphong(string data, playerSocket player)
        {
            if (player.room.siso == 1)
                player.socket.Send(VanCo.Serialize(data));
            else
            {
                player.room.plnguoichoi1.socket.Send(VanCo.Serialize(data));
                player.room.plnguoichoi2.socket.Send(VanCo.Serialize(data));
            }
        }

       

        private void thoatphonggame(string mess, playerSocket player)
        {
            itemMess = mess.Split(',');
            
            if (itemMess[1] == "1")
            {
                if (player.room.siso == 2)
                {
                    Room r = player.room;
                    r.plnguoichoi2.socket.Send(VanCo.Serialize("THOAT|," + "Người chơi " + r.plnguoichoi1.ten + " Đã thoát,"));
                    r.plnguoichoi1 = r.plnguoichoi2;
                    r.plnguoichoi2 = null;
                    r.siso = 1;
                    player.room.plnguoichoi1.room = r;

                }
                else
                {
                    listPhong.Remove(player.room);
                    player.room = null;
                }
            }
            else
            {
                if (player.room.siso == 2)
                {
                    Room r = player.room;
                    r.plnguoichoi1.socket.Send(VanCo.Serialize("THOAT|," + "Người Chơi " + r.plnguoichoi2.ten + " Đã thoát,"));
                    r.siso = 1;
                    r.plnguoichoi2 = null;
                    r.plnguoichoi1.room = r;
                }
                else
                {
                    listPhong.Remove(player.room);
                    player.room = null;
                }
            }
            
        }

        private void btCloseServer_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}