import axios from "axios";

const handleRequestAsync = async (requestUrl,requestData)=>{
        try {
            const response = await axios.post(requestUrl,requestData); 
            return response;
        } catch (error) {
            console.log(error);
            throw error;
        }
};

const AuthService = {
    async LoginServiceAsync(data) 
    {
        console.log(data)
        return await handleRequestAsync("https://localhost:7153/api/Auth/Login",data); // ! Burada api url gelecektir.
    },
    async RegisterServiceAsync(data)
    {
        return await handleRequestAsync("",data); // ! Burada api url gelecektir.
    },
};

export default AuthService;



    // async RegisterServiceAsync(name,secondName,surname,secondSurname,birthday,placeOfBirth,identityNo,
    //     startAJob,leavingJob,companyName,job,department,address,phoneNumber,wage,imgPath,password){
    //     let data = {
    //             name:name,
    //             secondName:secondName,
    //             surname:surname,
    //             secondSurname:secondSurname,
    //             birthday: Date(birthday),
    //             placeOfBirth:placeOfBirth,
    //             identityNo:identityNo,
    //             startAJob:Date(startAJob),
    //             leavingJob:Date(leavingJob),
    //             companyName:companyName,
    //             job:job,
    //             department:department,
    //             address:address,
    //             phoneNumber:phoneNumber,
    //             wage: parseFloat(wage),
    //             imgPath:File(imgPath),
    //             password:password
    //         };
    //         return await handleRequestAsync("",data); // ! Burada api url gelecektir. 
    //     }