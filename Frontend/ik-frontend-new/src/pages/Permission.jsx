import React from 'react'
import PermissionReqForm from '../components/forms/RequestForms/PermissionReqForm'
import PermissionTable from '../components/tables/PermissionTable'
import PermissionDeletedModal from '../components/modals/PermissionDeletedModal'

const Permission = () => {
  return (
    <div className='permission-content'>
        <PermissionReqForm/>
        <PermissionTable/>
        <PermissionDeletedModal/>
    </div>
  )
}

export default Permission