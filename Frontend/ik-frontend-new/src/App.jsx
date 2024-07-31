import { Route, Routes } from "react-router-dom"
import "./assets/css/App.css"
import Auth from "./pages/Auth"
import PrivateRoute from "./components/seedworks/PrivateRoute"
import Home from "./pages/Home"
import UpdatePassword from "./pages/UpdatePassword"
import Page404 from "./pages/errors/Page404"
import Permission from "./pages/Permission"
import Advance from "./pages/Advance"
import Expense from "./pages/Expense"
import EmployeeManagement from "./pages/EmployeeManagement"
import SiteManagement from "./pages/SiteManagement"
import CompanyManagerForm from "./components/forms/HomeForms/CompanyManagerForm"
import CompanyInfo from "./pages/CompanyInfo"
import CompanyManagerRejectAccept from "./pages/CompanyManagerRejectAccept"
import CompanyManagerExpenseTable from "./components/tables/CompanyManagerExpenseTable"
import CompanyManagerPermissionTable from "./components/tables/CompanyManagerPermissionTable"
import CompanyManageAdvanceTable from "./components/tables/CompanyManageAdvanceTable"


function App() {
  
  return (
    <>
        <Routes>        
            <Route path="/rejectaccept" element={<PrivateRoute element={<CompanyManagerRejectAccept/>} />} />
            <Route path="/manageexpense" element={<PrivateRoute element={<CompanyManagerExpenseTable/>} />} />
            <Route path="/manageadvancepayment" element={<PrivateRoute element={<CompanyManageAdvanceTable/>} />} />
            <Route path="/managepermissionrequest" element={<PrivateRoute element={<CompanyManagerPermissionTable/>} />} />
            <Route path="/" element = {<Auth/>}/>
            <Route path="/:userid/:resettoken" element = {<UpdatePassword/>}/>
            <Route path="/home" element={<PrivateRoute element={<Home />} />} />
            <Route path="/permission" element={<PrivateRoute element={<Permission/>} />} />
            <Route path="/advance" element={<PrivateRoute element={<Advance/>} />} />
            <Route path="/expense" element={<PrivateRoute element={<Expense/>} />} />
            <Route path="/manageemployee" element={<PrivateRoute element={<EmployeeManagement/>} />} />
            <Route path="/managecompany" element={<PrivateRoute element={<SiteManagement/>} />} />
            <Route path="/addcompanymanager" element={<PrivateRoute element={<CompanyManagerForm/>} />} />
            <Route path="/company/information/:companyid" element={ <PrivateRoute element={<CompanyInfo/>} /> } />
            <Route path="/*" element={ <PrivateRoute element={<Page404/>} /> } />
        </Routes>
    </>
  )
}

export default App
//<Route path="/advance" element={<PrivateRoute element={<Advance/>} />} />
//<Route path="/expense" element={<PrivateRoute element={<Expense/>} />} />