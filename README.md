# 🌍 Traversal Core - Modern Seyahat Rezervasyon Sistemi
Traversal, kullanıcıların hayallerindeki rotaları keşfedebileceği, rezervasyon yapabileceği ve deneyimlerini paylaşabileceği uçtan uca bir seyahat platformudur. 
Proje, ASP.NET Core 9.0 kullanılarak katmanlı mimari (N-Tier Architecture) ve modern tasarım kalıplarıyla geliştirilmiştir.

## 🚀 Öne Çıkan Özellikler
### 🏠 Kullanıcı Arayüzü (Traversal Web)
-Dinamik Rota Listeleme: Popüler tur noktalarının fiyat, süre ve içerik bilgileriyle sunulması.<br>
-Gelişmiş Filtreleme: Tarih ve lokasyon bazlı tur arama motoru.<br>
-Rehber Kadromuz: Uzman rehberlerin bölgeleriyle birlikte tanıtıldığı dinamik ekip sayfası.<br>
-İletişim & Harita: Google Maps entegrasyonlu ve AJAX tabanlı iletişim formu.<br>
-Yorum Sistemi: Tur detaylarında kullanıcıların fotoğraflı ve tarihli deneyim paylaşımları.<br>

<img width="1914" height="905" alt="1" src="https://github.com/user-attachments/assets/1d0980d8-540e-42d0-9b2a-60e79a9bf1ed" />
<img width="1915" height="831" alt="2" src="https://github.com/user-attachments/assets/636b5885-677c-4071-b508-42fcfe5d9b4d" />
<img width="1914" height="827" alt="3" src="https://github.com/user-attachments/assets/806f6d82-5a46-4580-984b-677e69c50507" />
<img width="1916" height="681" alt="4" src="https://github.com/user-attachments/assets/72e5b42f-17ae-4fa9-aa17-de95382fbb4f" />
<img width="1916" height="833" alt="5" src="https://github.com/user-attachments/assets/2d0989c6-2249-413a-9c53-a03cbe85e55a" />
<img width="1918" height="911" alt="6" src="https://github.com/user-attachments/assets/b533c0e8-477b-4bd9-b97b-6c98bce773ba" />
<img width="1917" height="913" alt="7" src="https://github.com/user-attachments/assets/50865f2a-0bd4-4b9f-9dc6-546eb23007be" />
<img width="1916" height="832" alt="8" src="https://github.com/user-attachments/assets/3e9223d2-ce61-45a4-9640-f70d574ca91c" />
<img width="1917" height="905" alt="9" src="https://github.com/user-attachments/assets/0ec39793-68f7-45e6-b65d-d3877cc42bd0" />
<img width="1915" height="912" alt="10" src="https://github.com/user-attachments/assets/f5181283-7e42-4134-833f-9b3ff6ce0423" />
<img width="460" height="358" alt="11" src="https://github.com/user-attachments/assets/0c3c0347-1ebe-46de-982a-9cc188e41a06" />

## 🔑 Kullanıcı Kayıt ve Giriş İşlemleri
Sistemin güvenlik ve kullanıcı yönetim merkezi olan bu bölümde, modern kimlik doğrulama yöntemleri kullanılmıştır.

### 📝 Kullanıcı Kayıt Sayfası (Sign Up)
-Identity Altyapısı: Yeni kullanıcı kayıtları AppUser sınıfı üzerinden, Identity'nin sunduğu güvenli CreateAsync metodu ile gerçekleştirilir.<br>
-Validasyon Kontrolleri: Şifre uzunluğu, e-posta formatı ve kullanıcı adının benzersizliği gibi kriterler anlık olarak denetlenir.<br>
<img width="1914" height="911" alt="12" src="https://github.com/user-attachments/assets/463df289-172b-4977-87f3-8502ff049914" />

### 🔓 Kullanıcı Giriş Sayfası (Sign In)
-Güvenli Kimlik Doğrulama: Kullanıcılar, hashlenmiş şifreleri ile sistem tarafından doğrulanır. PasswordSignInAsync metodu ile oturum yönetimi (Cookie tabanlı) sağlanır.
<img width="1917" height="915" alt="13" src="https://github.com/user-attachments/assets/1b270790-4db8-4c6c-9d7a-7b2572b2623a" />

