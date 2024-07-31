import { ApiRequests } from '../api/Api'

const AdvanceService = {
    async AddAdvancePayment(data){
        return await ApiRequests.handleRequestPostAsync("/AdvancePayments/add",data,false);
    }, 
    async UpdateAdvancePayment(data){
        return await ApiRequests.handleRequestPatchAsync("/AdvancePayments/update",data,false);
    },
    async DeleteAdvancePayment(id){
        return await ApiRequests.handleRequestDeleteAsync(`/AdvancePayments/delete?Id=${id}`);
    },
    async GetAllAdvancePaymentByUser(page,size){
       return await ApiRequests.handleRequestGetAsync(`AdvancePayments/getallbyuser?currentPage=${page}&pageSize=${size}`);
    },
    async GetAllAdvancePayment(page,size){
        return await ApiRequests.handleRequestGetAsync(`AdvancePayments/getall?currentPage=${page}&pageSize=${size}`);
     }
}
export default AdvanceService;