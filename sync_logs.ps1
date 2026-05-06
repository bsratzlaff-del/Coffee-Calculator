# Get the folder where THIS script is saved
$scriptPath = Split-Path -Parent $MyInvocation.MyCommand.Definition
$localFile = Join-Path $scriptPath "local_debug_report.txt"

$adb = "C:\Users\bsrat\AppData\Local\Android\Sdk\platform-tools\adb.exe"
$package = "com.companyname.mauiapp1"

Write-Host "--- Syncing logs to: $localFile ---" -ForegroundColor Cyan
Write-Host "Press Ctrl+C to stop" -ForegroundColor Gray

while($true) {
    # 1. Grab the data from the phone
    $data = & $adb shell "run-as $package cat files/debug_log.txt" 2>$null

    if ($data) {
        # 2. Write it to your PC. 'Set-Content' is faster for live syncing
        $data | Set-Content -Path $localFile -Encoding UTF8
        Write-Host "Synced at $(Get-Date -Format 'HH:mm:ss')" -ForegroundColor Green
    }
    else {
        Write-Host "Searching for logs..." -ForegroundColor DarkGray
    }

    Start-Sleep -Seconds 3
}