import React,{useContext} from 'react'
import CompanyManagerExpenseTableRow from './rows/CompanyManagerExpenseTableRow'
import { ApiContext } from '../../contexts/ApiContext'
import { DataContext } from '../../contexts/DataContext'
const CompanyManagerExpenseTable = () => {
const {expensesManager} = useContext(ApiContext)
const {notify}  = useContext(DataContext)
if (expensesManager.status === 200) {
  return (
    <table>
        <thead>
            <tr>
                <th scope="col">İSİM</th>
                <th scope="col">HARCAMA TÜRÜ</th>
                <th scope="col">HARCAMA TUTARI</th>
                <th scope="col">FATURA</th>
                <th scope="col">Cevaplanma TARİHİ</th>
                <th scope="col"></th>
                <th scope="col"></th>
            </tr>
        </thead>
        <tbody>
          {expensesManager.data.map((expense)=>{
            return <CompanyManagerExpenseTableRow expense={expense}/>
          })}
                    
        </tbody>
    </table>
  )
}

}

export default CompanyManagerExpenseTable