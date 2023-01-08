import React from "react";
import { AiFillEye } from "react-icons/ai";

const PasswordInput = ({ inputValue, setInputValue }) => {

    const [passwordType, setPasswordType] = React.useState('password');

    const handlePasswordChange = (e) => {
        setInputValue(e.target.value);
    }

    const togglePassword = (e) => {
        if (passwordType === 'password') {
            setPasswordType('text');
            return;
        }
        setPasswordType("password");
    }

    return (
        <div className="row">
            <div className="col-sm-3">
                <div className="input-group my-4 mx-4">
                    <input type={passwordType} onChange={handlePasswordChange} value={inputValue} name="password" class="form-control" placeholder="Password" />
                    <div className="input-group-btn">
                        <button className="btn btn-outline-primary" onClick={togglePassword}>
                            {passwordType === "password" ? <AiFillEye></AiFillEye> : <AiFillEye></AiFillEye>}
                        </button>
                    </div>
                </div>
            </div>
        </div>
    );
};

export default PasswordInput;
