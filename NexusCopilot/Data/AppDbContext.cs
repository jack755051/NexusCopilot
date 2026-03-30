using Microsoft.EntityFrameworkCore;

namespace NexusCopilot.Data;

// 架構師規範：繼承 DbContext，這是你的 C# 程式與 PostgreSQL 溝通的唯一橋樑
public class AppDbContext : DbContext
{
    // 建構子：接收外部傳入的連線設定 (例如連線字串)
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
}