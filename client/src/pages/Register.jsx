import React from 'react';

import { Link } from 'react-router-dom';
import { useNavigate } from 'react-router-dom';
import { useRegisterMutation } from '../features/auth/accountSlice';

import { FadeLoader } from 'react-spinners';

const Register = () => {
    const navigate = useNavigate();
    const [name, setName] = React.useState('');
    const [nickName, setNickName] = React.useState('');
    const [email, setEmail] = React.useState('');
    const [password, setPassword] = React.useState('');
    const [registerResponse, setRegisterResponse] = React.useState({});

    const [register, { isLoading, isError }] = useRegisterMutation();

    const [isRegisterSuccessfully, setIsRegisterSuccessfully] = React.useState(false);

    const handleSubmit = async (e) => {
        e.preventDefault();

        // //TODO ; доделать обработку регистрации
        // const result = await register({ name, nickName, email, password }).unwrap();
        // console.log('result', result); //object
        // setIsRegisterSuccessfully(true);

        // setRegisterResponse(result);
        // console.log(registerResponse);

        try {
            const result = await register({ name, nickName, email, password }).unwrap();
            setIsRegisterSuccessfully(true);
            setRegisterResponse(result);
        } catch (error) {
            console.log('error', error);
            setRegisterResponse(error);
        }
    }

    //TODO : валидация?
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
                            registerResponse.data.message ?
                                (
                                    <p>{registerResponse.data.message}</p>
                                ) :
                                (
                                    registerResponse.data.errors.map(obj => (
                                        <p>{obj}</p>
                                    ))
                                )
                        }
                    </h2>
                }

                <form onSubmit={handleSubmit}>
                    <div>
                        <label>Name</label>
                        <input
                            type='text'
                            className={`w-full p-2 text-primary border rounded-md outline-none text-sm transition duration-150 ease-in-out mb-4`}
                            id='name'
                            placeholder='Your name'
                            onChange={(e) => setName(e.target.value)}
                            value={name}
                            required
                        />
                    </div>
                    <div>
                        <label>Nickname</label>
                        <input
                            type='text'
                            className={`w-full p-2 text-primary border rounded-md outline-none text-sm transition duration-150 ease-in-out mb-4`}
                            id='nickname'
                            placeholder='Your display name'
                            onChange={(e) => setNickName(e.target.value)}
                            value={nickName}
                            required
                        />
                    </div>
                    <div>
                        <label>Email</label>
                        <input
                            type='email'
                            className={`w-full p-2 text-primary border rounded-md outline-none text-sm transition duration-150 ease-in-out mb-4`}
                            id='email'
                            placeholder='Your Email'
                            onChange={(e) => setEmail(e.target.value)}
                            value={email}
                            required
                        />
                    </div>
                    <div>
                        <label>Password</label>
                        <input
                            type='password'
                            className={`w-full p-2 text-primary border rounded-md outline-none text-sm transition duration-150 ease-in-out mb-4`}
                            id='password'
                            placeholder='Your Password'
                            onChange={(e) => setPassword(e.target.value)}
                            value={password}
                            required
                            minLength={5}
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
                    <span className='text-sm '>Are you have an account? <Link className='text-blue-600 hover:underline' to='/login'>sign up</Link></span>
                </form>
                <div className='flex justify-center pt-3'>
                    {
                        isLoading ? (<FadeLoader color="#36d7b7" />) :
                            (
                                isRegisterSuccessfully &&
                                <div>
                                    <h2 style={{ color: 'black' }}>{registerResponse.responseMessage}</h2>
                                </div>
                            )
                    }
                </div>
            </div >
        </div >
    )
};

export default Register;