import React from 'react';

import { useLocation } from "react-router-dom";
import { useDispatch } from 'react-redux';
import { useConfirmEmailQuery } from '../features/auth/accountSlice';

function useQuery() {
    const location = useLocation();
    const querystr = require('query-string');
    let { userId, code } = querystr.parse(location.search);

    return { userId, code };
}

const Test = () => {
    const { userId, code } = useQuery();

    const { data, isLoading, error } = useConfirmEmailQuery({
        userId: userId,
        code: encodeURIComponent(code)
    });

    console.log('confirm', data); // достать data от сюда(это message)
    console.log('confirm', error);

    return (
        <div>
            {
                isLoading ? (<h1>Loading</h1>) :
                    (
                        <h1>data</h1>
                    )
            }
        </div>
    )
};

export default Test;