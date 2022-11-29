import React from 'react';

import { Link } from 'react-router-dom';
import { useDispatch } from 'react-redux';
import { setCredentials } from '../features/auth/authSlice';
import { useLoginMutation } from '../features/auth/authApiSlice';

const Login = () => {
    const dispatch = useDispatch();
    const [login] = useLoginMutation();

    const [email, setEmail] = React.useState('');
    const [password, setPassword] = React.useState('');

    const handleSubmit = async (e) => {
        e.preventDefault();

        const userData = await login({ email, password }).unwrap();
        console.log('userdata', userData);
        dispatch(setCredentials(userData));
    };

    return (
        <div className='flex flex-col items-center justify-center w-screen h-screen bg-gray-200 text-gray-700'>
            <h1 class="font-bold text-2xl">Welcome Back :)</h1>
            <form class="flex flex-col bg-white rounded shadow-lg p-12 mt-12" onSubmit={handleSubmit}>
                <label class="font-semibold text-xs" for="usernameField">Email</label>
                <input class="flex items-center h-12 px-4 w-64 bg-gray-200 mt-2 rounded focus:outline-none focus:ring-2" type="text" onChange={(e) => setEmail(e.target.value)} value={email} />
                <label class="font-semibold text-xs mt-3" for="passwordField">Password</label>
                <input class="flex items-center h-12 px-4 w-64 bg-gray-200 mt-2 rounded focus:outline-none focus:ring-2" type="password" onChange={(e) => setPassword(e.target.value)} value={password} />
                <button type='submit' class="flex items-center justify-center h-12 px-6 w-64 bg-blue-600 mt-8 rounded font-semibold text-sm text-blue-100 hover:bg-blue-700">Login</button>
                <div class="flex mt-6 justify-center text-xs">
                    <Link class="text-blue-400 hover:text-blue-500" to="/register">Sign up</Link>
                </div>
            </form>
        </div>
    )
};

export default Login;