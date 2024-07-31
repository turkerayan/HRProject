import React,{useContext} from 'react'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faXmark } from '@fortawesome/free-solid-svg-icons';
import PermissionService from '../../services/PermissionService';
import { ApiContext } from '../../contexts/ApiContext';
import { DataContext } from '../../contexts/DataContext';
const PermissionDeletedModal = ({modalOption,setModalOptions,title}) => {

    const {setPermissionRequests} = useContext(ApiContext);
    const {notify} = useContext(DataContext)
    const deletePermission= async () =>{
        const response = await PermissionService.DeletePermissionRequest(modalOption.id);
        if (response.status === 200) {
            setPermissionRequests(prev => ({
                ...prev,
                data: prev.data.filter(x => x.id !== modalOption.id)
            }));
            setModalOptions((...prev) => ({...prev,open:false}))
            notify(response.status !== 200 ? response.data : "Başarılı bir şekilde silindi", response.status !== 200 ? "error" : "success");
        }   
    }
  return (
    <div className={`modal${modalOption?.open ?" open":""}`}>
        <div className='modal-fade' onClick={()=>setModalOptions((...prev)=>({...prev,open:false}))} ></div>
        <div className='modal-content'>
            <div className='modal-header'>
                <h1>{title}</h1>
                <FontAwesomeIcon icon={faXmark} fontSize={"25px"} onClick={()=>setModalOptions((...prev)=>({...prev,open:false}))} />
            </div>
            <div className='model-body'>
                <p><span className='text-danger border' >{modalOption?.name}</span> talebini iptal etmek istediginize emin misiniz ?</p>
                <p>İptal ettikten sonra işlem geri alınamıyacaktır.</p>
            </div>
            <div className='model-footer'>
                <button onClick={deletePermission} className='btn btn-danger'>Iptal et</button>
                <button onClick={()=>setModalOptions((...prev)=>({...prev,open:false}))} className='btn btn-blue'>Vazgeç</button>
            </div>
        </div>
    </div>
  )
}

export default PermissionDeletedModal