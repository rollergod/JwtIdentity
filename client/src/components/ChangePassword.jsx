import React from "react";
import PasswordInput from "./PasswordInput";

const ChangePassword = () => {

    const [firstInputValue, setFirstInputValue] = React.useState('');
    const [secondInputValue, setSecondInputValue] = React.useState('');

    return (
        <div>
            <PasswordInput inputValue={firstInputValue} setInputValue={setFirstInputValue}></PasswordInput>
            <PasswordInput inputValue={secondInputValue} setInputValue={setSecondInputValue}></PasswordInput>
            <button onClick={() => console.log(firstInputValue === secondInputValue)}>Test</button>
        </div >
    )
};

export default ChangePassword;