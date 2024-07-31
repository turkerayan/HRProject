import React from 'react'

const HomeCardInformation = ({userData}) => {
    let address = userData.address.split("  ").slice(2)
    let addressShort = userData.address.split("  ").slice(0,2).join("/")
  return (
    <div className='card' style={{margin:"1rem"}}>
        <div className='card-header'>
            <p>Iletisim Bilgileri</p>
        </div>
        <div className='card-content'>
            <div className='card-text-body'>
            <div>
                <p>{address}<br /><b>{addressShort}</b> </p>
                <p className='sub-text'>{userData.email}</p>
            </div>
        </div>
        <div className='card-text-footer'>
            <p>-</p>
            <p>Tel: <b style={{fontWeight:"800",color:"#000"}}>{userData.phoneNumber}</b> </p>
        </div>
        </div>
    </div> 
  )
}

export default HomeCardInformation