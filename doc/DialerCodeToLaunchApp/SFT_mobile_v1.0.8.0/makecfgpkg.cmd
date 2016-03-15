@setlocal
@echo off

REM -- check system type
if "%ProgramW6432%"=="" (
REM -- 32bit system
set "PROGRAM_INSTALL_ROOT=%ProgramFiles%"
) else (
REM -- 64bit system
set "PROGRAM_INSTALL_ROOT=%ProgramFiles(x86)%"
)

set "WPDKCONTENTROOT=%PROGRAM_INSTALL_ROOT%\Windows Kits\10\"
set "WPDKTOOL=%WPDKCONTENTROOT%\bin\x86;%WPDKCONTENTROOT%\Tools\bin\i386"
set "PATH=%PATH%;%WPDKTOOL%"
set SIGN_OEM=1
set SIGN_WITH_TIMESTAMP=0

@echo on
pkggen SFTConfig.oem.pkg.xml /config:"%WPDKCONTENTROOT%\Tools\bin\i386\pkggen.cfg.xml" /version:10.0.0.1
@echo off
echo generate SFTConfig spkg, rc=%ERRORLEVEL%

endlocal