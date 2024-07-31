import React from 'react'
import AdvanceReqForm from "../components/forms/RequestForms/AdvanceReqForm"
import AdvanceTable from '../components/tables/AdvanceTable'

const Advance = () => {
  return (
    <div className='advance-content'>
        <AdvanceReqForm/>
        <AdvanceTable/>
    </div>
  )
}

export default Advance