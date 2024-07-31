import React from 'react';

const Profile = () => {
  const currentUser = AuthService.getCurrentUser();

  return (
    <div>
      {currentUser ? (
        <div>
          <h1>Profile</h1>
          <p>Username: {currentUser.username}</p>
          <p>Email: {currentUser.email}</p>
        </div>
      ) : (
        <div>Please log in</div>
      )}
    </div>
  );
};

export default Profile;