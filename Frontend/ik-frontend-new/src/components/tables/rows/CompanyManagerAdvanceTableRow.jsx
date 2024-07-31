import React from 'react'
import SwitchCaseHelper from '../../../assets/js/SwitchCaseHelper'
import AdvanceService from '../../../services/AdvanceService'
const CompanyManagerAdvanceTableRow = ({advancePayment,notify}) => {
  var advancePaymentType = SwitchCaseHelper.workingTypes(advancePayment.type)
  const UpdateAdvanceStatus = async(id,status)=>{
    var data ={
      id: id,
      approvalStatus:status 
    }
    var response = await AdvanceService.UpdateAdvancePayment(data);
    notify(response.status !== 200 ? response.data : "İşlem Tamamlandı", response.status !== 200 ? "error" : "success");
    if (response.status ===200) {
      setTimeout(()=>{
        window.location.reload();
      },[1500])
    }
  }

  return (
    <tr>
      <td data-label="ISIM">{`${advancePayment.userFirstName} ${advancePayment.userSecondName} ${advancePayment.userSurname} ${advancePayment.userSecondSurname}`}</td>
        <td data-label="AVANS TÜRÜ">{advancePaymentType}</td>
        <td data-label="AVANS TUTARI">{advancePayment.money}</td>
        <td data-label="AÇIKLAMA">{advancePayment.description}</td>
        <td className={advancePayment.approvalStatus ===1 ?"bg-success":advancePayment.approvalStatus ===3 ?"bg-danger":null } data-label="Cevaplanma Tarihi">{advancePayment?.responseDate?.split("T")[0]}</td>
        <td>
            {advancePayment.approvalStatus === 2 ? <button onClick={()=>{UpdateAdvanceStatus(advancePayment.id,1)}} className='btn btn-success'>Onayla</button> : null}
          </td>
          <td>{advancePayment.approvalStatus === 2 ? <button onClick={()=>{UpdateAdvanceStatus(advancePayment.id,3)}} className='btn btn-danger'>Reddet</button> : null}
          </td>
    </tr>
  )
}

export default CompanyManagerAdvanceTableRow