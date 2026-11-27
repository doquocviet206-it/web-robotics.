using System.Collections.Generic;
using System.Linq;
using web_robotics.Models;

namespace web_robotics.Services
{
    public static class RoboticsMockData
    {
        public static List<LabMember> GetMembers()
        {
            return new List<LabMember>
            {
                new LabMember
                {
                    Id = 1,
                    Name = "GS. TS. Trần Quốc Hùng",
                    Role = "Trưởng phòng Thí nghiệm (Lab Director)",
                    Title = "Giáo sư, Tiến sĩ Cơ điện tử & Điều khiển Robot",
                    Specialization = "Nonlinear Control, Autonomous Mobile Robots (AMR), Bipedal Humanoid Dynamics",
                    Bio = "Hơn 20 năm kinh nghiệm nghiên cứu tại Viện Công nghệ Tokyo (TITech) và ĐH Quốc gia. Tác giả của hơn 85 bài báo ISI/IEEE về hệ thống tự hành và điều khiển robot công nghiệp.",
                    Email = "hung.tq@robotics-lab.edu.vn",
                    AvatarUrl = "https://images.unsplash.com/photo-1534528741775-53994a69daeb?auto=format&fit=crop&w=400&q=80",
                    Highlights = new List<string> { "Giải thưởng Khoa học Công nghệ Quốc gia 2024", "Chủ nhiệm 4 đề tài cấp Nhà nước", "Chủ tịch Hội đồng Cố vấn Robot Tự Hành Quốc Gia" }
                },
                new LabMember
                {
                    Id = 2,
                    Name = "PGS. TS. Lê Phương Thảo",
                    Role = "Phó Giám đốc phụ trách AI & Robot Vision",
                    Title = "Phó Giáo sư, Tiến sĩ Trí tuệ Nhân tạo & Thị giác máy tính",
                    Specialization = "3D Computer Vision, Deep Reinforcement Learning for Manipulation, Neural SLAM",
                    Bio = "Tốt nghiệp Tiến sĩ tại NUS (Singapore), nguyên chuyên viên nghiên cứu tại Viện A*STAR. Lãnh đạo nhóm nghiên cứu nhận dạng vật thể 6-DoF và thị giác cho cánh tay robot gắp phân loại tốc độ cao.",
                    Email = "thao.lp@robotics-lab.edu.vn",
                    AvatarUrl = "https://images.unsplash.com/photo-1573496359142-b8d87734a5a2?auto=format&fit=crop&w=400&q=80",
                    Highlights = new List<string> { "Best Paper Finalist - IEEE ICRA 2023", "Trưởng dự án Robot Y tế Hỗ trợ Phẫu thuật", "Top 10 Nhà nghiên cứu trẻ nổi bật 2025" }
                },
                new LabMember
                {
                    Id = 3,
                    Name = "TS. Nguyễn Minh Đức",
                    Role = "Trưởng nhóm Nghiên cứu Điều khiển & Nhúng",
                    Title = "Tiến sĩ Kỹ thuật Điều khiển Tự động (Đức)",
                    Specialization = "Embedded Real-Time Linux, RTOS, EtherCAT, BLDC Motor Drivers, Motion Planning",
                    Bio = "Từng công tác tại Bosch Robotics R&D Munich. Phụ trách kiến trúc phần cứng, vi điều khiển STM32/FPGA và bus truyền thông tốc độ cao cho các hệ thống robot của Lab.",
                    Email = "duc.nm@robotics-lab.edu.vn",
                    AvatarUrl = "https://images.unsplash.com/photo-1507003211169-0a1dd7228f2d?auto=format&fit=crop&w=400&q=80",
                    Highlights = new List<string> { "Phát triển bộ điều khiển FOC Driver 48V/50A cho khớp Robot", "5 bằng sáng chế thiết bị phần cứng điều khiển" }
                },
                new LabMember
                {
                    Id = 4,
                    Name = "ThS. Hoàng Đình Vũ",
                    Role = "Kỹ sư trưởng Hệ thống Tự hành (Lead AMR Engineer)",
                    Title = "Thạc sĩ Khoa học Máy tính & Robotics",
                    Specialization = "ROS 2 Humble/Iron, Nav2 Navigation Stack, 3D LiDAR SLAM, Cartographer, Multi-robot Fleet Management",
                    Bio = "Chủ nhiệm thiết kế hệ thống robot vận chuyển kho thông minh đã chuyển giao thành công cho 3 nhà máy sản xuất linh kiện điện tử và dược phẩm.",
                    Email = "vu.hd@robotics-lab.edu.vn",
                    AvatarUrl = "https://images.unsplash.com/photo-1500648767791-00dcc994a43e?auto=format&fit=crop&w=400&q=80",
                    Highlights = new List<string> { "Tác giả chính bộ mã nguồn mở ROS2-Industrial Fleet Planner", "Kiểm định thực tế > 20,000 giờ vận hành AMR an toàn" }
                },
                new LabMember
                {
                    Id = 5,
                    Name = "ThS. Đỗ Yến Nhi",
                    Role = "Nghiên cứu viên cao cấp (Senior Researcher)",
                    Title = "Nghiên cứu sinh Tiến sĩ Robotics & Biomimetics",
                    Specialization = "Soft Robotics, Bio-inspired Actuation, Compliant Grippers, Force/Torque Sensing",
                    Bio = "Tốt nghiệp Thạc sĩ tại KAIST (Hàn Quốc), chuyên nghiên cứu tay gắp mềm và cơ chế phỏng sinh học giúp robot tương tác an toàn với con người trong nông nghiệp và đóng gói thực phẩm.",
                    Email = "nhi.dy@robotics-lab.edu.vn",
                    AvatarUrl = "https://images.unsplash.com/photo-1580489944761-15a19d654956?auto=format&fit=crop&w=400&q=80",
                    Highlights = new List<string> { "Giải thưởng Tài năng Sáng tạo Trẻ VUSTA 2025", "Sở hữu 2 thiết kế Gripper biến dạng linh hoạt độc quyền" }
                },
                new LabMember
                {
                    Id = 6,
                    Name = "Kỹ sư Phạm Quang Huy",
                    Role = "Kỹ sư Thiết kế Cơ khí Chính xác (CAD/CAE Specialist)",
                    Title = "Kỹ sư Cơ điện tử",
                    Specialization = "SolidWorks, Ansys FEA/CFD, Harmonic Drive Integration, CNC 5-Axis Prototyping",
                    Bio = "Đảm nhiệm thiết kế khung sườn hợp kim hàng không, phân tích tải trọng động học, tản nhiệt và mô phỏng va đập cho các sản phẩm robot dạng người và robot bốn chân.",
                    Email = "huy.pq@robotics-lab.edu.vn",
                    AvatarUrl = "https://images.unsplash.com/photo-1519085360753-af0119f7cbe7?auto=format&fit=crop&w=400&q=80",
                    Highlights = new List<string> { "Chế tạo thành công chân robot bốn chân đạt vận tốc 3.5 m/s", "Tối ưu trọng lượng khung robot giảm 35% so với thế hệ 1" }
                }
            };
        }

