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
        }),
        forgotPassword: builder.mutation({
            query: email => ({
                url: 'account/forgotpassword',
                method: 'POST',
                body: { ...email }
            })
        }),
        changePassword: builder.mutation({
            query: credentials => ({
                url: 'account/resetpassword',
                method: 'POST',
                body: { ...credentials }
            })
        })
    })
})

export const {
    useLoginMutation,
    useRegisterMutation,
    useConfirmEmailQuery,
    useLazyConfirmEmailQuery,
    useForgotPasswordMutation,
    useChangePasswordMutation
} = accountSlice;