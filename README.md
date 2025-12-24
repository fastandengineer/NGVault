# NGVault

NGVault, NGVault formatında şifrelenmiş dosyaları analiz etmek, doğrulamak ve işlemek için geliştirilmiş bir Windows (WinForms) masaüstü uygulamasıdır. Uygulama; sürükle-bırak desteği ve toplu dosya işlemleri gibi modern kullanım özellikleri sunar.

*Özellikler

🗂️ Sürükle & Bırak Dosya Desteği
Dosyaları veya klasörleri doğrudan uygulamaya sürükleyerek ekleyebilirsiniz.

📁 Toplu İşlem (Batch Processing)
Birden fazla dosya aynı anda işlenebilir.

🔐 NGVault Şifreleme Durumu Analizi
Şifreli
Şifresiz
Bilinmiyor

⚠️ Özel Hata Yönetimi
Yanlış parola
Bozuk veri
NGVault formatında olmayan dosyalar için özel exception yapıları kullanılır.

📊 Gerçek Zamanlı UI Güncelleme
INotifyPropertyChanged kullanılarak dosya durumu ve sonuçlar anlık olarak arayüze yansıtılır.

🎨 Görselsiz, Tamamen Native UI
Drag-drop alanı ve açıklamalar tamamen WinForms kontrolleriyle oluşturulmuştur (harici görsel yoktur).

*Kullanılan Teknolojiler
.NET Framework (WinForms)
C#
INotifyPropertyChanged
Custom Exception Handling
Drag & Drop API
BindingList / Data Binding

*Temel Bileşenler
FileItem
Dosya bilgisi, boyut, durum ve sonuç verilerini temsil eder.
NGVault*Exception
NGVault’a özel hata senaryoları.

*Kullanım
Dosyaları uygulamaya sürükleyin veya “Dosya Seç” / “Klasör Seç” seçeneklerini kullanın.
Dosyalar otomatik olarak analiz edilir ve sonuçlar listelenir.

*Amaç
NGVault; özellikle adli bilişim, veri güvenliği ve şifreli arşiv analizi gibi senaryolar için sade, hızlı ve güvenilir bir masaüstü araç sunmayı hedefler.

*Lisans
Bu proje kişisel / kurumsal kullanım için geliştirilmiştir.
Lisans bilgisi ihtiyaca göre düzenlenebilir.
