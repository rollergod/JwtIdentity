import { createSlice } from '@reduxjs/toolkit';

const authSlice = createSlice({
    name: 'auth',
    initialState: {
        user: {
            name: '',
            email: '',
            displayName: '',
        },
        token: ''
    },
    reducers: {
        setCredentials: (state, action) => {
            const { displayName, email, token, userName } = action.payload;

            state.user = {
                name: userName,
                email: email,
                displayName: displayName
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