using System;
using System.Collections.Generic;
using System.Linq;
using web_robotics.Models;

namespace web_robotics.Services
{
    public class ChatbotResponse
    {
        public string Reply { get; set; } = string.Empty;
        public List<string> RelatedLinks { get; set; } = new();
        public List<string> Suggestions { get; set; } = new();
    }

    public class RoboticsAssistantService(RoboticsDataService data)
    {
        public ChatbotResponse ProcessQuery(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                return new ChatbotResponse
                {
                    Reply = "Chào bạn! Tôi là Trợ lý AI Robotics Lab. Bạn có thể hỏi tôi về các dự án robot, thành viên nghiên cứu, tài liệu hướng dẫn kỹ thuật hoặc các khái niệm như ROS 2, SLAM, FOC, Inverse Kinematics...",
                    Suggestions = new List<string> { "Giới thiệu AeroBot-AMR 500", "ROS 2 là gì?", "SLAM hoạt động thế nào?", "Các công bố khoa học gần đây" }
                };
            }

            var q = query.ToLower().Trim();

            // 1. Hỏi về ROS / ROS 2
            if (q.Contains("ros") || q.Contains("ros2") || q.Contains("middleware"))
            {
                return new ChatbotResponse
                {
                    Reply = "ROS 2 (Robot Operating System 2) là nền tảng middleware phân tán được xây dựng dựa trên tiêu chuẩn DDS (Data Distribution Service). Điểm mạnh vượt trội của ROS 2 so với ROS 1 là: không cần nút trung tâm (roscore), hỗ trợ kiểm soát chất lượng dịch vụ (QoS), đáp ứng tính toán thời gian thực (Real-time), và hỗ trợ trực tiếp đa nền tảng (Linux, Windows, macOS, Micro-ROS cho MCU).",
                    RelatedLinks = new List<string> { "/Knowledge/Detail/tong-quan-kien-truc-ros2-co-ban-den-nang-cao" },
                    Suggestions = new List<string> { "Đọc bài viết chi tiết về ROS 2", "SLAM trong ROS 2 hoạt động sao?", "Xem tài liệu cài đặt ROS 2 Humble" }
                };
            }

            // 2. Hỏi về SLAM / Lập bản đồ / Định vị
            if (q.Contains("slam") || q.Contains("định vị") || q.Contains("bản đồ") || q.Contains("mapping") || q.Contains("lidar"))
            {
                return new ChatbotResponse
                {
                    Reply = "SLAM (Simultaneous Localization and Mapping) là kỹ thuật giúp robot vừa ước lượng vị trí của chính nó, vừa dựng bản đồ môi trường chưa từng biết trước. Tại Lab, chúng tôi ứng dụng cả 2D LiDAR SLAM (Cartographer) cho xe AMR kho hàng và 3D Visual-Inertial SLAM (RTAB-Map, LIO-SAM) cho robot bốn chân và drone.",
                    RelatedLinks = new List<string> { "/Knowledge/Detail/toan-dien-ve-slam-cho-robot-tu-hanh", "/Projects/Detail/aerobot-amr-500" },
                    Suggestions = new List<string> { "Xem bài phân tích thuật toán SLAM", "Dự án xe tự hành AeroBot-AMR 500", "Công bố khoa học về Multi-Robot SLAM" }
                };
            }

            // 3. Hỏi về Dự án AeroBot AMR
            if (q.Contains("aerobot") || q.Contains("amr") || q.Contains("kho") || q.Contains("xe tự hành"))
            {
                var p = data.GetProjects().FirstOrDefault(x => x.Slug == "aerobot-amr-500");
                return new ChatbotResponse
                {
                    Reply = $"Dự án **{p?.Title}** là robot tự hành tải trọng 500kg đã hoàn thành và ứng dụng thực tế. Robot sử dụng ROS 2 Humble, Cartographer SLAM, cảm biến an toàn kép SIL2/PLd, pin sạc tự động LiFePO4 và tích hợp trực tiếp hệ thống quản lý nhà máy Fleet Management.",
                    RelatedLinks = new List<string> { "/Projects/Detail/aerobot-amr-500", "/Projects/Completed" },
                    Suggestions = new List<string> { "Xem thông số kỹ thuật AeroBot-500", "Tài liệu API tích hợp Fleet Management", "Xem sản phẩm CyberArm 7-DoF" }
                };
            }

