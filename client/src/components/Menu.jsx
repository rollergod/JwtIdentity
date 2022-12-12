import React from 'react';
import { BsFillMoonStarsFill } from 'react-icons/bs';

import { Link } from 'react-router-dom';
import { useSelector } from 'react-redux';
import { selectCurrentUser } from '../features/auth/authSlice';

import { logOut } from '../features/hooks/logOut';

const Menu = () => {
    const user = useSelector(selectCurrentUser);
    return (
        <nav className='py-3 mb-12 flex justify-between'>
            <h1 className='text-xl'>developedbyrollergod</h1>
            <ul className='flex items-center'>
                <li> <BsFillMoonStarsFill className='cursor-pointer text-2xl' /> </li>
                <li>
                    <a className='bg-gradient-to-r from-cyan-500 to-teal-500 text-white px-4 py-2 rounded-md ml-8' href="#">About</a>
                </li>
                <li>
                    <a className='bg-gradient-to-b from-purple-500 to-purple-700 text-white px-4 py-2 rounded-md ml-8' href="#">Resume</a>
                </li>
                <li>
                    <a className='bg-gradient-to-t from-orange-500 to-orange-600 text-white px-4 py-2 rounded-md ml-8' href="#">Github</a>
                </li>
                {
                    user === null || undefined ?
                        (
                            <>
                                <li>
                                    <Link className='text-black px-4 py-2 hover:text-red-500 transition duration-300' to="/register">Register</Link>
                                </li>
                                <li>
                                    <Link className='text-black px-4 py-2 hover:text-red-500 transition duration-300' to="/login">Login</Link>
                                </li>
                            </>
                        )
                        : (
                            <li>
                                <Link onClick={logOut} className='text-black px-4 py-2 hover:text-red-500 transition duration-300' to="/">Logout</Link>
                            </li>
                        )
                }

            </ul>
        </nav>
    )
};

export default Menu;