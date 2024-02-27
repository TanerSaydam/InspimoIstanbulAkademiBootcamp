î
PC:\InspimoIstanbulAkademiBootcamp\Projeler\PersonelApp\PersonelServer\Program.cs
var 
builder 
= 
WebApplication 
. 
CreateBuilder *
(* +
args+ /
)/ 0
;0 1
builder		 
.		 
Services		 
.		 
AddDefaultCors		 
(		  
)		  !
;		! "
builder 
. 
Services 
. 
AddDbContext 
<  
ApplicationDbContext 2
>2 3
(3 4
options4 ;
=>< >
{ 
options 
. 
UseSqlServer 
( 
builder  
.  !
Configuration! .
.. /
GetConnectionString/ B
(B C
$strC N
)N O
)O P
;P Q
} 
) 
; 
builder 
. 
Services 
. 
AddControllers 
(  
)  !
;! "
builder 
. 
Services 
. #
AddEndpointsApiExplorer (
(( )
)) *
;* +
builder 
. 
Services 
. 
AddSwaggerGen 
( 
)  
;  !
var 
app 
= 	
builder
 
. 
Build 
( 
) 
; 
if 
( 
app 
. 
Environment 
. 
IsDevelopment !
(! "
)" #
)# $
{   
app!! 
.!! 

UseSwagger!! 
(!! 
)!! 
;!! 
app"" 
."" 
UseSwaggerUI"" 
("" 
)"" 
;"" 
}## 
app%% 
.%% 
UseCors%% 
(%% 
)%% 
;%% 
app'' 
.'' 
UseStaticFiles'' 
('' 
)'' 
;'' 
app)) 
.)) 
UseHttpsRedirection)) 
()) 
))) 
;)) 
app++ 
.++ 
UseAuthorization++ 
(++ 
)++ 
;++ 
app-- 
.-- 
MapControllers-- 
(-- 
)-- 
;-- 
app// 
.// 
Run// 
(// 
)// 	
;//	 
ô	
_C:\InspimoIstanbulAkademiBootcamp\Projeler\PersonelApp\PersonelServer\DTOs\CreatePersonelDto.cs
	namespace 	
PersonelServer
 
. 
DTOs 
; 
public 
sealed 
record 
CreatePersonelDto &
(& '
string 

	FirstName 
, 
string 

LastName 
, 
string 

	StartDate 
, 
decimal 
Salary 
, 
string 

PhoneNumber 
, 
string		 

Email		 
,		 
string

 

City

 
,

 
string 

District 
, 
string 

FullAddress 
, 
	IFormFile 
? 

AvatarFile 
, 
	IFormFile 
? 
CVFile 
, 
List 
< 	
	IFormFile	 
> 
? 
CertificateFiles %
,% &
	IFormFile 
? 
DiplomaFile 
, 
	IFormFile 
? 
HealthReportFile 
)  
;  !¬
hC:\InspimoIstanbulAkademiBootcamp\Projeler\PersonelApp\PersonelServer\Controllers\PersonelsController.cs
	namespace 	
PersonelServer
 
. 
Controllers $
;$ %
[ 
Route 
( 
$str "
)" #
]# $
[ 
ApiController 
] 
public 
sealed 
class 
PersonelsController '
:( )
ControllerBase* 8
{		 
[

 
HttpPost

 
]

 
public 

IActionResult 
Create 
(  
[  !
FromForm! )
]) *
CreatePersonelDto+ <
request= D
)D E
{ 
string 
? 
avatarFileName 
=  
null! %
;% &
string 
? 

cvFileName 
= 
null !
;! "
string 
? 
diplomaFileName 
=  !
null" &
;& '
List 
< 
string 
> 
?  
certificateFileNames *
=+ ,
null- 1
;1 2
string 
? 
healthReportFile  
=! "
null# '
;' (
if 

( 
request 
. 

AvatarFile 
is !
not" %
null& *
)* +
{ 	
avatarFileName 
= 
FileService (
.( )
FileSaveToServer) 9
(9 :
request: A
.A B

AvatarFileB L
,L M
$strN `
)` a
;a b
} 	
if 

( 
request 
. 
CVFile 
is 
not !
null" &
)& '
{ 	

cvFileName 
= 
FileService $
.$ %
FileSaveToServer% 5
(5 6
request6 =
.= >
CVFile> D
,D E
$strF T
)T U
;U V
} 	
if 

( 
request 
. 
DiplomaFile 
is  "
not# &
null' +
)+ ,
{ 	
diplomaFileName 
= 
FileService )
.) *
FileSaveToServer* :
(: ;
request; B
.B C
DiplomaFileC N
,N O
$strP c
)c d
;d e
}   	
if"" 

("" 
request"" 
."" 
HealthReportFile"" $
is""% '
not""( +
null"", 0
)""0 1
{## 	
healthReportFile$$ 
=$$ 
FileService$$ *
.$$* +
FileSaveToServer$$+ ;
($$; <
request$$< C
.$$C D
HealthReportFile$$D T
,$$T U
$str$$V o
)$$o p
;$$p q
}%% 	
if(( 

((( 
request(( 
.(( 
CertificateFiles(( $
is((% '
not((( +
null((, 0
)((0 1
{)) 	 
certificateFileNames**  
=**! "
new**# &
(**& '
)**' (
;**( )
foreach++ 
(++ 
var++ 
item++ 
in++  
request++! (
.++( )
CertificateFiles++) 9
)++9 :
{,,  
certificateFileNames-- $
.--$ %
Add--% (
(--( )
FileService--) 4
.--4 5
FileSaveToServer--5 E
(--E F
item--F J
,--J K
$str--L c
)--c d
)--d e
;--e f
}.. 
}// 	
return22 
Ok22 
(22 
)22 
;22 
}33 
}55 ß
eC:\InspimoIstanbulAkademiBootcamp\Projeler\PersonelApp\PersonelServer\Context\ApplicationDbContext.cs
	namespace 	
PersonelServer
 
. 
Context  
;  !
public 
sealed 
class  
ApplicationDbContext (
:) *
	DbContext+ 4
{ 
public 
 
ApplicationDbContext 
(  
DbContextOptions  0
options1 8
)8 9
:: ;
base< @
(@ A
optionsA H
)H I
{ 
}		 
}

 