<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.bgwL7P = New System.ComponentModel.BackgroundWorker
        Me.bgwL6P = New System.ComponentModel.BackgroundWorker
        Me.bgwG4P = New System.ComponentModel.BackgroundWorker
        Me.bgwGBP = New System.ComponentModel.BackgroundWorker
        Me.lstStatus = New System.Windows.Forms.ListBox
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
        Me.SuspendLayout()
        '
        'bgwL7P
        '
        Me.bgwL7P.WorkerReportsProgress = True
        Me.bgwL7P.WorkerSupportsCancellation = True
        '
        'bgwL6P
        '
        Me.bgwL6P.WorkerReportsProgress = True
        Me.bgwL6P.WorkerSupportsCancellation = True
        '
        'bgwG4P
        '
        Me.bgwG4P.WorkerReportsProgress = True
        Me.bgwG4P.WorkerSupportsCancellation = True
        '
        'bgwGBP
        '
        Me.bgwGBP.WorkerReportsProgress = True
        Me.bgwGBP.WorkerSupportsCancellation = True
        '
        'lstStatus
        '
        Me.lstStatus.FormattingEnabled = True
        Me.lstStatus.Location = New System.Drawing.Point(3, 6)
        Me.lstStatus.Name = "lstStatus"
        Me.lstStatus.Size = New System.Drawing.Size(389, 121)
        Me.lstStatus.TabIndex = 0
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ProgressBar1.Location = New System.Drawing.Point(0, 132)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(396, 14)
        Me.ProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.ProgressBar1.TabIndex = 1
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(396, 146)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.lstStatus)
        Me.Name = "Form1"
        Me.Text = "REQ2PO Workflow"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents bgwL7P As System.ComponentModel.BackgroundWorker
    Friend WithEvents bgwL6P As System.ComponentModel.BackgroundWorker
    Friend WithEvents bgwG4P As System.ComponentModel.BackgroundWorker
    Friend WithEvents bgwGBP As System.ComponentModel.BackgroundWorker
    Friend WithEvents lstStatus As System.Windows.Forms.ListBox
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar

End Class
