import React,{useContext} from 'react'
import CompanyManagerAdvanceTableRow from './rows/CompanyManagerAdvanceTableRow'
import { ApiContext } from '../../contexts/ApiContext';
import { DataContext } from '../../contexts/DataContext';


const CompanyManageAdvanceTable = () => {
  const {advancePaymentManager} = useContext(ApiContext)
  const {ToastContainer,notify} = useContext(DataContext)
  if (advancePaymentManager.status === 200) {
    return (
      <table>
        <thead>
            <tr>
                <th scope="col">İSİM</th>
                <th scope="col">AVANS TÜRÜ</th>
                <th scope="col">AVANS TUTARI</th>
                <th scope="col">AÇIKLAMA</th>
                <th scope="col">Cevaplanma Tarihi</th>
                <th scope="col"></th>
                <th scope="col"></th>
            </tr>
        </thead>
        <tbody>
          {advancePaymentManager.data.map((advancePayment)=> <CompanyManagerAdvanceTableRow notify={notify} advancePayment={advancePayment}/>)}
        </tbody>
        <ToastContainer/>
    </table>
        
      )
  }

}


export default CompanyManageAdvanceTable