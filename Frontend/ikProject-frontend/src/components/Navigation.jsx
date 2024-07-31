import React from 'react'
import {Link} from "react-router-dom"
import  "../assets/styles/navigation.scss"
const Navigation = () => {
  return (
    <nav className="navigation-bar">
      <div className='top-nav'></div>
      <div className='menu'>
        <Link to="/">Home</Link>
        <Link to="/login">Login</Link>
        <Link to="/settings">Settings</Link>
        <Link to="/information">User Information</Link>
        </div>
      </nav>
  )
}

export default Navigation