import { ApiRequests } from '../api/Api'

const ExpenseService ={
    async AddExpenses(data){
        return await ApiRequests.handleRequestPostAsync("/Expenses/add", data,true);
    },
 
    async UpdateExpense(data){
        return await ApiRequests.handleRequestPatchAsync("/Expenses/update",data,false);
    },
 
    async DeleteExpenses(id){
        return await ApiRequests.handleRequestDeleteAsync(`/Expenses/delete?Id=${id}`);
    },
 
    async GetAllExpenses(){
        return await ApiRequests.handleRequestGetAsync("/Expenses/getall?currentPage=1&pageSize=10");
    },
   
    async GetAllExpensesByUser(page,size){
        return await ApiRequests.handleRequestGetAsync(`/Expenses/getallbyuser?currentPage=${page}&pageSize=${size}`);
    }
}
export default ExpenseService;