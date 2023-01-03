import React from 'react';
import { useSelector } from 'react-redux';

import { selectCurrentUser, selectCurrentToken } from '../features/auth/authSlice';

const Profile = () => {
    const user = useSelector(selectCurrentUser);
    return (
        <>
            <div className='h-1/2 rounded flex flex-col'>

                <img
                    alt="..."
                    src='/photo.jpg'
                    className="rounded-full border-none  object-cover"
                    style={{ maxWidth: "180px", height: "180px", margin: "0 auto" }}
                />

                <div className='my-6'>

                    <h2 className='font-bold text-3xl'>{user.name}</h2>
                    <h3 className='text-gray-500 py-1'>Email - {user.email}</h3>
                    <h3 className='text-gray-500'>Nickname - {user.displayName}</h3>
                </div>

                <button>Change password</button>
            </div>
        </>
    )
};

export default Profile;