            // 4. Hỏi về Cánh tay robot / CyberArm / Động học IK
            if (q.Contains("tay") || q.Contains("arm") || q.Contains("cyberarm") || q.Contains("ik") || q.Contains("động học") || q.Contains("kinematic"))
            {
                return new ChatbotResponse
                {
                    Reply = "CyberArm 7-DoF là cánh tay robot 7 bậc tự do công nghiệp với độ chính xác lặp lại ±0.02 mm, bus EtherCAT 1kHz và hỗ trợ điều khiển lực mềm dẻo (Compliance Control). Lab cũng chia sẻ bài viết kỹ thuật giải bài toán Động học thuận và Động học nghịch (Inverse Kinematics) với ma trận DH và Jacobian.",
                    RelatedLinks = new List<string> { "/Projects/Detail/cyberarm-7dof", "/Knowledge/Detail/dong-hoc-robot-manipulator-dh-va-dong-hoc-nghich-ik" },
                    Suggestions = new List<string> { "Đọc bài viết về Động học Robot DH & IK", "Xem sơ đồ chân phần cứng CyberArm", "Thuật toán Bin-Picking bằng AI Vision" }
                };
            }

            // 5. Hỏi về Thành viên / Lab Director / Trưởng lab
            if (q.Contains("thành viên") || q.Contains("trưởng lab") || q.Contains("giáo sư") || q.Contains("nhân sự") || q.Contains("director") || q.Contains("tiến sĩ"))
            {
                return new ChatbotResponse
                {
                    Reply = "Phòng Thí nghiệm Robotics do GS. TS. Trần Quốc Hùng làm Trưởng phòng (Lab Director), cùng PGS. TS. Lê Phương Thảo (AI & Vision), TS. Nguyễn Minh Đức (Điều khiển & Nhúng), ThS. Hoàng Đình Vũ (AMR & ROS 2), ThS. Đỗ Yến Nhi (Soft Robotics) và KS. Phạm Quang Huy (Cơ khí chính xác). Lab quy tụ hơn 25 nghiên cứu sinh và kỹ sư tài năng.",
                    RelatedLinks = new List<string> { "/Members" },
                    Suggestions = new List<string> { "Xem danh sách toàn bộ thành viên", "Liên hệ hợp tác nghiên cứu", "Các đề tài đang tuyển sinh NCS" }
                };
            }

            // 6. Hỏi về Công bố khoa học / Nghiên cứu / IEEE
            if (q.Contains("bài báo") || q.Contains("công bố") || q.Contains("nghiên cứu") || q.Contains("ieee") || q.Contains("paper") || q.Contains("publication"))
            {
                return new ChatbotResponse
                {
                    Reply = "Lab đã công bố nhiều công trình trên các tạp chí và hội nghị hàng đầu thế giới về Robot như IEEE Transactions on Robotics (T-RO), IEEE ICRA 2025, IEEE IROS 2024, Soft Robotics Journal và Journal of Field Robotics. Các hướng mũi nhọn gồm: Adaptive Control, 6D-GraspNet, Quadruped Sim-to-Real, và Multi-Robot Collaborative SLAM.",
                    RelatedLinks = new List<string> { "/Research" },
                    Suggestions = new List<string> { "Xem toàn bộ 5 công bố tiêu biểu", "Bài báo IEEE T-RO về Adaptive Sliding Mode", "Bài báo ICRA về 6D-GraspNet" }
                };
            }

