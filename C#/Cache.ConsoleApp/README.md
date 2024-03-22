# Cache Kütüphaneleri

## Memory Cache
## Redis Cache
3 Kurulum yöntemi var 
  * Windows üzerinde Linux console aktif edip onun üzerinden kurma
  * Redis'in eski bir versiyonunu windows setup ile kurma
  * Docker üzerinden ayaða kaldýrma


### Windows üzerinde Linux console aktif edip onun üzerinden kurma
- Denetim masasý > Program ekle kaldýr > Windows özellikleri aç / kapat'girin
- Windows Subsystem for Linux seçeneðini seçin ve Ok ile kapatýn
- Microsoft Store üzerinden Ubuntu programýný kurun
- Ubunto programýný açtýktan sonra sýrayla aþaðýdaki kodlarý çalýþtýrýn

```bash
sudo apt update //bu kod ubuntu ile linux console kullanmamýz için ayar yapacak ve bir admin þifresi isteyecek. Herhangi bir þifre verebilirsiniz
sudo apt install redis-server //Bilgisayarýnýza redis server'ý kurmanýzý saðlayacak
redis-server //localhost:6379'da Redis'i ayaða kaldýrmanýzý saðlar
redis-cli ping //bu kod karþýlýðýnda PONG deðeri alýyorsanýz redisin çalýþtýðýný gösterir
```

### Redis'in eski bir versiyonunu windows setup ile kurma
- Aþaðýdaki GitHub reposundan Windows kurulumunu indirip kurabilirsiniz.

```bash
https://github.com/tporadowski/redis/releases 

//localhost:6379'da Redis'i ayaða kaldýrýr
redis-cli ping //bu kod karþýlýðýnda PONG deðeri alýyorsanýz redisin çalýþtýðýný gösterir
```

### Docker üzerinden ayaða kaldýrma
- Aþaðýdaki docker kodunu konsolda çalýþtýrmanýz yeterli

```bash
docker run --name some-redis -p 6379:6379 -d redis

//çalýþýp çalýþmadýðýný aþaðýdaki kod ile kontrol edebiliyorsunuz
docker exec -it some-redis redis-cli ping //bu kod karþýlýðýnda PONG deðeri alýyorsanýz redisin çalýþtýðýný gösterir
```

