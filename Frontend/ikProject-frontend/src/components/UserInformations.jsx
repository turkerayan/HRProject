import React, { useReducer } from 'react'

const UserInformations = () => {
    const userInformation = ""
  
    
  
    return (
userInformation
?
    <div className='information-card'>
        <img src={apiImagePath+userInformation.imgPath} alt="" />
    </div>
    :
    <div>Yükleniyor...</div>
  )
}

export default UserInformations