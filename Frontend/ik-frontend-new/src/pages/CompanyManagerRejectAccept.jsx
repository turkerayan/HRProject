import React from 'react'
import CompanyManageAdvanceTable from '../components/tables/CompanyManageAdvanceTable'
import CompanyManagerExpenseTable from '../components/tables/CompanyManagerExpenseTable'
import CompanyManagerPermissionTable from '../components/tables/CompanyManagerPermissionTable'

const CompanyManagerRejectAccept = () => {
  return (
    <div>
        <CompanyManageAdvanceTable/>
        <CompanyManagerExpenseTable/>
        <CompanyManagerPermissionTable/>
    </div>
  )
}

export default CompanyManagerRejectAccept