import React,{useContext,useState} from 'react'
import AdvanceTableRow from './rows/AdvanceTableRow'
import { ApiContext } from '../../contexts/ApiContext'
import SwitchCaseHelper from '../../assets/js/SwitchCaseHelper'
import AdvanceDeletedModal from '../modals/AdvanceDeletedModal'
const AdvanceTable = () => {
    const {advances} = useContext(ApiContext);
    const [approvStatus,setApprovStatus] = useState(0);
    const [modalOption,setModalOptions] = useState({
        id:"",
        name:"",
        open:false,
    });
    if (advances.status === 200) {
 
        let advanceList = [...advances.data]
        advanceList = SwitchCaseHelper.filterList(approvStatus,advanceList)
        return (
            <div>
                <div className="table-header" style={{display:"flex",justifyContent:"space-between",alignItems:"center"}}>
                    <h1>AVANS TALEPLERİ TABLOSU</h1>
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
                            <th scope="col">AVANS TÜRÜ</th>
                            <th scope="col">AVANS TUTARI</th>
                            <th scope="col">AÇIKLAMA</th>
                            <th scope="col">ONAY DURUMU</th>
                            <th scope="col"></th>
                        </tr>
                    </thead>
                    <tbody>
                        {advanceList.map((advance)=>{
                        return <AdvanceTableRow key={advance.id} advance={advance} setModalOptions={setModalOptions} />
                        })}
                    </tbody>
                </table>
                <AdvanceDeletedModal modalOption={modalOption} setModalOptions={setModalOptions} title={"Avans Talebini iptal ediliyor..."} />
            </div>
        )
    }
}

export default AdvanceTable