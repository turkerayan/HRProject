import React, { useState, useContext } from 'react'
import { DataContext } from '../../../contexts/DataContext';
import { ApiContext } from '../../../contexts/ApiContext';
import EmployeeService from '../../../services/EmployeeService';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faSpinner } from '@fortawesome/free-solid-svg-icons';
const AddEmployeeForm = () => {
    const { notify, ToastContainer } = useContext(DataContext);
    const { user,setPersonals,personals} = useContext(ApiContext)

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
        companyId: user?.data?.company?.id
    });
    formData.isBoy === "true" ? true : false

    const handleInputChange = (e) => {
        const { name, value } = e.target;
        setFormData({ ...formData, [name]: value });
    };

    const handleFileChange = (e) => {
        setFormData({ ...formData, imgPath: e.target.files[0] });
    };

    const handleForm = async (e) => {
        e.preventDefault();
        setLoading(true);
        const response = await EmployeeService.AddAPersonel(formData);
        console.log(response);
        if (response.status === 201) {
            console.log(response);
            setPersonals(prev => ({ ...prev, data: [response.data, ...prev.data] }));
            console.log(personals);
            window.location.reload();
        }
        notify(response.status !== 201 ? response.data : "Başarılı bir şekilde oluştu", response.status !== 201 ? "error" : "success");
        setLoading(false);
    };

    return (
        <form onSubmit={handleForm} className='addemployeeform-container'>
            <h3>Çalışan Ekleme Form</h3>

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
                <label>Telefon Numarası:</label>
                <input type="tel" pattern="{1}[0-9]{12}" name='phoneNumber' placeholder='905123456789' value={formData.phoneNumber} onChange={handleInputChange} required />
            </div>
            <div>
                <label>Email:</label>
                <input type="email" name="email" value={formData.email} onChange={handleInputChange} required />
            </div>
            <div>
                <label>Adres:</label>
                <input type="text" name="address" value={formData.address} onChange={handleInputChange} required />
            </div>

            <div>
                <label>Fotoğraf:</label>
                <input type="file" name="imgPath" onChange={handleFileChange} required />
            </div>


            <button type='submit' className={`btn btn-success ${!loading ? "" : "disable"}`}>
                {!loading ? "Personal Ekle" : <FontAwesomeIcon className='spinner' icon={faSpinner} />}
            </button>


            <ToastContainer />
        </form>
    )
}

export default AddEmployeeForm