        public static List<ProjectItem> GetProjects()
        {
            return new List<ProjectItem>
            {
                new ProjectItem
                {
                    Id = 1,
                    Title = "AeroBot-AMR 500: Robot Tự Hành Vận Chuyển Hàng Nặng Trong Kho Thông Minh",
                    Slug = "aerobot-amr-500",
                    Category = "Autonomous Mobile Robot (AMR)",
                    Status = "Đã hoàn thành",
                    IsCompletedProduct = true,
                    Year = 2025,
                    ShortDescription = "Robot tự hành công nghiệp tải trọng 500kg, tích hợp LiDAR 360°, camera 3D Depth, thuật toán SLAM thời gian thực và bàn nâng thủy lực tự động kết nối ERP/WMS.",
                    DetailedDescription = "AeroBot-AMR 500 được chế tạo nhằm giải quyết bài toán tự động hóa vận chuyển nội bộ trong các nhà máy lắp ráp điện tử và kho logistics. Robot trang bị cụm cảm biến an toàn chuẩn Safety Laser Scanner SIL2/PLd, cho phép vận hành đồng bộ cùng con người mà không cần dây dẫn từ trường hay mã QR dán sàn.",
                    TechStack = "ROS 2 Humble, C++, Python, RTAB-Map, Nav2, Cartographer, Modbus TCP, STM32H7 Motor Driver",
                    Specifications = "Tải trọng: 500 kg | Tốc độ max: 1.8 m/s | Thời lượng pin: 10h liên tục | Pin LiFePO4 tự sạc 60 phút | Độ chính xác định vị: ±5 mm",
                    LeadResearcher = "ThS. Hoàng Đình Vũ, GS.TS Trần Quốc Hùng",
                    ImageUrl = "https://images.unsplash.com/photo-1485827404703-89b55fcc595e?auto=format&fit=crop&w=900&q=80",
                    KeyFeatures = new List<string>
                    {
                        "Tự động lập bản đồ 3D SLAM không cần rải mã vạch sàn",
                        "Tránh chướng ngại vật động đa hướng với cụm quét laser an toàn kép",
                        "Hệ thống quản lý đội xe (Fleet Management) quản trị hơn 50 robot cùng lúc",
                        "Cơ cấu bàn nâng tự động tích hợp cân điện tử và cảm biến tiệm cận"
                    }
                },
                new ProjectItem
                {
                    Id = 2,
                    Title = "CyberArm 7-DoF: Cánh Tay Robot Công Nghiệp Tinh Xảo Hỗ Trợ AI Vision",
                    Slug = "cyberarm-7dof",
                    Category = "Manipulator & Industrial Robotics",
                    Status = "Đã hoàn thành",
                    IsCompletedProduct = true,
                    Year = 2025,
                    ShortDescription = "Cánh tay robot 7 bậc tự do sử dụng động cơ không chổi than tích hợp hộp số sóng Harmonic Drive, trang bị cảm biến lực 6 trục ở cổ tay và camera RGB-D trên đầu gắp.",
                    DetailedDescription = "Cánh tay robot mô phỏng cánh tay người hoàn chỉnh với 7 bậc tự do, giúp tránh điểm kỳ dị (singularity avoidance) dễ dàng trong không gian hẹp. Được ứng dụng trong công đoạn hàn vi mạch, lắp ráp linh kiện cơ khí chính xác và kiểm tra chất lượng sản phẩm (Visual QC Inspection).",
                    TechStack = "MoveIt 2, PyTorch, YOLOv10-Pose, EtherCAT High-speed Bus, Xenomai Real-Time Linux Kernel",
                    Specifications = "Tầm với: 850 mm | Độ lặp lại: ±0.02 mm | Tải trọng đầu gắp: 5 kg | Trọng lượng thân máy: 18 kg | Bus điều khiển: EtherCAT 1kHz",
                    LeadResearcher = "PGS. TS. Lê Phương Thảo, TS. Nguyễn Minh Đức",
                    ImageUrl = "https://images.unsplash.com/photo-1618005182384-a83a8bd57fbe?auto=format&fit=crop&w=900&q=80",
                    KeyFeatures = new List<string>
                    {
                        "7 bậc tự do linh hoạt vượt trội so với chuẩn 6-DoF truyền thống",
                        "Điều khiển lực phản hồi Compliance Control chống làm hỏng chi tiết khi tiếp xúc",
                        "AI Vision 3D nhận diện vật thể ngẫu nhiên trong thùng chứa (Bin-picking)",
                        "Lập trình quỹ đạo kéo - thả trực quan không cần biết code chuyên sâu (Teaching Pendant)"
                    }
                },
                new ProjectItem
                {
                    Id = 3,
                    Title = "Quadro-Titan: Robot Bốn Chân Vượt Địa Hình Cứu Hộ & Tuần Tra",
                    Slug = "quadro-titan",
                    Category = "Quadruped & Biomimetic Robot",
                    Status = "Đang nghiên cứu",
                    IsCompletedProduct = false,
                    Year = 2026,
                    ShortDescription = "Robot bốn chân phỏng sinh học có khả năng vượt bậc thang, dốc đứng, sỏi đá gập ghềnh và bùn lầy, phục vụ kiểm tra nhà máy điện hạt nhân và cứu hộ thiên tai.",
                    DetailedDescription = "Quadro-Titan sử dụng thuật toán Model Predictive Control (MPC) kết hợp Whole-Body Control (WBC) để giữ thăng bằng tức thời khi bị va đập hoặc trượt chân. Các chân được truyền động bằng Quasi-Direct Drive (QDD) mô-men xoắn cao với độ trễ cực thấp.",
                    TechStack = "C++20, Pinocchio Dynamics Library, CasADi, Isaac Gym Sim-to-Real, Jetson Orin Nano, ROS 2",
                    Specifications = "Khối lượng: 26 kg | Vận tốc chạy tối đa: 3.5 m/s (12.6 km/h) | Tải trọng mang thêm: 12 kg | Khả năng leo dốc: 35 độ",
                    LeadResearcher = "GS. TS. Trần Quốc Hùng, KS. Phạm Quang Huy",
                    ImageUrl = "https://images.unsplash.com/photo-1546776310-eef45dd6d63c?auto=format&fit=crop&w=900&q=80",
                    KeyFeatures = new List<string>
                    {
                        "Khả năng phục hồi thăng bằng cực nhanh sau khi bị tác động ngoại lực mạnh",
                        "Huấn luyện hành vi chuyển động qua Deep Reinforcement Learning trên Nvidia Isaac Sim",
                        "Camera nhiệt FLIR và cảm biến phát hiện rò rỉ khí gas CO/H2S từ xa",
                        "Tự động leo bậc thang cao 18cm và vượt qua bùn lầy địa hình rừng núi"
                    }
                },
                new ProjectItem
                {
                    Id = 4,
                    Title = "MediBot-Delivery: Robot Khử Khuẩn Và Phục Vụ Y Tế Nội Viện",
                    Slug = "medibot-delivery",
                    Category = "Medical & Service Robotics",
                    Status = "Đã hoàn thành",
                    IsCompletedProduct = true,
                    Year = 2024,
                    ShortDescription = "Robot dịch vụ y tế trang bị hệ thống đèn khử khuẩn UV-C công suất cao kết hợp buồng chứa thuốc có mã khóa điện tử, tích hợp gọi thang máy tự động.",
                    DetailedDescription = "Đã được triển khai thử nghiệm thực tế tại Bệnh viện Đa khoa Trung tâm trong thời gian cách ly và điều trị phòng ngừa lây nhiễm chéo. Robot tự đi thang máy qua kết nối IoT không dây, đưa hồ sơ bệnh án, mẫu xét nghiệm và cơm đến từng buồng bệnh nhân.",
                    TechStack = "ROS Navigation, ESP32 Gateway, WebRTC Video Call, Facial Recognition, UV-C Sterilization Control",
                    Specifications = "Buồng chứa: 4 ngăn có khóa thông minh | Đèn UV-C: 254nm 180W | Thời gian khử khuẩn phòng: 12 phút | Tự động về trạm sạc",
                    LeadResearcher = "PGS. TS. Lê Phương Thảo, ThS. Hoàng Đình Vũ",
                    ImageUrl = "https://images.unsplash.com/photo-1581092160607-ee22621dd758?auto=format&fit=crop&w=900&q=80",
                    KeyFeatures = new List<string>
                    {
                        "Giao tiếp qua màn hình cảm ứng tương tác và giọng nói tiếng Việt mượt mà",
                        "Tích hợp mô-đun gọi thang máy tầng và mở cửa tự động qua chuẩn IoT Zigbee/Wi-Fi",
                        "Cảm biến phát hiện chuyển động con người để tự ngắt đèn UV-C tuyệt đối an toàn",
                        "Theo dõi lộ trình và giám sát video trực tiếp 24/7 từ trạm điều dưỡng trung tâm"
                    }
                },
                new ProjectItem
                {
                    Id = 5,
                    Title = "NexusHumanoid: Hệ Thống Thân Robot Hình Người Bán Tự Hành",
                    Slug = "nexushumanoid",
                    Category = "Humanoid Robotics",
                    Status = "Đang nghiên cứu",
                    IsCompletedProduct = false,
                    Year = 2026,
                    ShortDescription = "Mô hình robot hình người tỷ lệ 1:1 thử nghiệm khả năng phối hợp thị giác - ngôn ngữ - hành động (VLA Models) và thao tác hai tay khéo léo (Bimanual Manipulation).",
                    DetailedDescription = "NexusHumanoid là nền tảng nghiên cứu tham vọng nhất của Lab, tập hợp các đột phá về mô hình trí tuệ nhân tạo thị giác - ngôn ngữ (VLM) kết hợp điều khiển chuyển động toàn thân (Whole-Body Teleoperation & Autonomous Manipulation). Dự án nhằm hỗ trợ con người trong các công việc nguy hiểm hoặc hỗ trợ người cao tuổi.",
                    TechStack = "MuJoCo, Open-Teleoperation, Vision-Language-Action (VLA), ROS 2, Dual Nvidia Jetson AGX Orin, CAN-FD",
                    Specifications = "Chiều cao: 165 cm | Cân nặng: 48 kg | Số khớp chuyển động: 32 DoF | Cảm biến lực bàn chân 6 trục",
                    LeadResearcher = "GS. TS. Trần Quốc Hùng, PGS. TS. Lê Phương Thảo, Đội ngũ NCS",
                    ImageUrl = "https://images.unsplash.com/photo-1535378917042-10a22c95931a?auto=format&fit=crop&w=900&q=80",
                    KeyFeatures = new List<string>
                    {
                        "Thực hiện thao tác đồng bộ hai tay để bưng bê đồ vật kích thước lớn",
                        "Học hành vi qua bắt chước chuyển động con người với bộ găng tay thực tế ảo VR",
                        "Tích hợp mô hình ngôn ngữ lớn xử lý khẩu lệnh tự nhiên và phân rã nhiệm vụ (Task Planning)",
                        "Thiết kế khớp trợ lực đàn hồi (Series Elastic Actuator - SEA) an toàn khi va chạm"
                    }
                },
                new ProjectItem
                {
                    Id = 6,
                    Title = "AgriScan-Drone: Máy Bay Không Người Lái Phân Tích Cây Trồng Bằng AI",
                    Slug = "agriscan-drone",
                    Category = "Autonomous Drone & Agriculture",
                    Status = "Đã hoàn thành",
                    IsCompletedProduct = true,
                    Year = 2025,
                    ShortDescription = "Hệ thống máy bay không người lái tự hành quét đa phổ, tự động phát hiện sâu bệnh, phân tích chỉ số NDVI và phun thuốc mục tiêu chính xác từng centimet.",
                    DetailedDescription = "Hệ thống UAV tự hành bay quét theo lưới tọa độ GPS-RTK sai số cực tiểu. Dữ liệu ảnh đa phổ được xử lý biên (Edge AI) ngay trên drone, phát hiện điểm sâu bệnh để chỉ kích hoạt đầu phun vi điểm, tiết kiệm 70% lượng hóa chất nông nghiệp.",
                    TechStack = "PX4 Autopilot, MAVLink, QGroundControl, Multispectral Camera, TensorRT, RTK-GNSS",
                    Specifications = "Thời gian bay: 35 phút/lần sạc | Diện tích quét: 40 hecta/giờ | Cảm biến đa phổ 5 dải màu | Độ chính xác RTK: 1-2 cm",
                    LeadResearcher = "ThS. Hoàng Đình Vũ, KS. Phạm Quang Huy",
                    ImageUrl = "https://images.unsplash.com/photo-1527977966376-1c8408f9f108?auto=format&fit=crop&w=900&q=80",
                    KeyFeatures = new List<string>
                    {
                        "Lập lộ trình bay tự động hoàn toàn chỉ với một chạm trên bản đồ vệ tinh",
                        "Nhận diện bệnh vàng lá, nấm mốc và thiếu nước qua ảnh quang phổ thời gian thực",
                        "Cơ chế tránh chướng ngại vật bằng radar sóng milimet chống va chạm đường dây điện",
                        "Xuất báo cáo tự động tích hợp bản đồ số cho nhà quản lý nông trang"
                    }
                }
            };
        }

