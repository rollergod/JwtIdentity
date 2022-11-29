import React from 'react';
import { AiFillGithub } from 'react-icons/ai';
import { BsTelegram } from 'react-icons/bs';
import { SiVk } from 'react-icons/si';

const Socials = () => {
    return (
        <div className='text-5xl flex justify-center gap-16 py-3 text-gray-600 mb-16'>
            <AiFillGithub />
            <BsTelegram />
            <SiVk />
        </div>
    )
};

export default Socials;