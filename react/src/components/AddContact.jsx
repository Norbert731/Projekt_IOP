import React, { useState } from "react";
import axios from "axios";

const AddContact = ({ togglePopup }) => {
  const [user, setUser] = useState({
    userID: 0,
    firstName: "",
    lastName: "",
    email: "",
    gender: "",
    city: "",
  });

  const handleSubmit = async (e) => {
    e.preventDefault();

    try {
      const response = await axios.put("/api/ContactsList", user);

      if (response.status === 200) {
        console.log("Contact saved successfully");
        // Reset the form
        setUser({
          userID: 0,
          firstName: "",
          lastName: "",
          email: "",
          gender: "",
          city: "",
        });
        togglePopup(); // Close the popup
      } else {
        console.log("Contact saving failed");
      }
    } catch (error) {
      console.error("An error occurred while saving the contact", error);
    }
  };

  const handleChange = (e) => {
    const { name, value } = e.target;
    setUser((prevUser) => ({
      ...prevUser,
      [name]: value,
    }));
  };

  const handleClose = () => {
    setUser({
      userID: 0,
      firstName: "",
      lastName: "",
      email: "",
      gender: "",
      city: "",
    });
    togglePopup(); // Close the popup
  };

  return (
    <>
      <div className="overlay" onClick={handleClose}></div>
      <div className="contact-form">
        <button onClick={handleClose} className="contact-form__close">
          Close
        </button>
        <h2>Add Contact</h2>
        <form onSubmit={handleSubmit} className="contact-form__form">
          <div>
            <label htmlFor="firstName">First Name:</label>
            <input
              type="text"
              id="firstName"
              name="firstName"
              value={user.firstName}
              onChange={handleChange}
              required
            />
          </div>
          <div>
            <label htmlFor="lastName">Last Name:</label>
            <input
              type="text"
              id="lastName"
              name="lastName"
              value={user.lastName}
              onChange={handleChange}
              required
            />
          </div>
          <div>
            <label htmlFor="email">Email:</label>
            <input
              type="email"
              id="email"
              name="email"
              value={user.email}
              onChange={handleChange}
              required
            />
          </div>
          <div>
            <label htmlFor="gender">Gender:</label>
            <input
              type="text"
              id="gender"
              name="gender"
              value={user.gender}
              onChange={handleChange}
              required
            />
          </div>
          <div>
            <label htmlFor="city">City:</label>
            <input
              type="text"
              id="city"
              name="city"
              value={user.city}
              onChange={handleChange}
              required
            />
          </div>
          <button type="submit" className="btn">
            Save
          </button>
        </form>
      </div>
    </>
  );
};

export default AddContact;