### 🔑 Şifremi Unuttum ve Güvenli Sıfırlama Süreci
-Kullanıcıların hesaplarına erişimi kaybetmeleri durumunda devreye giren profesyonel şifre yenileme akışıdır.<br>
-E-posta Doğrulama Linki: Kullanıcı "Şifremi Unuttum" talebi oluşturduğunda, sistem arka planda benzersiz bir Password Reset Token oluşturur ve bu token'ı içeren özel bir sıfırlama linkini kullanıcının kayıtlı e-posta adresine gönderir.<br>
-MailKit Entegrasyonu: Şifre yenileme mailleri, SMTP protokolü üzerinden güvenli bir şekilde iletilir.<br>
-Güvenli Güncelleme: Kullanıcı maildeki linke tıkladığında, token geçerliliği kontrol edilir ve yeni şifresini belirlemesi için özel bir forma yönlendirilir. Bu sayede hesap güvenliği en üst düzeyde korunur.<br>
<img width="1246" height="390" alt="36" src="https://github.com/user-attachments/assets/bf207ec3-643b-42df-9a4d-3bd59aa2c4d5" />
<img width="987" height="69" alt="37" src="https://github.com/user-attachments/assets/738fe760-9279-4040-8062-d655fa6dca48" />
<img width="1264" height="378" alt="38" src="https://github.com/user-attachments/assets/1ef5e595-29c7-4c64-b70d-047bea67b795" />

## 👤 Gezgin (Member) Dashboard Sayfası
-Kullanıcıların kendi verilerini takip ettiği, şık ve fonksiyonel yönetim merkezidir.

### ⚡ Teknik Detaylar:
-Sidebar Entegrasyonu: Kullanıcı dil değiştirdiğinde tüm yönetim paneli menüleri seçilen dile göre dinamik olarak güncellenir.<br>
-Veri Senkronizasyonu: Dashboard üzerindeki sayılar, kullanıcının veritabanındaki Reservations ve Comments tablolarındaki kendine ait verilerin anlık sayılmasıyla (Count) oluşur.<br>
-Rol Bazlı Yetkilendirme: Giriş yapan kullanıcının rolü Admin ise, Sidebar üzerinde ek yönetim butonu (Admin Paneline Geç) dinamik olarak aktifleşir ve görünür olur.<br>
<img width="1917" height="907" alt="14" src="https://github.com/user-attachments/assets/41e98ad4-32f9-4d3a-882a-a0925235b0c4" />

### 👤 Profil Güncelleme Sayfası
-Kullanıcının sistemdeki kişisel bilgilerini ve görselini özelleştirebildiği bölümdür.<br>
-Identity Veri Güncelleme: UserEditViewModel aracılığıyla kullanıcının adı, soyadı, e-posta ve şifre gibi bilgileri Identity altyapısı kullanılarak güvenli bir şekilde güncellenir.<br>
-Profil Fotoğrafı Yükleme: Kullanıcılar kendi fotoğraflarını sisteme yükleyebilir. Yüklenen görseller sunucu tarafında benzersiz isimlerle (Guid) saklanır ve veritabanındaki ImageUrl alanına kaydedilir.<br>
-Güvenli Şifre Yenileme: Şifre değişikliği yapılmak istendiğinde, Identity'nin şifreleme algoritmaları yeni şifreyi otomatik olarak hashleyerek güvenliği sağlar.<br>
<img width="1915" height="912" alt="15" src="https://github.com/user-attachments/assets/8859e7be-00f4-4cf9-a494-fb844dd16eba" />

### 📅 Aktif Rezervasyonlarım
-Kullanıcının yaptığı ve admin tarafından onaylanmış veya süreci devam eden güncel seyahat listesidir.<br>
-Filtrelenmiş Veri Akışı: Veritabanındaki tüm rezervasyonlar içinden sadece o an giriş yapmış olan kullanıcıya (Logged-in User) ait ve durumu "Aktif/Onaylandı" olan veriler listelenir.<br>
-Rota Detayları: Rezervasyon yapılan turun adı, kişi sayısı ve tarihi gibi bilgiler, Destination tablosuyla kurulan ilişki (Relationship) sayesinde anlık olarak çekilir.<br>
-Durum Takibi: Kullanıcı, seyahatinin onay durumunu bu tablo üzerinden şeffaf bir şekilde takip edebilir.<br>
<img width="1918" height="910" alt="16" src="https://github.com/user-attachments/assets/b3a09614-4393-4ac3-884d-205869ddf90f" />

