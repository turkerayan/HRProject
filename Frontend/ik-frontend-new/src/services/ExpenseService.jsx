import { ApiRequests } from '../api/Api'
const ExpenseService ={
    async AddExpenses(data){
        return await ApiRequests.handleRequestPostAsync("/Expenses/add", data,false);
    },

    async UpdateExpense(data){
        return await ApiRequests.handleRequestPatchAsync("/Expenses/update",data,false);
    },

    async DeleteExpenses(data){
        return await ApiRequests.handleRequestPatchAsync("/Expenses/delete",data,false);
    },

    async GetAllExpenses(){
        return await ApiRequests.handleRequestGetAsync("/Expenses/getall?currentPage=1&pageSize=10");
    },
    
    async GetAllExpensesByUser(){
        return await ApiRequests.handleRequestGetAsync("/Expenses/getallbyuser");
    }
}
export default ExpenseService;