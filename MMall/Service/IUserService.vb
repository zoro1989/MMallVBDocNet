Public Interface IUserService
    Function Login(vieModel As UserLoginViewModel) As ServerResponse(Of UserLoginDto)
    Function Register(viewModel As UserRegisterViewModel) As ServerResponse(Of String)
    Function SelectQuestion(viewModel As ForgetPasswrodViewModel) As ServerResponse(Of String)
    Function CheckAnswer(viewModel As ForgetPasswrodViewModel) As ServerResponse(Of String)
    Function ForgetResetPassword(viewModel As ForgetPasswrodViewModel) As ServerResponse(Of String)
End Interface
