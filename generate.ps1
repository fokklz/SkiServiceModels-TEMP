# -----------------------------------------------------------------------------
# This script is used to generate the README.md file from the README.raw.md
# file in each subdirectory and the class files. 
# The class files are searched for a placeholder line that contains the 
# class name. When found, the class definition is extracted and replaces 
# the placeholder line with a code block.
# Author:  Fokko Vos
# Date:    02.12.2023
# Updated: 20.01.2024
# -----------------------------------------------------------------------------

$workingDirectory = Get-Location
$directories = Get-ChildItem -Directory -Path $workingDirectory

$directoriesInfo = @{
    "MODEL" = "Models"
    "MODELBASE" = "Models\Base"
    "DTO" = "DTOs"
    "REQDTO" = "DTOs\Requests"
    "REQDTOBASE" = "DTOs\Requests\Base"
    "RESDTO" = "DTOs\Responses"
    "RESDTOBASE" = "DTOs\Responses\Base"
    "INTERFACE" = "Interfaces"
    "INTERFACEBASE" = "Interfaces\Base"
    "INTERFACEMODEL" = "Interfaces\Models"
    "ENUM" = "Enums"
}

function Extract-ClassDefinition {
     param (
        [string]$Name,
        [string]$Type,
        [string]$Dir
    )

    $targetDir = Join-Path $Dir $directoriesInfo[$Type]
    $filePath = Join-Path $targetDir "$Name.cs"

    $classContent = @()
    $insideClass = $false
    $bracesCount = 0

    switch ($Type) {
		{$_ -in "INTERFACE", "INTERFACEMODEL", "INTERFACEBASE"} {
			$pattern = '^\s*public interface\s'
		}
		"ENUM" {
			$pattern = '^\s*public enum\s'
		}
		default {
			$pattern = '^\s*public class\s'
		}
	}

    Write-Host "Extracting $Type definition for $Name from $filePath"
    Get-Content $filePath | ForEach-Object {
        if ($_ -match $pattern) {
            $insideClass = $true
            $bracesCount = 1
            # Check and remove the first level of indentation (tab or 4 spaces)
            $classContent += if ($_ -match "^\t") { $_.Remove(0, 1) } 
                            elseif ($_ -match "^ {4}") { $_.Remove(0, 4) } 
                            else { $_ }
            return
        }

        if ($insideClass) {
            # Check and remove the first level of indentation (tab or 4 spaces)
            $line = if ($_ -match "^\t") { $_.Remove(0, 1) } 
                    elseif ($_ -match "^ {4}") { $_.Remove(0, 4) } 
                    else { $_ }

            $classContent += $line

            $line.ToCharArray() | ForEach-Object {
                if ($_ -eq '{') {
                    $bracesCount++
                }
                if ($_ -eq '}') {
                    $bracesCount--
                }
            }

            if ($bracesCount -eq 1) {
                $insideClass = $false
            }
        }
    }


    $codeBlockStart = '```csharp'
    $codeBlockEnd = '```'
    $codeBlockInner = $classContent -join "`r`n"

    if($Type -eq 'EFMODEL' -or $Type -eq 'BSONMODEL' ){
        return "$codeBlockStart`r`n$codeBlockInner`r`n$codeBlockEnd`r`n"
    }else{
        return "[back up](#contents)`r`n$codeBlockStart`r`n$codeBlockInner`r`n$codeBlockEnd`r`n"
    }
}

foreach ($dir in $directories) {
    $inputFile = Join-Path $dir.FullName "README.raw.md"
    $outputFile = Join-Path $dir.FullName "README.md"

    if (Test-Path $inputFile) {
        Write-Host "Processing $inputFile..."

        Clear-Content $outputFile -ErrorAction SilentlyContinue

        $content = Get-Content $inputFile

        foreach ($line in $content) {
            if ($line -match '<<(.+)::(.+)>>') {
                $type = $matches[1]
                $className = $matches[2]

                $line = Extract-ClassDefinition -Name $className -Type $type -Dir $dir.FullName
            }

            $line | Out-File $outputFile -Append
        }

        Write-Host "README.md generated at $outputFile"
    }
    else {
        Write-Host "No README.raw.md found in $dir.FullName"
    }
}
