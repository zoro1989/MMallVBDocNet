Public Interface IUserDao
    Function CheckUsername(username As String) As List(Of User)
    Function CheckEmail(email As String) As List(Of User)

    Function SelectLogin(username As String, password As String) As List(Of User)

    Function InsertUser(viewModel As UserRegisterViewModel) As Boolean

    Function SelectQuestionByUsername(username As String) As List(Of User)
    Function CheckAnswer(username As String, question As String, answer As String) As List(Of User)
    Function UpdatePasswordByUsername(username As String, password As String) As Boolean
End Interface
