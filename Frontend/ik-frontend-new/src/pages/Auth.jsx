import React, { useState,useContext } from 'react'
import LoginForm from '../components/forms/AuthForms/LoginForm'
import RePasswordForm from '../components/forms/AuthForms/RePasswordForm'
import { DataContext } from '../contexts/DataContext';

const Login = () => {
  const [isPassive,setIsPassive] = useState(false);
  
  const {notify,ToastContainer} = useContext(DataContext)
    
  return (
    <div className='login-container'>
        <div className='form-container'>
            <LoginForm isPassive ={isPassive} setIsPassive={setIsPassive} notify={notify}  />
            <RePasswordForm isPassive ={isPassive} setIsPassive={setIsPassive} notify={notify} />
        </div>
        <div className='login-right-container'>
            
        </div>
        <ToastContainer/>
    </div>
  )
}

export default Login