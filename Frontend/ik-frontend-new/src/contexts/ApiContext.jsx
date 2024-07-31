import { createContext, useState, useEffect } from "react";
import UserService from "../services/UserService";
import PermissionService from "../services/PermissionService";
import AdvanceService from "../services/AdvanceService";
import ExpenseService from "../services/ExpensesService";
import CompanyService from "../services/CompanyService";
export const ApiContext = createContext();

const ApiContextProvider = ({ children }) => {
    const [user, setUser] = useState({
        status: "",
        data: "",
    });
    const [permissionType, setPermisisonType] = useState({
        status: "",
        data: "",
    });
    const [permissionRequests,setPermissionRequests] = useState({
        status: "",
        data: "",
    })

    const [advances,setAdvances] = useState({
        status: "",
        data: "",
    })
    const [expenses,setExpenses] = useState({
        status: "",
        data: "",
    })
    const [companies,setCompanies] = useState({
        status: "",
        data: "",
    })
    const [personals,setPersonals] = useState({
        status: "",
        data: "",
      })

    const [expensesManager,setExpensesManager] = useState({
        status: "",
        data: "",
    })

    const [permissionManager,setpPermissionManager] = useState({
        status: "",
        data: "",
    })
    const [advancePaymentManager,setAdvancePaymentManager] = useState({
        status: "",
        data: "",
    })


    const [imgPath, setImgPath] = useState("");
    useEffect(() => {
        const fetchData = async () => {
            const responseUser = await UserService.getUser();
            const responsPermissionType = await PermissionService.GetAllPermissionType();
            const responsePermissionRequest = await PermissionService.GetAllPermissionRequest();
            const responseAdvances = await AdvanceService.GetAllAdvancePaymentByUser(1,10);
            const responseExpenses = await ExpenseService.GetAllExpensesByUser(1,10);
            const responseCompanies = await CompanyService.GetAllCompany(1,10);
            const responseExpensesManager =  await ExpenseService.GetAllExpenses();
            const responsePermissionManager =  await PermissionService.GettAllPermissionRequestManager();
            const responseAdvancePaymentManager =  await AdvanceService.GetAllAdvancePayment(1,10);
            setUser({ status: responseUser.status, data: responseUser.data });
            setPermisisonType({status: responsPermissionType.status, data: responsPermissionType.data});
            setPermissionRequests({status: responsePermissionRequest.status, data: responsePermissionRequest.data});
            setAdvances({status: responseAdvances.status, data: responseAdvances.data});
            setExpenses({status: responseExpenses.status, data: responseExpenses.data});
            setCompanies({status: responseCompanies.status, data: responseCompanies.data});
            setExpensesManager({status: responseExpensesManager.status, data: responseExpensesManager.data});
            setpPermissionManager({status: responsePermissionManager.status, data: responsePermissionManager.data});
            setAdvancePaymentManager({status: responseAdvancePaymentManager.status, data: responseAdvancePaymentManager.data});
        };
        fetchData();
    }, [sessionStorage.getItem("Token")]);
    const values = {
        user,
        setUser,
        setImgPath,
        imgPath,
        permissionType,
        permissionRequests,
        setPermissionRequests,
        advances,
        setAdvances,
        expenses,
        setExpenses,
        companies,
        setCompanies,
        personals,
        setPersonals,
        expensesManager,
        permissionManager,
        advancePaymentManager
    };
    return <ApiContext.Provider value={values}>{children}</ApiContext.Provider>;
};
export default ApiContextProvider;
