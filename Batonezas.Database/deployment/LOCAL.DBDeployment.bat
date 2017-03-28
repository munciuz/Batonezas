@echo off

SET DIR=%~d0%~p0%

SET database.name="TestRoundhousE"
SET sql.files.directory="%DIR%..\Scripts"
SET server.database="(local)"
SET repository.path="https://github.com/chucknorris/roundhouse.git"
SET version.file="_BuildInfo.xml"
SET version.xpath="//buildInfo/version"
SET environment="LOCAL"

"%DIR%Console\rh.exe" /d=%database.name% /f=%sql.files.directory% /s=%server.database% /vf=%version.file% /vx=%version.xpath% /r=%repository.path% /env=%environment% /simple

pause