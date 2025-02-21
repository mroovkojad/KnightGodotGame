function Select-GodotExecutable {
    [CmdletBinding()]
    param ()

    Add-Type -AssemblyName System.Windows.Forms

    $dialog = New-Object System.Windows.Forms.OpenFileDialog
    $dialog.Filter = "Executable Files (*.exe)|*.exe"
    $dialog.Title = "Select Godot Executable"
    $dialog.Multiselect = $false
    $dialog.InitialDirectory = [Environment]::GetFolderPath('ProgramFiles')

    do {
        $result = $dialog.ShowDialog()

        if ($result -eq [System.Windows.Forms.DialogResult]::OK) {
            $fileName = [System.IO.Path]::GetFileName($dialog.FileName)

            if ($fileName -match '^Godot.*\.exe$' -and $fileName -notmatch 'console\.exe$') {
                Write-Host "Selected File: $($dialog.FileName)"
                return $dialog.FileName
            }
            else {
                [System.Windows.Forms.MessageBox]::Show("Invalid file selected. Please select a Godot executable that does not end with 'console.exe'.", "Invalid Selection", [System.Windows.Forms.MessageBoxButtons]::OK, [System.Windows.Forms.MessageBoxIcon]::Warning)
            }
        }
        else {
            Write-Host "No file selected."
            return $null
        }
    } while ($true)
}
$godotPath = Select-GodotExecutable
Write-Output "Selected Godot Path: $godotPath"
try {


    Write-Output "Setting GODOT4 environment variable..."
    [Environment]::SetEnvironmentVariable("GODOT4", "$godotPath" , "User")
} catch {
    Write-Error "An error occurred: $_"
}