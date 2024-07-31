import React,{useState,useContext, useEffect} from 'react'
import EmployeeTableRow from './rows/EmployeeTableRow';
import { ApiContext } from '../../contexts/ApiContext';
import EmployeeService from '../../services/EmployeeService';
const EmployeeTable = () => {
const{user,personals,setPersonals} = useContext(ApiContext)
    //burayı arama motoru eklemeye çalıştım 
  const [searchTerm, setSearchTerm] = useState('');
  const [filterCategory, setFilterCategory] = useState('');
  let companyId = user?.data?.company?.id

  useEffect(()=>{
    const fetchData = async () => {
      if (companyId !==null) {
        let user = JSON.parse(atob(sessionStorage.getItem("Token").split(".")[1]));
          const userId =  user["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"];
          console.log(userId);
          if(userId!==undefined){
            const tempPersonals = await EmployeeService.GetByIdCompany(userId);
            setPersonals({status: tempPersonals.status, data: tempPersonals.data.personels});
          }
        
        
      }
    }
    fetchData();

  },[companyId])


  const handleSearch = (event) => {
    setSearchTerm(event.target.value);
  };

  const handleFilter = (event) => {
    setFilterCategory(event.target.value);
  };


  // const filteredItems = items
  //   .filter((item) => {
  //     return (
  //       item.name.toLowerCase().includes(searchTerm.toLowerCase()) &&
  //       (filterCategory === '' || item.category === filterCategory)
  //     );
  //   })
  //   .map((item) => (
  //     <li key={item.id}>
  //       {item.name} - {item.category}
  //     </li>
  //   ));
  if (personals.status === 200 && user.status === 200) {
    console.log(personals.data)

    return (
      <div>
        <div className="table-header" style={{display:"flex",justifyContent:"space-between",alignItems:"center"}}>
            <h1>ÇALIŞANLAR TABLOSU</h1>
        </div>
        <table>
            <thead>
                <tr>
                    <th scope="col">ADI</th>
                    <th scope="col">SOYADI</th>
                    <th scope="col">DEPARTMAN</th>
                    <th scope="col">MESLEK</th>
                </tr>
            </thead>
            <tbody>
                {personals.data?.map((personal)=><EmployeeTableRow key={personal.id} personal={personal}/>)}
    
            </tbody>
        </table>
    </div>
      )   
  }


}

export default EmployeeTable