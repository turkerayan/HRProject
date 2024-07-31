import React from 'react'

const HomeCardWork = ({userData,isInfo}) => {
    let role = sessionStorage.getItem("Role")
    role =  role.split(",")[0];
    switch (role) {
        case "CompanyManager":
            role = "Şirket Yöneticisi"
        break;
        case "Personel":
            role="Personel";
        break;
        default:
            role="Site Yöneticisi"
            break;
    }
    
  return (
    <div className={`card ${isInfo ?"":"close"}`} style={{margin:"1rem"}}>
        <div className='card-header'>
            <p>Çalışma Bilgileri</p>
        </div>
        <div className='card-content'>
            <div className='card-text-body'>
                <div>
                    <p>{userData.department} Departmanı</p>
                    <p className='sub-text'>{role}</p>
                </div>
            </div>
        <div className='card-text-footer'>
            <p>Şirket: <b style={{fontWeight:"800",color:"#000"}}>{userData.companyName}</b> </p>
            <p>Calisma Durumu: <b style={{fontWeight:"800",color:"#000"}}>{userData.isActive ?"Aktif":"Pasif"}</b> </p>
        </div>
        </div>
    </div> 
  )
}

export default HomeCardWork