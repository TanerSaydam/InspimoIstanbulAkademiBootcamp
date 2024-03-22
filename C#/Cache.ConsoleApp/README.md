# Cache K�t�phaneleri

## Memory Cache
## Redis Cache
3 Kurulum y�ntemi var 
  * Windows �zerinde Linux console aktif edip onun �zerinden kurma
  * Redis'in eski bir versiyonunu windows setup ile kurma
  * Docker �zerinden aya�a kald�rma


### Windows �zerinde Linux console aktif edip onun �zerinden kurma
- Denetim masas� > Program ekle kald�r > Windows �zellikleri a� / kapat'girin
- Windows Subsystem for Linux se�ene�ini se�in ve Ok ile kapat�n
- Microsoft Store �zerinden Ubuntu program�n� kurun
- Ubunto program�n� a�t�ktan sonra s�rayla a�a��daki kodlar� �al��t�r�n

```bash
sudo apt update //bu kod ubuntu ile linux console kullanmam�z i�in ayar yapacak ve bir admin �ifresi isteyecek. Herhangi bir �ifre verebilirsiniz
sudo apt install redis-server //Bilgisayar�n�za redis server'� kurman�z� sa�layacak
redis-server //localhost:6379'da Redis'i aya�a kald�rman�z� sa�lar
redis-cli ping //bu kod kar��l���nda PONG de�eri al�yorsan�z redisin �al��t���n� g�sterir
```

### Redis'in eski bir versiyonunu windows setup ile kurma
- A�a��daki GitHub reposundan Windows kurulumunu indirip kurabilirsiniz.

```bash
https://github.com/tporadowski/redis/releases 

//localhost:6379'da Redis'i aya�a kald�r�r
redis-cli ping //bu kod kar��l���nda PONG de�eri al�yorsan�z redisin �al��t���n� g�sterir
```

### Docker �zerinden aya�a kald�rma
- A�a��daki docker kodunu konsolda �al��t�rman�z yeterli

```bash
docker run --name some-redis -p 6379:6379 -d redis

//�al���p �al��mad���n� a�a��daki kod ile kontrol edebiliyorsunuz
docker exec -it some-redis redis-cli ping //bu kod kar��l���nda PONG de�eri al�yorsan�z redisin �al��t���n� g�sterir
```

