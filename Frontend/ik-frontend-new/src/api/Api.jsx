import axios from "axios";

const api = axios.create({ baseURL:"https://ikteam1.azurewebsites.net/api/" });
//const api = axios.create({ baseURL:"https://localhost:7153/api/" });

const addTokenHeader = ()=>{
    api.defaults.headers.common["Authorization"] = `Bearer ${sessionStorage.getItem("Token")}` ;
}

export const ApiRequests ={
    async handleRequestGetAsync(requestUrl){
        try {
            addTokenHeader();
            const res = await api.get(requestUrl)
            return { data: res.data, status: res.status}
        } catch (error) {
            let res;
            if (!error.response) res = { data: error.message,status: error.code};
            else res = {data: error.response.data.title,status: error.response.status};
            return res;
        }
    },
    async handleRequestPostAsync(requestUrl,requestData,hasToken = true){
        try {
            if (!hasToken) {
                const res = await api.post(requestUrl,requestData)
                return { data: res.data, status: res.status }
            }
            addTokenHeader();
            api.defaults.headers.common["Authorization"] = `Bearer ${sessionStorage.getItem("Token")}` ;

            const res = await api.post(requestUrl,requestData,{
                headers:{ 'Content-Type': 'multipart/form-data' }
            })
            return { data: res.data, status: res.status }
        }catch (error) {
            let res;
            if (!error.response) res = { data: error.message,status: error.code};
            else res = {data: error.response.data.title,status: error.response.status};
            return res;
        }
    },
    async handleRequestPutAsync (requestUrl,requestData){
        try {
            addTokenHeader();
            console.log(requestData)
            const res = await api.put(requestUrl,requestData)
            return { data: res.data, status: res.status }
        }catch (error) {
            let res;
            if (!error.response) res = { data: error.message,status: error.code};
            else res = {data: error.response.data.title,status: error.response.status};
            return res;
        }
    },
    async handleRequestDeleteAsync (requestUrl){
        try {
            addTokenHeader();
            const res = await api.delete(`${requestUrl}`)
            return { data: res.data, status: res.status }
        }catch (error) {
            let res;
            if (!error.response) res = { data: error.message,status: error.code};
            else res = {data: error.response.data.title,status: error.response.status};
            return res;
        }
    },

    async handleRequestPatchAsync(requestUrl, requestData) {
        try {
            addTokenHeader();
            const res = await api.patch(requestUrl, requestData);
            return { data: res.data, status: res.status };
        } catch (error) {
            let res;
            if (!error.response) {
                res = { data: error.message, status: error.code };
            } else {
                res = { data: error.response.data.title, status: error.response.status };
            }
            return res;
        }
    }
}
