'Name: Joel Murphy
'Date: Dec. 13, 2012
'Purpose: To display the employee records that were stored in the structure in the Input Form

Option Strict On

Public Class OutputForm
    'Declare constants
    Private Const MIN_EMPLOYEES_INT As Integer = 0I
    Private Const MAX_EMPLOYEES_INT As Integer = 10I
    Private Const HOURLY_WAGE_DECIMAL As Decimal = 10.5D

    'Declare variables
    'EmployeesEntered is of the shared structure type in InputForm
    Private EmployeesEntered(MAX_EMPLOYEES_INT - 1) As InputForm.EmployeeInfo
    Private NumOfEmployeeInt As Integer
    Private RecordPlaceInt As Integer = 0I
    Private HoursWorkedDec As Decimal
    Private WeeklyPayDec As Decimal

    'Procedure that fills in the textboxes with the employee information
    Private Sub Display_Employee(ByVal index As Integer)

        NameTextBox.Text = EmployeesEntered(index).NameString
        NumberTextBox.Text = EmployeesEntered(index).NumberString
        HoursWorkedDec = EmployeesEntered(index).HoursDecimal
        HoursTextBox.Text = CStr(HoursWorkedDec)
        WeeklyPayDec = HoursWorkedDec * HOURLY_WAGE_DECIMAL
        PayTextBox.Text = CStr(WeeklyPayDec)


    End Sub

    'Click next and a new employee record will show up if there are any left
    Private Sub NextButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NextButton.Click
        If RecordPlaceInt <= NumOfEmployeeInt - 1 Then
            Display_Employee(RecordPlaceInt)
            RecordPlaceInt += 1
        Else
            MessageBox.Show("No more employee records to display", "No More Records", MessageBoxButtons.OK, MessageBoxIcon.Information)
            NextButton.Enabled = False
        End If



    End Sub

    Private Sub ExitButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitButton.Click
        'Closes the application
        Me.Close()

    End Sub

    Private Sub OutputForm_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        'When the output is closed so is the Input
        InputForm.Close()
    End Sub

    Private Sub OutputForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'When the form is activated
        NumOfEmployeeInt = InputForm.NumOfEmployeeInt
        For i As Integer = MIN_EMPLOYEES_INT To NumOfEmployeeInt
            EmployeesEntered(i) = InputForm.EmployeesEntered(i)
        Next i

        If RecordPlaceInt <= NumOfEmployeeInt - 1 Then
            Display_Employee(RecordPlaceInt)
            RecordPlaceInt += 1
        Else
            MessageBox.Show("No employee records to display", "No Records", MessageBoxButtons.OK, MessageBoxIcon.Information)
            NextButton.Enabled = False
        End If
    End Sub
End Class