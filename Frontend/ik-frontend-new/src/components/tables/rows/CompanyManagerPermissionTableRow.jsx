import React from 'react'
import PermissionService from '../../../services/PermissionService'
const CompanyManagerPermissionTableRow = ({permission,notify}) => {
  const UpdatePermissionStatus = async (id,status)=>{
    var data ={
      permissinRequestId: id,
      approvalStatus:status 
    }
    console.log(data)
    const response = await PermissionService.PermissionRequestUpdate(data)
    notify(response.status !== 200 ? response.data : "İşlem Tamamlandı", response.status !== 200 ? "error" : "success");
    if (response.status ===200) {
      setTimeout(()=>{
        window.location.reload();
      },[1500])
    }
  }
  console.log(permission.permissionStart.split("T")[0])
  return (
    <tr>
      <td data-label="ISIM"> {`${permission.userFirstName} ${permission.userSecondName??""} ${permission.userSurname} ${permission.userSecondSurname??""}`}</td>
        <td data-label="İZİN TÜRÜ">{permission.name}</td>
        <td data-label="BAŞLAMA TARİHİ">{permission.permissionStart.split("T")[0]}</td>
        <td data-label="BİTİŞ TARİHİ">{permission.permissionEnd.split("T")[0]}</td>
        <td className={permission.approvalStatus ===1 ?"bg-success":permission.approvalStatus ===3 ?"bg-danger":null } data-label="CEVAPLANMA TARİHİ">{permission.replyDate.split("T")[0]}</td>
        <td>
            {permission.approvalStatus === 2 ? <button onClick={()=>{UpdatePermissionStatus(permission.id,1)}} className='btn btn-success'>Onayla</button> : null}
          </td>
          <td>{permission.approvalStatus === 2 ? <button onClick={()=>{UpdatePermissionStatus(permission.id,3)}} className='btn btn-danger'>Reddet</button> : null}
          </td>
    </tr>
  )
}

export default CompanyManagerPermissionTableRow