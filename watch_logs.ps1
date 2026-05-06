# This script "tails" your Android log file inside VSCode
$adb = "C:\Users\bsrat\AppData\Local\Android\Sdk\platform-tools\adb.exe"
$package = "com.companyname.mauiapp1"

Write-Host "--- Starting Coffee App Log Stream ---" -ForegroundColor Cyan

# This clears the screen and then constantly 'cats' the file every 2 seconds
while($true) {
    Clear-Host
    Write-Host "Last Updated: $(Get-Date -Format 'HH:mm:ss')" -ForegroundColor Gray
    & $adb shell "run-as $package cat files/debug_log.txt"
    Start-Sleep -Seconds 2
}