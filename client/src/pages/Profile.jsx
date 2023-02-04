import React from 'react';
import { useSelector } from 'react-redux';
import ChangePassword from './ChangePassword';
import PasswordInput from '../components/PasswordInput';

import { selectCurrentUser } from '../features/auth/authSlice';
import { useForgotPasswordMutation } from '../features/auth/accountSlice';

const Profile = () => {
    const user = useSelector(selectCurrentUser);

    const [forgotPassword, { isLoading, isError, error, data }] = useForgotPasswordMutation();

    const checkTestForgotPassword = async (e) => {
        e.preventDefault();
        console.log(user);
        try {
            const result = await forgotPassword({ email: user.email }).unwrap();
        } catch (error) {
            console.log(error);
        }
    }

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

                <button className='underline text-blue-500 hover:text-blue-600' onClick={checkTestForgotPassword}>Forgot your password?</button>

                {
                    data && <h2>{data.message}</h2> //TODO : отформатировать текст
                }
            </div>
        </>
    )
};

export default Profile;