import React, { useEffect, useState } from "react";
import axios from "axios";

export default function Contacts() {
  const [users, setUsers] = useState([]);

  useEffect(() => {
    const fetchUsers = async () => {
      try {
        const response = await axios.get(
          "https://localhost:7265/api/ContactsList"
        );
        setUsers(response.data);
        console.log(response.data);
      } catch (error) {
        console.error(error);
      }
    };

    fetchUsers();
  }, []);

  return (
    <table className="contacts">
      <thead>
        <tr>
          <th>First Name</th>
          <th>Last Name</th>
          <th>Email</th>
          <th>Gender</th>
          <th>City</th>
        </tr>
      </thead>
      <tbody>
        {users.map((user) => (
          <tr key={user.userid}>
            <td>{user.firstName}</td>
            <td>{user.lastName}</td>
            <td>{user.email}</td>
            <td>{user.gender}</td>
            <td>{user.city}</td>
          </tr>
        ))}
      </tbody>
    </table>
  );
}
