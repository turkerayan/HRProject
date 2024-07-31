import React,{useContext,useState} from 'react'
import { ApiContext } from '../../../contexts/ApiContext'
import AdvanceService from '../../../services/AdvanceService'
import { DataContext } from '../../../contexts/DataContext'
import { faSpinner } from '@fortawesome/free-solid-svg-icons';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
export const AdvanceReqForm = () => {
    const {setAdvances} = useContext(ApiContext);
    const {notify,ToastContainer} = useContext(DataContext);

    const [loading,setLoading] = useState(false);

    const [text, setText] = useState('');
    const [error, setError] = useState('');
    const minChars = 10;

    const handleForm = async (e)=>{
        e.preventDefault();
        setLoading(true);

        const formData = {
            type: e.target.type.selectedOptions[0].value,
            currency:e.target.currency.selectedOptions[0].value,
            description: e.target.description.value,
            money: e.target.money.value,
        };

        const response = await AdvanceService.AddAdvancePayment(formData);
        console.log(response)
        if (response.status ===201) {
            setAdvances(prev => ({ ...prev, data: [response.data, ...prev.data]}));  
        }

        notify(response.status !== 201 ? response.data : "Basarılı bir şekilde eklendi", response.status !== 201 ? "error" : "success");
        setLoading(false);
        
    };
    const handleChange = (e) => {
        const inputText = e.target.value;
        setText(inputText);
    
        // Check if the input meets the minimum character requirement
        if (inputText.length < minChars) {
          setError(`Minimum ${minChars} characters required.`);
        } else {
          setError('');
        }
      };
    
      const handleSubmit = (e) => {
        e.preventDefault();
        if (text.length >= minChars) {
          alert('Submitted: ' + text);
        } else {
          setError(`Minimum ${minChars} characters required.`);
        }
      };
    

  return (
    <div className='advanceform-container'>
        <h3>Avans Talep Formu</h3>
        <form onSubmit={handleForm}>
            <div className='advance-type'>
                <label>Avans Türü:</label>
                <select name='type' required>
                    <option value={1}>Bireysel</option>
                    <option value={2}>Kurumsal</option>
                </select>
            </div>
            <div className='advance-amount'>
                <label>Avans Tutarı:</label>
                <input type="number" name='money' required />
            </div>
            <div className='advance-type'>
                <label>Döviz Tipi:</label>
                <select  name='currency' required>
                    <option value={1}>Tl</option>
                    <option value={2}>Dolar</option>
                    <option value={3}>Euro</option>
                    <option value={4}>GBP</option>
                </select>
            </div>
            <div className='advance-desc'>
              <label htmlFor="">Açıklama</label>
                <textarea name='description' value={text} onSubmit={handleSubmit} onChange={handleChange} required/>
                {error && <p style={{ color: 'red' }}>{error}</p>}
            </div>
            <button type='submit' style={{width:"100%"}}  className={`btn btn-success ${!loading ? "" : "disable"}`}>{!loading ? "Onayla ":<FontAwesomeIcon className='spinner' icon={faSpinner} />}</button>
        </form>
        <ToastContainer/>
    </div>
  )
}

export default AdvanceReqForm