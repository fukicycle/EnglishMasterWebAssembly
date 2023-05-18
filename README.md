# EnglishMaster (WebAssembly)
### Webアプリの練習として英語学習アプリを作成中です<br/>
EnglishMasterのWebAssemblyバージョンとして開発中<br/>
動作改善により初代サーバーサイドより高速動作可能
## 必要要件
* .NET7
* IIS or Apache (Web server)

## 注意
* Debugには以下のファイルの追加を推奨します
* appsettings.json
```
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "DB": "user id=[USER_NAME];password=[PASSWORD];server=[SERVER_HOST];initial catalog=[DB_NAME];trust server certificate=true;"
  }
}

```

## 現在のアプリ
* https://www.sato-home.mydns.jp/EnglishMasterClient

