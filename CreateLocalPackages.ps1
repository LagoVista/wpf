$scriptPath = Split-Path $MyInvocation.MyCommand.Path

Write-Output $scriptPath

Set-Location $scriptPath

#TODO: Giving strange compile errors...need to manually rebuild Release config before packaging
#$msbuild = "C:\Windows\Microsoft.NET\Framework\v4.0.30319\msbuild.exe"
#& $msbuild  /t:Clean,Build /verbosity:q /p:Configuration=Release

. ./UpdateNuspecVersion.ps1 -preRelease alpha -major 0 -minor 8

$oldChildren = gci $scriptPath -Recurse *.nupkg
foreach( $oldChild in $oldChildren){
	if(!($oldChild.DirectoryName -match "packages")){
		Remove-Item $oldChild -Recurse
	}
}

$children = gci $scriptPath -recurse *.nuspec
foreach( $child in $children)
{
	$projectPath = Split-Path $child.FullName

	Write-Output $child.FullName
	nuget pack -OutputDirectory D:\LocalNuget $child.FullName
	nuget pack $child.FullName
}