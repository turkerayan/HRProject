import React from 'react'

import "../assets/styles/login.scss"

const Login = () => {

  return( 
    <div className="login-container">
      <h1>Login</h1>
        <form >
            <div className="form-group">
                <label htmlFor="email">Email:</label>
                <input type="email" id="email" name="email" required />
            </div>
            <div className="form-group">
                <label htmlFor="password">Password:</label>
                <input type="password" id="password" name="password" required />
            </div>
            <button type="submit" className="btn">Login</button>
            <button type="button" className="btn forgot-password">Forgot Password</button>
        </form>
    </div>
  )
}

export default Login