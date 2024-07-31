import { ApiRequests } from '../api/Api'

const CompanyService = {
    async AddCompany(data){
        return await ApiRequests.handleRequestPostAsync("/Company/addcompany",data,true);
    }, 
    async UpdateCompany(data){
        return await ApiRequests.handleRequestPatchAsync("/Company/update",data,false);
    },
    async DeleteCompany(id){
        return await ApiRequests.handleRequestDeleteAsync(`/Company/deletecompany?Id=${id}`);
    },
    async GetAllCompany(page,size){
       return await ApiRequests.handleRequestGetAsync(`Company/getallcompany?CurrentPage=${page}&PageSize=${size}`);
    },
    async GetByIdCompany(id){
        return await ApiRequests.handleRequestGetAsync(`Company/getcompanysitemanager?Id=${id}`)
    }
}
export default CompanyService;