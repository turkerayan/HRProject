import React, { useState } from 'react'
import {  Navigate,useNavigate } from 'react-router-dom';
import Navbar from './Navbar';
import Sidebar from './Sidebar';
import Content from './Content';
import ApiContextProvider from '../../contexts/ApiContext';

const PrivateRoute = ({ element}) => {

    const[isWrap,setIsWrap] = useState();

    const navigate = useNavigate();

    const handleWrap = ()=>{
        setIsWrap(!isWrap);
    };
    let expTime =new Date(sessionStorage.getItem("Expiration")).getTime() - Date.now() ;

    const timeOut = setTimeout(()=>{
        sessionStorage.clear()
        clearTimeout(timeOut)
        navigate("/")
    },expTime)

  return sessionStorage.getItem("Token") ? 
  <ApiContextProvider>
    <div className='container'>
          <Sidebar  isWrap={isWrap} />
          <div className={`container-body ${isWrap ? "wrap": "" }`} >
              <Navbar handleWrap={handleWrap} />
              <Content element={element} setIsWrap={setIsWrap}  />
          </div>
    </div> 
  </ApiContextProvider>
    : 
  <Navigate to="/"/>
}

export default PrivateRoute