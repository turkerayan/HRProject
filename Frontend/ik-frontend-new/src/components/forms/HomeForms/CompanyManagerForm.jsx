import React, { useContext, useState } from 'react';
import { ApiContext } from '../../../contexts/ApiContext';
import CompanyManagerService from '../../../services/CompanyManagerService';
import { DataContext } from '../../../contexts/DataContext';
import { faSpinner } from '@fortawesome/free-solid-svg-icons';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { toast, ToastContainer } from 'react-toastify';
import CompanyService from '../../../services/CompanyService';
import { useParams } from 'react-router-dom';
import 'react-toastify/dist/ReactToastify.css';

export const CompanyManagerForm = () => {
    const { setCompanies, companies } = useContext(ApiContext);
    const { notify } = useContext(DataContext);
    const {companyid} = useParams();
    const [loading, setLoading] = useState(false);
    const [formData, setFormData] = useState({
        name: '',
        secondName: '',
        surname: '',
        secondSurname: '',
        phoneNumber: '',
        email: '',
        address: '',
        birthDate: '',
        placeOfBirth: '',
        identityNo: '',
        startAJob: '',
        leavingJob: '',
        job: '',
        department: '',
        wage: '',
        imgPath: null,
        isBoy: false,
        password: "12345Aa.",
        companyId: companyid
    });

    const handleInputChange = (e) => {
        const { name, value } = e.target;
        setFormData({ ...formData, [name]: name === 'isBoy' ? value === 'true' : value });
    };

    const handleFileChange = (e) => {
        setFormData({ ...formData, imgPath: e.target.files[0] });
    };

    const handleForm = async (e) => {
        e.preventDefault();

        setLoading(true);
        const response = await CompanyManagerService.addCompanyManager(formData);

        notify(response.status !== 201 ? response.data : "Başarılı bir şekilde oluştu", response.status !== 201 ? "error" : "success");
        setLoading(false);
        if (response.status === 201) {
            setTimeout(()=>{
                window.location.reload();
            },[1500])
        }
    };

    if (companies.status === 200) {
        var company = companies.data.filter((company) => company?.id === companyid);
        let formattedBirthDate ,formattedLeavingJob,formattedStartJob
        if (company[0].companyManger !== null) {
            formattedBirthDate = company[0].companyManger?.birthDate !== null ? new Date(company[0].companyManger?.birthDate)?.toISOString()?.substr(0, 10) : null;
            formattedLeavingJob = company[0].companyManger?.leavingJob !== null ?  new Date(company[0].companyManger.leavingJob).toISOString().substr(0, 10) : null;
            formattedStartJob = company[0].companyManger?.startAJob !== null ? new Date(company[0].companyManger?.startAJob).toISOString().substr(0, 10) : null ;
        }

        const handleFormUpdate = async (e) => {
            e.preventDefault();
            setLoading(true);

            let formData2={
                id:company[0]?.companyManger?.id,
                name: e.target?.name?.value,
                secondName: e?.target?.secondName?.value,
                surname: e?.target?.surname?.value,
                secondSurname: e?.target?.secondSurname?.value,
                phoneNumber: e?.target?.phoneNumber?.value,
                email: e?.target?.email?.value,
                address: e?.target?.address?.value,
                birthDate: e?.target?.birthDate?.value,
                placeOfBirth: e?.target?.placeOfBirth?.value,
                identityNo: e?.target?.identityNo?.value,
                startAJob: e?.target?.startAJob?.value,
                leavingJob: e?.target?.leavingJob?.value,
                job: e?.target?.job?.value,
                department: e?.target?.department?.value,
                wage: e?.target?.wage?.value,
                imgPath: e?.target?.imgPath?.files[0],
                isBoy: e?.target?.isBoy?.value,
                password: "12345Aa.",
                companyId: companyid
            }

            const response = await CompanyManagerService.updateCompanyManager(formData2);
         

            notify(response.status !== 200 ? response.data : "Başarılı bir şekilde oluştu", response.status !== 200 ? "error" : "success");

            setLoading(false);

            if (response.status === 200) {
                setTimeout(()=>{
                    window.location.reload();
                },[1500])
            }
        };

        if (company[0].companyManger === null) {
            return (
                <div className='companymanagerform-container' style={{width:"30%"}}>
                    <h3>Şirket Yöneticisi Ekleme Form</h3>
                    <form onSubmit={handleForm}>
                        <div>
                            <label>Adı:</label>
                            <input type="text" name="name" value={formData.name} onChange={handleInputChange} required />
                        </div>
                        <div>
                            <label>İkinci Adı:</label>
                            <input type="text" name="secondName" value={formData.secondName} onChange={handleInputChange} />
                        </div>
                        <div>
                            <label>Soyadı:</label>
                            <input type="text" name="surname" value={formData.surname} onChange={handleInputChange} required />
                        </div>
                        <div>
                            <label>İkinci Soyadı:</label>
                            <input type="text" name="secondSurname" value={formData.secondSurname} onChange={handleInputChange} />
                        </div>
                        <div>
                            <label>Doğum Tarihi:</label>
                            <input type="date" name="birthDate" value={formData.birthDate} onChange={handleInputChange} required />
                        </div>
                        <div>
                            <label>Doğum Yeri:</label>
                            <input type="text" name="placeOfBirth" value={formData.placeOfBirth} onChange={handleInputChange} required />
                        </div>
                        <div>
                            <label>Kimlik Numarası:</label>
                            <input type="number" name="identityNo" minLength="11" maxLength="11" value={formData.identityNo} onChange={handleInputChange} required />
                        </div>
                        <div>
                            <label>İşe Başlama Tarihi:</label>
                            <input type="date" name="startAJob" value={formData.startAJob} onChange={handleInputChange} required />
                        </div>
                        <div>
                            <label>İşten Çıkış Tarihi:</label>
                            <input type="date" name="leavingJob" value={formData.leavingJob} onChange={handleInputChange} />
                        </div>
                        <div>
                            <label>Meslek:</label>
                            <input type="text" name="job" value={formData.job} onChange={handleInputChange} required />
                        </div>
                        <div>
                            <label>Departman:</label>
                            <input type="text" name="department" value={formData.department} onChange={handleInputChange} required />
                        </div>
                        <div>
                            <label>Maaş:</label>
                            <input type="text" name="wage" value={formData.wage} onChange={handleInputChange} required />
                        </div>
                        <div>
                            <label>Cinsiyet:</label>
                            <select id="" name="isBoy" value={formData.isBoy} onChange={handleInputChange}>
                                <option value={true}>Erkek</option>
                                <option value={false}>Kadın</option>
                            </select>
                        </div>
                        <div>
                            <label>Phone Number:</label>
                            <input type="text" name="phoneNumber" value={formData.phoneNumber} onChange={handleInputChange} required />
                        </div>
                        <div>
                            <label>Email:</label>
                            <input type="email" name="email" value={formData.email} onChange={handleInputChange} required />
                        </div>
                        <div>
                            <label>Address:</label>
                            <input type="text" name="address" value={formData.address} onChange={handleInputChange} required />
                        </div>
                        <div>
                            <label>Image Path:</label>
                            <input type="file" name="imgPath" onChange={handleFileChange} required />
                        </div>
                            <button type='submit' className={`btn btn-success ${!loading ? "" : "disable"}`}>
                                {!loading ? "Yönetici Ekle" : <FontAwesomeIcon className='spinner' icon={faSpinner} />}
                            </button>
                    </form>
                    <ToastContainer />
                </div>
            );
        }else{
            return (
                <div className='companymanagerform-container' style={{width:"30%"}}>
                    <h3>Şirket Yöneticisi Güncelleme Form</h3>
                    <form onSubmit={handleFormUpdate}>
                        <div>
                            <label>Adı:</label>
                            <input type="text" name="name"defaultValue={company[0]?.companyManger?.name} onChange={handleInputChange} required />
                        </div>
                        <div>
                            <label>İkinci Adı:</label>
                            <input type="text" name="secondName" defaultValue={company[0]?.companyManger?.secondName} onChange={handleInputChange} />
                        </div>
                        <div>
                            <label>Soyadı:</label>
                            <input type="text" name="surname" defaultValue={company[0]?.companyManger?.surname}  onChange={handleInputChange} required />
                        </div>
                        <div>
                            <label>İkinci Soyadı:</label>
                            <input type="text" name="secondSurname" defaultValue={company[0]?.companyManger?.secondSurname} onChange={handleInputChange} />
                        </div>
                        <div>
                            <label>Doğum Tarihi:</label>
                            <input type="date" name="birthDate"  defaultValue={formattedBirthDate} onChange={handleInputChange} required />
                        </div>
                        <div>
                            <label>Doğum Yeri:</label>
                            <input type="text" name="placeOfBirth" defaultValue={company[0]?.companyManger?.placeOfBirth} onChange={handleInputChange} required />
                        </div>
                        <div>
                            <label>Kimlik Numarası:</label>
                            <input type="number" name="identityNo" minLength="11" maxLength="11" defaultValue={company[0]?.companyManger?.identityNo} onChange={handleInputChange} required />
                        </div>
                        <div>
                            <label>İşe Başlama Tarihi:</label>
                            <input type="date" name="startAJob" defaultValue={formattedStartJob} onChange={handleInputChange} required />
                        </div>
                        <div>
                            <label>İşten Çıkış Tarihi:</label>
                            <input type="date" name="leavingJob" defaultValue={formattedLeavingJob} onChange={handleInputChange} />
                        </div>
                        <div>
                            <label>Meslek:</label>
                            <input type="text" name="job" defaultValue={company[0]?.companyManger?.job} onChange={handleInputChange} required />
                        </div>
                        <div>
                            <label>Departman:</label>
                            <input type="text" name="department" defaultValue={company[0]?.companyManger?.department} onChange={handleInputChange} required />
                        </div>
                        <div>
                            <label>Maaş:</label>
                            <input type="text" name="wage" defaultValue={company[0]?.companyManger?.wage} onChange={handleInputChange} required />
                        </div>
                        <div>
                            <label>Cinsiyet:</label>
                            <select id="" name="isBoy" defaultValue={company[0]?.companyManger?.isBoy} onChange={handleInputChange}>
                                <option value={true}>Erkek</option>
                                <option value={false}>Kadın</option>
                            </select>
                        </div>
                        <div>
                            <label>Phone Number:</label>
                            <input type="text" name="phoneNumber" defaultValue={company[0]?.companyManger?.phoneNumber} onChange={handleInputChange} required />
                        </div>
                        <div>
                            <label>Email:</label>
                            <input type="email" name="email" defaultValue={company[0]?.companyManger?.email} onChange={handleInputChange} required />
                        </div>
                        <div>
                            <label>Address:</label>
                            <input type="text" name="address" defaultValue={company[0]?.companyManger?.address} onChange={handleInputChange} required />
                        </div>
                        <div>
                            <label>Image Path:</label>
                            <input type="file" name="imgPath"  onChange={handleFileChange} />
                        </div>
                            <button type='submit' className={`btn btn-success ${!loading ? "" : "disable"}`}>
                                {!loading ? "Yönetici Güncelle" : <FontAwesomeIcon className='spinner' icon={faSpinner} />}
                            </button>
                    </form>
                    <ToastContainer />
                </div>
            );
        }
      
    }
};

export default CompanyManagerForm;