### ⏳ Onay Bekleyen Rezervasyonlarım
-Kullanıcının yaptığı başvuruların admin tarafından incelenme sürecini takip ettiği alandır.<br>
-Süreç Şeffaflığı: Kullanıcı, admin onay verene kadar rezervasyonunu bu listede görür. Admin "Onayla" butonuna bastığı anda bu veri otomatik olarak Aktif Rezervasyonlar sekmesine taşınır.<br>
-İlişkisel Veri Gösterimi: Include yapısı sayesinde rezervasyonun hangi rotaya ait olduğu, fiyatı ve tarihi gibi detaylar tek bir satırda kullanıcıya sunulur.<br>
-Veri Tutarlılığı: Kullanıcı aynı tura mükerrer (tekrarlayan) hatalı kayıt açmasın diye bu listedeki veriler üzerinden kontrol mekanizmaları çalıştırılır.<br>
<img width="1917" height="910" alt="17" src="https://github.com/user-attachments/assets/3289114d-7ff1-4f2b-a554-7eafc8d46b49" />

### ➕ Yeni Rezervasyon Oluşturma
-Kullanıcıların hayallerindeki seyahati planladıkları dinamik başvuru ekranıdır.<br>
-Dinamik Rota Seçimi: Kullanıcılar, sistemdeki aktif destinasyonlar arasından seçim yapabilir. Bu liste arka planda DestinationManager üzerinden sadece aktif turları getirir.<br>
-Akıllı Kapasite Kontrolü: Rezervasyon sırasında seçilen kişi sayısı, veritabanındaki turun toplam kapasitesiyle uyumlu olacak şekilde (Validation) denetlenir.<br>
-Otomatik Durum Atama: Form gönderildiği anda rezervasyonun statüsü kod tarafında otomatik olarak "Onay Bekliyor" (Pending) olarak atanır ve adminin onay listesine düşer.<br>
<img width="1917" height="912" alt="18" src="https://github.com/user-attachments/assets/75fdd0e7-9024-44e9-8d7d-70e34cc37e4f" />


### 💬 Kullanıcının Yaptığı Yorumlar
-Gezginin tur deneyimleri sonrası paylaştığı fikirlerin yönetim merkezidir.<br>
-Kişisel Yorum Arşivi: Sadece o an oturum açmış olan kullanıcıya ait yorumlar listelenir. Kullanıcı, hangi rotaya ne zaman yorum yaptığını ve yorumunun içeriğini buradan takip edebilir.<br>
-Onay Durumu Takibi: Admin tarafından henüz onaylanmamış yorumlar "Beklemede" statüsüyle görünür. Onaylandığı anda tur detay sayfasında herkes tarafından görülebilir hale gelir.<br>
-CRUD Operasyonları: Kullanıcı, kendi yaptığı yorumları bu panel üzerinden silme veya güncelleme yetkisine sahiptir.<br>
<img width="1916" height="910" alt="19" src="https://github.com/user-attachments/assets/680e495a-a574-4a03-a469-9a43fe4f0390" />

### 🗺️ Sitedeki Aktif ve Son Rotalar
-Kullanıcı panelinden çıkmadan sistemdeki en yeni seyahat fırsatlarının sergilendiği alandır:
-Aktif Rotalar Listesi: Destination tablosundaki Status alanı "True" olan tüm turlar; fiyat, kapasite ve rehber bilgisiyle birlikte kullanıcıya sunulur.
-Son Rotalar (Recently Added): Veritabanına eklenen en son 4 veya 5 rota, "Yeni" etiketiyle listelenerek kullanıcının ilgisine sunulur. Bu işlem OrderByDescending(x => x.DestinationID).Take(5) mantığı ile veritabanı seviyesinde optimize edilmiştir.
-Hızlı Rezervasyon Köprüsü: Kullanıcı, bu listede ilgisini çeken bir rotayı gördüğünde doğrudan "Yeni Rezervasyon" sayfasına yönlenerek işlemini tamamlayabilir.
<img width="1918" height="905" alt="20" src="https://github.com/user-attachments/assets/6b6b4eb0-a959-48ca-a6d0-ff1c5ac059d4" />
<img width="1918" height="906" alt="21" src="https://github.com/user-attachments/assets/5ada0efc-d090-4272-9332-4af447bc98f1" />


