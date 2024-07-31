
import React,{useContext} from 'react'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faCircleInfo,faTrash } from '@fortawesome/free-solid-svg-icons' 
import { NavLink } from 'react-router-dom'
import { ApiContext } from '../../../contexts/ApiContext'
import { DataContext } from '../../../contexts/DataContext'
import CompanyService from '../../../services/CompanyService'

const CompanyTableRow = ({company}) => {
  if (!company) {
    return null;
  }
  else{
    const {notify,ToastContainer} = useContext(DataContext)
    const {setCompanies} = useContext(ApiContext);
    const Delete = async (id)=>{
      var response = await CompanyService.DeleteCompany(id);
      if (response.status === 200) {
          setCompanies(prev => ({
            ...prev,
            data: prev.data.filter(company => company.id !== id) 
        }));   
      };
      notify(response.status !== 200 ? response.data : "Başarılı bir şekilde silindi", response.status !== 200 ? "error" : "success");

    }
  return (
  <tr>
    <td data-label="SIRKET ADI">{company.name} </td>
    <td data-label="SIRKET TEL NO">{company.phoneNumber}</td>
    <td data-label="SIRKET DURUMU">{company.isAktive ? "Aktif":"Pasif"}</td>
    {company.companyManger ? (
        <td data-label="SIRKET YONETICI">
          {company.companyManger.name} {company.companyManger.secondName} {company.companyManger.surname} {company.companyManger.secondSurname}
        </td>
      ) : (
        <td data-label="SIRKET YONETICI">Yönetici Yok</td>
      )}

    <td>
    <NavLink to={`/company/information/${company.id}`} className='btn btn-success' style={{fontSize:"14px",marginRight:"1rem"}} ><FontAwesomeIcon icon={faCircleInfo} /></NavLink>
    <button onClick={()=>{Delete(company.id)}} className='btn btn-danger' style={{fontSize:"14px"}} ><FontAwesomeIcon icon={faTrash} /></button></td>
</tr>
  )
}
}

export default CompanyTableRow


