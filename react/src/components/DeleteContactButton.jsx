import React from "react";
import axios from "axios";
export default function DeleteContactButton(props) {
  const handleClick = () => {
    try {
      axios.delete(`https://localhost:7265/api/ContactsList/${props.userid}`);
    } catch (error) {
      console.error(error);
    }
  };
  return <button onClick={handleClick}>Delete</button>;
}
