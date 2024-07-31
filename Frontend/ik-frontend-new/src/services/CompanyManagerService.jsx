import { ApiRequests } from "../api/Api";

const CompanyManagerService = {
    async addCompanyManager(data){
        return await ApiRequests.handleRequestPostAsync("Auth/CreateCompanyManager",data,true); 
    },
    async updateCompanyManager(data){

        return await ApiRequests.handleRequestPostAsync("Auth/UpdateCompanyManager",data)
    },
    
};

export default CompanyManagerService;