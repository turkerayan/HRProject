import React, { useContext, useEffect, useState } from 'react';import { ApiContext } from '../contexts/ApiContext';
import { useParams } from 'react-router-dom';
import CompanyService from '../services/CompanyService';
import '../assets/sass/companyInfo.scss'
import CompanyManagerForm from '../components/forms/HomeForms/CompanyManagerForm';
import "../assets/css/App.css"

const CompanyInfo = () => {
  const { companyInfo } = useContext(ApiContext);
  const { companyid } = useParams();
  const [company, setCompany] = useState({
    status: "",
    data: "",
  });

  useEffect(() => {
    const fetchData = async () => {
      const companyInfo = await CompanyService.GetByIdCompany(companyid);
      setCompany({ status: companyInfo.status, data: companyInfo.data });
    };
    fetchData();
  }, [companyid]);

  if (company.status === 200) {
    const {
      name,
      mersisNo,
      taxNo,
      taxAdministration,
      imgPath,
      phoneNumber,
      email,
      address,
      personelCount,
      establishmentDate,
      contractStartDate,
      contractEndDate,
      personels,
      isAktive,
    } = company.data;

    return (
      <div className='companydetail-content' >
      <CompanyManagerForm/>
      <div className="companydetail-container" style={{width:"100%"}}>
        <div>  
            <div className={isAktive ? 'active' : 'inactive'}>
              <img src={`https://ikteam1.azurewebsites.net/images/companies/${imgPath}`} alt={`${name} logo`} className="company-logo" />
              <h2 className="company-name">{name}</h2>
            </div>
            <div className="details">
              <div className="labels">
                <p><strong>MERSIS No:</strong></p>
                <p><strong>Vergi No:</strong></p>
                <p><strong>Vergi Dairesi:</strong></p>
                <p><strong>Telefon:</strong></p>
                <p><strong>Email:</strong></p>
                <p><strong>Adres:</strong></p>
                <p><strong>Personel Sayısı:</strong></p>
                <p><strong>Kuruluş Tarihi:</strong></p>
                <p><strong>Sözleşme Başlangıç Tarihi:</strong></p>
                <p><strong>Sözleşme Bitiş Tarihi:</strong></p>
                <p><strong>Personeller:</strong></p>
              </div>
              <div className="values">
                <p>{mersisNo}</p>
                <p>{taxNo}</p>
                <p>{taxAdministration}</p>
                <p>{phoneNumber}</p>
                <p>{email}</p>
                <p>{address}</p>
                <p>{personelCount}</p>
                <p>{establishmentDate}</p>
                <p>{contractStartDate}</p>
                <p>{contractEndDate}</p>
                <p>{personels.map((personel,index) =>   
                  <span key={index}> {`${personel.name} ${personel.secondName} ${personel.surname}`} {index !== personels.length - 1 ? ', ' : ''} </span>)}</p>
              </div>
            </div>
          </div>
        </div>
      </div>
    );
  } else {
    return <div>Loading...</div>;
  }
};

export default CompanyInfo;

