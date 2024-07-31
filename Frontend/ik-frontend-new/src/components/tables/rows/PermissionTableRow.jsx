import React from "react";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faTrashCan,faCheck,faXmark } from "@fortawesome/free-solid-svg-icons";
import SwitchCaseHelper from "../../../assets/js/SwitchCaseHelper";

const PermissionTableRow = ({ permission,setModalOptions }) => {
    let approvalStatu = SwitchCaseHelper.approvalStatus(permission.approvalStatus);

    const PopUp=( targertId, targerName)=>{
        setModalOptions((...prev)=>({...prev,name:targerName,id:targertId,open:true}))
    }
    

    return (
        <tr className={permission.approvalStatus===3 ? "bg-danger":permission.approvalStatus===1?"bg-success":""} key={permission.id}>
            <td data-label="Yıllık İzin">{permission.name}</td>
            <td data-label="Başlama Tarihi">{permission.permissionStart.split("T")[0]}</td>
            <td data-label="Bitiş Tarihi">{permission.permissionEnd.split("T")[0]}</td>
            <td data-label="Onay durumu"  style={{fontWeight:"600"}}>{approvalStatu}</td>
            {permission.approvalStatus === 2 ? <td onClick={()=>PopUp(permission.id,permission.name)} data-label="Onay durumu"><FontAwesomeIcon className="btn btn-warning" icon={faTrashCan} /></td>:
            <td data-label="Onay durumu" ><FontAwesomeIcon style={{pointerEvents:"none"}} className={permission.approvalStatus===1?"btn btn-white text-success":"btn btn-white text-danger"} icon={permission.approvalStatus===1?faCheck:faXmark} /></td>
            }
        </tr>
    );
};

export default PermissionTableRow;
