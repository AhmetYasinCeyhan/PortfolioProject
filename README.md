# Portfolyo Projesi

.NET Core MVC ile geliştirilmiş tam özellikli bir portfolyo ve blog web sitesi.

## Özellikler

- **Yönetim Paneli**: Proje ve blog yazılarınızı kolayca yönetin
- **Blog Sistemi**: SEO dostu URL yapısı ile etkili bir blog oluşturun
- **Portfolyo**: Projelerinizi kategorilere ayırıp sergileyebilirsiniz
- **İletişim Formu**: Ziyaretçilerin sizinle iletişime geçmesini sağlar
- **Kullanıcı Yönetimi**: Admin kullanıcıları için kimlik doğrulama ve yetkilendirme 

## Teknolojiler

- ASP.NET Core 9.0 MVC
- Entity Framework Core 9.0
- MSSQL Server
- Identity Framework
- Repository ve Unit of Work Pattern
- N-tier Architecture

## Kurulum

1. Projeyi klonlayın:
   ```
   git clone https://github.com/username/PortfolioProject.git
   ```

2. Veritabanını oluşturun:
   ```
   dotnet ef database update
   ```

3. Projeyi çalıştırın:
   ```
   dotnet run
   ```

## Proje Yapısı

- **PortfolioProject.Core**: Entity modelleri ve interface tanımları
- **PortfolioProject.Data**: DbContext, Repository ve UnitOfWork implementasyonları
- **PortfolioProject.Services**: İş mantığı servisleri
- **PortfolioProject.Web**: MVC web uygulaması

## Lisans

MIT