        public static List<ResearchPublication> GetPublications()
        {
            return new List<ResearchPublication>
            {
                new ResearchPublication
                {
                    Id = 1,
                    Title = "Robust Adaptive Sliding Mode Control for Heavy-Payload Autonomous Mobile Robots in Dynamic Warehouse Environments",
                    Authors = "Tran Quoc Hung, Hoang Dinh Vu, Nguyen Minh Duc",
                    JournalOrConference = "IEEE Transactions on Robotics (T-RO)",
                    Year = 2025,
                    Doi = "10.1109/TRO.2025.3344120",
                    CitationRank = "IEEE T-RO (Q1 - Top 1% Robotics)",
                    Category = "Control & Dynamics",
                    Abstract = "Bài báo đề xuất thuật toán điều khiển trượt thích nghi bền vững kết hợp bộ quan sát nhiễu trạng thái mở rộng (ESO) cho xe tự hành tải trọng lớn. Kết quả thực nghiệm trên robot 500kg cho thấy giảm 45% sai số bám quỹ đạo khi tải trọng thay đổi đột ngột.",
                    PaperUrl = "https://ieeexplore.ieee.org/document/example-tro"
                },
                new ResearchPublication
                {
                    Id = 2,
                    Title = "6D-GraspNet: End-to-End Real-Time 6-DoF Object Pose Estimation and Grasp Planning in Cluttered Scenes",
                    Authors = "Le Phuong Thao, Do Yen Nhi, Tran Quoc Hung",
                    JournalOrConference = "IEEE International Conference on Robotics and Automation (ICRA 2025)",
                    Year = 2025,
                    Doi = "10.1109/ICRA.2025.1012984",
                    CitationRank = "IEEE ICRA (Hội nghị hàng đầu thế giới về Robot)",
                    Category = "AI & Computer Vision",
                    Abstract = "Nghiên cứu kiến trúc mạng nơ-ron tích chập 3D kết hợp Transformer giúp xác định tư thế vật thể 6 bậc tự do với độ trễ dưới 25ms trên ảnh mây điểm Point Cloud bị che khuất một phần.",
                    PaperUrl = "https://ieeexplore.ieee.org/document/example-icra"
                },
                new ResearchPublication
                {
                    Id = 3,
                    Title = "Sim-to-Real Transfer of Whole-Body Dynamic Locomotion for Quadruped Robots via Meta-Reinforcement Learning",
                    Authors = "Tran Quoc Hung, Pham Quang Huy, Le Phuong Thao",
                    JournalOrConference = "IEEE/RSJ International Conference on Intelligent Robots and Systems (IROS 2024)",
                    Year = 2024,
                    Doi = "10.1109/IROS.2024.9876543",
                    CitationRank = "IEEE IROS (Hội nghị Robot Quốc tế uy tín cao)",
                    Category = "Quadruped & Locomotion",
                    Abstract = "Giải pháp thu hẹp khoảng cách Sim-to-Real trong điều khiển robot bốn chân chạy trên bề mặt trơn trượt bằng kỹ thuật xáo trộn miền thông số động học (Domain Randomization) và mô hình hóa lực ma sát phi tuyến tính.",
                    PaperUrl = "https://ieeexplore.ieee.org/document/example-iros"
                },
                new ResearchPublication
                {
                    Id = 4,
                    Title = "Bio-Inspired Compliant Soft Gripper with Embedded Tactile Sensing for Damage-Free Agricultural Harvesting",
                    Authors = "Do Yen Nhi, Le Phuong Thao, Nguyen Minh Duc",
                    JournalOrConference = "Soft Robotics Journal (Mary Ann Liebert)",
                    Year = 2024,
                    Doi = "10.1089/soro.2023.0189",
                    CitationRank = "Q1 Journal - Impact Factor 7.9",
                    Category = "Soft Robotics & Sensors",
                    Abstract = "Thiết kế tay gắp mềm khí nén cấu trúc origami phỏng sinh học tích hợp màng cảm biến áp điện tử, cho phép thu hoạch các loại quả dễ bầm dập như cà chua, dâu tây với tỷ lệ nguyên vẹn đạt 99.4%.",
                    PaperUrl = "https://liebertpub.com/doi/example-soft-robotics"
                },
                new ResearchPublication
                {
                    Id = 5,
                    Title = "Multi-Robot Collaborative LiDAR SLAM with Bandwidth-Constrained Decentralized Data Fusion",
                    Authors = "Hoang Dinh Vu, Nguyen Minh Duc, Tran Quoc Hung",
                    JournalOrConference = "Journal of Field Robotics (Wiley)",
                    Year = 2025,
                    Doi = "10.1002/rob.22150",
                    CitationRank = "Q1 Journal - Top Field Robotics",
                    Category = "SLAM & Multi-Robot Fleet",
                    Abstract = "Kỹ thuật đồng bộ bản đồ phân tán cho đội hình xe tự hành hoạt động trong môi trường ngầm không có GPS và băng thông mạng không dây bị suy hao mạnh, tối ưu hóa kích thước dữ liệu truyền tải giảm 80%.",
                    PaperUrl = "https://onlinelibrary.wiley.com/doi/example-jfr"
                }
            };
        }

