import React from 'react'
import CompanyTable from '../components/tables/CompanyTable'
// import AddCompanyForm from '../components/forms/AddingForms/AddCompanyForm'
import CompanyForm from '../components/forms/HomeForms/CompanyForm'

const SiteManagement = () => {
  return (
    <div className='sitemanagement-content'>
      <CompanyForm/>
      <CompanyTable/>
    </div>
  )
}

export default SiteManagement