## 🛠️ Admin Sayfaları (Yönetim & Kontrol Paneli)
-Bu kısım, misafirlerin web sitesine girdiğinde karşılaştığı "Vitrin" kısmıdır.<br>
-İstatistiksel Dashboard: Toplam rota sayısı, bekleyen rezervasyonlar ve kullanıcı sayıları anlık verilerle takip edilir.<br>
-Yorum Yönetimi: Gelen tüm kullanıcı yorumları burada listelenir. Admin, uygunsuz içerikleri silebilir veya yorumları yayına alabilir.<br>
-Dinamik Rota Yönetimi: Yeni tur rotaları ekleme, fiyat güncelleme ve kapasite kontrolü bu panelden yapılır.<br>
<img width="1915" height="912" alt="22" src="https://github.com/user-attachments/assets/ac501c8f-17b9-437e-8a9b-1f3b65e906f7" />
<img width="1902" height="633" alt="23" src="https://github.com/user-attachments/assets/f3687214-7a2f-40f5-9c22-3730c91e2eb3" />

### 💬 Tüm Kullanıcı Yorumları Yönetimi
-Admin panelinin bu bölümünde, site genelinde yapılmış olan tüm kullanıcı yorumları merkezi bir tabloda listelenir.<br>
-İlişkisel Veri Gösterimi: Yorumu yapan kullanıcının adı ve yorumun yapıldığı rota bilgisi (Destination), Entity Framework Include yapısı sayesinde tek bir satırda birleştirilerek gösterilir.<br>
Tam Kontrol: Admin, bu ekran üzerinden gelen tüm geri bildirimleri inceleyebilir, uygunsuz içerikleri silecek veya onaylayacak yetkiye sahiptir.<br>
<img width="1915" height="905" alt="24" src="https://github.com/user-attachments/assets/e7f5a092-aa72-47a0-ab5a-4f77c746b63e" />

### 📍 Rota (Destinasyon) Listesi ve Kontrolü
-Sistemdeki tüm tur rotalarının admin tarafındaki ana kumanda merkezidir.<br>
-Detaylı Rota Takibi: Şehir ismi, tur fiyatı, kişi kapasitesi ve turun aktiflik durumu gibi tüm kritik veriler bu tabloda sergilenir.<br>
-Hızlı Aksiyonlar: Admin, mevcut rotaları güncelleyebilir, silebilir veya yeni bir rota eklemek için bu listeyi referans alarak sistemdeki boşlukları analiz edebilir.<br>
-Dinamik Veri Akışı: Burada yapılan her güncelleme, ana sayfadaki "Popüler Rotalar" kısmına anlık olarak yansır.<br>
<img width="1917" height="912" alt="25" src="https://github.com/user-attachments/assets/dd5fb0ce-9a8b-42b5-8475-fc838e6a3351" />

### 👥 Kullanıcı (Üye) Yönetim Listesi
-Sisteme kayıt olan tüm misafirlerin kontrol edildiği ve yönetildiği merkezdir.<br>
-Identity Altyapısı: Tüm kullanıcı verileri ASP.NET Core Identity tablosundan çekilerek; isim, soyisim, kullanıcı adı ve e-posta gibi detaylarla listelenir.<br>
-Rol ve Durum Takibi: Admin, bu liste üzerinden hangi kullanıcının aktif olduğunu görebilir ve üye bazlı yetkilendirme işlemlerini bu veriler ışığında planlayabilir.<br<
-Hızlı Erişim: Binlerce kullanıcı olsa dahi, veritabanı seviyesinde optimize edilmiş sorgularla üyeler hızlıca listelenir.<br>
-Kullanıcının yapmış olduğu yorumlar ve gittiği tur listesine erişim mümkündür.<br>
<img width="1909" height="905" alt="26" src="https://github.com/user-attachments/assets/6ec129f1-dca2-455d-b18e-6f19120e8fd9" />

