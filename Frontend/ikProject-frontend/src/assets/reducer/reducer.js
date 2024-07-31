export const initialState = {
    loginData: [],
    registerData: [],
};

export const reducer = (state, action) => {
    switch (action.type) {
        case "Login":
            return {
                ...state,
                loginData: action.payload,
            };
            case "Register":
                return{
                    ...state,
                    registerData: action.payload, 
                }
        default:
            break;
    }
};
