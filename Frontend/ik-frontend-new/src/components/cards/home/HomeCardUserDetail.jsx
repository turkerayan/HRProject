import React from 'react'
import { Link } from 'react-router-dom';
const HomeCardUserDetail = ({userData,isInfo}) => {
    let startJob =userData.startAJob.split("T")[0].split("-").reverse().join(".");

    let leavingJob=null
    if (userData.leavingJob !==null) 
        leavingJob = userData.leavingJob.split("T")[0].split("-").reverse().join(".");
    const role =sessionStorage.getItem("Role")
  return (
    <div className={`card ${isInfo ?"":"close"}`} style={{margin:"1rem"}}>
    <div className='card-header'>
        <p>Kullanıcı Kişisel Bilgiler</p>
    </div>
    <div className='card-content'>
        <div className='card-text-body'>
            <div>
                <p>Tc Kimlik No: <span>{userData.identityNo}</span> </p>
                {role === "Personal" ?           <button style={{fontFamily:"monospace"}} className='btn btn-blue'>
                    <Link to="/permission"  style={{color:"#fff"}}>İzin Taleplerim</Link>

                </button> :null}
     
            </div>
        </div>
    <div className='card-text-footer'>
        <p>İşe giriş tarihi: <b style={{fontWeight:"800",color:"#000"}}>{startJob}</b> </p>
        <p>İşten Çıkış tarihi: <b style={{fontWeight:"800",color:"#000"}}>{leavingJob === null ?"-":leavingJob}</b> </p>
    </div>
    </div>
</div> 
  )
}

export default HomeCardUserDetail