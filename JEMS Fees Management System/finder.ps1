Get-ChildItem ".\"  | `
Foreach-Object{
	$file = Get-Content $_.FullName
	$origString = "global::JEMS_Fees_Management_System." + "Properties.Settings.Default.ConnectionString" #"ConcessionDataSet"
	$containsWord = $file | %{$_ -match $origString}
	If($containsWord -contains $true)
	{
		Write-Host $_
	}

}