Start-Job -ScriptBlock { & "$env:LOCALAPPDATA\Android\Sdk\emulator\emulator.exe" -avd CoffeeShop }

& "$env:LOCALAPPDATA\Android\Sdk\emulator\emulator.exe" -avd CoffeePhone -no-snapshot-load

Remove-Item -Recurse -Force bin, obj

dotnet build -t:Run -f net10.0-android -p:AdbTarget="-e"