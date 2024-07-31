import React from 'react'
import SwitchCaseHelper from '../../../assets/js/SwitchCaseHelper'
import ExpenseService from '../../../services/ExpensesService'

const CompanyManagerExpenseTableRow = ({expense}) => {
  var expenseType = SwitchCaseHelper.expenseTypes(expense.type)
  const UpdateExpenseStatus = async (id,status)=>{
    var data ={
      id: id,
      approvalStatus:status 
    }
    const res = await ExpenseService.UpdateExpense(data)
  }
    return (
      <tr key={expense.id}>
        <td data-label="ISIM">{`${expense.userFirstName} ${expense.userSecondName} ${expense.userSurname} ${expense.userSecondSurname}`}</td>
          <td data-label="HARCAMA TÜRÜ">{expenseType}</td>
          <td data-label="HARCAMA TUTARI">{expense.money}</td>
          <td data-label="FATURA"><a target='_blank' href={`https://ikteam1.azurewebsites.net/images/expenses/${expense.imagePath}`}>Resim</a></td>
          <td className={expense.approvalStatus ===1 ?"bg-success":expense.approvalStatus ===3 ?"bg-danger":null } data-label="Cevaplanma Tarihi">{expense.responseDate.split("T")[0]}</td>
          <td>
            {expense.approvalStatus === 2 ? <button onClick={()=>{UpdateExpenseStatus(expense.id,1)}} className='btn btn-success'>Onayla</button> : null}
          </td>
          <td>{expense.approvalStatus === 2 ? <button onClick={()=>{UpdateExpenseStatus(expense.id,3)}} className='btn btn-danger'>Reddet</button> : null}
          </td>
      </tr>
    )

}

export default CompanyManagerExpenseTableRow