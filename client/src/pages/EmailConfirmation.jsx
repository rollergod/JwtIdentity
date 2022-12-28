import React from 'react';

import { FadeLoader } from 'react-spinners';
import { useQuery } from '../features/hooks/useQuery';
import { useNavigate } from 'react-router-dom';
import { useConfirmEmailQuery } from '../features/auth/accountSlice';
import CountDownTimer from '../components/CountDownTimer';

const EmailConfirmation = () => {
    const { userId, code } = useQuery();

    //TODO: email уже подтверждён?
    const { isLoading, isError } = useConfirmEmailQuery({
        userId: userId,
        code: encodeURIComponent(code)
    });

    const navigate = useNavigate()

    React.useEffect(() => {
        if (!isLoading)
            setTimeout(() => {
                navigate('/login')
            }, 5000)
    }, [isLoading])

    const hoursMinSecs = { hours: 0, minutes: 0, seconds: 5 };
    return (
        <div className='flex justify-center pt-10'>
            {
                isLoading ? (<FadeLoader color="#36d7b7" />) :
                    (
                        <div>
                            <h2 className='text-3xl py-1 font-medium'>Ваш Email успешно подтверждён.
                                Теперь вы сможете войти в свой аккаунт</h2>
                            <br />
                            <p>
                                Через <CountDownTimer hoursMinSecs={hoursMinSecs} /> секунд вы будете перенаправлены на страницу входа.
                            </p>
                        </div>
                    )
            }
        </div>
    )
};

export default EmailConfirmation;