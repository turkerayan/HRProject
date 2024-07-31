import React from 'react'

//çalışan ekleme formu yazıldı (düzenlenmesi gerek)
const EmployeeTableRow = ({personal}) => {

  return (
    <tr>
        <td data-label="CALISAN ADI">{personal.name}</td>
        <td data-label="CALISAN SOYADI">{personal.surname}</td>
        <td data-label="CALISAN DEPARTMAN">{personal.department}</td>
        <td data-label="CALISAN MESLEK">{personal.job}</td>
    </tr>
  )
}

export default EmployeeTableRow