import React from 'react';

const Error = ({ message, errors }) => {

    return (
        <h2>
            Ooops.. something went wrong:
            {
                message ?
                    (
                        <p className='text-red-500'>{message}</p>
                    ) :
                    (
                        errors.map(obj => (
                            <p className='text-red-500'>{obj}</p>
                        ))
                    )
            }
        </h2>
    )
};

export default Error;