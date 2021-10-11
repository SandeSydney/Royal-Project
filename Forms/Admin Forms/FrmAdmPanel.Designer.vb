<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmAdmPanel
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnViewAddCust = New System.Windows.Forms.Button()
        Me.btnViewAddGarm = New System.Windows.Forms.Button()
        Me.btnViewAddUsers = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackgroundImage = Global.ROYAL_LAUNDRY_AND_DRY_CLEANING_MANAGEMENT_SYSTEM.My.Resources.Resources.sundown
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Controls.Add(Me.btnViewAddCust)
        Me.Panel1.Controls.Add(Me.btnViewAddGarm)
        Me.Panel1.Controls.Add(Me.btnViewAddUsers)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(590, 442)
        Me.Panel1.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(233, 93)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(118, 24)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Admin Panel"
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.PictureBox1)
        Me.Panel3.Controls.Add(Me.Label1)
        Me.Panel3.Location = New System.Drawing.Point(4, 12)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(582, 74)
        Me.Panel3.TabIndex = 6
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.ROYAL_LAUNDRY_AND_DRY_CLEANING_MANAGEMENT_SYSTEM.My.Resources.Resources.laundry
        Me.PictureBox1.Location = New System.Drawing.Point(7, 3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(81, 62)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 2
        Me.PictureBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe Print", 20.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(94, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(471, 47)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Royal Laundry and Dry Cleaners"
        '
        'btnViewAddCust
        '
        Me.btnViewAddCust.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnViewAddCust.Location = New System.Drawing.Point(173, 286)
        Me.btnViewAddCust.Name = "btnViewAddCust"
        Me.btnViewAddCust.Size = New System.Drawing.Size(227, 148)
        Me.btnViewAddCust.TabIndex = 5
        Me.btnViewAddCust.Text = "View / Add Customers"
        Me.btnViewAddCust.UseVisualStyleBackColor = True
        '
        'btnViewAddGarm
        '
        Me.btnViewAddGarm.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnViewAddGarm.Location = New System.Drawing.Point(304, 125)
        Me.btnViewAddGarm.Name = "btnViewAddGarm"
        Me.btnViewAddGarm.Size = New System.Drawing.Size(227, 148)
        Me.btnViewAddGarm.TabIndex = 4
        Me.btnViewAddGarm.Text = "View / Add Garments"
        Me.btnViewAddGarm.UseVisualStyleBackColor = True
        '
        'btnViewAddUsers
        '
        Me.btnViewAddUsers.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnViewAddUsers.Location = New System.Drawing.Point(39, 125)
        Me.btnViewAddUsers.Name = "btnViewAddUsers"
        Me.btnViewAddUsers.Size = New System.Drawing.Size(221, 148)
        Me.btnViewAddUsers.TabIndex = 3
        Me.btnViewAddUsers.Text = "View / Add Users"
        Me.btnViewAddUsers.UseVisualStyleBackColor = True
        '
        'FrmAdmPanel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(590, 442)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "FrmAdmPanel"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Adm Panel"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnViewAddGarm As Button
    Friend WithEvents btnViewAddUsers As Button
    Friend WithEvents btnViewAddCust As Button
    Friend WithEvents Panel3 As Panel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
End Class
