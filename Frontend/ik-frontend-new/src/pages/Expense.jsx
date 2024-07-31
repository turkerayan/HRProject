import React from 'react'
import ExpenseReqForm from "../components/forms/RequestForms/ExpenseReqForm"
import ExpenseTable from '../components/tables/ExpenseTable'

const Expense = () => {
  return (
    <div className='expense-content'>
        <ExpenseReqForm/>
        <ExpenseTable/>
    </div>
  )
}

export default Expense