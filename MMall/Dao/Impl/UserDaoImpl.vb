﻿Imports System.Data.SqlClient
Imports MMall

Public Class UserDaoImpl : Implements IUserDao

    Private Const _baseColumnStr As String = "id, username, password, email, phone, question, answer, role, create_time, update_time"

    Public Function CheckEmail(email As String) As List(Of User) Implements IUserDao.CheckEmail
        Dim helper As SQLHelper = New SQLHelper
        Dim resList As List(Of User) = New List(Of User)
        Dim sqlStr As String = "select id from cjbmall_user where email=@email"
        Dim params() As SqlParameter = {New SqlParameter("@email", email)}
        Dim dt As DataTable = helper.ExecSelect(sqlStr, CommandType.Text, params)
        Return ConvertHelper.convertToList(Of User)(dt)
    End Function

    Private Function CheckUsername(username As String) As List(Of User) Implements IUserDao.CheckUsername
        Dim helper As SQLHelper = New SQLHelper
        Dim resList As List(Of User) = New List(Of User)
        Dim sqlStr As String = "select id from cjbmall_user where username=@username"
        Dim params() As SqlParameter = {New SqlParameter("@username", username)}
        Dim dt As DataTable = helper.ExecSelect(sqlStr, CommandType.Text, params)
        Return ConvertHelper.convertToList(Of User)(dt)
    End Function

    Private Function SelectLogin(username As String, password As String) As List(Of User) Implements IUserDao.SelectLogin
        Dim helper As SQLHelper = New SQLHelper
        Dim resList As List(Of User) = New List(Of User)
        Dim sqlStr As String = "select " & _baseColumnStr & " from cjbmall_user where username=@username and password=@password"
        Dim params() As SqlParameter = {New SqlParameter("@username", username), New SqlParameter("@password", password)}
        Dim dt As DataTable = helper.ExecSelect(sqlStr, CommandType.Text, params)
        Return ConvertHelper.convertToList(Of User)(dt)
    End Function

    Public Function InsertUser(viewModel As UserRegisterViewModel) As Boolean Implements IUserDao.InsertUser
        Dim helper As SQLHelper = New SQLHelper
        Dim sqlStr As String = "insert into cjbmall_user values(@username, @password, @email, @phone,@question,@answer,@role,@createTime,@updateTime)"
        Dim sqlParams() As SqlParameter = {New SqlParameter("@username", viewModel.Username),
            New SqlParameter("@password", viewModel.Password),
            New SqlParameter("@email", viewModel.Email),
            New SqlParameter("@phone", viewModel.Phone),
            New SqlParameter("@question", viewModel.Question),
            New SqlParameter("@answer", viewModel.Answer),
            New SqlParameter("@role", viewModel.Role),
            New SqlParameter("@createTime", Date.Now),
            New SqlParameter("@updateTime", Date.Now)}
        Dim result As Boolean = helper.ExecAddDelUpdate(sqlStr, CommandType.Text, sqlParams)
        Return result
    End Function

    Public Function SelectQuestionByUsername(username As String) As List(Of User) Implements IUserDao.SelectQuestionByUsername
        Dim helper As SQLHelper = New SQLHelper
        Dim resList As List(Of User) = New List(Of User)
        Dim sqlStr As String = "select question from cjbmall_user where username=@username"
        Dim params() As SqlParameter = {New SqlParameter("@username", username)}
        Dim dt As DataTable = helper.ExecSelect(sqlStr, CommandType.Text, params)
        Return ConvertHelper.convertToList(Of User)(dt)
    End Function

    Public Function CheckAnswer(username As String, question As String, answer As String) As List(Of User) Implements IUserDao.CheckAnswer
        Dim helper As SQLHelper = New SQLHelper
        Dim resList As List(Of User) = New List(Of User)
        Dim sqlStr As String = "select id from cjbmall_user where username=@username and question=@question and answer=@answer"
        Dim params() As SqlParameter = {New SqlParameter("@username", username),
            New SqlParameter("@question", question), New SqlParameter("@answer", answer)}
        Dim dt As DataTable = helper.ExecSelect(sqlStr, CommandType.Text, params)
        Return ConvertHelper.convertToList(Of User)(dt)
    End Function

    Public Function UpdatePasswordByUsername(username As String, password As String) As Boolean Implements IUserDao.UpdatePasswordByUsername
        Dim helper As SQLHelper = New SQLHelper
        Dim sqlStr As String = "update cjbmall_user set password=@passwordNew, update_time=@updateTime where username=@username"
        Dim sqlParams() As SqlParameter = {New SqlParameter("@username", username),
            New SqlParameter("@passwordNew", password),
            New SqlParameter("@updateTime", Date.Now)}
        Dim result As Boolean = helper.ExecAddDelUpdate(sqlStr, CommandType.Text, sqlParams)
        Return result
    End Function
End Class
