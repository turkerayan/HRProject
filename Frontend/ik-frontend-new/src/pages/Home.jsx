import React, { useContext, useState,useRef } from 'react'
import "../assets/sass/home.scss"
import AdminDetail from "../components/AdminDetail.jsx"
import { ApiContext } from '../contexts/ApiContext.jsx'
import HomeCardInformation from '../components/cards/home/HomeCardInformation.jsx'
import HomeCardWork from '../components/cards/home/HomeCardWork.jsx'
import HomeCardUser from '../components/cards/home/HomeCardUser.jsx'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faCircleInfo,faPenToSquare } from '@fortawesome/free-solid-svg-icons'
import HomeCardUserDetail from '../components/cards/home/HomeCardUserDetail.jsx'
import HomeUpdateForm from '../components/forms/HomeForms/HomeUpdateForm.jsx'
const Home = () => {
const {setUser,setImgPath,imgPath,user} = useContext(ApiContext);
const [isInfo,setIsInfo] = useState(false)
const [isUpdateForm,setIsUpdateForm] = useState(false)

if (user.status === 200) {
    const userDetail = {...user.data};
    return ( 
        <div className='home-container' >
            <HomeCardUser userDetail={userDetail} imgPath={imgPath}  />
            <HomeCardInformation userData={userDetail} /> 
            <HomeCardUserDetail userData={userDetail} isInfo={isInfo} />
            <HomeCardWork userData={userDetail} isInfo={isInfo} />
            <HomeUpdateForm isUpdateForm={isUpdateForm} userData={userDetail} setImgPath={setImgPath} setUser={setUser}/>
            <button onClick={()=>{setIsInfo(!isInfo)}} className='btn btn-success home-info-btn' >
                <FontAwesomeIcon icon={faCircleInfo} className='info-icon' />
                <span>Detay</span>
            </button>
            <button onClick={()=>{setIsUpdateForm(!isUpdateForm)}} className='btn btn-warning home-update-btn'>
                <FontAwesomeIcon icon={faPenToSquare} className='info-icon' />
                <span>Güncelleme</span>
            </button>


            {/*
            {
                user?.data!=='' ?<AdminDetail adminDetails={user?.data} imgPath={imgPath} setImgPath={setImgPath} setUser={setUser} /> :<></>
                }
                */}
        </div>
            
    
        )
}


}

export default Home