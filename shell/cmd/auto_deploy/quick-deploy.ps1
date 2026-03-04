Add-Type -AssemblyName System.Windows.Forms
Add-Type -AssemblyName System.Drawing

# Set working directory
$scriptPath = Split-Path -Parent $MyInvocation.MyCommand.Path
Set-Location $scriptPath

# Create main form
$form = New-Object System.Windows.Forms.Form
$form.Text = "MAD ERP - Quick Deploy"
$form.Size = New-Object System.Drawing.Size(500, 450)
$form.StartPosition = "CenterScreen"
$form.FormBorderStyle = "FixedDialog"
$form.MaximizeBox = $false
$form.Font = New-Object System.Drawing.Font("Segoe UI", 10)

# Environment Label
$lblEnv = New-Object System.Windows.Forms.Label
$lblEnv.Location = New-Object System.Drawing.Point(20, 20)
$lblEnv.Size = New-Object System.Drawing.Size(150, 25)
$lblEnv.Text = "Environment:"
$form.Controls.Add($lblEnv)

# Environment ComboBox
$cmbEnv = New-Object System.Windows.Forms.ComboBox
$cmbEnv.Location = New-Object System.Drawing.Point(20, 45)
$cmbEnv.Size = New-Object System.Drawing.Size(200, 30)
$cmbEnv.DropDownStyle = "DropDownList"
$cmbEnv.Items.AddRange(@("TEST", "PROD"))
$cmbEnv.SelectedIndex = 0
$form.Controls.Add($cmbEnv)

# Service Label
$lblService = New-Object System.Windows.Forms.Label
$lblService.Location = New-Object System.Drawing.Point(20, 90)
$lblService.Size = New-Object System.Drawing.Size(150, 25)
$lblService.Text = "Select Service:"
$form.Controls.Add($lblService)

# Service ListBox
$lstServices = New-Object System.Windows.Forms.ListBox
$lstServices.Location = New-Object System.Drawing.Point(20, 115)
$lstServices.Size = New-Object System.Drawing.Size(440, 220)
$lstServices.Font = New-Object System.Drawing.Font("Consolas", 10)

# Add services
$services = @(
    "--- Backend Services ---",
    "erp-adm-service",
    "erp-hrm-service",
    "erp-org-service",
    "erp-std-service",
    "erp-com-service",
    "erp-fin-service",
    "erp-my-service",
    "erp-dash-service",
    "erp-app-service",
    "erp-link-service",
    "erp-lms-service",
    "erp-itg-service-gateway",
    "erp-itg-service-proxy",
    "erp-adm-job-service",
    "erp-logger-job-service",
    "--- BFF Services ---",
    "erp-adm-web-bff",
    "erp-hrm-web-bff",
    "erp-org-web-bff",
    "erp-std-bff-web",
    "erp-com-bff-web",
    "erp-fin-bff-web",
    "erp-dash-bff-web",
    "erp-app-bff-web",
    "erp-link-bff-web",
    "erp-lms-bff-web"
)

foreach ($svc in $services) {
    $lstServices.Items.Add($svc)
}
$lstServices.SelectedIndex = 3  # Default: erp-org-service
$form.Controls.Add($lstServices)

# Deploy Button
$btnDeploy = New-Object System.Windows.Forms.Button
$btnDeploy.Location = New-Object System.Drawing.Point(20, 350)
$btnDeploy.Size = New-Object System.Drawing.Size(140, 40)
$btnDeploy.Text = "Deploy"
$btnDeploy.BackColor = [System.Drawing.Color]::FromArgb(0, 120, 212)
$btnDeploy.ForeColor = [System.Drawing.Color]::White
$btnDeploy.FlatStyle = "Flat"
$btnDeploy.Cursor = "Hand"

$btnDeploy.Add_Click({
    $selectedService = $lstServices.SelectedItem
    $selectedEnv = $cmbEnv.SelectedItem.ToString().ToLower()
    
    # Skip separator lines
    if ($selectedService -like "---*") {
        [System.Windows.Forms.MessageBox]::Show("Please select a valid service", "Warning", "OK", "Warning")
        return
    }
    
    # Confirm deployment
    $result = [System.Windows.Forms.MessageBox]::Show(
        "Deploy $selectedService to $($selectedEnv.ToUpper())?",
        "Confirm Deployment",
        "YesNo",
        "Question"
    )
    
    if ($result -eq "Yes") {
        $form.Hide()
        
        # Run deploy script
        $deployCmd = "cmd /c `"$scriptPath\deploy.bat`" $selectedEnv $selectedService"
        Start-Process -FilePath "cmd.exe" -ArgumentList "/k", "$scriptPath\deploy.bat", $selectedEnv, $selectedService -Wait
        
        $form.Show()
    }
})
$form.Controls.Add($btnDeploy)

# Cancel Button
$btnCancel = New-Object System.Windows.Forms.Button
$btnCancel.Location = New-Object System.Drawing.Point(170, 350)
$btnCancel.Size = New-Object System.Drawing.Size(100, 40)
$btnCancel.Text = "Exit"
$btnCancel.FlatStyle = "Flat"
$btnCancel.Add_Click({ $form.Close() })
$form.Controls.Add($btnCancel)

# Status Label
$lblStatus = New-Object System.Windows.Forms.Label
$lblStatus.Location = New-Object System.Drawing.Point(280, 360)
$lblStatus.Size = New-Object System.Drawing.Size(180, 25)
$lblStatus.ForeColor = [System.Drawing.Color]::Gray
$lblStatus.Text = "Select and click Deploy"
$form.Controls.Add($lblStatus)

# Double-click to deploy
$lstServices.Add_DoubleClick({
    $btnDeploy.PerformClick()
})

# Show form
$form.Add_Shown({ $form.Activate(); $lstServices.Focus() })
[void]$form.ShowDialog()
