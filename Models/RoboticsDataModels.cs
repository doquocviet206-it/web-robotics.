namespace web_robotics.Models
{
    public class LabMember
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty; // GS.TS, PGS.TS, NCS, Kỹ sư trưởng...
        public string Specialization { get; set; } = string.Empty;
        public string Bio { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string AvatarUrl { get; set; } = string.Empty;
        public List<string> Highlights { get; set; } = new();
    }

    public class ProjectItem
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty; // Autonomous Mobile Robot, Manipulator, Humanoid, Drone/UAV, AI Vision
        public string Status { get; set; } = string.Empty; // "Đã hoàn thành" hoặc "Đang nghiên cứu"
        public string ShortDescription { get; set; } = string.Empty;
        public string DetailedDescription { get; set; } = string.Empty;
        public string TechStack { get; set; } = string.Empty;
        public string Specifications { get; set; } = string.Empty;
        public string LeadResearcher { get; set; } = string.Empty;
        public int Year { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public bool IsCompletedProduct { get; set; }
        public List<string> KeyFeatures { get; set; } = new();
    }

    public class ResearchPublication
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Authors { get; set; } = string.Empty;
        public string JournalOrConference { get; set; } = string.Empty; // IEEE T-RO, ICRA, IROS, etc.
        public int Year { get; set; }
        public string Doi { get; set; } = string.Empty;
        public string Abstract { get; set; } = string.Empty;
        public string PaperUrl { get; set; } = string.Empty;
        public string CitationRank { get; set; } = "Q1 / Scopus / IEEE";
        public string Category { get; set; } = string.Empty;
    }

    public class KnowledgeArticle
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty; // ROS/ROS2, Điều khiển & Động lực học, Thị giác máy tính (CV), SLAM & Navigation, AI & Reinforcement Learning, Phần cứng & Cảm biến
        public string Level { get; set; } = "Cơ bản"; // Cơ bản, Nâng cao, Chuyên sâu
        public string Author { get; set; } = string.Empty;
        public string PublishedDate { get; set; } = string.Empty;
        public int ReadTimeMinutes { get; set; }
        public string Summary { get; set; } = string.Empty;
        public string ContentMarkdown { get; set; } = string.Empty;
        public List<string> Tags { get; set; } = new();
    }

    public class LabDocGuide
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty; // Tài liệu hướng dẫn, Lab Standard Operating Procedure (SOP), Hardware Setup, Dataset
        public string FileSize { get; set; } = string.Empty;
        public string Version { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string TargetAudience { get; set; } = string.Empty;
        public string DownloadOrViewUrl { get; set; } = string.Empty;
    }

    public class LabOverviewViewModel
    {
        public int TotalProjects { get; set; }
        public int CompletedProducts { get; set; }
        public int ActivePublications { get; set; }
        public List<ProjectItem> FeaturedProjects { get; set; } = new();
        public List<ResearchPublication> RecentPublications { get; set; } = new();
        public List<KnowledgeArticle> LatestArticles { get; set; } = new();
    }
}
