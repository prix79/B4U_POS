@echo off

echo *** windows time service stop and demand config***
sc stop w32time  >nul
sc config w32time start= demand  >nul

echo *** windows time server setting***
w32tm /config /manualpeerlist:"time.nist.gov,0x9" /syncfromflags:MANUAL >nul

echo *** windwos time poll interval MAX value setting(registry) **
reg add "HKLM\SYSTEM\CurrentControlSet\services\w32time\Config" /f /v "MaxPosPhaseCorrection" /t REG_DWORD /d 0xFFFFFFFF  >nul
reg add "HKLM\SYSTEM\CurrentControlSet\services\w32time\Config" /f /v "MaxNegPhaseCorrection" /t REG_DWORD /d 0xFFFFFFFF  >nul

echo *** windows time service start ***
sc start w32time >nul

echo *** windows time resync ***
echo *** PLEASE WAIT!!!!!!!!!!!! ***
w32tm /resync >nul

echo *** windwos time poll interval value change(for security-1hour)(registry) **
reg add "HKLM\SYSTEM\CurrentControlSet\services\w32time\Config" /f /v "MaxPosPhaseCorrection" /t REG_DWORD /d "3600" >nul
reg add "HKLM\SYSTEM\CurrentControlSet\services\w32time\Config" /f /v "MaxNegPhaseCorrection" /t REG_DWORD /d "3600" >nul

echo *** windows time service restart ***
sc stop w32time >nul
sc start w32time >nul

start %~dp0\Register.exe