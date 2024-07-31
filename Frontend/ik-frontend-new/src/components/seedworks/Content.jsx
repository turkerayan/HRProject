import React from 'react'

const Content = ({element,setIsWrap}) => {
  let width = window.innerWidth;

  return (
    <div className='content' onClick={width <= 770 ? ()=>{setIsWrap(true)}:null} >
        {element}
    </div>
  )
}

export default Content