import React, { useState } from 'react'
import AuthValidation from '../../../validations/AuthValidations';
import AuthService from '../../../services/AuthService';
import { faSpinner } from '@fortawesome/free-solid-svg-icons';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'


const RePasswordForm = ({isPassive,setIsPassive,notify}) => {
  const [errors,setErrors] = useState();
  const [loading,setLoading] = useState(false);

  const handleRePassword = async (e) =>{
    e.preventDefault();
    setLoading(true);
  
      const data = {
        email:e.target.rePasswordEmail.value
      }
    const validationErrors = AuthValidation.RePasswordValidation(data.email);

    setErrors(validationErrors)
    console.log(validationErrors)

    if (validationErrors.isValid && validationErrors.email ==="") {
      const response = await AuthService.RePasswordServiceAsycn(data);
      console.log(response)
      notify(response.status !== 200 ? response.data : "Email Gönderildi", response.status !== 200 ? "error" : "success");
    }

    setLoading(false);
 
  }
  return (
    <form onSubmit={handleRePassword}  className={`re-password-form ${isPassive ?"" :"passive"}`}>
        <h2>Yeni Şifre Al</h2>
        <h4>Email adresinizi girerek şifrenizi yenileyin</h4>
        <div className='form-group'>
            <label htmlFor="rePasswordEmail">Email Adresi</label>
            <input type="email" name="rePasswordEmail" id="rePasswordEmail" required placeholder='jhon@bilgeadamboost.com' />
            <span>{errors?.email}</span>
        </div>
        <button type='submit'  className={`btn btn-blue ${!loading ? "" : "disable"}`}>{!loading ? "Devam Et":<FontAwesomeIcon className='spinner' icon={faSpinner} />}</button>

        <button onClick={()=>setIsPassive(!isPassive)} type='button' className='btn btn-warning'>Giriş'e dön</button>

    </form>
  )
}

export default RePasswordForm