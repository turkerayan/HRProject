import React,{useContext,useState,useRef,useEffect} from 'react'
import { DataContext } from '../../../contexts/DataContext'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faSpinner } from '@fortawesome/free-solid-svg-icons'
import UserService from '../../../services/UserService'

const HomeUpdateForm = ({isUpdateForm,userData,setImgPath,setUser}) => {
    const{notify,ToastContainer} = useContext(DataContext)
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
        if (imageUrl.length !== 0 ) {
        setImgPath(`https://ikteam1.azurewebsites.net/images/profiles/${userData?.imgPath}`)
        //setImgPath("https://localhost:7153/images/profiles/" + userData?.imgPath)
        }
    },[imageUrl])

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
        const address = updateVal.address.value;
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
  return (
    <div className={`home-update-form ${isUpdateForm ?"":"close"}`}>
        <form  onSubmit={handleSubmit} className="update-card open" ref={scrollRef}>
            <label>Resim:</label>
            <input type="file" accept=".png, .jpeg , .jpg" name='image' onChange={(e) => (checkFileSize(e),handleFileChange(e))}/>
            <label>Telefon:</label>
            <input defaultValue={userData?.phoneNumber} type="tel" pattern="[0-9]{12}" name='phoneNumber' placeholder='905123456789' required />
            <label>Adres:</label>
            <div className='adres-group'>
              <input defaultValue={userData?.address} placeholder='Adress' type="text" name="address" required />

            </div>
            <button type='submit'  style={{margin:"0.75rem 0"}} className={`btn btn-warning ${!loading ? "" : "disable"}`}>{!loading ? "Guncelle ":<FontAwesomeIcon className='spinner' icon={faSpinner} />}</button>
        </form>
        <ToastContainer/>

    </div>
  )
}

export default HomeUpdateForm