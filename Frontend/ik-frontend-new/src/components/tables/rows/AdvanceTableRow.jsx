import React from 'react'
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faTrashCan,faCheck,faXmark } from "@fortawesome/free-solid-svg-icons";
import SwitchCaseHelper from '../../../assets/js/SwitchCaseHelper'
const AdvanceTableRow = ({advance,setModalOptions}) => {
    let typeName = SwitchCaseHelper.workingTypes(advance.type);
    let currencyName = SwitchCaseHelper.currencyTypes(advance.currency)
    let approvalName =SwitchCaseHelper.approvalStatus(advance.approvalStatus)
    let role = sessionStorage.getItem("Role")

    const PopUpPersonal=( targertId, targerName)=>{
      setModalOptions((...prev)=>({...prev,name:targerName,id:targertId,open:true}))
  }

  const PopUpCompManager=( targertId, targerName)=>{
    setModalOptions((...prev)=>({...prev,name:targerName,id:targertId,open:true}))
}
  return (
    <tr key={advance.id} className={advance.approvalStatus===3 ? "bg-danger":advance.approvalStatus===1?"bg-success":""} >
        <td data-label="AVANS TÜRÜ">{typeName}</td>
        <td data-label="AVANS TUTARI">{advance.money} {currencyName} </td>
        <td data-label="AÇIKLAMA">{advance.description}</td>
        <td data-label="ONAY DURUMU">{approvalName}</td>
        {advance.approvalStatus === 2 && role==="CompanyManager"  ? <td onClick={()=>PopUpCompManager(advance.id,advance.description)} data-label="Onay durumu"><FontAwesomeIcon className="btn btn-warning" icon={faTrashCan} /></td>:
            <td data-label="Onay durumu" ><FontAwesomeIcon style={{pointerEvents:"none"}} className={advance.approvalStatus===1?"btn btn-white text-success":"btn btn-white text-danger"} icon={advance.approvalStatus===1?faCheck:faXmark} /></td>
            }
        {advance.approvalStatus === 2 && role==="Personal" ? <td onClick={()=>PopUpPersonal(advance.id,advance.description)} data-label="Onay durumu"><FontAwesomeIcon className="btn btn-warning" icon={faTrashCan} /></td>:
            <td data-label="Onay durumu" ><FontAwesomeIcon style={{pointerEvents:"none"}} className={advance.approvalStatus===1?"btn btn-white text-success":"btn btn-white text-danger"} icon={advance.approvalStatus===1?faCheck:faXmark} /></td>
            }
    </tr>
  )
}

export default AdvanceTableRow