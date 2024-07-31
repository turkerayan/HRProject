import React from 'react'
import EmployeeTable from '../components/tables/EmployeeTable'
import AddEmployeeForm from '../components/forms/AddingForms/AddEmployeeForm'

const EmployeeManagement = () => {
  return (
    <div className='employee-content'>
        <AddEmployeeForm/>
        <EmployeeTable/>
    </div>
  )
}

export default EmployeeManagement