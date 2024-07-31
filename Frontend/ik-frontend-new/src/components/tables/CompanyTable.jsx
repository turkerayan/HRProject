import React, { useState,useContext } from 'react'
import { ApiContext } from '../../contexts/ApiContext'
import CompanyTableRow from './rows/CompanyTableRow'
import { DataContext } from '../../contexts/DataContext'

const CompanyTable = () => {
    const {companies} = useContext(ApiContext)
    const {ToastContainer} = useContext(DataContext)
    const [page,SetPage] = useState();
    if (companies.status === 200) {
        return (
            <div>
               <div className="table-header" style={{display:"flex",justifyContent:"space-between",alignItems:"center"}}>
                   <h1>ŞİRKETLER TABLOSU</h1>
               </div>
               <table>
                   <thead>
                       <tr>
                           <th scope="col">ADI</th>
                           <th scope="col">Telefon Numarası</th>
                           <th scope="col">DURUMU</th>
                           <th scope="col">YÖNETİCİ</th>
                           <th scope="col">-</th>
                       </tr>
                   </thead>
                   <tbody>
                       {companies.data.map(company =>  <CompanyTableRow key={company.id} company={company} />)}         
                   </tbody>
               </table>
               <ToastContainer/>

           </div>
        )
    }
}

export default CompanyTable


