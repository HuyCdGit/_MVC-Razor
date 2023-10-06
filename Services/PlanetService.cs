using AppMVC.Models;

namespace AppMVC.Services
{
    public class PlanetService : List<PlanetModel>
    {
        public PlanetService()
        {
            this.Add(new PlanetModel(){
                Id = 1,
                Name = "Mercury",
                VnName = "Sao Thủy",
                Content = "Sao Thủy (Mercury) hay Thủy tinh (chữ Hán: 水星) là hành tinh nhỏ nhất và gần Mặt Trời nhất trong tám hành tinh thuộc Hệ Mặt Trời, với chu kỳ quỹ đạo bằng khoảng 88 ngày Trái Đất. Nhìn từ Trái Đất, hành tinh hiện lên với chu kỳ giao hội trên quỹ đạo bằng xấp xỉ 116 ngày, và nhanh hơn hẳn những hành tinh khác. Tốc độ chuyển động nhanh này đã khiến người La Mã đặt tên hành tinh là Mercurius, vị thần liên lạc và đưa tin một cách nhanh chóng. Trong thần thoại Hy Lạp tên của vị thần này là Hermes (Ερμής). Tên tiếng Việt của hành tinh này dựa theo tên do Trung Quốc đặt, chọn theo hành thủy trong ngũ hành.",
            });
            this.Add(new PlanetModel(){
                Id = 2,
                Name = "Venus",
                VnName = "Sao Kim",
                Content = "Sao Kim hay Kim tinh (chữ Hán: 金星), còn gọi là sao Thái Bạch (太白), Thái Bạch Kim tinh (太白金星) (tiếng Anh: Venus) là hành tinh thứ 2 trong hệ Mặt Trời, tự quay quanh nó với chu kỳ 224,7 ngày Trái Đất. Xếp sau Mặt Trăng, nó là thiên thể tự nhiên sáng nhất trong bầu trời tối, với cấp sao biểu kiến bằng −4.6, đủ sáng để tạo nên bóng trên mặt nước. Bởi vì Sao Kim là hành tinh phía trong tính từ Trái Đất, nó không bao giờ xuất hiện trên bầu trời mà quá xa Mặt Trời: góc ly giác đạt cực đại bằng 47,8°. Sao Kim đạt độ sáng lớn nhất ngay sát thời điểm hoàng hôn hoặc bình minh, do vậy mà dân gian còn gọi là sao Hôm, khi hành tinh này hiện lên lúc hoàng hôn, và sao Mai, khi hành tinh này hiện lên lúc bình minh.",
            });
            this.Add(new PlanetModel(){
                Id = 3,
                Name = "Earth",
                VnName = "Trái Đất",
                Content = " Trái Đất 🜨 Hình ảnh Trái Đất nhìn từ tàu Apollo 17 ngày 7 tháng 12 năm 1972. Bức ảnh Viên Bi Xanh nổi tiếng, chụp từ Apollo 17 Đặc điểm của quỹ đạo (Kỷ nguyên J2000) Bán trục lớn 149 597 887 km hay 1,00000011 AU.  Chu vi 940 × 106 km hay 6,283 AU.  Độ lệch tâm 0,01671022 Cận điểm 147 098 074 km hay 0,9832899 AU.  Viễn điểm 152 097 701 km hay 1,0167103 AU.  Chu kỳ 365,25696 ngày hay 1,0000191 năm.  Chu kỳ biểu kiến không áp dụng. Vận tốc quỹ đạo:   - trung bình 29,783 km/s.  - tối đa 30,287 km/s.  - tối thiểu 29,291 km/s. Độ nghiêng 0,00005° đối với mặt phẳng hoàng đạo hay 7,25° đối với xích đạo Mặt Trời.  Kinh độ điểm mọc 348,73936°. Góc cận điểm 114,20783°. Tổng số vệ tinh 1 – (mặt trăng)   Đặc điểm của hành tinh Đường kính:   - tại xích đạo 12756,28 km.  - tại cực 12713,56 km.  - trung bình 12742,02 km. Độ dẹp 0,0033528 Chu vi vòng kính:   - tại xích đạo 40075 km.  - qua hai cực 40008 km. Diện tích 510.100.000 km²  - toàn bộ bề mặt 510 072 000 km².  - đất 148 940 000 km²(29,2%)  - nước 312 369 000 km²(70,8%) Thể tích 1083,2073 × 109 km³. Khối lượng 5973,6 × 1024 kg. Tỉ trọng 5,5153 g/cm³. Gia tốc trọng trường tại xích đạo 9,780327 m/s² hay 0,99732 G.  Vận tốc vũ trụ cấp 2 11,186 km/s. Chu kỳ tự quay 0,99726968 ngày hay 23,934 giờ.  Vận tốc tự quay tại xích đạo 1674,38 km/h. Độ nghiêng trục quay 23,439281°. Xích kinh độ cực bắc 0° (0 h 0 m 0 s) Thiên độ cực bắc 90° Hệ số phản xạ 0,367 Nhiệt độ bề mặt:   - tối thiểu 185 K  - trung bình 287 K  - tối đa 331 K Áp suất khí quyển tại bề mặt 101,3 kPa   Cấu tạo của khí quyển Nitơ (N2) 78,08% Oxy(O2) 21% Argon (Ar) 0,93% Carbon dioxide (CO2) 0,038% Hơi nước (H2O) 1% (thay đổi theo điều kiện thời tiết) Trái Đất, hay còn gọi là Địa Cầu (chữ Hán: 地球, tiếng Anh: Earth), là hành tinh thứ ba tính từ Mặt Trời, đồng thời cũng là hành tinh lớn nhất trong các hành tinh đất đá của hệ Mặt Trời xét về bán kính, khối lượng và mật độ của vật chất. Trái Đất còn được biết tên với các tên gọi hành tinh xanh, là nhà của hàng triệu loài sinh vật, trong đó có con người và cho đến nay nó là nơi duy nhất trong vũ trụ được biết đến là có sự sống. Hành tinh này được hình thành cách đây khoảng 4,55 tỷ năm và sự sống xuất hiện trên bề mặt của nó khoảng 1 tỷ năm trước. ",
            });
            this.Add(new PlanetModel(){
                Id = 4,
                Name = "Mars",
                VnName = "Sao Hỏa",
                Content = "Sao Hỏa hay Hỏa tinh (chữ Hán: 火星, tiếng Anh: Mars) là hành tinh thứ tư tính từ Mặt Trời ra. Sao Hoả là hành tinh có kích thước bé thứ hai trong Hệ Mặt Trời, chỉ lớn hơn Sao Thủy. Sao Hỏa là hành tinh đất đá với bầu khí quyển mỏng, với nhiều hố va chạm, núi lửa, thung lũng, sa mạc và chỏm băng ở trên bề mặt như là ở trên Trái Đất. Sao Hoả hay được gọi ví von là Hành tinh Đỏ do bề mặt hành tinh chứa rất nhiều sắt(III) oxide có màu đỏ cam",
            });
            this.Add(new PlanetModel(){
                Id = 5,
                Name = "Jupiter",
                VnName = "Sao Mộc",
                Content = " Sao Mộc Ảnh tổng hợp từ tàu Cassini khi lướt qua Sao Mộc. Chấm tối là bóng của Europa. Vết Đỏ Lớn, một cơn bão tồn tại từ lâu có chiều quay ngược với các dải mây xung quanh, phía dưới bên phải. Các dải mây trắng, gọi là vùng, hay vùng khí nhẹ bay lên-mây cao; những dải mây màu đỏ nâu, gọi là vành đai, hay vùng khí thấp hơn-mây thấp. Vùng mây trắng chứa băng amonia và những vùng mây thấp chưa biết rõ thành phần. Đặc trưng quỹ đạo Kỷ nguyên J2000 Điểm viễn nhật 816.520.800 km (5,458104 AU) Điểm cận nhật 740.573.600 km (4,950429 AU) Bán trục lớn 778.547.200 km (5,204267 AU) Độ lệch tâm 0,048775 Chu kỳ quỹ đạo 4.332,59 ngày 11,8618 năm 10.475,8 ngày Sao Mộc Chu kỳ giao hội 398,88 ngày Tốc độ vũ trụ cấp 1 trung bình 13,07 km/s Độ bất thường trung bình 18,818° Độ nghiêng quỹ đạo  1,305° đối với mặt phẳng hoàng đạo 6,09° đối với xích đạo Mặt Trời 0,32° đối với mặt phẳng bất biến Kinh độ điểm mọc 100,492° Góc cận điểm 275,066° Vệ tinh đã biết 67 Đặc trưng vật lý Bán kính trung bình 69.911 ± 6 km Bán kính xích đạo 71.492 ± 4 km 11,209 Trái Đất Bán kính cực 66.854 ± 10 km 10,517 Trái Đất Độ dẹt 0,06487 ± 0,00015 Diện tích bề mặt 6,1419×1010 km2 121,9 Trái Đất Thể tích  1,4313×1015 km3 1321,3 Trái Đất Khối lượng  1,8986×1027 kg 317,8 Trái Đất 1/1047 Mặt Trời Mật độ trung bình 1,326 g/cm3 Hấp dẫn bề mặt 24,79 m/s2  2,528 g Tốc độ vũ trụ cấp 2 59,5 km/s Chu kỳ thiên văn 9,925 h (9 h 55 m 30 s) Vận tốc quay tại xích đạo 12,6 km/s  45.300 km/h Độ nghiêng trục quay 3,13° Xích kinh cực Bắc 268,057°  17 h 52 min 14 s Xích vĩ cực Bắc 64,496° Suất phản chiếu 0,343 (Bond)  0,52 (hình học) Nhiệt độ bề mặt cực tiểu trung bình cực đại Mức 1 bar  165 K  0,1 bar  112 K  Cấp sao biểu kiến -1,6 đến -2,94 Đường kính góc 29,8 — 50,1 Khí quyển Áp suất bề mặt 20–200 kPa (lớp mây) Biên độ cao 27 km Thành phần khí quyển  89,8±2,0% hydro (H2) 10,2±2,0% heli ~0,3% methan ~0,026% amonia ~0,003% hydro deuteri (HD) 0,0006% ethan 0,0004% nước Băng:  amonia nước Amoni hydro sulfide(NH4SH) Sao Mộc (Jupiter) hay Mộc tinh (chữ Hán: 木星) là hành tinh thứ năm tính từ Mặt Trời và là hành tinh lớn nhất trong Hệ Mặt Trời. Nó là hành tinh khí khổng lồ với khối lượng bằng một phần nghìn của Mặt Trời nhưng bằng hai lần rưỡi tổng khối lượng của tất cả các hành tinh khác trong Hệ Mặt Trời cộng lại. Sao Mộc được xếp vào nhóm hành tinh khí khổng lồ cùng với Sao Thổ (Sao Thiên Vương và Sao Hải Vương được xếp vào hành tinh băng khổng lồ). Hai hành tinh này đôi khi được gọi là hành tinh kiểu Sao Mộc hoặc hành tinh vòng ngoài.",
            });
            this.Add(new PlanetModel(){
                Id = 6,
                Name = "Saturn",
                VnName = "Sao Thổ",
                Content = "Sao Thổ (Saturn) (chữ Hán: 土星) là hành tinh thứ sáu tính theo khoảng cách trung bình từ Mặt Trời và là hành tinh lớn thứ hai về đường kính cũng như khối lượng, sau Sao Mộc trong Hệ Mặt Trời. Tên tiếng Anh của hành tinh mang tên thần Saturn trong thần thoại La Mã, ký hiệu thiên văn của hành tinh là (♄) thể hiện cái liềm của thần. Sao Thổ là hành tinh khí khổng lồ với bán kính trung bình bằng 9 lần của Trái Đất. Tuy khối lượng của hành tinh cao gấp 95 lần khối lượng của Trái Đất nhưng với thể tích lớn hơn 763 lần, khối lượng riêng trung bình của Sao Thổ chỉ bằng một phần tám so với của Trái Đất.",
            });
            this.Add(new PlanetModel(){
                Id = 7,
                Name = "Uranus",
                VnName = "Sao Thiên Vương",
                Content = "Sao Thiên Vương (Uranus) hay Thiên Vương tinh (chữ Hán: 天王星) là hành tinh thứ bảy tính từ Mặt Trời; là hành tinh có bán kính lớn thứ ba và có khối lượng lớn thứ tư trong Hệ Mặt Trời. Sao Thiên Vương có thành phần tương tự như Sao Hải Vương. Cả hai có thành phần hóa học khác so với hai hành tinh khí khổng lồ lớn hơn là Sao Mộc và Sao Thổ.",
            });
            this.Add(new PlanetModel(){
                Id = 8,
                Name = "Neptune",
                VnName = "Sao Hải Vương",
                Content = " Sao Hải Vương ♆ Sao Hải Vương chụp từ Voyager 2. Sao Hải Vương với Vết Tối Lớn bên trái và Vết Tối Nhỏ phía dưới bên phải. Các đám mây trắng chứa băng mêtan; màu xanh nổi bật của hành tinh là do phân tử mêtan hấp thụ ánh sáng bước sóng đỏ. Khám phá Khám phá bởi  Urbain Le Verrier John Couch Adams Johann Galle Ngày phát hiện 23 tháng 9 năm 1846[1] Đặc trưng quỹ đạo[6][7] Kỷ nguyên J2000 Điểm viễn nhật 4.553.946.490 km  30,44125206 AU Điểm cận nhật 4.452.940.833 km  29,76607095 AU Bán trục lớn 4.503.443.661 km  30,10366151 AU Độ lệch tâm 0,011214269 Chu kỳ quỹ đạo 60.190,03[2] ngày 164,79 năm 89.666 ngày Sao Hải Vương[3] Chu kỳ giao hội 367,49 ngày[4] Tốc độ vũ trụ cấp 1 trung bình 5,43 km/s[4] Độ bất thường trung bình 267,767281° Độ nghiêng quỹ đạo 1,767975° so với mặt phẳng Hoàng Đạo 6,43° so với xích đạo Mặt Trời 0,72° so với mặt phẳng bất biến[5] Kinh độ điểm mọc 131,794310° Góc cận điểm 265,646853° Vệ tinh đã biết 14 Đặc trưng vật lý Bán kính xích đạo 24.764 ± 15 km[8][9] 3,883 Trái Đất Bán kính cực 24.341 ± 30 km[8][9] 3,829 Trái Đất Độ dẹt 0,0171 ± 0,0013 Diện tích bề mặt 7,6183×109 km²[2][9] 14,98 Trái Đất Thể tích 6,254×1013 km³[4][9] 57,74 Trái Đất Khối lượng 1,0243×1026 kg[4] 17,147 Trái Đất 5,15×10-5 Mặt Trời Mật độ trung bình 1,638 g/cm³[4][9] Hấp dẫn bề mặt 11,15 m/s2[4][9] 1,14 g Tốc độ vũ trụ cấp 2 23,5 km/s[4][9] Chu kỳ thiên văn 0,6713 ngày[4] 16 h 6 min 36 s Vận tốc quay tại xích đạo 2,68 km/s  9.660 km/h Độ nghiêng trục quay 28,32°[4] Xích kinh cực Bắc 19h 57m 20s[8] 299,3° Xích vĩ cực Bắc 42,950°[8] Suất phản chiếu 0,290 (Bond) 0,41 (hình học)[4] Nhiệt độ bề mặt cực tiểu trung bình cực đại Mức 1 bar  72 K[4]  0,1 bar (10 kPa)  55 K[4]  Cấp sao biểu kiến 8,02 tới 7,78[4][10] Đường kính góc 2,2–2,4″[4][10] Khí quyển[4] Biên độ cao 19,7 ± 0,6 km Thành phần khí quyển  80±3.2% Hydro (H2) 19±3.2% Heli (He) 1.5±0.5% Mêtan (CH4) ~0.019% Hydrogen deuteride (HD) ~0.00015% Êtan (C2H6) Băng:  Amonia (NH3) Nước (H2O) Amoni hydrosulfide (NH4SH) Mêtan (?) Sao Hải Vương (Neptune) hay Hải Vương tinh (chữ Hán: 海王星) là hành tinh thứ tám và xa nhất tính từ Mặt Trời trong Hệ Mặt Trời. Nó là hành tinh lớn thứ tư về đường kính và lớn thứ ba về khối lượng. Sao Hải Vương có khối lượng riêng lớn nhất trong số các hành tinh khí trong hệ Mặt trời.",
            });
        }
    }
}