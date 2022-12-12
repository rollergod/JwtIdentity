import { store } from '../../app/store';
import { deleteCredentials } from '../auth/authSlice';

export const logOut = () => {
    store.dispatch(deleteCredentials());
    localStorage.clear();
}