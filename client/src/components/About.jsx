import React from 'react'

const About = () => {
    return (
        <div className='mb-16'>
            <h3 className='text-3xl py-1 font-medium'>About me</h3>
            <p className='mx-auto text-md py-2 leading-8 text-gray-800 w-1/2'>
                My name is Renat. I`m from Russia and i`m 20 years old and i like to <span className='text-teal-500'>write code</span>.
                <br />
                Since the beginning of my journey, I have discovered a lot of <span className='text-blue-700'>new things</span>.
                I get a lot of pleasure when I write code.
                <br />
                Every day I try to reach <span className='text-teal-500'>new heights.</span>
            </p>
        </div>
    )
};

export default About;