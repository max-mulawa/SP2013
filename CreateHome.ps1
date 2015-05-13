Add-PSSnapin Microsoft.SharePoint.Powershell -ErrorAction SilentlyContinue

function CreateSite
{
	param ([string]$title, [string]$url)
	$site = Get-SPSite | Where-Object {$_.Url -eq $url} 
	if($site -ne $null)
	{
		# Write-Host "Deleting site at $($url)"
		# Remove-SPSite $url -Confirm:$false
		return
	}
	Write-Host  "Creating $($title) at $($url)"
    New-SPSite -Url $url -Name $title -Template "STS#0" -OwnerAlias "MULAWA\tedp" -SecondaryOwnerAlias "MULAWA\mulawam"
}

function CreateEventObj{
	param([string] $title, [string] $description, [datetime]$eventDate)
	$event = @{}
	$event.Title = $title;
	$event.Description = $description;
	$event.EventDate = $eventDate;
	return $event;
}

$homeSiteUrl = "http://intranet.mulawa.com/sites/home";
$amateurBoxingSiteUrl = "http://intranet.mulawa.com/sites/amateur";
$proBoxingSiteUrl = "http://intranet.mulawa.com/sites/pro";
CreateSite "Boxing Reunited" $homeSiteUrl; 
CreateSite "Amateur Boxing" $amateurBoxingSiteUrl;
CreateSite "Professional Boxing" $proBoxingSiteUrl;

$proEvents = @();
$proEvents += CreateEventObj "Max Schmeling vs Joe Louis, The Fight of the Decade" "For NYSAC, NBA & World Heavyweight titles." "1938-06-22";
$proEvents += CreateEventObj "Ali vs Joe Frazier, The Fight of the Century" "The Ring, WBA & WBC World Heavyweight titles." "1971-03-08";
$proEvents += CreateEventObj "Floyd Mayweather, Jr. vs Manny Pacquiao" "For WBA (Super), WBC, The Ring & Lineal Welterweight titles." "2015-05-02";
$proEvents

$amateurEvents = @();
$amateurEvents += CreateEventObj "Zbigniew Pietrzykowski vs Cassius Clay" "Olimpic Games, Semi-finals, Rome" "1960-08-18";
$amateurEvents += CreateEventObj "Jerzy Kulej vs Evgeni Frolov" "Olimpic Games, Final, Tokyo" "1964-10-23";
$amateurEvents += CreateEventObj "Marian Kasprzyk vs Ricardas Tamulis" "Olimpic Games, Final, Tokyo" "1964-10-23";
$amateurEvents


