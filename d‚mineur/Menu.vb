Imports System.IO

Public Class Menu


    Private Sub ButtonQ_Click(sender As Object, e As EventArgs) Handles ButtonQ.Click
        Dim mb = MsgBox("Voulez vous quitter l'application ?", MessageBoxButtons.YesNo, "Quitter")
        If mb = Windows.Forms.DialogResult.Yes Then
            Me.Close()

        End If
    End Sub

    Private Sub ButtonNvP_Click(sender As Object, e As EventArgs) Handles ButtonNvP.Click



        If saisirJoueur.Text.Length < 3 Then
            MsgBox("Veuillez entrez un nom de plus de 3 caractères pour lancer une partie.", vbExclamation, "Nom incorrect")

            '8x8'
        ElseIf RadioButton2.Checked = True Then


            Me.Visible = False
            Grille.Visible = True
            'saisirJoueur.Text = ""

        Else
            Me.Visible = False
            Grille4.Visible = True
            'saisirJoueur.Text = ""


        End If

    End Sub

    Private Sub ButtonSc_Click(sender As Object, e As EventArgs) Handles ButtonSc.Click
        Me.Visible = False

        Console.WriteLine(ComboBox2.SelectedItem.ToString & "sheesh")

        Scores.Visible = True
    End Sub

    Private Sub Menu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RadioButton2.Checked = True

        ComboBox1.Enabled = False
        ComboBox2.Enabled = True

        ComboBox1.SelectedItem = 4
        ComboBox2.SelectedItem = 10

        RadioButton3.Checked = True

        TextBox1.Text = 60

        RadioButton5.Checked = True



    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged, RadioButton2.CheckedChanged
        For i As Integer = 1 To 16
            ComboBox1.Items.Add(i)
        Next

        For i As Integer = 1 To 64
            ComboBox2.Items.Add(i)
        Next

        If RadioButton1.Checked = True Then
            ComboBox1.Enabled = True
            ComboBox2.Enabled = False


        ElseIf RadioButton2.Checked = True Then
            ComboBox2.Enabled = True
            ComboBox1.Enabled = False

        End If
    End Sub

    Private Sub RadioButtonTheme_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton5.CheckedChanged, RadioButton6.CheckedChanged, RadioButton7.CheckedChanged


        If RadioButton5.Checked = True Then
            Me.BackColor = Color.LightSlateGray
            Grille.BackColor = Color.LightSlateGray
            Grille4.BackColor = Color.LightSlateGray
            Scores.BackColor = Color.LightSlateGray


        ElseIf RadioButton6.Checked = True Then
            Me.BackColor = Color.FromArgb(64, 64, 64)
            Grille.BackColor = Color.FromArgb(64, 64, 64)
            Grille4.BackColor = Color.FromArgb(64, 64, 64)
            Scores.BackColor = Color.FromArgb(64, 64, 64)

        ElseIf RadioButton7.Checked = True Then
            Me.BackColor = Color.Gainsboro
            Grille.BackColor = Color.Gainsboro
            Grille4.BackColor = Color.Gainsboro
            Scores.BackColor = Color.Gainsboro

        End If
    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress

        If Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) And Not e.KeyChar = "." Then
            e.Handled = True
        End If

    End Sub

End Class