        public static List<KnowledgeArticle> GetKnowledgeArticles()
        {
            return new List<KnowledgeArticle>
            {
                new KnowledgeArticle
                {
                    Id = 1,
                    Title = "Tổng quan kiến trúc ROS 2 (Robot Operating System) từ cơ bản đến nâng cao",
                    Slug = "tong-quan-kien-truc-ros2-co-ban-den-nang-cao",
                    Category = "ROS & Middleware",
                    Level = "Cơ bản đến Trung cấp",
                    Author = "ThS. Hoàng Đình Vũ",
                    PublishedDate = "15/10/2026",
                    ReadTimeMinutes = 12,
                    Summary = "Khám phá kiến trúc nền tảng ROS 2 dựa trên chuẩn DDS, so sánh chi tiết với ROS 1, cách thức hoạt động của Node, Topic, Service, Action và cơ chế Real-Time Executor.",
                    Tags = new List<string> { "ROS2", "DDS", "Micro-ROS", "Middleware", "C++", "Python" },
                    ContentMarkdown = @"
### 1. Tại sao ROS 2 là tương lai của ngành Robotics?
Trong hơn một thập kỷ, **ROS (Robot Operating System)** là tiêu chuẩn thực tế để nghiên cứu robot trong học thuật. Tuy nhiên, ROS 1 có những giới hạn cốt lõi: phụ thuộc vào nút trung tâm `roscore` (điểm nghẽn lỗi đơn), không hỗ trợ tính toán thời gian thực (Real-Time), không có cơ chế bảo mật nguyên bản, và khó vận hành trên mạng không dây không ổn định.

**ROS 2 ra đời để khắc phục toàn bộ các nhược điểm này:**
- **DDS (Data Distribution Service)** làm tầng liên lạc nền tảng: Phân tán hoàn toàn, không cần master node, hỗ trợ khám phá nốt tự động (P2P Discovery).
- **Quality of Service (QoS)**: Cho phép tinh chỉnh độ tin cậy của bản tin (Reliable vs Best-effort, Transient Local, Durability, Deadline).
- **Real-Time Ready**: Thiết kế để có thể chạy trên các hệ điều hành thời gian thực (RTOS, Xenomai, FreeRTOS qua Micro-ROS).
- **Hỗ trợ đa nền tảng**: Hoạt động mượt mà trên Ubuntu Linux, Windows, macOS và vi điều khiển (MCU).

### 2. Các thành phần giao tiếp cơ bản trong ROS 2
1. **Nodes**: Đơn vị tính toán nhỏ nhất chịu trách nhiệm cho một tác vụ cụ thể (ví dụ: Node đọc cảm biến LiDAR, Node lập kế hoạch di chuyển).
2. **Topics (Publish/Subscribe)**: Kênh truyền thông một chiều bất đồng bộ, phù hợp với dữ liệu luồng liên tục như ảnh camera, dữ liệu cảm biến đo laser.
3. **Services (Request/Response)**: Mô hình đồng bộ hỏi - đáp hai chiều, dùng khi cần gửi lệnh và chờ xác nhận kết quả (ví dụ: kích hoạt cánh tay gắp, bật rơ-le).
4. **Actions (Goal/Feedback/Result)**: Mô hình tương tác cho các tác vụ tốn thời gian, hỗ trợ gửi phản hồi liên tục và có thể hủy lệnh bất cứ lúc nào (ví dụ: lệnh điều hướng robot di chuyển tới tọa độ đích).

### 3. Ví dụ nhanh khởi tạo ROS 2 Node bằng C++
```cpp
#include ""rclcpp/rclcpp.hpp""

class SensorNode : public rclcpp::Node {
public:
    SensorNode() : Node(""sensor_reader"") {
        RCLCPP_INFO(this->get_logger(), ""Robotics Lab: Sensor Node Initialized Successfully!"");
    }
};

int main(int argc, char **argv) {
    rclcpp::init(argc, argv);
    auto node = std::make_shared<SensorNode>();
    rclcpp::spin(node);
    rclcpp::shutdown();
    return 0;
}
```
"
                },
                new KnowledgeArticle
                {
                    Id = 2,
                    Title = "Toàn diện về SLAM (Simultaneous Localization and Mapping) cho Robot Tự Hành",
                    Slug = "toan-dien-ve-slam-cho-robot-tu-hanh",
                    Category = "SLAM & Navigation",
                    Level = "Chuyên sâu",
                    Author = "GS. TS. Trần Quốc Hùng",
                    PublishedDate = "28/09/2026",
                    ReadTimeMinutes = 15,
                    Summary = "Phân tích nguyên lý toán học đằng sau bài toán vừa định vị vừa lập bản đồ (SLAM): Phân loại LiDAR SLAM vs Visual SLAM, Kalman Filter, Graph-based SLAM và đóng vòng lặp (Loop Closure).",
                    Tags = new List<string> { "SLAM", "LiDAR", "Visual-SLAM", "Cartographer", "Nav2", "Bản đồ 3D" },
                    ContentMarkdown = @"
### 1. Bản chất của bài toán SLAM (Con gà và Quả trứng)
Để vẽ được bản đồ chính xác, robot cần biết mình đang đứng ở đâu. Nhưng để biết chính xác mình đang ở đâu, robot lại cần một bản đồ có sẵn! SLAM giải quyết đồng thời hai bài toán tưởng như mâu thuẫn này thông qua ước lượng xác suất trạng thái.

### 2. Hai trường phái thuật toán chính
- **Filter-based SLAM (EKF-SLAM, FastSLAM)**: Cập nhật đệ quy vị trí và đặc trưng môi trường theo từng chu kỳ. Thích hợp cho hệ thống vi điều khiển nhẹ nhưng độ chính xác giảm dần khi bản đồ mở rộng quy mô lớn.
- **Graph-based SLAM (Cartographer, RTAB-Map, LIO-SAM)**:
  - **Frontend**: Khớp nối các khung quét liên tiếp (Scan-to-Scan hoặc Scan-to-Submap matching) sử dụng thuật toán ICP (Iterative Closest Point) hoặc NDT (Normal Distributions Transform).
  - **Backend**: Xây dựng đồ thị ràng buộc không gian. Khi phát hiện robot quay lại một vị trí đã từng đi qua (Loop Closure), thuật toán tối ưu phi tuyến (như g2o, Ceres Solver) sẽ nắn chỉnh toàn bộ đồ thị để loại bỏ sai số trôi tích lũy (drift).

### 3. Bảng so sánh 2D LiDAR SLAM và 3D Visual-Inertial SLAM
| Tiêu chí | 2D LiDAR SLAM (Cartographer) | 3D Visual-Inertial SLAM (ORB-SLAM3 / RTAB-Map) |
|---|---|---|
| **Cảm biến chính** | Laser Scanner quét mặt phẳng | Stereo Camera / RGB-D + IMU 6 trục |
| **Độ nhạy ánh sáng** | Miễn nhiễm với bóng tối | Phụ thuộc cường độ chiếu sáng |
| **Khả năng trích xuất đặc trưng** | Hình học cấu trúc tường/cột | Kết cấu bề mặt (Texture), màu sắc, vật thể AI |
| **Chi phí phần cứng** | Trung bình - Cao | Thấp - Trung bình |
| **Ứng dụng tiêu biểu** | Xe tự hành nhà xưởng AMR | Drone tự hành bay ngoài trời, kính AR/VR |
"
                },
                new KnowledgeArticle
                {
                    Id = 3,
                    Title = "Động học Robot Manipulator: Ma trận Denavit-Hartenberg (DH) và Bài toán Động học Nghịch (IK)",
                    Slug = "dong-hoc-robot-manipulator-dh-va-dong-hoc-nghich-ik",
                    Category = "Điều khiển & Động lực học",
                    Level = "Cơ bản đến Trung cấp",
                    Author = "TS. Nguyễn Minh Đức",
                    PublishedDate = "05/09/2026",
                    ReadTimeMinutes = 14,
                    Summary = "Hướng dẫn chi tiết từng bước đặt hệ tọa độ theo chuẩn Denavit-Hartenberg (DH Parameters), tính toán động học thuận (Forward Kinematics) và giải phương trình động học nghịch (IK) bằng giải tích lẫn số học.",
                    Tags = new List<string> { "Động học", "Manipulator", "DH Matrix", "Inverse Kinematics", "Jacobian" },
                    ContentMarkdown = @"
### 1. Bốn tham số Denavit-Hartenberg (DH) kinh điển
Quy ước DH cho phép mô tả mối quan hệ vị trí và hướng giữa hai khâu (link) liên tiếp của cánh tay robot chỉ bằng 4 tham số:
1. **$a_i$ (Link length)**: Khoảng cách giữa trục $Z_{i-1}$ và $Z_i$ dọc theo trục $X_i$.
2. **$\alpha_i$ (Link twist)**: Góc xoay từ trục $Z_{i-1}$ đến $Z_i$ quanh trục $X_i$.
3. **$d_i$ (Link offset)**: Khoảng cách giữa trục $X_{i-1}$ và $X_i$ dọc theo trục $Z_{i-1}$ (biến số đối với khớp tịnh tiến).
4. **$\theta_i$ (Joint angle)**: Góc xoay từ trục $X_{i-1}$ đến $X_i$ quanh trục $Z_{i-1}$ (biến số đối với khớp quay).

### 2. Ma trận biến đổi đồng nhất thứ tự khớp
$$T_{i-1}^i = \begin{bmatrix} 
\cos\theta_i & -\sin\theta_i\cos\alpha_i & \sin\theta_i\sin\alpha_i & a_i\cos\theta_i \\
\sin\theta_i & \cos\theta_i\cos\alpha_i & -\cos\theta_i\sin\alpha_i & a_i\sin\theta_i \\
0 & \sin\alpha_i & \cos\alpha_i & d_i \\
0 & 0 & 0 & 1
\end{bmatrix}$$

### 3. Bài toán Động học Nghịch (Inverse Kinematics - IK)
- **Phương pháp Giải tích (Analytical IK)**: Tìm nghiệm chính xác bằng hình học hoặc đại số. Thường áp dụng cho các cấu trúc tay 6 bậc thỏa mãn điều kiện Pieper (3 trục cổ tay cắt nhau tại 1 điểm). Tốc độ tính toán siêu nhanh (<1 micro giây), thích hợp cho hệ thống nhúng thời gian thực.
- **Phương pháp Số học (Numerical IK)**: Sử dụng ma trận Jacobian ($J$) và thuật toán lặp Levenberg-Marquardt hoặc Pseudo-Inverse để giải xấp xỉ cho mọi cấu hình robot bất kỳ (đặc biệt là robot dư bậc 7-DoF như CyberArm).
"
                },
                new KnowledgeArticle
                {
                    Id = 4,
                    Title = "Ứng dụng Thị giác máy tính 3D và Deep Learning trong Robot gắp phân loại (Bin-Picking)",
                    Slug = "thi-giac-may-tinh-3d-va-deep-learning-trong-bin-picking",
                    Category = "AI & Robot Vision",
                    Level = "Nâng cao",
                    Author = "PGS. TS. Lê Phương Thảo",
                    PublishedDate = "19/08/2026",
                    ReadTimeMinutes = 11,
                    Summary = "Cách tích hợp camera đám mây điểm RGB-D với mô hình mạng nơ-ron nhận dạng vật thể và ước lượng điểm gắp an toàn 6-DoF chống va chạm trong thùng hàng công nghiệp.",
                    Tags = new List<string> { "Deep Learning", "Bin-Picking", "RGB-D", "Point Cloud", "PyTorch", "Grasp Planning" },
                    ContentMarkdown = @"
### 1. Thách thức lớn của bài toán Bin-Picking truyền thống
Trong sản xuất thông minh, các chi tiết kim loại, bu-lông, phụ tùng thường nằm lộn xộn trong các thùng chứa lớn (bin). Camera 2D truyền thống không thể nhận diện được độ sâu, độ nghiêng và hiện tượng bề mặt kim loại bị phản xạ chói lóa.

### 2. Pipeline xử lý 3D Vision hiện đại
1. **Thu thập đám mây điểm (Point Cloud Acquisition)**: Camera cấu trúc ánh sáng (Structured Light) hoặc ToF tạo ra ma trận hàng triệu điểm không gian $(X, Y, Z, R, G, B)$.
2. **Lọc nhiễu và phân đoạn (Filtering & Segmentation)**: Dùng thuật toán PassThrough, VoxelGrid và RANSAC để loại bỏ mặt phẳng đáy thùng và viền bao.
3. **Ước lượng tư thế 6D (6-DoF Pose Estimation)**: Mạng nơ-ron học sâu trích xuất vector đặc trưng hình học 3D, đối chiếu với mô hình CAD số của sản phẩm để xác định ma trận chuyển vị $[R | T]$.
4. **Grasp Quality Evaluation**: Tính toán ma trận ma sát tiếp xúc (Friction Cone) của kẹp gắp và kiểm tra va chạm của thân robot với thành thùng (Collision Checking qua MoveIt).
"
                },
                new KnowledgeArticle
                {
                    Id = 5,
                    Title = "Kỹ thuật Thiết kế Động cơ Không Chổi Than (BLDC) & Bộ điều khiển FOC cho Robot Chân và Khớp Tay",
                    Slug = "thiet-ke-dong-co-bldc-bo-dieu-khien-foc-cho-robot",
                    Category = "Phần cứng & Điện tử Nhúng",
                    Level = "Nâng cao",
                    Author = "TS. Nguyễn Minh Đức & KS. Phạm Quang Huy",
                    PublishedDate = "11/07/2026",
                    ReadTimeMinutes = 13,
                    Summary = "Nguyên lý điều khiển tựa từ thông (Field Oriented Control - FOC), thuật toán biến đổi Clarke-Park, giải pháp đọc encoder tuyệt đối SSI/BiSS-C và mạch công suất MOSFET cho robot di động.",
                    Tags = new List<string> { "FOC", "BLDC", "STM32", "Inverter", "SVPWM", "CAN-FD" },
                    ContentMarkdown = @"
### 1. Tại sao Robot hiện đại chuyển sang Động cơ BLDC điều khiển FOC?
Động cơ bước truyền thống rung lắc và tổn hao công suất lớn, trong khi động cơ DC chổi than nhanh mòn và sinh tia lửa điện. Động cơ không chổi than (BLDC / PMSM) phối hợp với thuật toán **FOC (Field-Oriented Control)** mang lại:
- Khả năng kiểm soát mô-men xoắn (torque) mượt mà ở vận tốc 0 rpm.
- Hiệu suất năng lượng lên đến 92-95%, giảm nhiệt độ cuộn dây.
- Khả năng hoạt động ở chế độ Trong suốt (Back-drivability), biến động cơ thành cảm biến lực ảo cho robot phỏng sinh học.

### 2. Các bước trong chu trình tính toán FOC
1. Đo dòng 2 hoặc 3 pha ($i_a, i_b, i_c$) qua điện trở shunt dòng cao tần.
2. Đo góc quay rotor $\theta$ qua cảm biến góc từ tính Magnetic Absolute Encoder (14-18 bit resolution).
3. **Biến đổi Clarke**: Chuyển từ hệ quy chiếu 3 pha sang hệ tọa độ 2 pha tĩnh $(\alpha, \beta)$.
4. **Biến đổi Park**: Chuyển từ hệ tọa độ tĩnh sang hệ tọa độ quay đồng bộ với từ thông rotor $(d, q)$.
5. Hai bộ điều khiển PID độc lập: $I_d$ (ép về 0 để tối đa hóa hiệu suất) và $I_q$ (tỷ lệ trực tiếp với mô-men đầu ra).
6. **Biến đổi nghịch Park & SVPWM**: Tạo xung điều biến độ rộng vector không gian đóng mở cầu 6 MOSFET.
"
                },
                new KnowledgeArticle
                {
                    Id = 6,
                    Title = "Khung chuẩn an toàn công nghiệp ISO 3691-4 và ISO 10218 cho Robot Tự hành & Cobot",
                    Slug = "khung-chuan-an-toan-iso-3691-4-va-iso-10218-cho-robot",
                    Category = "Tiêu chuẩn & An toàn Lab",
                    Level = "Cơ bản đến Trung cấp",
                    Author = "ThS. Đỗ Yến Nhi & ThS. Hoàng Đình Vũ",
                    PublishedDate = "02/06/2026",
                    ReadTimeMinutes = 9,
                    Summary = "Tổng hợp các quy chuẩn an toàn bắt buộc khi thiết kế, lập trình và chuyển giao robot tự hành (AGV/AMR) và robot cộng tác (Cobot) làm việc chung không gian với người lao động.",
                    Tags = new List<string> { "ISO 3691-4", "ISO 10218", "Safety Laser Scanner", "PLd/SIL2", "Cobot" },
                    ContentMarkdown = @"
### 1. Tiêu chuẩn ISO 3691-4:2023 cho Xe tự hành công nghiệp (AMR/AGV)
Tiêu chuẩn này quy định các yêu cầu kỹ thuật tối thiểu để ngăn ngừa tai nạn va chạm:
- **Trường bảo vệ an toàn chủ động (Safety Zones)**: Cảm biến laser an toàn phải tự động chuyển đổi vùng quét phụ thuộc vào vận tốc di chuyển và góc cua lái.
- **Nút dừng khẩn cấp cấp độ 0 hoặc 1 (E-Stop)**: Đặt ở mọi góc tiếp cận của robot, cắt trực tiếp rơ-le nguồn động cơ chính.
- **Mức độ an toàn chức năng**: Đạt tối thiểu Performance Level d (PL d) theo tiêu chuẩn ISO 13849-1.

### 2. Tiêu chuẩn ISO 10218-1 & ISO/TS 15066 cho Robot cộng tác (Cobot)
- Bốn chế độ cộng tác:
  1. Dừng an toàn có giám sát (Safety-rated monitored stop).
  2. Dẫn hướng bằng tay (Hand guiding).
  3. Giám sát khoảng cách và tốc độ (Speed and separation monitoring).
  4. Giới hạn lực và công suất (Power and force limiting - PFL): Khi va chạm bất ngờ với cơ thể con người, lực cản và áp lực sinh ra không được vượt quá ngưỡng gây tổn thương sinh học theo bảng tra cứu nhân trắc học.
"
                }
            };
        }

