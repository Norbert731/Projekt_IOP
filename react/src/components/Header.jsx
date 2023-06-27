import React from "react";
import { Link } from "react-router-dom";

export default function Header() {
  return (
    <header className="header">
      <ul className="header__list">
        <li>
          <Link to="/">Contacts</Link>
        </li>
        <li>
          <Link to="/login">Login</Link>
        </li>
        <li>
          <Link to="/registration">Sign up</Link>
        </li>
      </ul>
    </header>
  );
}
