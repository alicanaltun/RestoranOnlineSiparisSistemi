
# Restoran Online Sipariş Sistemi

Bu proje, bir restoran müşterilerinin online olarak sipariş verebilmesi ve takibini yapabilmesi için geliştirilmiş **C#** dilinde yazılmış bir masaüstü uygulamasıdır. Projede UI ve UX için Jakob Nielsen'ın kullanılabilirlik heuristikleri göz önünde bulundurulmuştur.

## Örnek Kullanım Senaryosu ve Videolu Tanıtım

[Proje Tanıtım Videosunu İzlemek için Tıklayınız](https://drive.google.com/file/d/17mHfomrHlraIT6rAcORtBslB_528agrn/view?usp=sharing)


## Özellikler

### Kullanıcı Özellikleri

- Kullanıcı kaydı yapabilme ve giriş işlemi.
- Kategorize edilmiş restoran menüsünü görüntüleme ve arama (filreleme) işlemleri.
- Ürünleri sepete ekleme, çıkarma ve azaltıp-artırma işlemleri.
- Sepeti onaylayıp sipariş verme işlemi.
- Ödeme işlemleri.
- İsteğe bağlı olarak sipariş notu ekleme.
- Sipariş geçmişini görüntüleme ve detaylarını inceleyebilme.
- Siparişin güncel durumunu görüntüleyebilme.
- Kişisel bilgileri güncelleyebilme.
- Şifre değiştirme işlemleri.

## Kurulum

1. Projeyi **Visual Studio**’da açın.
2. **Nuget Paket Yöneticisi**'nden `Bunifu.UI.WinForms` kütüphanesini projeye ekleyin.
3. `fastburger.bak` dosyasını **Microsoft SQL Server** veritabanında çalıştırın.
4. SQL Server bağlantı linkininizi `RestaurantApp /LoginForm.cs` ve `RestaurantApp /CustomerForm.cs` sınıfından düzenleyin.
5. Veritabanı bağlantısını kontrol edin
6. Programı **Visual Studio**’da çalıştırın.
7. Eğer veritabanında ürün yoksa ürün eklerken: 
    - Ürün fotoğrafını `RestaurantApp\Resources\images` içerisindeki bir kategori dizinine kopyalayın.
    - Veritabanına ürünü eklerken `urunler` tablosundaki `urun_img` satırına ürün fotoğrafının dizin yolunu ekleyin. Örneğin: `images\Menuler\Avantaj_Menüsü.png` 

## Kullanım

1. Kullanıcı olarak giriş yapın veya yeni bir hesap oluşturun.
2. Menüden ürünleri seçerek sepete ekleyin.
3. Ödeme işlemini tamamlayarak sipariş verin.
4. Sipariş durumunu takip edin.

## Katkıda Bulunma

Çalışan ve yönetici sayfaları geliştirme aşamasındadır. Katkıda bulunmak isterseniz, lütfen bir **pull request** gönderin veya bir **issue** açın.

## Lisans

Bu proje şu an için lisanssızdır.

## Bilgilendirme (Disclaimer)
Bu proje hiçbir ticari amaç güdülmeden kendimi geliştirmek amacıyla oluşturduğum örnek bir projedir. Video içerisinde kullanılan görseller telif haklarına tabi olduğundan paylaşılmamıştır.

This project is a sample project created for self-improvement without any commercial intent. The images used in the video are subject to copyright and have not been shared.
