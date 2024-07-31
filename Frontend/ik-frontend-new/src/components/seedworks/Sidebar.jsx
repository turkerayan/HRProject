import React, { useState } from "react";
import { Link, NavLink } from "react-router-dom";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faHouse } from "@fortawesome/free-solid-svg-icons";
import { faAddressCard } from "@fortawesome/free-solid-svg-icons";
import {
    faThumbtack,
    faChevronDown,
    faRectangleList,
    faBeerMugEmpty,
    faAddressBook,
} from "@fortawesome/free-solid-svg-icons";
import { faGlobe } from "@fortawesome/free-solid-svg-icons";
import logo from "../../assets/images/ANK_15__2.png";
import logosmall from "../../assets/images/sidebarlogo.png";
const Sidebar = ({ isWrap }) => {
    const [menuOpen, isMenuOpen] = useState(false);

    let role = sessionStorage.getItem("Role");
    console.log(role);
    return (
        <aside className={`sidebar ${isWrap ? "wrap" : ""}`}>
            <Link to={"/home"}> <img src={isWrap ? logosmall : logo} className="logo-sidebar" alt="logo-sidebar" /></Link>
            <ul>
                <li> <NavLink to={"/home"}> <FontAwesomeIcon icon={faHouse} /> <span>Anasayfa</span></NavLink></li>
                {role === "Personal" ? (
                    <li>
                        <div className="drop-menu">
                            <div className="drop-menu-header" onClick={() => isMenuOpen(!menuOpen)} >
                                <FontAwesomeIcon icon={faAddressCard} /> <span>Talepler</span> <FontAwesomeIcon className="down-icon" icon={faChevronDown} />
                            </div>
                            <ul className={`drop-menu-content ${menuOpen ? "open" : "" }`}>
                                <li> <NavLink to={"/expense"}> <FontAwesomeIcon icon={faRectangleList}/><span>Harcama Talebi</span></NavLink></li>
                                <li> <NavLink to={"/permission"}><FontAwesomeIcon icon={faBeerMugEmpty}/><span>İzin Talebi</span></NavLink> </li>
                                <li> <NavLink to={"/advance"}> <FontAwesomeIcon icon={faAddressBook} /><span>Avans Talebi</span></NavLink> </li>
                            </ul>
                        </div>
                    </li>
                ) : null}
                {role === "SiteManager" ? (
                    <>
                        <li><NavLink to={"/managecompany"}> <FontAwesomeIcon icon={faGlobe} /><span>Şirketler</span></NavLink></li>
                    </>
                ) : null}
                {role === "CompanyManager" ? (
                    <>
                    <li><NavLink to={"/manageemployee"}> <FontAwesomeIcon icon={faThumbtack} /><span>Çalışanlar</span></NavLink></li>
                    <li><NavLink to={"/manageexpense"}> <FontAwesomeIcon icon={faThumbtack} /><span>Harcamalar</span></NavLink></li>
                    <li><NavLink to={"/managepermissionrequest"}> <FontAwesomeIcon icon={faThumbtack} /><span>İzinler</span></NavLink></li>
                    <li><NavLink to={"/manageadvancepayment"}> <FontAwesomeIcon icon={faThumbtack} /><span>Avanslar</span></NavLink></li>                    

                    </>
                ):null}
            </ul>
        </aside>
    );
};

export default Sidebar;
