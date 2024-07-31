import React,{ useState } from 'react'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faEye,faEyeSlash } from '@fortawesome/free-regular-svg-icons'
import AuthService from '../../../services/AuthService';
import AuthValidation from '../../../validations/AuthValidations';
import { faSpinner } from '@fortawesome/free-solid-svg-icons';
import { useNavigate } from 'react-router-dom';

const LoginForm = ({isPassive,setIsPassive,notify}) => {
    const [togglePassword,setTogglePassword] = useState(false);
    const [errors,setErrors] = useState();
    const [loading,setLoading] = useState(false);
    const navigate = useNavigate();


    const handleLogin = async (e) => {
        e.preventDefault();

        setLoading(true);

        const data = { email: e.target.email.value.trim(), password: e.target.password.value.trim()};

        const validationErrors = AuthValidation.LoginValidation(data);

        setErrors(validationErrors);
        
        if (validationErrors.isValid && validationErrors.email ==="" && validationErrors.password ==="") {
            const response = await AuthService.LoginServiceAsync(data);       
            if (response.status === 200) {
                let user = JSON.parse(atob(response.data.token.split(".")[1]));
                window.sessionStorage.setItem("Token", response.data.token);
                window.sessionStorage.setItem("Email", user.email);
                window.sessionStorage.setItem("Role", user["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"]);
                window.sessionStorage.setItem("FullName", user["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name"]);
                window.sessionStorage.setItem("Expiration",response.data.expiration);
                
            }
            notify(response.status !== 200 ? response.data : "Giriş Başarılı", response.status !== 200 ? "error" : "success");
            if (response.status === 200 && sessionStorage.getItem("Token") !== null )  navigate("/home")
        }
        setLoading(false)
    };

  return (
    <form onSubmit={handleLogin}  className={`form-login ${!isPassive ? "" :"passive"}`}>
        <h2>MAIN CREW</h2>
        <div className='form-group'>
            <label htmlFor="email">Email Adresi</label>
            <input type="email" name="email" id="email" required placeholder='jhon@bilgeadamboost.com' />
            <span>{errors?.email}</span>
        </div>
        <div className='form-group'>
            <label htmlFor="password">Şifre</label>
            <div className='input-password-container'>
                <FontAwesomeIcon onClick={()=>setTogglePassword(!togglePassword)} icon={!togglePassword? faEye:faEyeSlash} className='password-icons' />
                <input type={`${!togglePassword ?"password":"text"}`} name="password" id="password" placeholder='Şifre' required />
            </div>
            <span>{errors?.password}</span>
        </div>
        <button type='submit'  className={`btn btn-blue ${!loading ? "" : "disable"}`}>{!loading ? "Giriş Yap ":<FontAwesomeIcon className='spinner' icon={faSpinner} />}</button>
        <button onClick={()=>{setIsPassive(!isPassive)}} type='button' className='btn btn-warning'>Şifremi Unuttum</button>
    </form>
  )
}

export default LoginForm