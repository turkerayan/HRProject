import React,{useContext} from 'react'
import CompanyManagerPermissionTableRow from './rows/CompanyManagerPermissionTableRow'
import { ApiContext } from '../../contexts/ApiContext'
import { DataContext } from '../../contexts/DataContext'
const CompanyManagerPermissionTable = () => {
  const {permissionManager} = useContext(ApiContext)
  const {notify,ToastContainer} = useContext(DataContext)
  console.log(permissionManager)
  if (permissionManager.status === 200) {
    return (
      <table>
          <thead>
              <tr>
                <th scope="col">İSİM</th>
                  <th scope="col">İZİN TÜRÜ</th>
                  <th scope="col">BAŞLAMA TARİHİ</th>
                  <th scope="col">BİTİŞ TARİHİ</th>
                  <th scope="col">CEVAPLANMA TARİHİ	</th>
                  <th scope="col"></th>
                  <th scope="col"></th>
              </tr>
          </thead>
          <tbody>
            {permissionManager.data.map((permission)=> <CompanyManagerPermissionTableRow notify={notify} permission={permission}/>)}
          </tbody>
          <ToastContainer/>
      </table>
    )
  }

}

export default CompanyManagerPermissionTable