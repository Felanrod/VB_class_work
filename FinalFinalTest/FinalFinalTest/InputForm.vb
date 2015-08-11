'Name: Joel Murphy
'Date: Dec. 13, 2012
'Purpose: Able to enter employee information and it is stored in a structure for the output form

Option Strict On

Public Class InputForm

    'Declare a structure
    Friend Structure EmployeeInfo
        Dim NameString As String
        Dim NumberString As String
        Dim HoursDecimal As Decimal
    End Structure

    'Declare constants
    Private Const MAX_EMPLOYEES_INT As Integer = 10I
    Private Const MIN_HOURS_DECIMAL As Decimal = 0D
    Private Const MAX_HOURS_DECIMAL As Decimal = 40D

    Friend EmployeesEntered(MAX_EMPLOYEES_INT - 1) As EmployeeInfo
    Friend NumOfEmployeeInt As Integer = 0I
    Private HoursWorkedDecimal As Decimal

    Private Sub ExitButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitButton.Click
        'Close the application
        Me.Close()
    End Sub

    Private Sub ClearButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearButton.Click
        'Clear all input boxes
        NameTextBox.Clear()
        NameTextBox.Focus()
        NumberTextBox.Clear()
        HoursTextBox.Clear()
    End Sub

    Private Sub SaveButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveButton.Click
        'Only maximum of 50 employees can be entered
        If NumOfEmployeeInt < MAX_EMPLOYEES_INT Then
            'Check if the Name TextBox is blank
            If NameTextBox.Text <> "" Then
                'Check if the Number TextBox is blank
                If NumberTextBox.Text <> "" Then
                    'Check if the Hours TextBox is blank
                    If HoursTextBox.Text <> "" Then

                        Try
                            'Get the hours worked
                            HoursWorkedDecimal = Decimal.Parse(HoursTextBox.Text)
                            'check if hours worked is positive
                            If HoursWorkedDecimal >= MIN_HOURS_DECIMAL Then
                                'check if Hours Worked is between 0 through 40
                                If HoursWorkedDecimal <= MAX_HOURS_DECIMAL Then

                                    'Put the textbox values into the structure
                                    EmployeesEntered(NumOfEmployeeInt).NameString = NameTextBox.Text
                                    EmployeesEntered(NumOfEmployeeInt).NumberString = NumberTextBox.Text
                                    EmployeesEntered(NumOfEmployeeInt).HoursDecimal = HoursWorkedDecimal
                                    NumOfEmployeeInt += 1
                                    ClearButton_Click(sender, e)

                                Else

                                    MessageBox.Show("Hours Worked may not exceed " & MAX_HOURS_DECIMAL & " hours", "Max Hours Exceeded", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                    With HoursTextBox
                                        .SelectAll()
                                        .Focus()
                                    End With

                                End If

                            Else
                                MessageBox.Show("Hours Worked must be a positive number", "Hours Not Positive", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                With HoursTextBox
                                    .SelectAll()
                                    .Focus()
                                End With

                            End If

                        Catch ex As FormatException
                            MessageBox.Show("Hours Worked must be a number", "Hours Input Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            With HoursTextBox
                                .SelectAll()
                                .Focus()
                            End With

                        End Try
                    Else

                        MessageBox.Show("Please enter the employee's hours worked", "Hours Input Empty", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        NameTextBox.Focus()

                    End If
                Else

                    MessageBox.Show("Please enter an employee's number", "Number Input Empty", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    NumberTextBox.Focus()
                End If
            Else
                MessageBox.Show("Please enter an employee's name", "Name Input Empty", MessageBoxButtons.OK, MessageBoxIcon.Information)
                NameTextBox.Focus()
            End If

        Else
            MessageBox.Show("Only " & MAX_EMPLOYEES_INT & " employees' information may be stored", "Finished Employee List", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub InputForm_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        'Set focus to the name TextBox when form loads
        NameTextBox.Focus()
    End Sub

    Private Sub DoneButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DoneButton.Click
        'Hide this form and show Output
        Me.Hide()
        OutputForm.Show()
    End Sub
End Class
