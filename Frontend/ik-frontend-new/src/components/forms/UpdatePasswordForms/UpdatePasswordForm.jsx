import React,{useState,} from 'react'
import { Link, useParams } from 'react-router-dom';
import { faSpinner } from '@fortawesome/free-solid-svg-icons';
import { faEye,faEyeSlash } from '@fortawesome/free-regular-svg-icons';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import AuthService from '../../../services/AuthService';
import AuthValidation from '../../../validations/AuthValidations';

const UpdatePasswordForm = ({notify}) => {
    const {userid,resettoken}= useParams();
    const [togglePassword,setTogglePassword] = useState({password:false,repassword:false});
    const [isButton,setIsButton] = useState(true);
    const [errors,setErrors] = useState();
    const [loading,setLoading] = useState(false);

    const handleUpdatePassword = async (e)=>{

        e.preventDefault();

        setLoading(true);

        const dataValidation = {
            password: e.target.password.value.trim(),
            rePassword: e.target.repassword.value.trim()
        }

        const validationErrors = AuthValidation.UpdatePasswordValiddation(dataValidation);

        setErrors(validationErrors);

        if (validationErrors.isValid && validationErrors.password === "" && validationErrors.rePassword === "") {

            const data = { id: userid, resetToken: resettoken, newPassword: dataValidation.password};
            
            const response = await AuthService.UpdatePasswordServiceAsycn(data);

            notify(response.status !== 200 ? response.data : "Şifreniz Başarılı Bir Şekilde Güncellendi", response.status !== 200 ? "error" : "success");
            
            setIsButton(false);
        }

        setLoading(false);

    }
  return (
    <form onSubmit={handleUpdatePassword} className='update-password-form'>
        <div className='form-group'>
            <label htmlFor="password">Yeni Şifreniz</label>
            <div className='input-password-container'>
                <FontAwesomeIcon onClick={()=>setTogglePassword({...togglePassword,password:!togglePassword.password})} icon={!togglePassword.password? faEye:faEyeSlash} className='password-icons' />
                <input onCopy={(e)=>e.preventDefault()} onPaste={(e)=>e.preventDefault()} onCut={(e)=>e.preventDefault()} type={`${!togglePassword.password ?"password":"text"}`} name="password" id="password" placeholder='Password' required />
            </div>                <span>{errors?.password}</span>
        </div>
        <div className='form-group'>

            <label htmlFor="repassword">Şifrenizi Tekrarı</label>

            <div className='input-password-container'>
                <FontAwesomeIcon onClick={()=>setTogglePassword({...togglePassword,repassword:!togglePassword.repassword})}  icon={!togglePassword.repassword? faEye:faEyeSlash} className='password-icons' />
                <input onCopy={(e)=>e.preventDefault()} onPaste={(e)=>e.preventDefault()}  onCut={(e)=>e.preventDefault()} type={`${!togglePassword.repassword ?"password":"text"}`} name="repassword" id="repassword" placeholder='Password' required />
            </div>
            <span>{errors?.rePassword}</span>
        </div>
        {isButton ?
        <button type='submit'  className={`btn btn-blue ${!loading ? "" : "disable"}`}>{!loading ? "Giriş Yap ":<FontAwesomeIcon className='spinner' icon={faSpinner} />}</button> 
        :
        <Link className='btn btn-warning' to={"/"}>Girişe Dön</Link>
        }

    </form>
  )
}

export default UpdatePasswordForm