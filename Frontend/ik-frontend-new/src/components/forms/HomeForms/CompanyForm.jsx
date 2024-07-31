import React, { useContext, useState } from 'react';
import { ApiContext } from '../../../contexts/ApiContext';
import CompanyServices from '../../../services/CompanyService';
import { DataContext } from '../../../contexts/DataContext';
import { faSpinner } from '@fortawesome/free-solid-svg-icons';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';

export const CompanyForm = () => {
    const { setCompanies } = useContext(ApiContext);
    const { notify, ToastContainer } = useContext(DataContext);

    const [loading, setLoading] = useState(false);
    const [formData, setFormData] = useState({
        name: '',
        mersisNo: '',
        taxNo: '',
        taxAdministration: '',
        phoneNumber: '',
        email: '',
        address: '',
        personelCount: 0,
        establishmentDate: '',
        contractStartDate: new Date().toISOString().split('T')[0],
        contractEndDate: new Date().toISOString().split('T')[0],
        imgPath: null,
    });

    const handleInputChange = (e) => {
        const { name, value } = e.target;
        setFormData({ ...formData, [name]: value });
    };

    const handleFileChange = (e) => {
        setFormData({ ...formData, imgPath: e.target.files[0] });
    };
    const validateForm = () => {
        const requiredFields = ['name', 'mersisNo', 'taxNo', 'taxAdministration', 'phoneNumber', 'email', 'address', 'establishmentDate', 'contractStartDate', 'contractEndDate', 'imgPath'];
        for (let field of requiredFields) {
            if (!formData[field] || formData[field] === '') {
                return false;
            }
        }
        return true;
    };

    const handleForm = async (e) => {
        e.preventDefault();
        if (!validateForm()) {
            notify('Please fill in all required fields.', 'error');
            return;
        }
        setLoading(true);

        const response = await CompanyServices.AddCompany(formData);
        
        if (response.status === 201) {
            setCompanies(prev => ({ ...prev, data: [response.data, ...prev.data] }));
        }

        notify(response.status !== 201 ? response.data : "Başarılı bir şekilde eklendi", response.status !== 201 ? "error" : "success");
        setLoading(false);
    };

    return (
        <div className='companyform-container'>
            <h3>Şirket Ekleme Form</h3>
            <form onSubmit={handleForm}>
                <div>
                    <label>Ad:</label>
                    <input type="text" name="name" value={formData.name} onChange={handleInputChange} required />
                </div>
                <div>
                    <label>Mersis Numarası:</label>
                    <input type="text" name="mersisNo" value={formData.mersisNo} onChange={handleInputChange} required />
                </div>
                <div>
                    <label>Vergi Numarası:</label>
                    <input type="text" name="taxNo" value={formData.taxNo} onChange={handleInputChange} required />
                </div>
                <div>
                    <label>Vergi Dairesi:</label>
                    <input type="text" name="taxAdministration" value={formData.taxAdministration} onChange={handleInputChange} required />
                </div>
                <div>
                    <label>Telefon Numarası:</label>
                    <input type="text" name="phoneNumber" value={formData.phoneNumber} onChange={handleInputChange} required />
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
                    <label>Kuruş Tarihi:</label>
                    <input type="date" name="establishmentDate" value={formData.establishmentDate} onChange={handleInputChange} required />
                </div>
                <div>
                    <label>Sözleşme Başlangıç Tarihi:</label>
                    <input type="date" name="contractStartDate" value={formData.contractStartDate} onChange={handleInputChange} required />
                </div>
                <div>
                    <label>Sözleşme Bitiş Tarihi:</label>
                    <input type="date" name="contractEndDate" value={formData.contractEndDate} onChange={handleInputChange} required />
                </div>
                <div>
                    <label>Logo:</label>
                    <input type="file" name="imgPath" onChange={handleFileChange} required />
                </div>
                <button type='submit' className={`btn btn-success ${!loading ? "" : "disable"}`}>
                    {!loading ? "Şirket Ekle" : <FontAwesomeIcon className='spinner' icon={faSpinner} />}
                </button>
            </form>
            <ToastContainer />
        </div>
    );
};

export default CompanyForm;
