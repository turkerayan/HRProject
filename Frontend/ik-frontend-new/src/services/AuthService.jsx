import { ApiRequests } from "../api/Api";

const AuthService = {
    async LoginServiceAsync(data){
        return await ApiRequests.handleRequestPostAsync("Auth/Login",data,false); 
    },
    async RegisterServiceAsync(data){
        return await ApiRequests.handleRequestPostAsync("",data); 
    },
    async RePasswordServiceAsycn(data){
        return await ApiRequests.handleRequestPostAsync("Auth/RePasswordToken",data,false);
    },
    async UpdatePasswordServiceAsycn(data){
        return await ApiRequests.handleRequestPutAsync("Auth/UpdatePassword",data,false);
    },
    Logout(){
        sessionStorage.clear();
    }
};

export default AuthService;