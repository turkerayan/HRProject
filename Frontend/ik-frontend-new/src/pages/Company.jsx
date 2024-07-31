import React from 'react';
import CompanyForm from "../components/forms/HomeForms/CompanyForm";
import CompanyTable from '../components/tables/CompanyTable';

const Company = () => {
  return (
    <div className='company-content'>
        <CompanyForm/>
        <CompanyTable/>
    </div>
  );
}

export default Company;
