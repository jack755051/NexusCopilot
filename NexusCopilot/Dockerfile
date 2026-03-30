# 階段 1: 運行環境 (Runtime)
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
WORKDIR /app
EXPOSE 5020

# 階段 2: 編譯環境 (SDK)
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# 1. 先複製專案檔並還原 (利用快取)
COPY ["NexusCopilot/NexusCopilot.csproj", "NexusCopilot/"]
RUN dotnet restore "NexusCopilot/NexusCopilot.csproj"

# 2. 複製剩餘的所有原始碼
COPY . .

# 3. ⚠️ 重要：切換進去專案資料夾再執行 build
WORKDIR "/src/NexusCopilot"
RUN dotnet build "NexusCopilot.csproj" -c $BUILD_CONFIGURATION -o /app/build

# 階段 3: 發布 (Publish)
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
# 這裡因為已經在 WORKDIR /src/NexusCopilot，可以直接發布
RUN dotnet publish "NexusCopilot.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# 階段 4: 最終鏡像 (Final)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# 確保對應到編譯出的實體檔名
ENTRYPOINT ["dotnet", "NexusCopilot.dll"]