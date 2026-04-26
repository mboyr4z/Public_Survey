<div align="center">

<img src="https://img.shields.io/badge/.NET-8.0-512BD4?style=for-the-badge&logo=dotnet&logoColor=white"/>
<img src="https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=csharp&logoColor=white"/>
<img src="https://img.shields.io/badge/Entity_Framework_Core-8.0-512BD4?style=for-the-badge&logo=nuget&logoColor=white"/>
<img src="https://img.shields.io/badge/SQLite-003B57?style=for-the-badge&logo=sqlite&logoColor=white"/>
<img src="https://img.shields.io/badge/Bootstrap-5-7952B3?style=for-the-badge&logo=bootstrap&logoColor=white"/>
<img src="https://img.shields.io/badge/JWT-000000?style=for-the-badge&logo=jsonwebtokens&logoColor=white"/>

<br/><br/>

# 📊 PublicSurvey

**Yazarların, şirketlerin ve yorumcuların bir araya geldiği sosyal anket platformu — gönderi paylaş, kullanıcıları takip et, beğen, yorum yap ve mesajlaş.**

</div>

---

## 🚀 Özellikler

| Özellik | Açıklama |
|---|---|
| 👤 **Rol Tabanlı Erişim** | Author, Boss, Commentator ve Admin rolleriyle ayrı kullanıcı akışları |
| 📝 **Gönderi Sistemi** | Global veya yerel gönderi oluşturma, beğenme ve yorum yapma |
| 💬 **Doğrudan Mesajlaşma** | Kullanıcılar arası anlık chat sistemi |
| 🔍 **Kullanıcı Arama** | AJAX tabanlı canlı isim/soyisim araması |
| 🏢 **Şirket Yönetimi** | Boss kullanıcılar şirket kurabilir, yazarlar şirkete katılabilir |
| ✅ **Üyelik Onayı** | Admin, kullanıcı üyeliklerini aktif etmeden önce onaylar |
| 🛡️ **Admin Paneli** | Kullanıcı ve rol yönetimi için tam yetkili yönetim ekranı |
| 🔐 **JWT Kimlik Doğrulama** | REST API uç noktaları için JWT Bearer token güvenliği |

---

## 🛠️ Kullanılan Teknolojiler

### Backend
- **ASP.NET Core MVC** (.NET 8) — Razor Views ile sunucu taraflı rendering
- **Entity Framework Core 8** — Code-First yaklaşımıyla veritabanı yönetimi
- **ASP.NET Core Identity** — Kimlik doğrulama ve rol tabanlı yetkilendirme (RBAC)
- **JWT Bearer Token** — API güvenliği
- **AutoMapper** — Entity ↔ DTO dönüşümleri

### Frontend
- **Bootstrap 5** + **Font Awesome 6** — Duyarlı ve modern arayüz
- **jQuery** + **AJAX** — Sayfa yenilemeden canlı kullanıcı arama

### Mimari
- **N-Tier Katmanlı Mimari** (Presentation → Services → Repositories → Entities)
- **Repository Pattern** — Veri erişim katmanı soyutlaması
- **Unit of Work Pattern** — Tutarlı transaction yönetimi
- **View Components** — Modüler ve yeniden kullanılabilir UI bileşenleri

---

## 🏗️ Proje Yapısı

```
PublicSurvey/
├── Survey/           # Ana uygulama — controller'lar, view'lar, program.cs
├── Services/         # İş mantığı katmanı
├── Repositories/     # Veri erişim katmanı (EF Core)
├── Entities/         # Domain modelleri ve DTO'lar
├── Presentation/     # API controller'ları
└── Benimkiler/       # Paylaşılan yardımcı araçlar ve enum'lar
```

---

## 👥 Kullanıcı Rolleri

```
SurveyUser (temel sınıf)
├── Author       → Gönderi oluşturur ve yayınlar
├── Boss         → Şirket yönetir, gönderi paylaşır
├── Commentator  → Gönderileri okur ve yorum yapar
└── Admin        → Platformun tüm yönetiminden sorumludur
```

---

## ⚙️ Kurulum ve Çalıştırma

### Gereksinimler
- [.NET 8 SDK](https://dotnet.microsoft.com/download)

### Çalıştırma

```bash
git clone https://github.com/mboyr4z/Public_Survey.git
cd Public_Survey/Survey
dotnet run
```

Tarayıcında `https://localhost:5001` adresini aç.

---

## 📸 Ekran Görüntüleri

> _(Buraya ekran görüntüleri eklenecek)_

---

<div align="center">

ASP.NET Core ile ❤️ geliştirildi

</div>
