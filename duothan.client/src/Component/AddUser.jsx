import React, { useState } from 'react';
import './AddUser.css';

export const AddUser = () => {
    const [action, setAction] = useState("Add User");
    const [firstName, setFirstName] = useState("");
    const [lastName, setLastName] = useState("");
    const [username, setUsername] = useState("");
    const [mobileNumber, setMobileNumber] = useState("");
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");
    const [confirmPassword, setConfirmPassword] = useState("");

    return (
        <div className='container'>
            <div className='header'>
                <div className="text">Add User</div>
                <div className='underline'></div>
            </div>
            <div className='divide'>
                <div className="inputs">
                    <div className='input'>
                        <img src="" alt="" />
                        <input
                            type='text'
                            placeholder='First Name'
                            value={firstName}
                            onChange={(e) => setFirstName(e.target.value)}
                        />
                    </div>
                    <div className='input'>
                        <img src="" alt="" />
                        <input
                            type='text'
                            placeholder='Last Name'
                            value={lastName}
                            onChange={(e) => setLastName(e.target.value)}
                        />
                    </div>
                </div>
                <div className="inputs">
                    <div className='input'>
                        <img src="" alt="" />
                        <input
                            type='text'
                            placeholder='Username'
                            value={username}
                            onChange={(e) => setUsername(e.target.value)}
                        />
                    </div>
                    <div className='input'>
                        <img src="" alt="" />
                        <input
                            type='number'
                            placeholder='Mobile Number'
                            value={mobileNumber}
                            onChange={(e) => setMobileNumber(e.target.value)}
                        />
                    </div>
                </div>
                <div className='input'>
                    <img src="" alt="" />
                    <input
                        type='email'
                        placeholder='Email ID'
                        value={email}
                        onChange={(e) => setEmail(e.target.value)}
                    />
                </div>
                <div className="divide">
                    <div className="inputs">
                        <div className='input'>
                            <img src="" alt="" />
                            <input
                                type='password'
                                placeholder='Password'
                                value={password}
                                onChange={(e) => setPassword(e.target.value)}
                            />
                        </div>
                        <div className='input'>
                            <img src="" alt="" />
                            <input
                                type='password'
                                placeholder='Confirm Password'
                                value={confirmPassword}
                                onChange={(e) => setConfirmPassword(e.target.value)}
                            />
                        </div>
                    </div>
                </div>
                <div className="add-container">
                    <div className={action === "add" ? "add gray" : "add"} onClick={() => { setAction(null) }}>
                        Add User
                    </div>
                </div>
            </div>
        </div>
    );
}

export default AddUser;