### ✉️ "Bize Ulaşın" Mesaj Yönetimi
-Ziyaretçilerin iletişim formu aracılığıyla gönderdiği tüm mesajların admin panelindeki karşılığıdır.<br>
-Mesaj Arşivi: Gönderen kişinin adı, e-posta adresi, mesajın konusu ve içeriği kronolojik olarak sıralanır.<br>
-Geri Bildirim Kontrolü: Admin, gelen talepleri, şikayetleri veya iş birliği mesajlarını tek bir panelden okuyabilir ve gerekli aksiyonları (cevaplama, silme, arşivleme) alabilir.<br>
-AJAX Senkronizasyonu: Site tarafında AJAX ile gönderilen mesajlar, anında bu listeye düşer ve sayfa yenilemeye gerek kalmadan veritabanı bütünlüğü sağlanır.<br>
<img width="1917" height="912" alt="27" src="https://github.com/user-attachments/assets/310895a4-8bda-4dd2-ab89-50e32d46218e" />
<img width="1915" height="913" alt="28" src="https://github.com/user-attachments/assets/ab324ecc-3766-404b-8c13-e06aea558837" />

### 🎖️ Rehber Yönetimi ve Uzman Kadro Listesi
-Sistemin dinamik yapısını sağlayan rehberlerin admin tarafındaki yönetim merkezidir.<br>
-Aktif/Pasif Durum Yönetimi: Admin, rehberlerin sistemdeki durumunu (Aktif/Pasif) tek tıkla güncelleyebilir. Bu durum değişikliği, ana sayfadaki "Rehberlerimiz" kısmına anlık olarak yansır.<br>
-Görsel ve Bilgi Güncelleme: Rehberlerin fotoğrafları, uzmanlık alanları ve sosyal medya linkleri bu panel üzerinden kontrol edilir.<br>
-Veri Bütünlüğü: Rehber tablosu, destinasyonlar ile ilişkili olduğu için hangi turun hangi rehberde olduğu bilgisi bu veri yapısı üzerinden yönetilir.<br>
<img width="1916" height="913" alt="29" src="https://github.com/user-attachments/assets/59913bc3-3c1e-4b38-a77c-ef5a048cf284" />

### 📊 Excel Raporlama ve Veri Aktarımı
-Projenin profesyonel raporlama kabiliyetini gösteren, verilerin dış dünyaya açıldığı bölümdür.<br>
-Statik ve Dinamik Excel Raporları: Sistemdeki veriler (Rotalar, Kullanıcılar, Rezervasyonlar) ClosedXML veya EPPlus kütüphaneleri kullanılarak tek tıkla profesyonel bir Excel dosyasına dönüştürülür.<br>
-Anlık Veri Çıktısı: Veritabanındaki güncel tablo verileri, sütun başlıklarıyla birlikte düzenli bir şekilde raporlanır. Bu özellik, yöneticilerin sistem dışı analizler yapmasına olanak tanır.<br>
-Hızlı İndirme: Dosya oluşturma işlemi sunucu tarafında (Server-side) hızlıca tamamlanarak kullanıcıya bir FileStreamResult olarak döndürülür.<br>
<img width="1912" height="907" alt="30" src="https://github.com/user-attachments/assets/181bd9c1-6dbc-4213-bb5b-c1c89cf39a2f" />

### 📧 Yeni Mail Gönderim Merkezi
-Adminin sistem üzerinden kullanıcılara veya harici adreslere doğrudan e-posta gönderebildiği modüldür.<br>
-SMTP Entegrasyonu: Arka planda MailKit kütüphanesi kullanılarak Google (Gmail) veya özel SMTP sunucuları üzerinden güvenli e-posta gönderimi sağlanır.<br>
-Dinamik İçerik: Alıcı adresi, konu başlığı ve mesaj içeriği admin tarafından belirlenerek profesyonel bir iletişim kanalı oluşturulur.<br>
-İşlevsellik: Kampanyalar, tur bilgilendirmeleri veya bireysel geri dönüşler için admin panelinden ayrılmadan hızlıca aksiyon alınmasına imkan tanır.<br>
<img width="1914" height="910" alt="31" src="https://github.com/user-attachments/assets/ec330da1-a48e-4317-a878-5e4e6663457d" />