        public static List<LabDocGuide> GetLabDocs()
        {
            return new List<LabDocGuide>
            {
                new LabDocGuide
                {
                    Id = 1,
                    Title = "Sổ tay An toàn và Quy định Vận hành Phòng Thí nghiệm Robotics (SOP 2026)",
                    Category = "Lab Standard Operating Procedure (SOP)",
                    Version = "v3.2",
                    FileSize = "3.8 MB (PDF)",
                    TargetAudience = "Sinh viên, Học viên Cao học, Nghiên cứu sinh mới tham gia Lab",
                    Description = "Quy định chi tiết về trang thiết bị bảo hộ, quy trình bật nguồn điện cao áp trên trạm robot công nghiệp, lưu trữ pin LiPo/LiFePO4, và biện pháp xử lý sự cố khẩn cấp.",
                    DownloadOrViewUrl = "#"
                },
                new LabDocGuide
                {
                    Id = 2,
                    Title = "Hướng dẫn cài đặt và cấu hình môi trường lập trình ROS 2 Humble & Isaac Sim trên Ubuntu 22.04 LTS",
                    Category = "Software Setup & Tutorial",
                    Version = "v2.5",
                    FileSize = "5.1 MB (PDF & Code Repos)",
                    TargetAudience = "Kỹ sư phần mềm Robotics, Lập trình viên AI",
                    Description = "Từng bước cài đặt NVIDIA Driver, CUDA 12.x, Docker, ROS 2 Humble Hawksbill, Isaac Gym và thiết lập workspace mẫu hỗ trợ build với colcon.",
                    DownloadOrViewUrl = "#"
                },
                new LabDocGuide
                {
                    Id = 3,
                    Title = "Sơ đồ chân giao tiếp phần cứng và Tài liệu tích hợp chuẩn EtherCAT cho Controller CyberArm",
                    Category = "Hardware Manual & Schematics",
                    Version = "v1.4",
                    FileSize = "12.6 MB (PDF + Altium Schematics)",
                    TargetAudience = "Kỹ sư nhúng, Chuyên gia Cơ điện tử",
                    Description = "Sơ đồ nguyên lý mạch điều khiển, pinout cổng truyền thông CAN-FD, EtherCAT IN/OUT, cổng Encoder BiSS-C và hướng dẫn đấu nối nguồn công suất 48VDC.",
                    DownloadOrViewUrl = "#"
                },
                new LabDocGuide
                {
                    Id = 4,
                    Title = "Bộ dữ liệu hình ảnh 3D Point Cloud & RGB-D: Industrial Bin-Picking Benchmark (V-Grasp 2025)",
                    Category = "Open Research Dataset",
                    Version = "v1.0",
                    FileSize = "42.0 GB (Download Mirror / Torrent)",
                    TargetAudience = "Cộng đồng nghiên cứu AI & Computer Vision toàn cầu",
                    Description = "Chứa hơn 50,000 khung quét 3D của 120 chi tiết cơ khí khác nhau dưới đa dạng điều kiện chiếu sáng và vật thể che khuất, kèm nhãn ground-truth tư thế 6-DoF và điểm gắp tối ưu.",
                    DownloadOrViewUrl = "#"
                },
                new LabDocGuide
                {
                    Id = 5,
                    Title = "Tài liệu API Client & Hướng dẫn tích hợp Fleet Management Hệ thống AMR AeroBot-500",
                    Category = "Developer API Reference",
                    Version = "v2.1",
                    FileSize = "2.4 MB (HTML & OpenAPI 3.0)",
                    TargetAudience = "Kỹ sư tích hợp hệ thống, Doanh nghiệp triển khai nhà máy",
                    Description = "Mô tả đầy đủ RESTful API, WebSocket telemetry, định dạng tin nhắn MQTT và chuẩn kết nối VDA 5050 để điều phối nhóm robot tự hành từ xa.",
                    DownloadOrViewUrl = "#"
                }
            };
        }

        public static LabOverviewViewModel GetLabOverview()
        {
            var projects = GetProjects();
            var publications = GetPublications();
            var articles = GetKnowledgeArticles();

            return new LabOverviewViewModel
            {
                TotalProjects = projects.Count,
                CompletedProducts = projects.Count(p => p.IsCompletedProduct),
                ActivePublications = publications.Count,
                FeaturedProjects = projects.Take(3).ToList(),
                RecentPublications = publications.Take(3).ToList(),
                LatestArticles = articles.Take(3).ToList()
            };
        }
    }
}
