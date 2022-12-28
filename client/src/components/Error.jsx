import React from 'react';

const Error = ({ style, message, errors }) => {

    return (
        <h2>
            Ooops.. something went wrong:
            {
                message ?
                    (
                        <p className={style}>{message}</p>
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