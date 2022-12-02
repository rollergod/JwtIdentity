import { apiSlice } from "../../app/api/apiSlice";

export const accountSlice = apiSlice.injectEndpoints({
    endpoints: builder => ({
        login: builder.mutation({
            query: credentials => ({
                url: 'account/login',
                method: 'POST',
                body: { ...credentials },
            })
        }),
        register: builder.mutation({
            query: credentials => ({
                url: 'account/register',
                method: 'POST',
                body: { ...credentials },
            })
        }),
        confirmEmail: builder.query({
            query: ({ userId, code }) =>
                `account/confirmemail?userid=${userId}&code=${code}`,
        })
    })
})

export const {
    useLoginMutation,
    useRegisterMutation,
    useConfirmEmailQuery
} = accountSlice;