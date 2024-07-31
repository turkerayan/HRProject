import { ApiRequests } from "../api/Api"


const UserService ={
    async getUser(){
        return await ApiRequests.handleRequestGetAsync("User/getadmindetails");
    },
    async putUser(data){
        return await ApiRequests.handleRequestPostAsync("User/updateuser",data)
    }
    
}

export default UserService;