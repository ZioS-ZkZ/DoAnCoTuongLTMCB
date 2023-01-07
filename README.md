
- [Cờ tướng chơi qua mạng LAN](#cờ-tướng-chơi-qua-mạng-lan)
  - [Tổng quan công nghệ sử dụng](#tổng-quan-công-nghệ-sử-dụng)
  - [Tổng quan hệ thống game](#tổng-quan-hệ-thống-game)
  - [Tổng quan giao diện game](#tổng-quan-giao-diện-game)
  - [Tổng quan hiêu suất](#tổng-quan-hiêu-suất)
  - [Kết luận](#kết-luận)
# Cờ tướng chơi qua mạng LAN
## Tổng quan công nghệ sử dụng 
- Phía người chơi (Client): Windows Forms .NET, C#
- Phía server: Windows Forms .Net, C#
- Database: Chức năng Realtime Database của Firebase
- Sử dụng Hamachi để tạo ra một mạng LAN
## Tổng quan hệ thống game 
- **Kiến trúc hệ thống :** 

    ![](https://i.imgur.com/kOuBIUJ.png)

    - Client : Đây là các máy tính chạy ứng dụng trò chơi cờ tướng. Ứng dụng kết nối với server qua socket với phương thức TCP/IP port 9999. Truy xuất thông tin và lưu thông tin trên Realtime Database của FireBase.
    - Server: Trong mô hình này server có chức năng là nơi trung gian giao tiếp giữa các client với nhau, quản lý danh sách người chơi và danh sách phòng chơi.
    - Database : Sử dụng Realtime Database của Firebase. Dùng để lưu thông tin người chơi (tên, giới tính, năm sinh, username password, …) và thông tin lịch sử đấu của người chơi (kết quả, đối thủ, lượt đánh, tổng thời gian)

- **Thiết kế cơ sở dữ liệu**
    Có hai loại dữ liệu được lưu trên database:
    - Thông tin người chơi: tên, giới tính, năm sinh, username, password.

        ![](https://i.imgur.com/zJJcD5L.png)
        
    - Lịch sử trận đấu của người chơi: kết quả, đối thủ, lượt đánh, tổng thời gian

        ![](https://i.imgur.com/BZTPn3i.png)


- **Mô hình phân rã chức năng :**
    - Sơ đồ phân rã chức năng của người chơi :
    
    ![](https://i.imgur.com/gGTAzof.png)

    - Sơ đồ phân rã chức năng của server :
    
    ![](https://i.imgur.com/Z4j7NiL.png)

- **Mô hình usercase :**

    User case mô tả sự tương tác đặc trưng giữa người dùng và hệ thống. Nó thể hiện ứng xử của hệ thống đối với bên      ngoài, trong một hoàn cảnh nhất định, xét từ quan điểm   của người sử dụng.

    ![](https://i.imgur.com/X8w6GZW.png)

- **Sơ đồ phân lớp :**
    
    ![](https://i.imgur.com/9DCrk2i.png)
    
    - Cấu trúc dữ liệu quản lý bàn cờ:
        - Dùng 1 mảng static 2chiều [10x9] với mỗi phần tử là 1 struct tương ứng với 1 ô cờ trên bàn cờ, trên mỗi phần tử sẽ có các thuộc tính: Hàng, Cột, Phía, Trống, Tên, Phe để xác định ô cờ đó đang ở đâu và có đang lưu trữ thông tin của quân cờ nào hay không. Đồng thời có thêm 1 thuộc tính canMove(pictureBox) để lưu trữ hình ảnh của quân cờ (nếu có). 
    - Quản lý các quân cờ:
        - Xây dựng các class tuong, si, xe, phao, ma, tot, voi kế thừa từ class QuanCo đại diện cho các quân cờ lần lượt là Tướng, Sĩ, Xe, Pháo, Mã, Tốt, Tượng.
        - Tạo lớp NguoiChoi để quản lý các quân cờ, trong lớp NguoiChoi sẽ tạo các thể hiện của các lớp quân cờ(Tuong, Si, Tinh, Xe, Phao, Ma, Chot, Voi).
    - Quản lý ván cờ:
        - Xây dựng lớp VanCo bao gồm các thuộc tính và phương thức quản lý ván cờ đó.
    - Xây dựng các class:
        - Nhóm class giao diện : fBanCo.Designer.cs, fLogin.Designer.cs, fSignUp.Designer.cs, fEnd.Designer.cs
        - Nhóm class lưu dữ liệu : QuanCo, xe, ma, voi, si, tuong, phao, tot (lưu trữ cách thức di chuyển, tên, vị trí,...)
        - Nhóm class quản lí : VanCo(các hàm quản lý chung), BanCo (quản lý 90 ô cờ), NguoiChoi(quản lý các quân cờ).
        - Class hỗ trợ, tương tác :genaral.cs, fBanCo.cs, fLogin.cs, fEnd.cs (chứa code event như Click, FormClosing,…)

- **Lượt đồ Sequence**
    - Lượt đồ đăng nhập:
    
        ![](https://i.imgur.com/CTQ8LW6.png)

        Đặc tả các bước trong chức năng đăng nhập:
        - Người chơi yêu cầu giao diện đăng nhập, nhập các thông tin tài khoản mật khẩu được yêu cầu để đăng nhập.
        - Ở bước giao diện sẽ kiểm tra xem đã nhập hợp lệ hay chưa (có bị bỏ trống hay điền thiếu …) nếu kiểm tra hợp lệ thì kiểm tra trong database xem có tồn tại tài khoản đó không, nếu có thì dăng nhập thành công ngược lại thì thất bại.


    - Lượt đồ chơi game

        ![](https://i.imgur.com/6WHgGq7.png)

        Đặc tả luồng thực hiện chơi game :
        - Người chơi 1 thực hiện các chức năng như tạo ván cờ mới/ cầu hòa/ chịu thua thì sẽ gửi 1 message thông tin đến cho người chơi 2 và chờ xác nhận của người chơi 2, sau khi người chơi 2 xác nhận thì sẽ gửi thông tin xác nhận về cho server và server sẽ gửi thông tin đến 2 player để 2 player thực hiện (ví dụ: Người chơi 1 gửi yêu cầu tạo mới ván cờ, nếu người chơi 2 xác nhận việc tạo mới ván cờ thì ván cờ sẽ được tạo mới)
        - Tiếp theo là thực hiện các động tác đánh cờ gửi tin nhắn … thì sẽ thự hiện luồng đồng bộ như sau : người chơi 1 sẽ thự hiện gửi một message chứ thông tin thực hiện và server sẽ sử lý và trả về cho cả 2 cùng thực hiện hành động đó ( ví dụ : người chơi 1 muốn di chuyển quân mã vào vị trí cột 2 dòng 3 thì sẽ gửi thông tin đó cho server, server sẽ sử lý và gửi lại cho người chơi 1 thực hiện và người chơi 2 cũng sẽ thực hiện để đồng bộ giữa 2 người chơi).

## Tổng quan giao diện game
Thứ tự nhập liệu sẽ được hiển thị bằng các con số trên các giao diện.

- Giao diện đăng ký :

    ![](https://i.imgur.com/exjn84h.png)

- Giao diện đăng nhập :

    ![](https://i.imgur.com/hcYtt9K.png)
    
- Giao diện phòng chờ :

    ![](https://i.imgur.com/8Nc4mDe.png)

- Giao diện bàn cờ :

    - Defaut:

        ![](https://i.imgur.com/WEqQiqo.png)
        
    - Black:
    
        ![](https://i.imgur.com/QzDsEuQ.png)
        
    - Blue:
    
        ![](https://i.imgur.com/bVLM2WR.png)

    - Paper:
        
        ![](https://i.imgur.com/RvCAHL8.png)

- Giao diện kết thúc trân đấu:

    ![](https://i.imgur.com/2mVkXiq.png)

- Giao diện của server :

    ![](https://i.imgur.com/GWpkNAP.png)

## Tổng quan hiêu suất 

- Khả năng chịu tải :
    Chương trình có thể kết nối lên đến 10 máy. Nếu vượt quá số lượng trên, mặc dù chương trình vẫn cho phép thực thi nhưng xảy ra tình trạng chậm.
- Độ trễ :
    Tùy thuộc vào mạng sẽ dẫn đến độ trễ cỡ từ 0 – 1 giây. Độ trễ trên vẫn có thể chấp nhận được vì đây không phải là game fps. Vượt quá số lượng 10 máy thời gian này có thể tăng lên. 
    
## Kết luận 

- Ưu điểm :
    - Ứng dụng có giao diện dễ sử dụng.
    - Màu sắc hài hòa, giao diện thân thiện với người dùng.
    - Có nhiều tính năng giúp người dùng có thể tùy chỉnh giao diện bàn cờ sao cho phù hợp với bản thân.
    - Âm thành sống động, nhộn nhịp tạo sự hứng thú với người dùng.
    - Giao tiếp trực tiếp giữa hai người chơi.
- Nhược điểm :
    - Khả năng chịu tải còn khá kém
    - Dễ bị tác động bởi môi trường có điều kiện kém
    - Tồn tại độ trễ giữa hai người chơi nhưng không đáng kể.
    - Cần tải ứng dụng đi kèm để kết nối hai người chơi ở hai máy khác nhau.
    - Vẫn còn tồn tại các bug trong quá trình chơi.

