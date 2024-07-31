import { createContext} from "react";
import { ToastContainer, toast } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";

export const DataContext = createContext();

const DataContextProvider = ({ children }) => {

    const notify = (message, type) => {
        toast[type](message, {
            position: "top-left",
            autoClose: 3000,
            hideProgressBar: false,
            closeOnClick: true,
            pauseOnHover: true,
            draggable: true,
            progress: undefined,
            theme: "light",
        });
    };

    const values = {
        notify,
        ToastContainer,
    };
    return (
        <DataContext.Provider value={values}>{children}</DataContext.Provider>
    );
};
export default DataContextProvider;
