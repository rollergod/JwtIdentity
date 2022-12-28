import React from 'react';
import Error from '../components/Error';

import { FadeLoader } from 'react-spinners';
import { useQuery } from '../features/hooks/useQuery';
import { useNavigate } from 'react-router-dom';
import { useConfirmEmailQuery, useLazyConfirmEmailQuery } from '../features/auth/accountSlice';
import CountDownTimer from '../components/CountDownTimer';

const EmailConfirmation = () => {
    const { userId, code } = useQuery();

    const [confirmationEmail, { isLoading, isError, error }] = useLazyConfirmEmailQuery();
    const navigate = useNavigate()

    React.useEffect(() => {
        (async () => {
            try {
                await confirmationEmail({
                    userId: userId,
                    code: encodeURIComponent(code)
                });
            } catch (error) {
                console.log(error);
            }
        })();
    }, [])

    React.useEffect(() => {
        if (isError && !isLoading)
            setTimeout(() => {
                navigate('/login')
            }, 5000)
    }, [isLoading, isError])

    const hoursMinSecs = { hours: 0, minutes: 0, seconds: 5 };

    return (
        <div className='flex justify-center pt-10'>
            {
                isLoading ? (<FadeLoader color="#36d7b7" />) :
                    (
                        <div>
                            {
                                isError ?
                                    <Error
                                        style={'text-3xl py-1 font-medium text-red-500'}
                                        message={error.data.message}
                                        errors={error.data.errors}
                                    /> :
                                    (
                                        <div>
                                            <h2 className='text-3xl py-1 font-medium'>Ваш Email успешно подтверждён.
                                                Теперь вы сможете войти в свой аккаунт</h2>
                                            <br />
                                        </div>
                                    )
                            }
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