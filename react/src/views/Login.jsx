import React, { useState } from "react";
import Layout from "../components/Layout";

const Login = () => {
  const [login, setLogin] = useState("");
  const [password, setPassword] = useState("");

  const handleSubmit = async (e) => {
    e.preventDefault();

    const response = await fetch("https://localhost:7265/api/Users/login", {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify({ login, password }),
    });

    // Handle the response from the server
    if (response.ok) {
      console.log("success");
    } else {
      console.log(response);
    }
  };

  return (
    <Layout>
      <div className="login">
        <h2 className="title">Login</h2>
        <form onSubmit={handleSubmit} className="login-form">
          <div>
            <label>Login:</label>
            <input
              type="text"
              value={login}
              onChange={(e) => setLogin(e.target.value)}
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
          <button type="submit" className="btn">
            Login
          </button>
        </form>
      </div>
    </Layout>
  );
};

export default Login;
