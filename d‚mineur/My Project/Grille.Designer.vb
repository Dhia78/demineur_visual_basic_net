<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Grille
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Grille))
        Me.ButtonAbd = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.TempsRestant = New System.Windows.Forms.Label()
        Me.PanelGrille = New System.Windows.Forms.TableLayoutPanel()
        Me.PanelLabel = New System.Windows.Forms.TableLayoutPanel()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'ButtonAbd
        '
        Me.ButtonAbd.Location = New System.Drawing.Point(341, 418)
        Me.ButtonAbd.Name = "ButtonAbd"
        Me.ButtonAbd.Size = New System.Drawing.Size(75, 23)
        Me.ButtonAbd.TabIndex = 64
        Me.ButtonAbd.Text = "Abandonner"
        Me.ButtonAbd.UseVisualStyleBackColor = True
        '
        'Timer1
        '
        '
        'TempsRestant
        '
        Me.TempsRestant.AutoSize = True
        Me.TempsRestant.Font = New System.Drawing.Font("Calisto MT", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TempsRestant.Location = New System.Drawing.Point(646, 53)
        Me.TempsRestant.Name = "TempsRestant"
        Me.TempsRestant.Size = New System.Drawing.Size(142, 24)
        Me.TempsRestant.TabIndex = 65
        Me.TempsRestant.Text = "TempsRestant"
        '
        'PanelGrille
        '
        Me.PanelGrille.BackColor = System.Drawing.Color.Transparent
        Me.PanelGrille.BackgroundImage = CType(resources.GetObject("PanelGrille.BackgroundImage"), System.Drawing.Image)
        Me.PanelGrille.ColumnCount = 8
        Me.PanelGrille.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.PanelGrille.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.PanelGrille.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.PanelGrille.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.PanelGrille.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.55422!))
        Me.PanelGrille.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.04819!))
        Me.PanelGrille.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.95181!))
        Me.PanelGrille.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.6506!))
        Me.PanelGrille.ForeColor = System.Drawing.Color.Black
        Me.PanelGrille.Location = New System.Drawing.Point(209, 41)
        Me.PanelGrille.Name = "PanelGrille"
        Me.PanelGrille.RowCount = 8
        Me.PanelGrille.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.PanelGrille.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.PanelGrille.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.PanelGrille.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.PanelGrille.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.PanelGrille.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.PanelGrille.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.93801!))
        Me.PanelGrille.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.66846!))
        Me.PanelGrille.Size = New System.Drawing.Size(332, 371)
        Me.PanelGrille.TabIndex = 66
        '
        'PanelLabel
        '
        Me.PanelLabel.BackColor = System.Drawing.Color.Transparent
        Me.PanelLabel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset
        Me.PanelLabel.ColumnCount = 8
        Me.PanelLabel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.PanelLabel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.PanelLabel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.PanelLabel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.PanelLabel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.55422!))
        Me.PanelLabel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.04819!))
        Me.PanelLabel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.95181!))
        Me.PanelLabel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.6506!))
        Me.PanelLabel.ForeColor = System.Drawing.Color.Black
        Me.PanelLabel.Location = New System.Drawing.Point(194, 26)
        Me.PanelLabel.Name = "PanelLabel"
        Me.PanelLabel.RowCount = 8
        Me.PanelLabel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.PanelLabel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.PanelLabel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.PanelLabel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.PanelLabel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.PanelLabel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.PanelLabel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.93801!))
        Me.PanelLabel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.66846!))
        Me.PanelLabel.Size = New System.Drawing.Size(332, 371)
        Me.PanelLabel.TabIndex = 68
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(621, 240)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 73
        Me.Button2.Text = "Reprendre"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(621, 195)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 72
        Me.Button1.Text = "Pause"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Grille
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightSlateGray
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.PanelGrille)
        Me.Controls.Add(Me.TempsRestant)
        Me.Controls.Add(Me.ButtonAbd)
        Me.Controls.Add(Me.PanelLabel)
        Me.Name = "Grille"
        Me.Text = "Grille"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ButtonAbd As Button
    Friend WithEvents Timer1 As Timer
    Friend WithEvents TempsRestant As Label
    Friend WithEvents PanelGrille As TableLayoutPanel
    Friend WithEvents PanelLabel As TableLayoutPanel
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
End Class
