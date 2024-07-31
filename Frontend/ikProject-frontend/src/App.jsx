import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import Login from "./components/Login";

import Profile from "./components/Profile";

import Home from "./components/Home";
import Navigation from "./components/Navigation";
import UserInformations from "./components/UserInformations";

function App() {
    return (
        <>
            <div>
                <div className="container">
                    <main className="main-content">
                        <Router>
                            <Navigation />
                            <Routes>
                                <Route exact path="/" element={<Home />} />
                                <Route path="/login" element={<Login />} />
                                <Route
                                    path="/information"
                                    element={<UserInformations />}
                                ></Route>
                            </Routes>
                        </Router>
                    </main>
                </div>
            </div>
        </>
    );
}

export default App;
