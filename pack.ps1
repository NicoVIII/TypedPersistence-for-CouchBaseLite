param (
    [Parameter(Mandatory = $true)][string]$Version
)

# Set correct version
$projectFile = "src/TypedPersistence.CouchbaseLite/FSharp/TypedPersistence.CouchbaseLite.FSharp.fsproj"
(Get-Content $projectFile).replace('$version$', $Version) | Set-Content $projectFile
(Get-Content $projectFile).replace('<!--<Version>', '<Version>') | Set-Content $projectFile
(Get-Content $projectFile).replace('</Version>-->', '</Version>') | Set-Content $projectFile

# Pack as NugetPackage
dotnet pack src/TypedPersistence.CouchbaseLite/FSharp -c Release -o ../../..