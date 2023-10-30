Public Class Falkon


    Dim navigateWindow As New Navigate


    Private Sub NavigateToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles NavigateToolStripMenuItem.Click
        If navigateWindow.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.myBrowser.Navigate(navigateWindow.txtUrl.Text)
        End If
        navigateWindow.Text = ""
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        AboutBox.ShowDialog()
    End Sub

    Private Sub Falkon_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.lblApplicationStatus.Text = "Ready"
    End Sub

    Private Sub myBrowser_Navigating(sender As Object, e As WebBrowserNavigatingEventArgs) Handles myBrowser.Navigating
        'modifying the label in the status with the URL entered by the user
        Me.lblApplicationStatus.Text = e.Url.Host.ToString
    End Sub

    Private Sub myBrowser_ProgressChanged(sender As Object, e As WebBrowserProgressChangedEventArgs) Handles myBrowser.ProgressChanged

        If e.CurrentProgress < e.MaximumProgress Then
            'check if the current progress in the progressbar is >= to the maximum if yes reset it with the min

            If pbStatus.Value >= pbStatus.Maximum Then
                pbStatus.Value = pbStatus.Minimum
            Else
                'just increse the progressBar
                pbStatus.PerformStep()
            End If

        Else
            'when the document is fully downloaded, reset the progressBar to the min(0)
            pbStatus.Value = pbStatus.Minimum

        End If
    End Sub

    Private Sub myBrowser_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles myBrowser.DocumentCompleted
        'get app title using the my namespace
        If My.Application.Info.Title <> "" Then
            Me.Text = My.Application.Info.Title + " - " + e.Url.Host.ToString
        Else
            'if the app title is missing use the app name , without the extension
            Me.Text = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName) + " - " + e.Url.Host.ToString
        End If
        Me.lblApplicationStatus.Text = "Ready"
    End Sub
End Class
