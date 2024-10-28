@echo off

set locationFileNameExt="%UserProfile%\Desktop\ProjectPublished"

@REM اگر از قبل پوشه های اضافی موجود بود پاک شود
if exist %locationFileNameExt% (rmdir /s /q %locationFileNameExt%)

dotnet publish -c Release -r win-x64 --no-self-contained -v m -o %locationFileNameExt%

@REM پوشه های اضافی پاک میشوند
rmdir /s /q RahkaranTransfer

echo Sucess!
PAUSE