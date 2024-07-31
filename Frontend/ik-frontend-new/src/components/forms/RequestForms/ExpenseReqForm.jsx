import React,{useContext,useState,useRef} from 'react'
import { ApiContext } from '../../../contexts/ApiContext'
import ExpenseService from '../../../services/ExpensesService';
import { DataContext } from '../../../contexts/DataContext'
import { faSpinner } from '@fortawesome/free-solid-svg-icons';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'

export const ExpenseReqForm = () => {
    const {setExpenses} = useContext(ApiContext);
    const {notify,ToastContainer} = useContext(DataContext);
    const FormRef = useRef()
    const [loading,setLoading] = useState(false);

    const handleForm = async (e)=>{
        e.preventDefault();
        setLoading(true);

        let formObejct = Object.fromEntries(new FormData(FormRef.current).entries());

        const formData = {
            type: e.target.type.selectedOptions[0].value,
            currency:e.target.currency.selectedOptions[0].value,
            money: e.target.money.value,
            image:formObejct.image
        };
        console.log(formData)
        const response = await ExpenseService.AddExpenses(formData);
        console.log(response)
        if (response.status ===201) {
            setExpenses(prev => ({ ...prev, data: [ response.data,...prev.data]}));  
            }

        notify(response.status !== 201 ? response.data : "Basarılı bir şekilde eklendi", response.status !== 201 ? "error" : "success");
        setLoading(false);
    }
  return (
    <div className='expenseform-container'>
        <h3>Harcama Talep Formu</h3>
        <form onSubmit={handleForm} ref={FormRef}>
            <div className='expense-type'>
                <label>Harcama Türü:</label>
                <select name='type' required>
                    <option value={1} >Yemek</option>
                    <option value={2} >Konaklama</option>
                    <option value={3} >Seyahat</option>
                </select>
            </div>
            <div className='expense-amount'>
            <label>Harcama Tutarı:</label>
            <input type="number" name='money' required />
            
            <label>Döviz Tipi:</label>
            <select name='currency' required>
                <option value={1}>Türk Lirası</option>
                <option value={2}>Dolar</option>
                <option value={3}>Euro</option>
                <option value={4}>GBP</option>
            </select>
            </div>
            <div>
            <input className='expense-reciept' type="file" name='image' accept=".png, .jpeg , .jpg, .pdf" required/>
            </div>
            <button type='submit' style={{width:"100%"}}  className={`btn btn-success ${!loading ? "" : "disable"}`}>{!loading ? "Onayla ":<FontAwesomeIcon className='spinner' icon={faSpinner} />}</button>
        </form>
        <ToastContainer/>

    </div>
  )
}
export default ExpenseReqForm
