# Cache Kütüphaneleri

## Memory Cache
## Redis
3 Kurulum yöntemi var 
  * Windows üzerinde Linux console aktif edip onun üzerinden kurma
  * Redis'in eski bir versiyonunu windows setup ile kurma
  * Docker üzerinden ayağa kaldırma


### Windows üzerinde Linux console aktif edip onun üzerinden kurma
- Denetim masası > Program ekle kaldır > Windows özellikleri aç / kapat'girin
- Windows Subsystem for Linux seçeneğini seçin ve Ok ile kapatın
- Microsoft Store üzerinden Ubuntu programını kurun
- Ubuntu programını açtıktan sonra sırayla aşağıdaki kodları çalıştırın

```bash
sudo apt update //bu kod ubuntu ile linux console kullanmamız için ayar yapacak
                //bir admin şifresi isteyecek. Herhangi bir şifre verebilirsiniz
sudo apt install redis-server //Bilgisayarınıza redis server'ı kurmanızı sağlayacak
redis-server //localhost:6379'da Redis'i ayağa kaldırmanızı sağlar
redis-cli ping //bu kod karşılığında PONG değeri alıyorsanız redisin çalıştığını gösterir
```

### Redis'in eski bir versiyonunu windows setup ile kurma
- Aşağıdaki GitHub reposundan Windows kurulumunu indirip kurabilirsiniz.

```bash
https://github.com/tporadowski/redis/releases 

//localhost:6379'da Redis'i ayağa kaldırır
redis-cli ping //bu kod karşılığında PONG değeri alıyorsanız redisin çalıştığını gösterir
```

### Docker üzerinden ayağa kaldırma
- Aşağıdaki docker kodunu konsolda çalıştırmanız yeterli

```bash
docker run --name some-redis -p 6379:6379 -d redis

//çalışıp çalışmadığını aşağıdaki kod ile kontrol edebiliyorsunuz
docker exec -it some-redis redis-cli ping //bu kod karşılığında PONG değeri alıyorsanız redisin çalıştığını gösterir
```

