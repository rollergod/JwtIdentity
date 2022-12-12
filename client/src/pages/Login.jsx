import React from 'react';

import { Link } from 'react-router-dom';
import { useNavigate } from 'react-router-dom';
import { useDispatch } from 'react-redux';
import { setCredentials } from '../features/auth/authSlice';
import { useLoginMutation } from '../features/auth/accountSlice';

import { FadeLoader } from 'react-spinners';

const Login = () => {
    const navigate = useNavigate();
    const dispatch = useDispatch();
    const [login, { isError, isLoading }] = useLoginMutation();

    const [email, setEmail] = React.useState('');
    const [password, setPassword] = React.useState('');
    const [loginResponse, setLoginResponse] = React.useState({});

    const handleSubmit = async (e) => {
        e.preventDefault();

        try {
            const userData = await login({ email, password }).unwrap();
            dispatch(setCredentials(userData));

            if (!isLoading) {
                navigate('/', { replace: true });
            }

        } catch (error) {
            console.log('error', error);
            setLoginResponse(error);
        }
    };

    return (
        <div className='h-screen flex bg-gray-bg1'>
            <div className='w-full max-w-md m-auto bg-white rounded-lg border border-primaryBorder shadow-default py-10 px-16'>
                <h1 className='text-2xl font-medium text-primary mt-2 mb-5 text-center'>
                    Log in to your account 🔐
                </h1>

                {
                    isError &&
                    <h2>
                        Ooops.. something went wrong:
                        {
                            loginResponse.data.message ?
                                (
                                    <p>{loginResponse.data.message}</p>
                                )
                                :
                                (
                                    loginResponse.data.errors.map(obj => (
                                        <p>{obj}</p>
                                    ))
                                )
                        }
                    </h2>
                }

                <form onSubmit={handleSubmit}>
                    <div>
                        <label htmlFor='email'>Email</label>
                        <input
                            type='email'
                            className={`w-full p-2 text-primary border rounded-md outline-none text-sm transition duration-150 ease-in-out mb-4`}
                            id='email'
                            placeholder='Your Email'
                            onChange={(e) => setEmail(e.target.value)}
                            value={email}
                        />
                    </div>
                    <div>
                        <label htmlFor='password'>Password</label>
                        <input
                            type='password'
                            className={`w-full p-2 text-primary border rounded-md outline-none text-sm transition duration-150 ease-in-out mb-4`}
                            id='password'
                            placeholder='Your Password'
                            onChange={(e) => setPassword(e.target.value)}
                            value={password}
                        />
                    </div>

                    <div className='flex justify-center items-center mt-6'>
                        <button
                            className={`bg-green py-2 px-4 text-sm text-black rounded border border-green focus:outline-none focus:border-green-dark`}
                            type='submit'
                        >
                            Login
                        </button>
                    </div>
                    <span className='text-sm '>Dont have an account? <Link className='text-blue-600 hover:underline' to='/register'>sign up</Link></span>
                </form>
                <div className='flex justify-center pt-3'>
                    {
                        isLoading ? (<FadeLoader color="#36d7b7" />) :
                            (
                                isError === false &&
                                <div>
                                    {/* TODO: добавить в loginresponse - responseMessage */}
                                    <h2 style={{ color: 'black' }}>{loginResponse.token}</h2>
                                </div>
                            )
                    }
                </div>
            </div>
        </div>
    )
};

export default Login;