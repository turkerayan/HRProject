
import React, { useEffect, useRef, useState,useContext } from 'react'
import UserService from '../services/UserService'
import { DataContext } from '../contexts/DataContext'
import '../assets/sass/adminDetail.scss'
import { faSpinner } from '@fortawesome/free-solid-svg-icons';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
const AdminDetail = ({adminDetails,setUser,setImgPath,imgPath}) => {
    const{notify,ToastContainer} = useContext(DataContext)
    const [isOpenDetail, setIsOpenDetail] = useState(false)
    const [isOpenUpdate, setIsOpenUpdate] = useState(false)
    const [loading,setLoading] = useState(false);

    const [imageUrl, setImageUrl] = useState('');
    const scrollRef = useRef(null);
    
    const dateyear = { year: 'numeric', month: 'long' };
    const scrollToContent = () => {
        setTimeout(() => {
            if (scrollRef.current) {
                scrollRef.current.scrollIntoView({ behavior: 'smooth' });
            }
        }, 10);
    };
    
    useEffect(() => {
        if (isOpenUpdate) {
            scrollToContent();
        }
    }, [isOpenUpdate]);

    useEffect(()=>{
        setImgPath("https://ikteam1.azurewebsites.net/images/profiles/" + adminDetails?.imgPath)
        //setImgPath("https://localhost:7153/images/profiles/" + adminDetails?.imgPath)

    },[])

    
    const checkFileSize = (e) => {
        if (e.target.files[0].size > (1024 * 1024 * 2)){
            alert("Dosya boyutu 2MB'dan büyük")
            e.target.value = ""
        }           
    }
    
    const handleFileChange = (e) => {
        const file = e.target.files[0];
        const reader = new FileReader();

        reader.onloadend = () => {
          setImageUrl(reader.result);
        };
    
        if (file) {
          reader.readAsDataURL(file);
        }
      };
    
      const handleSubmit = async (e)=>{
          e.preventDefault();
          let formData = Object.fromEntries(new FormData(scrollRef.current).entries());
          setLoading(true);
          const updateVal = e.target;
          const address = updateVal.city.value+"  "+updateVal.district.value+"  "+updateVal.neighbourhood.value+"  "+updateVal.street.value+"  "+updateVal.aptNumber.value
          const data ={image:formData.image, address:address, phoneNumber:updateVal.phoneNumber.value}
          const response =  await UserService.putUser(data);
        if (response.status === 200) {
            if (formData.image.size !==0) {
                setImgPath(imageUrl)
            }
            setUser(prev => ({
                ...prev,
                data: {
                  ...prev.data,
                  address: address,
                  phoneNumber: updateVal.phoneNumber.value
                }
              }));    
        }
        notify(response.status !== 200 ? response.data : "Güncelleme Basarılı", response.status !== 200 ? "error" : "success");        
          setLoading(false);
    };

console.log(adminDetails?.address.split("  ")[0])
console.log(adminDetails?.address.split("  ")[1])
let Adress = adminDetails?.address.split("  ").splice(2)
const adresBirlestirilmis = `${Adress},${adminDetails?.address.split("  ")[0]}/${adminDetails?.address.split("  ")[1]}`;

    return (
        <div className='admin-detail-container'>
        <div className={`admin-detail-card ${isOpenDetail ? 'open' : ''}`}>

            <img src={imgPath || "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcREO17hg6KvLlweeZWN0LCEdi-OXM9qGpbQ9w&s"} alt="" />
            <div className='card-container' >

                <div className={`constant-details ${isOpenDetail ? 'open' : ''}`}>
                    <p className='name-label' >{`${adminDetails?.name} ${adminDetails?.secondName ?? ""} ${adminDetails?.surname} ${adminDetails?.secondSurname || ""} `}</p>
                    <p className="label">Email:</p>
                    <p className='detail-item'>{adminDetails?.email}</p>
                    <p className="label">Adres:</p>
                    <p className='detail-item'>{adresBirlestirilmis}</p>
                    <p className="label">Telefon Numarası:</p>
                    <p className='detail-item'>{adminDetails?.phoneNumber}</p>
                    <p className="label">Meslek:</p>
                    <p className='detail-item'>{adminDetails?.job}</p>
                    <p className="label">Departman:</p>
                    <p className='detail-item'>{adminDetails?.department}</p>
                </div>
                <div className={`additional-details ${isOpenDetail ? 'open' : ''}`}>
                    <p className="label">Doğum Günü:</p>
                    <p className='detail-item'>{new Date(adminDetails?.birthdate).toLocaleDateString('tr-TR', dateyear)}</p>
                    <p className="label">Doğum Yeri:</p>
                    <p className='detail-item'>{adminDetails?.placeOfBirth}</p>
                    <p className="label">Kimlik No:</p>
                    <p className='detail-item'>{adminDetails?.identityNo}</p>
                    <p className="label">İşe Başlama Tarihi</p>
                    <p className='detail-item'>{new Date(adminDetails?.startAJob).toLocaleDateString('tr-TR', dateyear)}</p>
                    <p className="label">İşten Çıkış Tarihi</p>
                    <p className='detail-item'>{new Date(adminDetails?.leavingJob).toLocaleDateString('tr-TR', dateyear)}</p>
                    <p className="label">Aktiflik:</p>
                    <p
                        className="is-active"
                        style={adminDetails?.isActive
                            ? { border: "2px solid #29c304",  color: "#29c304" }
                            : { border: "2px solid #ff2323",  color: "#ff2323" }}>
                        {adminDetails?.isActive ? "Aktif" : "Pasif"}
                    </p>
                    <p className="label">Şirket İsmi:</p>
                    <p className='detail-item'>{adminDetails?.companyName}</p>
                </div>
            </div>
            <div className='button-container'>
                <button className='view-detail' onClick={() => setIsOpenDetail(!isOpenDetail)}>{isOpenDetail ? "Daralt" : "Detay Göster"}</button>
                <button className='update' onClick={() => {setIsOpenUpdate(!isOpenUpdate);scrollToContent()}}>{isOpenUpdate ? "Kapat" : "Güncelle"}</button>

            </div>


        </div>
        <form onSubmit={handleSubmit} className={`update-card ${isOpenUpdate?"open":""}`} ref={scrollRef}>
            <label>Resim:</label>
            <input type="file" accept=".png, .jpeg , .jpg" name='image' onChange={(e) => (checkFileSize(e),handleFileChange(e))}/>
            <label>Telefon:</label>
            <input defaultValue={adminDetails?.phoneNumber} type="tel" pattern="{1}[0-9]{12}" name='phoneNumber' placeholder='905123456789' required />
            <label>Adres:</label>
            <div className='adres-group'>
            <input defaultValue={adminDetails?.address.split("  ")[0]} type="text" placeholder='İl'  name='city'  required />
            <input defaultValue={adminDetails?.address.split("  ")[1]} type="text" placeholder='İlçe' name='district' required/>
            <input defaultValue={adminDetails?.address.split("  ")[2]} type="text" placeholder='Mahalle/Cadde' name='neighbourhood' required />
            <input defaultValue={adminDetails?.address.split("  ")[3]} type="text" placeholder='Sokak' name='street' required />
            <input defaultValue={adminDetails?.address.split("  ")[4]} type="text" placeholder='Daire/Apartman No' name='aptNumber' required />
            </div>
            <button type='submit'  style={{margin:"0.75rem 0"}} className={`btn btn-warning ${!loading ? "" : "disable"}`}>{!loading ? "Guncelle ":<FontAwesomeIcon className='spinner' icon={faSpinner} />}</button>
        </form>
        <ToastContainer/>
    </div>
    )
}

export default AdminDetail




     // const [adminDetails, setAdminDetails] = useState(
    //     {
    //         name: "Muhammet",
    //         secondName: "Can",
    //         surname: "Şanverdi",
    //         secondSurname: null,
    //         email: "muhammetsanverdi97@gmail.com",
    //         birthdate: "0001-01-01T00:00:00",
    //         placeOfBirth: "sdgsdgs",
    //         identityNo: "46548645",
    //         startAJob: "2023-11-29T00:00:00",
    //         leavingJob: "2023-11-29T00:00:00",
    //         isActive: true,
    //         companyName: "dgsfvszdfgv",
    //         job: "sxdvgsxdzcvg",
    //         department: "sxzdgvszxg",
    //         address: "dfgjkhdfg",
    //         phoneNumber: "567456416",
    //         //imgPath: "c073787e-595f-4faf-ecbf-08dc7f1704a6_d8bb5e7f-b909-47a9-9260-684ece43ac59.jpg"
    //     }
    // );

    // useEffect(() => {
    //         UserService.GetAdminDetailAsync().then((res)=>{setAdminDetails(res.data);});
        
    //     //setAdminDetails()
    // }

    //     , [])