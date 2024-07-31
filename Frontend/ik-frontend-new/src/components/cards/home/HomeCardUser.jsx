import React from 'react'
const HomeCardUser = ({userDetail,imgPath}) => {
    
const birthdate = userDetail.birthdate.split("T")[0].split("-").reverse().join(".");
console.log(imgPath)
  return (
    <div className='card' style={{margin:"1rem"}}>
        <div className='card-header'>
            <p>Kullinici Bilgileri</p>
        </div>
        <div className='card-content'>
            <div className='card-text-body'>
                <div className='img-container'>
                    <img src={imgPath} alt="" /> 
                </div>
                <div>
                    <p>{userDetail.name} {userDetail.secondName} {userDetail.surname} {userDetail.secondSurname} </p>
                    <p className='sub-text'>{userDetail.job}</p>
                </div>
            </div>
            <div className='card-text-footer'>
                <p>Dogum Yeri: <b style={{fontWeight:"800",color:"#000"}}>{userDetail.placeOfBirth}</b> </p>
                <p>Doğum Yılı: <b style={{fontWeight:"800",color:"#000"}}>{birthdate}</b> </p>
            </div>
        </div>
    </div>
  )
}

export default HomeCardUser