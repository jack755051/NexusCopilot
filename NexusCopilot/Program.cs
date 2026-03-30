using Microsoft.EntityFrameworkCore;
using NexusCopilot.Data;

namespace NexusCopilot;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // ==========================================
        // 1. 基礎設施註冊區 (Dependency Injection)
        // ==========================================

        // 讀取 appsettings.json 裡面的資料庫連線密碼
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

        // 將 AppDbContext 註冊進系統，並指示它使用 Npgsql (PostgreSQL 驅動)
        builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));
        builder.Services.AddAuthorization();
        builder.Services.AddOpenApi();

        // ==========================================
        // 2. 中介軟體管線配置區 (Middleware Pipeline)
        // ==========================================
        var app = builder.Build();

        if (app.Environment.IsDevelopment()) app.MapOpenApi();

        // 架構師建議：在 WSL 本地開發時先註解掉 HTTPS 強制跳轉，避免憑證干擾
        // app.UseHttpsRedirection();
        app.UseAuthorization();

        // ==========================================
        // 3. API 路由定義區 (Endpoints)
        // ==========================================
        app.MapGet("/api/status", () => new
        {
            Message = "NexusCopilot API 啟動成功！",
            DatabaseConfigured = true,
            Time = DateTime.UtcNow
        });


        // 啟動伺服器
        app.Run();
    }
}