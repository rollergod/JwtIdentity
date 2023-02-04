import React from "react";
import { useQuery } from "../features/hooks/useQuery";
import PasswordInput from "../components/PasswordInput";

import { useChangePasswordMutation } from "../features/auth/accountSlice";
import { useSelector } from "react-redux";
import { selectCurrentUser } from "../features/auth/authSlice";

const ChangePassword = () => {

    const user = useSelector(selectCurrentUser);
    const { code } = useQuery();
    const [firstInputValue, setFirstInputValue] = React.useState('');
    const [secondInputValue, setSecondInputValue] = React.useState('');

    const [changePassword, { isError, isLoading, data, error }] = useChangePasswordMutation();

    const handleSubmit = async (e) => {
        e.preventDefault();

        try {
            const result = await changePassword({
                code: encodeURI(code),
                email: user.email,
                password: firstInputValue,
            }).unwrap();

            console.log('data', data);
            console.log('result', result);
        } catch (error) {
            console.log(error);
        }
    }

    return (
        <div>
            <PasswordInput inputValue={firstInputValue} setInputValue={setFirstInputValue}></PasswordInput>
            <PasswordInput inputValue={secondInputValue} setInputValue={setSecondInputValue}></PasswordInput>
            <button onClick={handleSubmit}>Test</button>
        </div >
    )
};

export default ChangePassword;