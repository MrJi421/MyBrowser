Public Class Falkon
    Dim navigateWindow As New Navigate
    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        AboutBox.ShowDialog()
    End Sub


    Private Sub NavigateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NavigateToolStripMenuItem.Click
        If navigateWindow.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.myBrowser.Navigate(navigateWindow.txtUrl.Text)
        End If
        navigateWindow.Text = ""
    End Sub

    Private Sub Falkon_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
