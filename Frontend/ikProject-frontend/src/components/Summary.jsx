import React,{useReducer} from 'react'

const initialState =
    {
        "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        "userName": "Turker",
        "normalizedUserName": "string",
        "email": "turkerayan@icloud.com",
        "normalizedEmail": "string",
        "emailConfirmed": true,
        "passwordHash": "string",
        "securityStamp": "string",
        "concurrencyStamp": "string",
        "phoneNumberConfirmed": true,
        "twoFactorEnabled": true,
        "lockoutEnd": "2024-05-29T08:41:34.270Z",
        "lockoutEnabled": true,
        "accessFailedCount": 0,
        "token": "string",
        "name": "Abdurrahman",
        "secondName": "Turker",
        "surname": "AYAN",
        "secondSurname": "AYAN2",
        "birthdate": "2024-05-29T08:41:34.270Z",
        "placeOfBirth": "string",
        "identityNo": "string",
        "startAJob": "2024-05-29T08:41:34.270Z",
        "leavingJob": "2024-05-29T08:41:34.270Z",
        "isActive": true,
        "companyName": "string",
        "job": "string",
        "department": "R&D",
        "address": "Izmir",
        "phoneNumber": "+905051234567",
        "wage": 0,
        "imgPath": "string"
      }


const reducer = (state, action) => {
    switch (action.type) {
      case 'UPDATE_USER':
        return { ...state, ...action.payload };
      default:
        return state;
    }
  };

  const Summary = () => {
    const [state, dispatch] = useReducer(reducer, initialState);

    const updateUser = (newInfo) => {
        dispatch({ type: 'UPDATE_USER', payload: newInfo });
      };






  return (
    <div>
         <h1>User Summary</h1>
      <img src={state.imgPath} alt="User" />
      <p><strong>Name:</strong> {state.name} {state.secondName} {state.surname} {state.secondSurname}</p>
      <p><strong>Email:</strong> {state.email}</p>
      <p><strong>Phone Number:</strong> {state.phoneNumber}</p>
      <p><strong>Address:</strong> {state.address}</p>
      <p><strong>Department:</strong> {state.department}</p>
   
    </div>
  )
}

export default Summary;