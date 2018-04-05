Imports MMall

Public Class ShippingServiceImpl : Implements IShippingService
    Private _shippingDao As IShippingDao = New ShippingDaoImpl
    Public Function AddShipping(viewModel As CartAddViewModel) As ServerResponse(Of Shipping) Implements IShippingService.AddShipping
        Dim shipping As Shipping = New Shipping
        shipping.UserId = viewModel.UserId
        shipping.ReceiverName = viewModel.ReceiverName
        shipping.ReceiverPhone = viewModel.ReceiverPhone
        shipping.ReceiverMobile = viewModel.ReceiverPhone
        shipping.ReceiverProvince = viewModel.ReceiverProvince
        shipping.ReceiverCity = viewModel.ReceiverCity
        shipping.ReceiverDistrict = "高新区"
        shipping.ReceiverAddress = viewModel.ReceiverAddress
        shipping.ReceiverZip = viewModel.ReceiverZip
        If String.IsNullOrEmpty(viewModel.ShippingId) Then
            Dim newId As Integer = _shippingDao.InsertShipping(shipping)
            If newId = 0 Then
                Return ServerResponse(Of Shipping).CreateByErrorMessage("添加地址失败")
            End If
            shipping.Id = newId
            Return ServerResponse(Of Shipping).createBySuccess(shipping)
        Else
            shipping.Id = Convert.ToInt32(viewModel.ShippingId)
            Dim result As Boolean = _shippingDao.UpdateShipping(shipping)
            If Not result Then
                Return ServerResponse(Of Shipping).CreateByErrorMessage("更新地址失败")
            End If
            Return ServerResponse(Of Shipping).createBySuccess(shipping)

        End If

    End Function

    Public Function DeleteShipping(shippingId As String, userId As String) As ServerResponse(Of String) Implements IShippingService.DeleteShipping
        Dim result As Boolean = _shippingDao.DeleteShippingById(shippingId, userId)
        If Not result Then
            Return ServerResponse(Of String).CreateByErrorMessage("删除地址失败")
        End If
        Return ServerResponse(Of String).createBySuccess("删除地址成功")
    End Function

    Public Function GetShippingInfoById(shippingId As String, userId As String) As ServerResponse(Of Shipping) Implements IShippingService.GetShippingInfoById
        Dim shippingList As List(Of Shipping) = _shippingDao.GetShippingById(shippingId, userId)
        If shippingList.Count = 0 Then
            Return ServerResponse(Of Shipping).CreateByErrorMessage("获取地址信息失败")
        End If
        Return ServerResponse(Of Shipping).createBySuccess(shippingList(0))
    End Function
End Class
