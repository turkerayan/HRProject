import React,{useContext} from 'react'

import ForgetPassword from "../assets/images/ForgetPassword.png"

import { DataContext } from '../contexts/DataContext';
import UpdatePasswordForm from '../components/forms/UpdatePasswordForms/UpdatePasswordForm';
const UpdatePassword = () => {
    const {notify,ToastContainer} = useContext(DataContext);

  return (
    <div className='update-password'>
        <div className='update-password-container'>
            <img  src={ForgetPassword} alt="" />
            <h2>Kariyer Yolculuğunuzun Kapısını Aralıyoruz</h2>
            <h4>Geleceğiniz İçin Güvenlik Anahtarı Burada</h4>
            <UpdatePasswordForm notify={notify}/>
        </div>
        <ToastContainer/>
    </div>
  )
}

export default UpdatePassword