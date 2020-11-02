$count = 0
$microServiceFailedCheck = $false
$clientFailedStart = $false
do {
    $count++
    $statusCodeOk = '200';
    Write-Output "[$env:STAGE_NAME] Starting container [Attempt: $count]"
    
    $microServiceHealthCheckUrls = @("http://localhost:5000/health", "http://localhost:5002/health", "http://localhost:5006/health", "http://localhost:5014/health")

    Foreach($msUrl in $microServiceHealthCheckUrls)
    {        
        $msWebResponse = Invoke-WebRequest -Uri $msUrl -UseBasicParsing
        if ($msWebResponse.statuscode -ne $statusCodeOk) {
            $microServiceFailedCheck = $true
            Start-Sleep -Seconds 2
            break
        } else {
            Write-Output "$($msUrl) returned 200 OK"
        }
    }
    
    if (!$microServiceFailedCheck)
    {
        $clientsHealthChecksUrl = @( "http://localhost:5008", "http://localhost", "http://localhost:5010")

        Foreach($clientUrl in $clientsHealthChecksUrl)
        {
            $clientWebResponse = Invoke-WebRequest -Uri $clientUrl -UseBasicParsing
            if ($clientWebResponse.statuscode -ne $statusCodeOk) {
                $clientFailedStart = $true
                Start-Sleep -Seconds 1
                break
            } else {
                Write-Output "$($clientUrl) returned 200 OK"
            }
        }
    }    
} until ((!$microServiceFailedCheck -and !$clientFailedStart) -or ($count -eq 3))

if ($microServiceFailedCheck -or $clientFailedStart) {
    exit 1
}