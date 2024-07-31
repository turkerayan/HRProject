import React,{useContext, useState} from 'react'
import { ApiContext } from '../../../contexts/ApiContext'
import PermissionService from '../../../services/PermissionService';
import { DataContext } from '../../../contexts/DataContext';
import { faSpinner } from '@fortawesome/free-solid-svg-icons';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'

const PermissionReqForm =  () => {
    const {permissionType,setPermissionRequests} = useContext(ApiContext);
    const {notify,ToastContainer} = useContext(DataContext)
    const [loading,setLoading] = useState(false);

    const handleForm = async (e)=>{
        e.preventDefault();
        setLoading(true);

        const formData = {
            permissionTypeId: e.target.permissionType.selectedOptions[0].id,
            appUserId:"6cdcef6d-d638-4957-af24-b5b735ca0647",
            permissionStart:e.target.startDate.value,
            permissionEnd:e.target.endDate.value
        };
   

        const response = await PermissionService.CreatePermissionRequest(formData);
        if (response.status ===201) {
            setPermissionRequests(prev => ({ ...prev, data: [response.data,...prev.data]}));  
            }


        notify(response.status !== 201 ? response.data : "Basarılı bir şekilde eklendi", response.status !== 201 ? "error" : "success");
        setLoading(false);
    }
    const handleStartDateChange = (e) => {
        const startDate = new Date(e.target.value);
        const endDate = new Date(startDate);
        endDate.setDate(startDate.getDate() + 7);
        document.getElementById('end-date').value = endDate.toISOString().split('T')[0];
    };
    // function permissionDays() {
    //     const startDate = new Date(document.getElementById('startDate').value);
    //     const endDate = new Date(document.getElementById('endDate').value);
    //     if(startDate===Date.now()){
    //         document.getElementById('permdays').innerText= "İzinler aynı gün'den başlayamaz!";
    //         return;
    //     }
    //     if (startDate > endDate) {
    //         document.getElementById('permdays').innerText = "Başlangıç günü bitiş gününden önce olmalıdır!";
    //         return;
    //     }
    
    //     let workingDays = 0;
    
    //     const currentDate = new Date(startDate);
    //     while (currentDate <= endDate) {
    //         const dayOfWeek = currentDate.getDay();
    //         if (dayOfWeek !== 0 && dayOfWeek !== 6) {
    //             workingDays++;
    //         }
    //         currentDate.setDate(currentDate.getDate() + 1);
    //     }
    
    //     document.getElementById('result').innerText = `İzin gün sayısı: ${workingDays}`;
    // }

    if (permissionType.data !== "") {
        return (
            <div className='permform-container'>
                <h3>İzin Talep Formu</h3>
                <form onSubmit={handleForm}>
                    <div className='permission-type'>
                        <label>İzin Türü:</label>
                        <select name='permissionType' required>
                            {permissionType?.data?.map((type)=>{
                                return <option id={type.id} key={type.id} >{type.name}</option>
                            })}
                        </select>
                    </div>
                    <div className='permission-dates'>
                        <div className='date'>
                            <label>Başlama Tarihi:</label>
                            <input  id='start-date' name='startDate' type="date" required onChange={handleStartDateChange}/>
                        </div>
                        <div className='date'>
                            <label>Bitiş Tarihi:</label>
                            <input id='end-date' name='endDate' type="date" required/>
                        </div>
                    </div>
                    <button type='submit' style={{width:"100%"}}  className={`btn btn-success ${!loading ? "" : "disable"}`}>{!loading ? "Onayla ":<FontAwesomeIcon className='spinner' icon={faSpinner} />}</button>
                    <p id='permdays'></p>
                </form>
                <ToastContainer/>
            </div>
          )
    }


}

export default PermissionReqForm