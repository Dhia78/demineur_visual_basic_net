Public Class Grille
    Dim tmp As Integer = Integer.Parse(démineur.Menu.TextBox1.Text)
    Dim compteCase As Integer = 0
    Dim perdu As Boolean = False
    Dim ent As Integer = Integer.Parse(démineur.Menu.ComboBox2.Text)

    'GENERATION MINES'
    Dim TabMines(63) As Integer
    Dim Generator As System.Random = New System.Random()
    Dim djMine As New List(Of Integer)
    Dim r As Integer

    Public Function getCompteCase() As String
        Return compteCase
    End Function

    Public Function getTemps() As String
        Return Integer.Parse(démineur.Menu.TextBox1.Text) - tmp
    End Function

    Private Sub Grille_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        PanelLabel.Visible = False

        If démineur.Menu.RadioButton4.Checked = True Then
            Button1.Visible = False
            Button2.Visible = False
        End If

        'TIMER'
        Timer1.Interval = 1000
        Timer1.Start()
        afficheHeure(sender, e)
        TempsRestant.Text = tmp


        'BOUTONS GRILLE'
        For i As Integer = 0 To 7
            For j As Integer = 0 To 7
                Dim nvBtn As New Button
                nvBtn.BackColor = Color.SteelBlue
                nvBtn.Width = 45
                nvBtn.Height = 45
                AddHandler nvBtn.Click, AddressOf Demasquer
                PanelGrille.Controls.Add(nvBtn, j, i)
            Next
        Next


        'Chaque mine ne peut pas occuper la place d'une mine déjà posé'


        For y As Integer = 0 To ent - 1
            If djMine.Contains(r) Then
                While djMine.Contains(r)
                    r = Generator.Next(0, 64)
                End While
                djMine.Add(r)
                TabMines(r) = 666
            Else
                djMine.Add(r)
                TabMines(r) = 666
            End If
        Next

        'debug tableau cases'

        'djMine.Sort()

        'For Each i As Integer In djMine
        '    Console.WriteLine(i & " ")
        'Next

        'For Each i As Integer In TabMines
        '    Console.WriteLine(i)
        'Next


        'Génération des cases chiffrées autours de chaque mine'
        Dim cpt As Integer = 0
        For Each p As Integer In TabMines
            'haut'
            If p = 666 And cpt > 8 Then
                If TabMines(cpt - 8) <> 666 Then
                    TabMines(cpt - 8) += 1
                End If
            End If
            'bas'
            If p = 666 And cpt < 56 Then
                If TabMines(cpt + 8) <> 666 Then
                    TabMines(cpt + 8) += 1
                End If
            End If
            'gauche'
            If p = 666 And cpt Mod 8 <> 0 Then
                If TabMines(cpt - 1) <> 666 Then
                    TabMines(cpt - 1) += 1
                End If
            End If
            'droite'
            If p = 666 And (cpt + 1) Mod 8 <> 0 Then
                If TabMines(cpt + 1) <> 666 Then
                    TabMines(cpt + 1) += 1
                End If
            End If
            'haut-gauche'
            If p = 666 And cpt > 8 And cpt Mod 8 <> 0 Then
                If TabMines(cpt - 9) <> 666 Then
                    TabMines(cpt - 9) += 1
                End If
            End If
            'haut-droit'
            If p = 666 And cpt > 8 And (cpt + 1) Mod 8 <> 0 Then
                If TabMines(cpt - 7) <> 666 Then
                    TabMines(cpt - 7) += 1
                End If
            End If
            'bas-gauche'
            If p = 666 And cpt < 56 And cpt Mod 8 <> 0 Then
                If TabMines(cpt + 7) <> 666 Then
                    TabMines(cpt + 7) += 1
                End If
            End If
            'bas-droit'
            If p = 666 And cpt < 56 And (cpt + 1) Mod 8 <> 0 Then
                If TabMines(cpt + 9) <> 666 Then
                    TabMines(cpt + 9) += 1
                End If
            End If

            cpt = cpt + 1
        Next

        'Label panel pour les cases chiffrées (666 = mine)'
        Dim x As Integer = 0
        For i As Integer = 0 To 7
            For j As Integer = 0 To 7
                Dim nvLab As New Label
                nvLab.Text = TabMines(x)
                nvLab.TextAlign = ContentAlignment.MiddleCenter
                x = x + 1
                PanelLabel.Controls.Add(nvLab, j, i)
            Next
        Next



    End Sub

    Private Sub Demasquer(sender As Object, e As EventArgs)




        Dim row = PanelGrille.GetRow(sender)
        Dim col = PanelGrille.GetColumn(sender)

        row = row * 8

        Dim indBtn As Integer = row + col

        'si la case est une mine'
        If djMine.Contains(indBtn) Then
            perdu = True
            sender.BackColor = Color.Red

            For i As Integer = 0 To 7
                For j As Integer = 0 To 7
                    If TabMines(i * 8 + j) = 666 Then
                        PanelGrille.Controls.Item(i * 8 + j).BackColor = Color.Red
                    End If
                Next
            Next


            Timer1.Stop()
            Dim mb = MsgBox("Partie perdue... ;^(", MessageBoxButtons.OK, "Ah...")

            If mb = Windows.Forms.DialogResult.OK Then
                Me.Close()
                démineur.Menu.Visible = True
                démineur.Menu.saisirJoueur.Text = ""
            End If

            'si la case est chiffrée'
        ElseIf TabMines(indBtn) > 0 And TabMines(indBtn) <> 666 Then

            'si la case est chiffrée, on son chiffre en texte + le bouton ne peut plus être utilisé'
            sender.Text = TabMines(indBtn)
            sender.Enabled = False

            sender.FlatStyle = Windows.Forms.FlatStyle.Flat
            sender.FlatAppearance.BorderSize = 0
            sender.FlatAppearance.MouseDownBackColor = Color.Transparent
            sender.FlatAppearance.MouseOverBackColor = Color.Transparent
            sender.BackColor = Color.Transparent



            'si la case est vide'
        ElseIf TabMines(indBtn) = 0 Then
            compteCase = compteCase + 1
            'si la case est vide, on ne met rien en texte + le bouton ne peut plus être utilisé'
            sender.Text = ""
            sender.Enabled = False

            'pour rendre le bouton transparaent'
            sender.FlatStyle = Windows.Forms.FlatStyle.Flat
            sender.FlatAppearance.BorderSize = 0
            sender.FlatAppearance.MouseDownBackColor = Color.Transparent
            sender.FlatAppearance.MouseOverBackColor = Color.Transparent
            sender.BackColor = Color.Transparent


            'revele tt autour, case milieu grille'
            If indBtn > 8 And indBtn Mod 8 <> 0 And (indBtn + 1) Mod 8 <> 0 And indBtn < 56 Then

                Dim haut = PanelGrille.GetControlFromPosition(col, (row / 8) - 1)
                Dim bas = PanelGrille.GetControlFromPosition(col, (row / 8) + 1)
                Dim gauche = PanelGrille.GetControlFromPosition(col - 1, row / 8)
                Dim droite = PanelGrille.GetControlFromPosition(col + 1, row / 8)
                Dim hg = PanelGrille.GetControlFromPosition(col - 1, (row / 8) - 1)
                Dim hd = PanelGrille.GetControlFromPosition(col + 1, (row / 8) - 1)
                Dim bg = PanelGrille.GetControlFromPosition(col - 1, (row / 8) + 1)
                Dim bd = PanelGrille.GetControlFromPosition(col + 1, (row / 8) + 1)


                If TabMines(indBtn - 8) = 0 Then
                    haut.Text = ""
                Else
                    haut.Text = TabMines(indBtn - 8)

                End If
                haut.Enabled = False
                haut.BackColor = Color.Transparent



                If TabMines(indBtn + 8) = 0 Then
                    bas.Text = ""
                Else
                    bas.Text = TabMines(indBtn + 8)

                End If
                bas.Enabled = False
                bas.BackColor = Color.Transparent



                If TabMines(indBtn - 1) = 0 Then
                    gauche.Text = ""
                Else
                    gauche.Text = TabMines(indBtn - 1)

                End If
                gauche.Enabled = False
                gauche.BackColor = Color.Transparent



                If TabMines(indBtn + 1) = 0 Then
                    droite.Text = ""
                Else
                    droite.Text = TabMines(indBtn + 1)

                End If
                droite.Enabled = False
                droite.BackColor = Color.Transparent



                If TabMines(indBtn - 9) = 0 Then
                    hg.Text = ""
                Else
                    hg.Text = TabMines(indBtn - 9)

                End If
                hg.Enabled = False
                hg.BackColor = Color.Transparent



                If TabMines(indBtn - 7) = 0 Then
                    hd.Text = ""
                Else
                    hd.Text = TabMines(indBtn - 7)

                End If
                hd.Enabled = False
                hd.BackColor = Color.Transparent



                If TabMines(indBtn + 7) = 0 Then
                    bg.Text = ""
                Else
                    bg.Text = TabMines(indBtn + 7)

                End If
                bg.Enabled = False
                bg.BackColor = Color.Transparent

                If TabMines(indBtn + 9) = 0 Then
                    bd.Text = ""
                Else
                    bd.Text = TabMines(indBtn + 9)

                End If
                bd.Enabled = False
                bd.BackColor = Color.Transparent

            End If

            'cas haut milieu, +hg, +hd'
            If indBtn < 8 Then
                'hg'
                If indBtn Mod 8 = 0 Then


                    Dim bas = PanelGrille.GetControlFromPosition(col, (row / 8) + 1)
                    Dim droite = PanelGrille.GetControlFromPosition(col + 1, row / 8)

                    Dim bd = PanelGrille.GetControlFromPosition(col + 1, (row / 8) + 1)


                    If TabMines(indBtn + 8) = 0 Then
                        bas.Text = ""
                    Else
                        bas.Text = TabMines(indBtn + 8)

                    End If
                    bas.Enabled = False
                    bas.BackColor = Color.Transparent




                    If TabMines(indBtn + 1) = 0 Then
                        droite.Text = ""
                    Else
                        droite.Text = TabMines(indBtn + 1)

                    End If
                    droite.Enabled = False
                    droite.BackColor = Color.Transparent



                    If TabMines(indBtn + 9) = 0 Then
                        bd.Text = ""
                    Else
                        bd.Text = TabMines(indBtn + 9)

                    End If
                    bd.Enabled = False
                    bd.BackColor = Color.Transparent

                    'hd'
                ElseIf (indBtn + 1) Mod 8 = 0 Then

                    Dim bas = PanelGrille.GetControlFromPosition(col, (row / 8) + 1)
                    Dim gauche = PanelGrille.GetControlFromPosition(col - 1, row / 8)

                    Dim bg = PanelGrille.GetControlFromPosition(col - 1, (row / 8) + 1)



                    If TabMines(indBtn + 8) = 0 Then
                        bas.Text = ""
                    Else
                        bas.Text = TabMines(indBtn + 8)

                    End If
                    bas.Enabled = False
                    bas.BackColor = Color.Transparent



                    If TabMines(indBtn - 1) = 0 Then
                        gauche.Text = ""
                    Else
                        gauche.Text = TabMines(indBtn - 1)

                    End If
                    gauche.Enabled = False
                    gauche.BackColor = Color.Transparent


                    If TabMines(indBtn + 7) = 0 Then
                        bg.Text = ""
                    Else
                        bg.Text = TabMines(indBtn + 7)

                    End If
                    bg.Enabled = False
                    bg.BackColor = Color.Transparent

                    'haut milieu
                Else


                    Dim bas = PanelGrille.GetControlFromPosition(col, (row / 8) + 1)
                    Dim gauche = PanelGrille.GetControlFromPosition(col - 1, row / 8)
                    Dim droite = PanelGrille.GetControlFromPosition(col + 1, row / 8)


                    Dim bg = PanelGrille.GetControlFromPosition(col - 1, (row / 8) + 1)
                    Dim bd = PanelGrille.GetControlFromPosition(col + 1, (row / 8) + 1)

                    If TabMines(indBtn + 8) = 0 Then
                        bas.Text = ""
                    Else
                        bas.Text = TabMines(indBtn + 8)

                    End If
                    bas.Enabled = False
                    bas.BackColor = Color.Transparent



                    If TabMines(indBtn - 1) = 0 Then
                        gauche.Text = ""
                    Else
                        gauche.Text = TabMines(indBtn - 1)

                    End If
                    gauche.Enabled = False
                    gauche.BackColor = Color.Transparent



                    If TabMines(indBtn + 1) = 0 Then
                        droite.Text = ""
                    Else
                        droite.Text = TabMines(indBtn + 1)

                    End If
                    droite.Enabled = False
                    droite.BackColor = Color.Transparent

                    If TabMines(indBtn + 7) = 0 Then
                        bg.Text = ""
                    Else
                        bg.Text = TabMines(indBtn + 7)

                    End If
                    bg.Enabled = False
                    bg.BackColor = Color.Transparent

                    If TabMines(indBtn + 9) = 0 Then
                        bd.Text = ""
                    Else
                        bd.Text = TabMines(indBtn + 9)

                    End If
                    bd.Enabled = False
                    bd.BackColor = Color.Transparent

                End If
            End If

            'cas bas milieu, +bg, +bg'
            If indBtn > 55 Then
                If indBtn Mod 8 = 0 Then

                    Dim haut = PanelGrille.GetControlFromPosition(col, (row / 8) - 1)

                    Dim droite = PanelGrille.GetControlFromPosition(col + 1, row / 8)

                    Dim hd = PanelGrille.GetControlFromPosition(col + 1, (row / 8) - 1)



                    If TabMines(indBtn - 8) = 0 Then
                        haut.Text = ""
                    Else
                        haut.Text = TabMines(indBtn - 8)

                    End If
                    haut.Enabled = False
                    haut.BackColor = Color.Transparent




                    If TabMines(indBtn + 1) = 0 Then
                        droite.Text = ""
                    Else
                        droite.Text = TabMines(indBtn + 1)

                    End If
                    droite.Enabled = False
                    droite.BackColor = Color.Transparent



                    If TabMines(indBtn - 7) = 0 Then
                        hd.Text = ""
                    Else
                        hd.Text = TabMines(indBtn - 7)

                    End If
                    hd.Enabled = False
                    hd.BackColor = Color.Transparent

                ElseIf (indBtn + 1) Mod 8 = 0 Then

                    Dim haut = PanelGrille.GetControlFromPosition(col, (row / 8) - 1)

                    Dim gauche = PanelGrille.GetControlFromPosition(col - 1, row / 8)

                    Dim hg = PanelGrille.GetControlFromPosition(col - 1, (row / 8) - 1)

                    If TabMines(indBtn - 8) = 0 Then
                        haut.Text = ""
                    Else
                        haut.Text = TabMines(indBtn - 8)

                    End If
                    haut.Enabled = False
                    haut.BackColor = Color.Transparent


                    If TabMines(indBtn - 1) = 0 Then
                        gauche.Text = ""
                    Else
                        gauche.Text = TabMines(indBtn - 1)

                    End If
                    gauche.Enabled = False
                    gauche.BackColor = Color.Transparent



                    If TabMines(indBtn - 9) = 0 Then
                        hg.Text = ""
                    Else
                        hg.Text = TabMines(indBtn - 9)

                    End If
                    hg.Enabled = False
                    hg.BackColor = Color.Transparent

                Else

                    Dim haut = PanelGrille.GetControlFromPosition(col, (row / 8) - 1)

                    Dim gauche = PanelGrille.GetControlFromPosition(col - 1, row / 8)
                    Dim droite = PanelGrille.GetControlFromPosition(col + 1, row / 8)
                    Dim hg = PanelGrille.GetControlFromPosition(col - 1, (row / 8) - 1)
                    Dim hd = PanelGrille.GetControlFromPosition(col + 1, (row / 8) - 1)



                    If TabMines(indBtn - 8) = 0 Then
                        haut.Text = ""
                    Else
                        haut.Text = TabMines(indBtn - 8)

                    End If
                    haut.Enabled = False
                    haut.BackColor = Color.Transparent


                    If TabMines(indBtn - 1) = 0 Then
                        gauche.Text = ""
                    Else
                        gauche.Text = TabMines(indBtn - 1)

                    End If
                    gauche.Enabled = False
                    gauche.BackColor = Color.Transparent



                    If TabMines(indBtn + 1) = 0 Then
                        droite.Text = ""
                    Else
                        droite.Text = TabMines(indBtn + 1)

                    End If
                    droite.Enabled = False
                    droite.BackColor = Color.Transparent



                    If TabMines(indBtn - 9) = 0 Then
                        hg.Text = ""
                    Else
                        hg.Text = TabMines(indBtn - 9)

                    End If
                    hg.Enabled = False
                    hg.BackColor = Color.Transparent



                    If TabMines(indBtn - 7) = 0 Then
                        hd.Text = ""
                    Else
                        hd.Text = TabMines(indBtn - 7)

                    End If
                    hd.Enabled = False
                    hd.BackColor = Color.Transparent


                End If
            End If

            'cas gauche milieu, pas haut pas bas'
            If indBtn Mod 8 = 0 And indBtn < 56 And indBtn > 7 Then


                Dim haut = PanelGrille.GetControlFromPosition(col, (row / 8) - 1)
                Dim bas = PanelGrille.GetControlFromPosition(col, (row / 8) + 1)

                Dim droite = PanelGrille.GetControlFromPosition(col + 1, row / 8)

                Dim hd = PanelGrille.GetControlFromPosition(col + 1, (row / 8) - 1)

                Dim bd = PanelGrille.GetControlFromPosition(col + 1, (row / 8) + 1)


                If TabMines(indBtn - 8) = 0 Then
                    haut.Text = ""
                Else
                    haut.Text = TabMines(indBtn - 8)

                End If
                haut.Enabled = False
                haut.BackColor = Color.Transparent



                If TabMines(indBtn + 8) = 0 Then
                    bas.Text = ""
                Else
                    bas.Text = TabMines(indBtn + 8)

                End If
                bas.Enabled = False
                bas.BackColor = Color.Transparent



                If TabMines(indBtn + 1) = 0 Then
                    droite.Text = ""
                Else
                    droite.Text = TabMines(indBtn + 1)

                End If
                droite.Enabled = False
                droite.BackColor = Color.Transparent



                If TabMines(indBtn - 7) = 0 Then
                    hd.Text = ""
                Else
                    hd.Text = TabMines(indBtn - 7)

                End If
                hd.Enabled = False
                hd.BackColor = Color.Transparent

                If TabMines(indBtn + 9) = 0 Then
                    bd.Text = ""
                Else
                    bd.Text = TabMines(indBtn + 9)

                End If
                bd.Enabled = False
                bd.BackColor = Color.Transparent
            End If

            'cas droite milieu, pas haut pas bas'
            If (indBtn + 1) Mod 8 = 0 And indBtn < 56 And indBtn > 7 Then

                Dim haut = PanelGrille.GetControlFromPosition(col, (row / 8) - 1)
                Dim bas = PanelGrille.GetControlFromPosition(col, (row / 8) + 1)
                Dim gauche = PanelGrille.GetControlFromPosition(col - 1, row / 8)

                Dim hg = PanelGrille.GetControlFromPosition(col - 1, (row / 8) - 1)

                Dim bg = PanelGrille.GetControlFromPosition(col - 1, (row / 8) + 1)



                If TabMines(indBtn - 8) = 0 Then
                    haut.Text = ""
                Else
                    haut.Text = TabMines(indBtn - 8)

                End If
                haut.Enabled = False
                haut.BackColor = Color.Transparent



                If TabMines(indBtn + 8) = 0 Then
                    bas.Text = ""
                Else
                    bas.Text = TabMines(indBtn + 8)

                End If
                bas.Enabled = False
                bas.BackColor = Color.Transparent



                If TabMines(indBtn - 1) = 0 Then
                    gauche.Text = ""
                Else
                    gauche.Text = TabMines(indBtn - 1)

                End If
                gauche.Enabled = False
                gauche.BackColor = Color.Transparent




                If TabMines(indBtn - 9) = 0 Then
                    hg.Text = ""
                Else
                    hg.Text = TabMines(indBtn - 9)

                End If
                hg.Enabled = False
                hg.BackColor = Color.Transparent


                If TabMines(indBtn + 7) = 0 Then
                    bg.Text = ""
                Else
                    bg.Text = TabMines(indBtn + 7)

                End If
                bg.Enabled = False
                bg.BackColor = Color.Transparent


            End If



        End If

        If perdu = False Then
            Dim puntos As Integer = 0
            'comptage des points pour les scores + condition de win
            For i As Integer = 0 To 7
                For j As Integer = 0 To 7
                    Dim bt = PanelGrille.GetControlFromPosition(j, i)
                    If bt.BackColor = Color.Transparent Then
                        puntos = puntos + 1
                    End If
                Next
            Next
            Console.WriteLine(puntos & " ?")

            compteCase = puntos
        End If



        'condition de win'
        If compteCase = 64 - ent Then
            Timer1.Stop()
            Dim mb = MsgBox("Partie gagnée bravo !!! :^)", MessageBoxButtons.OK, "Bien joué ! ;)")

            If mb = Windows.Forms.DialogResult.OK Then
                Console.WriteLine(démineur.Menu.saisirJoueur.Text & "eee")

                Dim j As Jr
                With j
                    .nom = démineur.Menu.saisirJoueur.Text
                    .nbCases = compteCase
                    .nbParties = .nbParties + 1
                    .temps = Integer.Parse(démineur.Menu.TextBox1.Text) - tmp

                End With
                Enregistrement.enregistrer(j)

                démineur.Menu.saisirJoueur.Items.Add(j.nom)

                Scores.TextBox1.Text = démineur.Menu.saisirJoueur.Text & " " & Me.getCompteCase() & " cases, 1 partie, " & Me.getTemps() & " secondes"

                Dim num As Integer = FreeFile()
                FileOpen(num, "Joueurs.txt", OpenMode.Append)

                Print(num, démineur.Menu.saisirJoueur.Text & " " & Me.getCompteCase() & " cases, 1 partie, " & Me.getTemps() & " secondes" & vbCrLf)

                FileClose(num)


                Me.Close()
                démineur.Menu.Visible = True
                démineur.Menu.saisirJoueur.Text = ""
            End If
        End If

    End Sub


    Private Sub ButtonAbd_Click(sender As Object, e As EventArgs) Handles ButtonAbd.Click


        Dim mb = MsgBox("Voulez vous abandonner ?", MessageBoxButtons.YesNo, "Abandon")
        If mb = Windows.Forms.DialogResult.Yes Then
            Me.Close()
            démineur.Menu.saisirJoueur.Text = ""
            démineur.Menu.Visible = True

            Timer1.Stop()

        End If


    End Sub


    Private Sub afficheHeure(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick

        If tmp = 0 Then

            Timer1.Stop()
            MsgBox("Temps écoulé !", , "Fin de la partie")

            If vbYes Then
                Me.Close()
                démineur.Menu.saisirJoueur.Text = ""
                démineur.Menu.Visible = True
            End If

        Else
            tmp -= 1
            TempsRestant.Text = tmp

        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Timer1.Stop()
        PanelGrille.Enabled = False
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Timer1.Start()
        PanelGrille.Enabled = True
    End Sub
End Class