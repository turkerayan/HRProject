import React, { useContext, useState } from 'react'
import ExpenseTableRow from './rows/ExpenseTableRow'
import { ApiContext } from "../../contexts/ApiContext";
import SwitchCaseHelper from "../../assets/js/SwitchCaseHelper";
import ExpenseDeletedModal from '../modals/ExpenseDeletedModal';

const ExpenseTable = () => {
    const { expenses } = useContext(ApiContext);
    const [approvStatus,setApprovStatus] = useState(0);
    const [modalOption,setModalOptions] = useState({
        id:"",
        name:"",
        open:false,
    });
    console.log(expenses)
if (expenses.status === 200) {
    let expensesList = [...expenses.data]
    expensesList = SwitchCaseHelper.filterList(approvStatus,expensesList);
        return (
            <div>
                <div className="table-header" style={{display:"flex",justifyContent:"space-between",alignItems:"center"}}>
                    <h1>HARCAMA TALEPLERİ TABLOSU</h1>
                    <ul style={{display:"flex",flexDirection:"row",gap:"0.5rem"}} >
                        <li><button onClick={()=>{setApprovStatus(0)}} className="btn btn-blue">Hepsi</button></li>
                        <li><button onClick={()=>{setApprovStatus(1)}} className="btn btn-success">Onay</button></li>
                        <li><button onClick={()=>{setApprovStatus(2)}} className="btn btn-warning">Bekleme</button></li>
                        <li><button onClick={()=>{setApprovStatus(3)}} className="btn btn-danger" >Red</button></li>
                    </ul>
                </div>
                <table>
                    <thead>
                        <tr>
                            <th scope="col">HARCAMA TÜRÜ</th>
                            <th scope="col">HARCAMA TUTARI</th>
                            <th scope="col">Fatura</th>
                            <th scope="col">ONAY DURUMU</th>
                            <th scope="col"></th>
                        </tr>
                    </thead>
                <tbody>
                    {expensesList.map(expen=> <ExpenseTableRow key={expen.id} expen={expen} setModalOptions={setModalOptions}  /> )}
                </tbody>
                </table>
                <ExpenseDeletedModal  modalOption={modalOption} setModalOptions={setModalOptions} title={"Dikkat izin talebi iptal ediliyor..."} />
            </div>
        )
    }

}

export default ExpenseTable