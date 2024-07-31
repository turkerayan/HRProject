import React from 'react'
import {faTrashCan,faCheck,faXmark   } from '@fortawesome/free-solid-svg-icons'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import SwitchCaseHelper from '../../../assets/js/SwitchCaseHelper'

const ExpenseTableRow = ({expen,setModalOptions}) => {
  let typeName = SwitchCaseHelper.expenseTypes(expen.type);
  let currencyName = SwitchCaseHelper.currencyTypes(expen.currency);
  let approvalName =SwitchCaseHelper.approvalStatus(expen.approvalStatus);
  
  const PopUp=( targertId, targerName)=>{
    setModalOptions((...prev)=>({...prev,name:targerName,id:targertId,open:true}));
}
let imgPath =  `https://ikteam1.azurewebsites.net/images/expenses/${expen.imagePath}`
//let imgPath =  `https://localhost:7153/images/expenses/${expen.imagePath}`
    return (
        <tr className={expen.approvalStatus===3 ? "bg-danger":expen.approvalStatus===1?"bg-success":""} key={expen.id}>
            <td data-label="HARCAMA TÜRÜ">{typeName}</td>
            <td data-label="HARCAMA TUTARI">{expen.money} {currencyName}</td>
            <td style={{fontWeight:"600"}} className='img-table' data-label="Fatura"><a target='_blank' href={imgPath}>Fatura bilgisi</a></td>
            <td data-label="ONAY DURUMU">{approvalName}</td>
            {expen.approvalStatus === 2 ? <td onClick={()=>PopUp(expen.id,typeName)} data-label="Onay durumu"><FontAwesomeIcon className="btn btn-warning" icon={faTrashCan} /></td>:
                <td data-label="Onay durumu" ><FontAwesomeIcon style={{pointerEvents:"none"}} className={expen.approvalStatus===1?"btn btn-white text-success":"btn btn-white text-danger"} icon={expen.approvalStatus===1?faCheck:faXmark} /></td>
            }
        </tr>
    )
}

export default ExpenseTableRow