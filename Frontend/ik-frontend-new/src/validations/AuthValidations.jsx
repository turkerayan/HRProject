
const emailValid = (email,errors)=>{
    if (email.trim() === "") {
        errors.email = "Mail Adresi zorunludur!";
        errors.isValid = false;
    }
    else if (!email.toLowerCase().endsWith("@bilgeadamboost.com")) {
        // errors.email = "Mail Adresinin Sonun @bilgeadamboost.com bulunmalıdır.";
        // errors.isValid = false;
    }
};

const passwordValid= (password,errors)=>{
    let passwordPattern = /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^a-zA-Z\d]).{8,}$/;
    if (password.trim() === "") {
        errors.password = "Şifre Boş Bırakılamaz";
        errors.isValid = false;
    } else if (!passwordPattern.test(password)) {
        errors.password =
            "Şifre en az 8 karakter uzunluğunda olmalı ve en az bir büyük harf, bir küçük harf, bir rakam ve bir özel karakter içermelidir";
        errors.isValid = false;
    };
}

const updatePasswordValid = (password,rePassword,errors)=>{
    if (password !== rePassword){
        errors.rePassword = "Sifreler uyusmamaktadir.";
        errors.isValid=false;
    } 
}

const AuthValidation = {
    LoginValidation(data) {
        const errors = { email: "",password: "",isValid: true};
        emailValid(data.email,errors)
        passwordValid(data.password,errors)

        return errors;
    },

    RePasswordValidation(email){
        const errors = { email: "",isValid: true};
        emailValid(email,errors)
        return errors
    },
    UpdatePasswordValiddation(data){
        const errors = { password: "", rePassword:"" , isValid: true};
        passwordValid(data.password,errors);
        updatePasswordValid(data.password,data.rePassword,errors);
        return errors
    }
};

export default AuthValidation;
