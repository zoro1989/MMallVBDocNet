Public Interface IHomeService
    Function SelectHomeData(user As User) As ServerResponse(Of HomeDataDto)
End Interface
