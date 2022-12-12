import { createSlice } from '@reduxjs/toolkit';

const authSlice = createSlice({
    name: 'auth',
    initialState: {
        user: {
            name: '',
            email: '',
        },
        token: ''
    },
    reducers: {
        setCredentials: (state, action) => {
            const { displayName, email, token } = action.payload;

            state.user = {
                name: displayName,
                email: email,
            };
            state.token = token;
        },
        deleteCredentials: (state, action) => {
            state.user = null;
            state.token = null;
        }
    }
});

export const { setCredentials, deleteCredentials } = authSlice.actions;

export default authSlice.reducer;

export const selectCurrentUser = (state) => state.auth.user;
export const selectCurrentToken = (state) => state.auth.token;