            // 7. Hỏi về Động cơ FOC / BLDC / Phần cứng
            if (q.Contains("foc") || q.Contains("bldc") || q.Contains("động cơ") || q.Contains("driver") || q.Contains("phần cứng") || q.Contains("stm32"))
            {
                return new ChatbotResponse
                {
                    Reply = "Kỹ thuật FOC (Field-Oriented Control) biến dòng 3 pha của động cơ không chổi than (BLDC) thành hai thành phần d-q độc lập, giúp điều khiển mô-men xoắn tức thời cực kỳ mượt mà. Lab đã tự phát triển các mạch điều khiển FOC Driver 48V/50A dùng chip STM32G4 và vi giao tiếp CAN-FD/EtherCAT.",
                    RelatedLinks = new List<string> { "/Knowledge/Detail/thiet-ke-dong-co-bldc-bo-dieu-khien-foc-cho-robot" },
                    Suggestions = new List<string> { "Đọc bài viết chi tiết FOC & BLDC", "Tải sơ đồ phần cứng mạch điều khiển", "Xem robot bốn chân Quadro-Titan" }
                };
            }

            // 8. Hỏi về Tài liệu hướng dẫn / SOP / Dataset
            if (q.Contains("tài liệu") || q.Contains("hướng dẫn") || q.Contains("sop") || q.Contains("download") || q.Contains("dataset") || q.Contains("cài đặt"))
            {
                return new ChatbotResponse
                {
                    Reply = "Khu vực Tài liệu Lab cung cấp: Sổ tay an toàn phòng thí nghiệm (SOP 2026), Hướng dẫn cài đặt ROS 2 & Isaac Sim, Sơ đồ tích hợp phần cứng EtherCAT, Bộ dữ liệu mở 3D Bin-Picking Benchmark (42 GB), và Tài liệu API tích hợp hệ thống xe tự hành.",
                    RelatedLinks = new List<string> { "/Docs" },
                    Suggestions = new List<string> { "Tải Sổ tay an toàn Lab (SOP)", "Xem hướng dẫn setup ROS 2 Humble", "Tải dataset 3D Point Cloud" }
                };
            }

            // Mặc định: Tra cứu tổng hợp
            var matchedArticles = data.GetKnowledgeArticles()
                .Where(a => a.Title.ToLower().Contains(q) || a.Summary.ToLower().Contains(q) || a.Tags.Any(t => t.ToLower().Contains(q)))
                .ToList();

            var matchedProjects = data.GetProjects()
                .Where(p => p.Title.ToLower().Contains(q) || p.ShortDescription.ToLower().Contains(q) || p.TechStack.ToLower().Contains(q))
                .ToList();

            if (matchedArticles.Any() || matchedProjects.Any())
            {
                var links = new List<string>();
                string text = $"Tìm thấy kết quả phù hợp cho từ khóa **\"{query}\"**:\n";
                if (matchedProjects.Any())
                {
                    text += $"- Dự án liên quan: **{matchedProjects.First().Title}**\n";
                    links.Add($"/Projects/Detail/{matchedProjects.First().Slug}");
                }
                if (matchedArticles.Any())
                {
                    text += $"- Bài viết kỹ thuật: **{matchedArticles.First().Title}**\n";
                    links.Add($"/Knowledge/Detail/{matchedArticles.First().Slug}");
                }

                return new ChatbotResponse
                {
                    Reply = text,
                    RelatedLinks = links,
                    Suggestions = new List<string> { "Xem thêm bài viết kỹ thuật", "Xem thêm dự án", "Hỏi câu khác" }
                };
            }

            return new ChatbotResponse
            {
                Reply = $"Tôi đã ghi nhận câu hỏi về: **{query}**. Bạn có thể tra cứu chi tiết hơn tại các danh mục chuyên đề của phòng thí nghiệm hoặc chọn một chủ đề gợi ý bên dưới:",
                Suggestions = new List<string> { "Kiến trúc ROS 2", "Thuật toán SLAM", "Động học Robot Manipulator", "Điều khiển FOC Động cơ BLDC", "Dự án xe tự hành AeroBot" }
            };
        }
    }
}

