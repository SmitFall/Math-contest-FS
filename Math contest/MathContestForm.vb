'Fallon Smith
'RCET 0265
'Spring 2022
'Math Contest
'

Option Explicit On
Option Strict On


Public Class MathContestForm
    Dim Attempts As Integer = 0
    Dim CorrectAnswer As Integer = 0

    Private Sub MathContestForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        'When form loads grey certain buttons and radio buttons
        AddRadioButton.Checked = True
        SubmitButton.Enabled = False
        SummeryButton.Enabled = False
        AddRadioButton.Enabled = False
        SubtractRadioButton.Enabled = False
        MultiplyRadioButton.Enabled = False
        DivideRadioButton.Enabled = False

    End Sub
    Private Sub StudentInformationGroupBox_Leave(sender As Object, e As EventArgs) Handles StudentInformationGroupBox.Leave
        ' If student Check comes back true then radio buttons enable & so does submit button
        Dim status As Boolean = False
        If StudentCheck() = False Then
            status = False
            MsgBox($"Sorry {NameTextBox}, but you are either in the wrong grade or to old")
        Else
            status = True
            AddRadioButton.Enabled = True
            SubtractRadioButton.Enabled = True
            MultiplyRadioButton.Enabled = True
            DivideRadioButton.Enabled = True
            SubmitButton.Enabled = True
            randomizenumbers()
        End If
    End Sub


    Function randomizenumbers() As Action
        'Generates random numbers
        Randomize()

        FirstNumberTextBox.Text = CStr(Int((100 - 0 + 1) * Rnd() + 1))
        SecondNumberTextBox.Text = CStr(Int((100 - 0 + 1) * Rnd() + 1))

    End Function
    Function StudentCheck() As Boolean
        Dim GoodAge As Boolean = False
        Dim GoodGrade As Boolean = False

        'verifies that the student is of age and in the right grade
        Select Case CInt(AgeTextBox.Text)

            Case 4 To 11
                GoodAge = True
            Case Else
                GoodAge = False
        End Select

        Select Case CInt(GradeTextBox.Text)
            Case 1 To 4
                GoodGrade = True
            Case Else
                GoodGrade = False
        End Select


        Return GoodAge And GoodGrade
    End Function


    Private Sub SubmitButton_Click(sender As Object, e As EventArgs) Handles SubmitButton.Click
        Dim FirstNumber As Integer
        Dim SecondNumber As Integer
        Dim studentAnswer As Integer
        FirstNumber = CInt(FirstNumberTextBox.Text)
        SecondNumber = CInt(SecondNumberTextBox.Text)
        studentAnswer = CInt(StudentsAnswerTextBox.Text)

        If AddRadioButton.Checked = True Then
            If studentAnswer = (FirstNumber + SecondNumber) Then
                MsgBox($"You are correct the answer is {FirstNumber + SecondNumber}")
                CorrectAnswer = (CorrectAnswer + 1)
                SummeryButton.Enabled = True
            ElseIf studentAnswer <> (FirstNumber + SecondNumber) Then
                MsgBox($"Sorry but the answer is {FirstNumber + SecondNumber}")
                SummeryButton.Enabled = True
            End If

        End If

        If SubtractRadioButton.Checked = True Then
            If studentAnswer = (FirstNumber - SecondNumber) Then
                MsgBox($"You are correct the answer is {FirstNumber - SecondNumber}")
                CorrectAnswer = (CorrectAnswer + 1)
                SummeryButton.Enabled = True
            ElseIf studentAnswer <> (FirstNumber - SecondNumber) Then
                MsgBox($"Sorry but the answer is {FirstNumber - SecondNumber}")
                SummeryButton.Enabled = True
            End If

        End If

        If MultiplyRadioButton.Checked = True Then
            If studentAnswer = (FirstNumber * SecondNumber) Then
                MsgBox($"You are correct the answer is {FirstNumber * SecondNumber}")
                CorrectAnswer = (CorrectAnswer + 1)
                SummeryButton.Enabled = True
            ElseIf studentAnswer <> (FirstNumber + SecondNumber) Then
                MsgBox($"Sorry but the answer is {FirstNumber * SecondNumber}")
                SummeryButton.Enabled = True
            End If

        End If

        If DivideRadioButton.Checked = True Then
            If studentAnswer = (FirstNumber / SecondNumber) Then
                MsgBox($"You are correct the answer is {FirstNumber / SecondNumber}")
                CorrectAnswer = (CorrectAnswer + 1)
                SummeryButton.Enabled = True
            ElseIf studentAnswer <> (FirstNumber + SecondNumber) Then
                MsgBox($"Sorry but the answer is {FirstNumber / SecondNumber}")
                SummeryButton.Enabled = True

            End If

        End If
        Attempts = (Attempts + 1)
        randomizenumbers()


    End Sub
    Private Sub SummeryButton_Click(sender As Object, e As EventArgs) Handles SummeryButton.Click
        'Displays to the user who they are and how many questions they got right compared to the ones they got wrong
        MsgBox($"{NameTextBox} you got {CorrectAnswer} out of {Attempts}")
    End Sub

    Private Sub ExitButton_Click(sender As Object, e As EventArgs) Handles ExitButton.Click
        Me.Close()
    End Sub

    Private Sub ClearButton_Click(sender As Object, e As EventArgs) Handles ClearButton.Click
        'resets text boxes
        NameTextBox.Text = ""
        FirstNumberTextBox.Text = ""
        SecondNumberTextBox.Text = ""
        GradeTextBox.Text = ""
        AgeTextBox.Text = ""
        StudentsAnswerTextBox.Text = ""

    End Sub

End Class
