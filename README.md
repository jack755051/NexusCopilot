# NexusCopilot

NexusCopilot 是一個現代化的企業級 AI 智能體協作工作區。本專案採用前後端分離架構，結合了強大的關聯式與向量資料庫能力，旨在提供流暢的 RAG (檢索增強生成) 體驗與即時互動。

## 🛠 核心技術堆疊 (Tech Stack)

* **後端 (Backend):** C# / .NET 10 Web API, Minimal API
* **前端 (Frontend):** Angular (Planning)
* **資料庫 (Database):** PostgreSQL + `pgvector` (支援 AI 向量搜尋)
* **ORM 架構:** Entity Framework Core (Code-First)
* **基礎設施 (Infrastructure):** Docker & Docker Compose
* 
## 🛠 開發進度 (Roadmap)

- [x] 初始化 .NET 10 Web API 骨架
- [x] Docker 基礎設施配置 (PostgreSQL + pgvector)
- [ ] 建立 EF Core 資料庫實體與 Migration
- [ ] 實作基礎 CRUD 與健康檢查 API
- [ ] 整合 Angular 前端介面
- [ ] RAG 向量搜尋功能開發

## 快速啟動 (Quick Start)

### 1. 啟動資料庫基礎設施
請確保已安裝 Docker，並在專案根目錄執行：
```bash
docker compose up -d
```

