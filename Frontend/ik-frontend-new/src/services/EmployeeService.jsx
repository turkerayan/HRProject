import { ApiRequests } from '../api/Api'

const EmployeeService = {
    async AddAPersonel(data){
        return await ApiRequests.handleRequestPostAsync("/User/addpersonal",data,true);
    }, 
    async UpdateAdvancePayment(data){
        return await ApiRequests.handleRequestPatchAsync("/AdvancePayments/update",data,false);
    },
    async DeleteAdvancePayment(id){
        return await ApiRequests.handleRequestDeleteAsync(`/AdvancePayments/delete?Id=${id}`);
    },
    async GetAllCompany(page,size,cpId){
       return await ApiRequests.handleRequestGetAsync(`Company/getall`);
    },
    async GetByIdCompany(id){
        return await ApiRequests.handleRequestGetAsync(`Company/getcompany?Id=${id}`)
    }
}
export default EmployeeService;