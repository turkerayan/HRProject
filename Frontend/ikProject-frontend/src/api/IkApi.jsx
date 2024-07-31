import axios from "axios";

const api = axios.create({
    baseURL:"https://localhost:7153/api",
    headers:{
        Authorization:`Bearer ${window.sessionStorage.getItem("Token")}`
    }
});

const IkApi ={
    async GetUser(){
        const res = await api.get("user/get");
    }
}




export default IkApi;