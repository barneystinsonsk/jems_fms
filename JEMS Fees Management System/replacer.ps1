Get-ChildItem ".\" -Filter *.Designer.cs | `
Foreach-Object{
    #$content = Get-Content $_.FullName
$origString = "global::JEMS_Fees_Management_System." + "Properties.Settings.Default.ConnectionString"
$newString = "GlobalVariables.dbConnectString"
(Get-Content $_.FullName) | ForEach-Object { $_ -replace $origString, $newString } | Set-Content $_.FullName

}
