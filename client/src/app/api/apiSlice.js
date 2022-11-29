import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react';
import { setCredentials, logOut } from '../../features/auth/authSlice';

const baseQuery = fetchBaseQuery({
    baseUrl: 'http://localhost:5053/api',
    prepareHeaders: (headers, { getState }) => {
        const token = getState().auth.token;

        console.log('token', token);
        if (token) {
            headers.set('Authorization', `Bearer ${token}`);
        }
        return headers;
    }
});

export const apiSlice = createApi({
    baseQuery: baseQuery,
    endpoints: builder => ({})
});
