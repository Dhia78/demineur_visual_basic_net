Module Enregistrement
    Public Structure Jr
        Dim nom As String
        Dim nbCases As Integer
        Dim nbParties As Integer
        Dim temps As Integer
    End Structure

    'Private Const PAS_EXT As Integer = 10
    Private tabJr(20) As Jr
    Private nbJ As Integer = 0


    Public Sub enregistrer(p As Jr)
        'If nbJ > UBound(tabJr) Then
        '    ReDim Preserve tabJr(nbJ + PAS_EXT)
        'End If

        tabJr(nbJ) = p
        nbJ += 1
    End Sub

    Public Function getJr(i As Integer) As Jr
        Debug.Assert(i >= 0 AndAlso i < nbJ)

        Return tabJr(i)
    End Function

    Public Function getNbJr() As Integer
        Return nbJ
    End Function

    Public Function getNom(i) As String
        Return tabJr(i).nom
    End Function

End Module
