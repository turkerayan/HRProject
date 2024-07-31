import React, { useContext, useState, useEffect } from "react";
import PermissionTableRow from "./rows/PermissionTableRow";
import { ApiContext } from "../../contexts/ApiContext";
import PermissionDeletedModal from "../modals/PermissionDeletedModal";
import SwitchCaseHelper from "../../assets/js/SwitchCaseHelper";
const PermissionTable = () => {
    const { permissionRequests , user } = useContext(ApiContext);
    const [approvStatus,setApprovStatus] = useState(0);
    const [modalOption,setModalOptions] = useState({
        id:"",
        name:"",
        open:false,
    });
    const [days ,setDays] =useState(0);

    useEffect(() => {
        if (user && user.data && user.data.startAJob) {
            let startYear = parseInt(user.data.startAJob.split("-")[0], 10);
            let currentYear = new Date().getFullYear();
            let permissionDaysLeft = (currentYear - startYear) * 14;

            if (permissionRequests && permissionRequests.status === 200) {
                let approvedPermissions = permissionRequests.data.filter(permission => permission.approvalStatus === 1);

                let approvedDays = approvedPermissions.reduce((total, permission) => {
                    let startDate = new Date(permission.permissionStart);
                    let endDate = new Date(permission.permissionEnd);
                    let diffTime = Math.abs(endDate - startDate);
                    let diffDays = Math.ceil(diffTime / (1000 * 60 * 60 * 24)) + 1;
                    return total + diffDays;
                }, 0);

                permissionDaysLeft -= approvedDays;
            }

            setDays(permissionDaysLeft);
        }
    }, [user, permissionRequests]);

    if (permissionRequests.status === 200) {
        let permissionRequestFilter = [...permissionRequests.data]; 
        permissionRequestFilter = SwitchCaseHelper.filterList(approvStatus,permissionRequestFilter)
   

        return (
            <div style={{background:"#fff",padding:"1rem",borderRadius:"12px"}}>
                <div className="table-header" >
                    <h3>İZİN TALEPLERİ TABLOSU    Kalan izin:{isNaN(days) ? 0 : days}</h3>
                    <ul style={{display:"flex",flexDirection:"row",gap:"0.5rem"}} >
                        <li><button onClick={()=>setApprovStatus(0)} className="btn btn-blue">Hepsi</button></li>
                        <li><button onClick={()=>setApprovStatus(1)} className="btn btn-success">Onay</button></li>
                        <li><button onClick={()=>setApprovStatus(2)} className="btn btn-warning">Bekleme</button></li>
                        <li><button onClick={()=>setApprovStatus(3)} className="btn btn-danger" >Red</button></li>
                    </ul>
                </div>
                <table>
                    <thead>
                        <tr>
                            <th scope="col">İZİN TÜRÜ</th>
                            <th scope="col">BAŞLAMA TARİHİ</th>
                            <th scope="col">BİTİŞ TARİHİ</th>
                            <th scope="col">ONAY DURUMU</th>
                            <th scope="col"></th>
                        </tr>
                    </thead>
                    <tbody>
                        {permissionRequestFilter.map((permission) => {
                            return (
                                <PermissionTableRow key={permission.id} permission={permission} setModalOptions={setModalOptions}  />
                            );
                        })}
                    </tbody>
                </table>
                <PermissionDeletedModal modalOption={modalOption} setModalOptions={setModalOptions} title={"Dikkat izin talebi iptal ediliyor..."}  />
            </div>
        );
    }
};

export default PermissionTable;
