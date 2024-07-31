import React from 'react'
import { Link } from 'react-router-dom'
const Page404 = () => {
  return (
    <div className='page-404' >
      <img src="https://ih1.redbubble.net/image.980012480.5663/st,small,507x507-pad,600x600,f8f8f8.u3.jpg" style={{margin:"auto"}} alt="" />
      <Link to={"/home"}>
      <button className='btn btn-danger'>Anasayfa'ya geri dön</button>
      </Link> 
    </div>
  )
}

export default Page404