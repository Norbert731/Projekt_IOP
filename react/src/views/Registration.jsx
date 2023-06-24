import React, { useState } from "react";

const Registration = () => {
  const [username, setUsername] = useState("");
  const [password, setPassword] = useState("");
  const [confirmPassword, setConfirmPassword] = useState("");
  const [message, setMessage] = useState("");

  const handleSubmit = async (e) => {
    e.preventDefault();

    // Perform client-side validation
    if (password !== confirmPassword) {
      setMessage("Passwords don't match");
      return;
    }
    setMessage("");

    const response = await fetch("https://localhost:7265/api/Users/register", {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify({ username, password }),
    });

    // Handle the response from the server
    if (response.ok) {
      console.log("success");
    } else {
      console.log(response);
    }
  };

  return (
    <div className="login">
      <h2 className="title">Register</h2>
      <form onSubmit={handleSubmit} className="login-form">
        <div>
          <label>Username:</label>
          <input
            type="text"
            value={username}
            onChange={(e) => setUsername(e.target.value)}
          />
        </div>
        <div>
          <label>Password:</label>
          <input
            type="password"
            value={password}
            onChange={(e) => setPassword(e.target.value)}
          />
        </div>
        <div>
          <label>Confirm Password:</label>
          <input
            type="password"
            value={confirmPassword}
            onChange={(e) => setConfirmPassword(e.target.value)}
          />
        </div>
        {message && <p className="message message--error">{message}</p>}
        <button type="submit" className="btn">
          Register
        </button>
      </form>
    </div>
  );
};

export default Registration;
