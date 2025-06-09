# 👨‍💼 Personel Tayin Takip Sistemi

Bu proje, personellerin tayin taleplerini oluşturabildiği, mevcut taleplerini görüntüleyebildiği ve profil bilgilerinin yer aldığı tam işlevsel bir web uygulamasıdır. Backend tarafı .NET Core ile katmanlı mimari kullanılarak geliştirilmiş, frontend ise React.js ile oluşturulmuştur.

## 🚀 Teknolojiler ve Altyapı

### Backend (.NET Core)

- Katmanlı Mimari:
  - **WebAPI**: API controller'ları içerir.
  - **Business**: İş mantığı burada yer alır.
  - **Core**: Ortak yapıların bulunduğu katman (AOP, loglama, cache vb.).
  - **DataAccess**: Entity Framework kullanılarak veri erişimi sağlanır.
  - **Entities**: Veri modelleri (entity'ler) burada tanımlanır.

- AOP (Aspect Oriented Programming):
  - `[PerformanceAspect(3)]`: Fonksiyon 3 saniyeden uzun sürerse loglanır.
  - `[LoggingAspect(typeof(FileLogger))]`: Tüm işlemler log.txt dosyasına loglanır.
  - `[CacheAspect]`: Veriler cache'e alınır, performans iyileştirmesi sağlar.
  - `[TransactionScopeAspect]`: İşlemler transaction kapsamına alınır.
  - `[ValidationAspect(typeof(UserValidator))]`: Parametre validasyonları yapılır.

- **Dependency Injection / IoC**: Autofac ile yapılandırılmıştır.
- **Loglama**: Merkezi loglama ile işlemler `log.txt` dosyasına yazılır.
- **JWT Token**: Giriş işlemleri token tabanlı güvenlik ile sağlanır.

### Frontend (React.js)

- Kullanıcı arayüzü modern React bileşenleriyle geliştirilmiştir.
- Sayfalar:
  - **Login**
  - **Register**
  - **Profile** (kullanıcının yaptığı tayin taleplerini gösterir)
  - **Yeni Tayin Talebi Oluşturma** sayfası
- React Router ile sayfalar arası yönlendirme yapılır.
- Axios kullanılarak API istekleri gerçekleştirilir.

### Veritabanı

- **PostgreSQL** kullanılmıştır.
- **pgAdmin** ile veritabanı yönetimi yapılabilir.

### Docker Desteği

Tüm bileşenler Docker üzerinden ayağa kaldırılabilir:
- React (port: 3000)
- WebAPI (.NET Core, port: 5000)
- PostgreSQL (default port: 5432, şifre: `toor`)
- pgAdmin (port: 5050)

---

## 📂 Proje Dizini

PersonelTayinTalep/
├── Backend/
│ ├── WebAPI/
│ ├── Business/
│ ├── DataAccess/
│ ├── Core/
│ └── Entities/
├── Frontend/
│ └── PersonelTayinTalepFrontend/
├── docker-compose.yml
├── README.md
└── log.txt


---

## ⚙️ Kurulum ve Çalıştırma

Aşağıdaki adımları takip ederek uygulamayı Docker üzerinden hızlıca çalıştırabilirsiniz:

### 1. Gereksinimler

- Docker ve Docker Compose yüklü olmalıdır.  
  - [Docker Kurulumu (Windows/macOS/Linux)](https://docs.docker.com/get-docker/)

### 2. `.env` Dosyası Oluşturun (Gerekirse)

Eğer yapılandırmalar için bir `.env` dosyası gerekiyorsa, aşağıdaki örneği kullanabilirsiniz:

```env
POSTGRES_USER=postgres
POSTGRES_PASSWORD=toor
POSTGRES_DB=personel_db
REACT_APP_API_URL=http://localhost:5000/api







*************************************************************************************************************
Docker Compose ile Uygulamayı Başlatın
Ana dizinde terminali açarak şu komutu çalıştırın:

bash
Kopyala
Düzenle
docker-compose up --build
Bu işlem tamamlandığında aşağıdaki servisler aktif olur:

React: http://localhost:3000

WebAPI (.NET Core): http://localhost:5000

pgAdmin: http://localhost:5050
pgAdmin giriş bilgileri admin@admin.com / admin olabilir (docker-compose’a bağlı).


 İlk Kayıt ve Giriş
React arayüzünde Register sayfasına giderek bir kullanıcı oluşturun.

Login sayfasından giriş yapın.

Profile sayfasında mevcut tayin taleplerinizi görebilir veya yenisini oluşturabilirsiniz.

Test ve Geliştirme
Swagger UI için WebAPI yayındayken: http://localhost:5000/swagger