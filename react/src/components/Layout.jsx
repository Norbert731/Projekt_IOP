import React from "react";
import Header from "./Header";

export default function Layout({ children }) {
  return (
    <>
      <Header />
      <main className="container">{children}</main>
    </>
  );
}
