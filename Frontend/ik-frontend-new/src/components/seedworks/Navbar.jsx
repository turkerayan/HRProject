import React, {useContext, useState } from 'react'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faBars } from '@fortawesome/free-solid-svg-icons'
import { ApiContext } from '../../contexts/ApiContext'
import { useNavigate } from 'react-router-dom'
import { useEffect } from 'react'
const Navbar = ({handleWrap}) => {
const[toggle,setToggle] = useState(false)

const handleToggle = ()=>{
  setToggle(!toggle);
}
const {user,imgPath,setImgPath} = useContext(ApiContext);
const navigate = useNavigate()

const handleLogout = ()=>{
  sessionStorage.clear()
  navigate("/")
}

useEffect(()=>{
  setImgPath(`https://ikteam1.azurewebsites.net/images/profiles/${user?.data?.imgPath}`)
  //setImgPath(`https://localhost:7153/images/profiles/${user?.data?.imgPath}`)
},[user?.data?.imgPath])

function capitalizeFirstLetter(string) {
  if (string) {
    return string.charAt(0).toUpperCase() + string.slice(1);
  }
  return ""; 
  
}
function makeAllUppercase(string) {
  if(string){
    return string.toUpperCase();
  }
  return "";
}

  return (
    <React.Suspense fallback ={"loading"}>
        <nav className='navbar'>
        <FontAwesomeIcon onClick={handleWrap} icon={faBars} style={{fontSize:"20px",cursor:"pointer", color:"#333"}} />    
            <div className='profile'>
                <h4 className='name-container'> Hoşgeldin, {capitalizeFirstLetter(user?.data?.name)} {capitalizeFirstLetter(user?.data?.secondName)} {makeAllUppercase(user?.data?.surname)} {makeAllUppercase(user?.data?.secondSurname)} </h4>
                <div className='dropdown-container'>
                    <img onClick={handleToggle} src={imgPath} className="profile-picture" alt="user-picture"/>
                    <div className={`dropdown ${toggle ?"open" :""}`}>
                        <ul>
                            <li onClick={handleLogout}>Çıkış</li>
                        </ul>
                    </div>
                </div>
            </div>
        </nav>
    </React.Suspense>
  )
}

export default Navbar