### 🤝 Referans ve İş Ortakları Yönetimi
-Web sitesinin güven vitrini olan "Mutlu Müşteriler ve Referanslar" bölümünün dinamik olarak yönetildiği alandır.<br>
-Kurumsal Görünüm: Sisteme yeni iş ortakları veya referans logoları eklendiğinde, ana sayfadaki slider yapısı bu verileri otomatik olarak çeker ve sergiler.<br>
-Görsel Yönetimi: Referansların isimleri ve logoları bu panel üzerinden güncellenebilir, aktif veya pasif duruma getirilebilir.<br>
-Marka Algısı: Admin, bu liste sayesinde sitenin profesyonel görünümünü ve sosyal kanıt (social proof) öğelerini dilediği zaman güncel tutabilir.<br>
<img width="1915" height="907" alt="32" src="https://github.com/user-attachments/assets/6f97355f-2147-419d-9a90-56765b6ad6d5" />

### 📅 Tüm Rezervasyonların Yönetimi ve Takibi
-Sistem üzerinden gerçekleştirilen tüm tur başvurularının merkezi olarak izlendiği ve durumlarının güncellendiği bölümdür.<br>
-Onay Mekanizması: Gelen rezervasyonlar "Onay Bekliyor", "Onaylandı" veya "İptal Edildi" gibi statülerle yönetilir. Admin, bu panel üzerinden tek tıkla rezervasyonun durumunu güncelleyebilir.<br>
-İlişkisel Veri Gösterimi: Rezervasyon tablosu; AppUser (Müşteri) ve Destination (Rota) tablolarıyla ilişkilidir. Bu sayede hangi müşterinin hangi tur için kaç kişilik yer ayırttığı anlık olarak listelenir.<br>
-Kapasite Kontrolü: Yapılan her yeni rezervasyon, ilgili rotanın kontenjanından otomatik olarak düşülür veya eklenir, böylece sistem genelinde veri tutarlılığı sağlanır.<br>
<img width="1913" height="908" alt="33" src="https://github.com/user-attachments/assets/a8774314-20e3-47fe-b274-656625ed17be" />

### 🔐 Admin Şifre Değiştirme ve Güvenlik Yönetimi
-Yöneticinin kendi hesap güvenliğini sağlaması için tasarlanmış, Identity altyapısını kullanan özel bir modüldür.<br>
-Identity Password Validator: Yeni şifre belirlenirken sistem, belirlenen güvenlik kriterlerini (Büyük harf, küçük harf, rakam ve sembol zorunluluğu) otomatik olarak denetler.<br>
-Hashleme Teknolojisi: Şifreler veritabanına asla düz metin olarak kaydedilmez; Identity'nin PasswordHasher sınıfı ile geri döndürülemez şekilde hash'lenerek saklanır.<br>
-Anlık Doğrulama: Mevcut şifrenin doğruluğu kontrol edildikten sonra yeni şifre ataması yapılır, böylece hesap güvenliği en üst düzeyde tutulur.<br>
<img width="1913" height="910" alt="34" src="https://github.com/user-attachments/assets/52ff9f7b-3328-476a-8708-bdffd8cd1193" />

### 🔑 Rol Yönetimi ve Yetkilendirme (RBAC)
-Sistemdeki tüm kullanıcıların yetki seviyelerinin belirlendiği, tam denetimli yönetim merkezidir.<br>
-Dinamik Rol Atama: Admin, sistemdeki herhangi bir kullanıcıyı seçerek ona "Admin", "Rehber" veya "Üye" gibi roller tanımlayabilir. Bu işlem arka planda UserManager.AddToRoleAsync ve RemoveFromRoleAsync metotları ile yönetilir.<br>
-Rol Ekleme ve Silme: Sisteme yeni bir yetki seviyesi (Örn: Moderatör) eklemek veya mevcut bir rolü sistemden kaldırmak bu panel üzerinden gerçekleştirilir.<br>
-Güvenlik Katmanı: Yapılan rol değişiklikleri, kullanıcının sisteme bir sonraki girişinde (veya Cookie güncellendiğinde) anında aktif olur. Böylece yetkisiz kişilerin kritik alanlara erişimi dinamik olarak engellenir.<br>
<img width="1916" height="909" alt="35" src="https://github.com/user-attachments/assets/2275928b-ee85-43f8-8597-c24827eb6ace" />






