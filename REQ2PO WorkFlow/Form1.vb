Public Class Form1
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Finish()
        Dim cn As New OAConnection.Connection
        cn.ExecuteInServer("Delete from tmpWorkFlow_Reqs")
        bgwL7P.RunWorkerAsync()
        bgwL6P.RunWorkerAsync()
        bgwG4P.RunWorkerAsync()
        bgwGBP.RunWorkerAsync()
    End Sub

    Private Sub bgwL7P_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgwL7P.DoWork
        Const SAPBox As String = "L7P"
        Dim REQ As New SAPCOM.OpenReqs_Report(SAPBox, "CF9019", "LAT")
        Dim cn As New OAConnection.Connection

        Dim Plts As New DataTable
        Dim POrg As New DataTable
        Dim PGrp As New DataTable

        Plts = cn.RunSentence("Select Valor From vst_ReqWorkFlow Where ((SAPBox = '" & SAPBox & "') And (Campo = 'Planta'))").Tables(0)
        PGrp = cn.RunSentence("Select Valor From vst_ReqWorkFlow Where ((SAPBox = '" & SAPBox & "') And (Campo = 'PurchGrp'))").Tables(0)
        POrg = cn.RunSentence("Select Valor From vst_ReqWorkFlow Where ((SAPBox = '" & SAPBox & "') And (Campo = 'PurchOrg'))").Tables(0)

        REQ.IncludePurchGroup("")
        REQ.IncludePurchOrg("")

        For Each R As DataRow In Plts.Rows
            REQ.IncludePlant(R("Valor").ToString.PadLeft(4))
        Next

        For Each R As DataRow In PGrp.Rows
            REQ.IncludePurchGroup(R("Valor").ToString.PadLeft(3))
        Next

        For Each R As DataRow In POrg.Rows
            REQ.IncludePurchOrg(R("Valor"))
        Next

        bgwL7P.ReportProgress(0, "Geeting L7P req workflow")
        REQ.Execute()
        If REQ.Success Then
            Dim cSAPBox As New DataColumn
            cSAPBox.ColumnName = "SAPBox"
            cSAPBox.Caption = "SAPBox"
            cSAPBox.DefaultValue = SAPBox
            REQ.Data.Columns.Add(cSAPBox)
            bgwL7P.ReportProgress(0, "Uploading L7P req workflow")
            cn.AppendTableToSqlServer("tmpWorkFlow_Reqs", REQ.Data)
        End If
    End Sub
    Private Sub bgwL6P_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgwL6P.DoWork
        Const SAPBox As String = "L6P"

        Dim cn As New OAConnection.Connection

        Dim Plts As New DataTable
        Dim POrg As New DataTable
        Dim PGrp As New DataTable

        Plts = cn.RunSentence("Select Valor From vst_ReqWorkFlow Where ((SAPBox = '" & SAPBox & "') And (Campo = 'Planta'))").Tables(0)
        PGrp = cn.RunSentence("Select Valor From vst_ReqWorkFlow Where ((SAPBox = '" & SAPBox & "') And (Campo = 'PurchGrp'))").Tables(0)
        POrg = cn.RunSentence("Select Valor From vst_ReqWorkFlow Where ((SAPBox = '" & SAPBox & "') And (Campo = 'PurchOrg'))").Tables(0)

        For Each R As DataRow In Plts.Rows
            Dim REQ As New SAPCOM.OpenReqs_Report(SAPBox, "CF9019", "LAT")

            REQ.IncludePurchGroup("")
            REQ.IncludePurchOrg("")

            REQ.IncludePlant(R("Valor").ToString.PadLeft(4))

            For Each Rw As DataRow In PGrp.Rows
                REQ.IncludePurchGroup(Rw("Valor").ToString.PadLeft(3))
            Next

            For Each Rw As DataRow In POrg.Rows
                REQ.IncludePurchOrg(Rw("Valor"))
            Next
            bgwL6P.ReportProgress(0, "Geeting L6P req workflow: " & R("Valor"))
            REQ.Execute()
            If REQ.Success Then
                If Not REQ.Data Is Nothing Then
                    Dim cSAPBox As New DataColumn
                    cSAPBox.ColumnName = "SAPBox"
                    cSAPBox.Caption = "SAPBox"
                    cSAPBox.DefaultValue = SAPBox
                    REQ.Data.Columns.Add(cSAPBox)
                    bgwL6P.ReportProgress(0, "Uploading L6P req workflow: " & R("Valor"))
                    cn.AppendTableToSqlServer("tmpWorkFlow_Reqs", REQ.Data)
                End If
            End If
        Next

    End Sub
    Private Sub bgwG4P_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgwG4P.DoWork
        Const SAPBox As String = "G4P"
        Dim REQ As New SAPCOM.OpenReqs_Report(SAPBox, "CF9019", "LAT")
        Dim cn As New OAConnection.Connection

        Dim Plts As New DataTable
        Dim POrg As New DataTable
        Dim PGrp As New DataTable

        Plts = cn.RunSentence("Select Valor From vst_ReqWorkFlow Where ((SAPBox = '" & SAPBox & "') And (Campo = 'Planta'))").Tables(0)
        PGrp = cn.RunSentence("Select Valor From vst_ReqWorkFlow Where ((SAPBox = '" & SAPBox & "') And (Campo = 'PurchGrp'))").Tables(0)
        POrg = cn.RunSentence("Select Valor From vst_ReqWorkFlow Where ((SAPBox = '" & SAPBox & "') And (Campo = 'PurchOrg'))").Tables(0)

        REQ.IncludePurchGroup("")
        REQ.IncludePurchOrg("")


        For Each R As DataRow In Plts.Rows
            REQ.IncludePlant(R("Valor").ToString.PadLeft(4))
        Next

        For Each R As DataRow In PGrp.Rows
            REQ.IncludePurchGroup(R("Valor").ToString.PadLeft(3))
        Next

        For Each R As DataRow In POrg.Rows
            REQ.IncludePurchOrg(R("Valor"))
        Next
        bgwG4P.ReportProgress(0, "Geeting G4P req workflow")
        REQ.Execute()
        If REQ.Success Then
            Dim cSAPBox As New DataColumn
            cSAPBox.ColumnName = "SAPBox"
            cSAPBox.Caption = "SAPBox"
            cSAPBox.DefaultValue = SAPBox
            bgwG4P.ReportProgress(0, "Uploading G4P req workflow")
            REQ.Data.Columns.Add(cSAPBox)
            cn.AppendTableToSqlServer("tmpWorkFlow_Reqs", REQ.Data)
        End If
    End Sub
    Private Sub bgwGBP_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgwGBP.DoWork
        Const SAPBox As String = "GBP"
        Dim REQ As New SAPCOM.OpenReqs_Report(SAPBox, "CF9019", "LAT")
        Dim cn As New OAConnection.Connection

        Dim Plts As New DataTable
        Dim POrg As New DataTable
        Dim PGrp As New DataTable

        Plts = cn.RunSentence("Select Valor From vst_ReqWorkFlow Where ((SAPBox = '" & SAPBox & "') And (Campo = 'Planta'))").Tables(0)
        PGrp = cn.RunSentence("Select Valor From vst_ReqWorkFlow Where ((SAPBox = '" & SAPBox & "') And (Campo = 'PurchGrp'))").Tables(0)
        POrg = cn.RunSentence("Select Valor From vst_ReqWorkFlow Where ((SAPBox = '" & SAPBox & "') And (Campo = 'PurchOrg'))").Tables(0)

        REQ.IncludePurchGroup("")
        REQ.IncludePurchOrg("")

        For Each R As DataRow In Plts.Rows
            REQ.IncludePlant(R("Valor").ToString.PadLeft(4))
        Next

        For Each R As DataRow In PGrp.Rows
            REQ.IncludePurchGroup(R("Valor").ToString.PadLeft(3))
        Next

        For Each R As DataRow In POrg.Rows
            REQ.IncludePurchOrg(R("Valor"))
        Next

        bgwGBP.ReportProgress(0, "Geeting GBP req workflow")
        REQ.Execute()
        If REQ.Success Then
            Dim cSAPBox As New DataColumn
            cSAPBox.ColumnName = "SAPBox"
            cSAPBox.Caption = "SAPBox"
            cSAPBox.DefaultValue = SAPBox
            REQ.Data.Columns.Add(cSAPBox)
            bgwGBP.ReportProgress(0, "Uploading GBP req workflow")
            cn.AppendTableToSqlServer("tmpWorkFlow_Reqs", REQ.Data)
        End If
    End Sub

    Private Sub Finish()
        If Not bgwG4P.IsBusy AndAlso Not bgwGBP.IsBusy AndAlso Not bgwL6P.IsBusy AndAlso Not bgwL7P.IsBusy Then
            lstStatus.Items.Insert(0, "Workflow downloaded. Updating records.")
            Dim Closed As New DataTable
            Dim cn As New OAConnection.Connection

            lstStatus.Items.Insert(0, "Updating new items.")
            cn.ExecuteStoredProcedure("Append_New_Reqs")
            cn.ExecuteInServer("Update WorkFlow_Reqs set [Upload date] = {fn Now()} Where [Upload date] is null")
            lstStatus.Items.Insert(0, "Updating service line.")
            cn.ExecuteInServer("Update WorkFlow_Reqs set [Service Line] = (case when left(Material,1) = 3 Then 'Store room' else 'Self service' end) Where [Service Line] is null")

            Closed = cn.RunSentence("Select * From vst_Workflow_Req_Closed").Tables(0)
            lstStatus.Items.Insert(0, "Closing reqs.")
            If Closed.Rows.Count > 0 Then
                For Each R As DataRow In Closed.Rows
                    cn.ExecuteInServer("Update WorkFlow_Reqs Set [Close date] = {fn now()} Where (([Close Date] is Null) And (SAPBox = '" & R("SAPBox") & "') and ([Req Number] = " & R("Req Number") & ") And ([Item Number] = " & R("Item Number") & "))")
                Next
            End If
            End
        End If
    End Sub

    Private Sub bgwL7P_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles bgwL7P.ProgressChanged
        lstStatus.Items.Insert(0, e.UserState)
    End Sub

    Private Sub bgwL7P_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgwL7P.RunWorkerCompleted
        Finish()
    End Sub

    Private Sub bgwG4P_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles bgwG4P.ProgressChanged
        lstStatus.Items.Insert(0, e.UserState)
    End Sub
    Private Sub bgwG4P_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgwG4P.RunWorkerCompleted
        Finish()
    End Sub

    Private Sub bgwGBP_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles bgwGBP.ProgressChanged
        lstStatus.Items.Insert(0, e.UserState)
    End Sub
    Private Sub bgwGBP_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgwGBP.RunWorkerCompleted
        Finish()
    End Sub

    Private Sub bgwL6P_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles bgwL6P.ProgressChanged
        lstStatus.Items.Insert(0, e.UserState)
    End Sub
    Private Sub bgwL6P_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgwL6P.RunWorkerCompleted
        Finish()
    End Sub
End Class
