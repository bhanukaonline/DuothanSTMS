import React from 'react';

const UserTableRow = ({ user, users, setUsers }) => {
  const handleDelete = async () => {
    try {
      // Implement delete logic here
    } catch (error) {
      console.error('Error deleting user', error);
    }
  };

  return (
    <tr>
      <td>{user.dtpCode}</td>
      <td>{user.username}</td>
      <td>{user.firstName}</td>
      <td>{user.lastName}</td>
      <td>{user.mobile}</td>
      <td>{user.email}</td>
      <td>{user.status}</td>
      <td>
        <button onClick={handleDelete} className="text-red-500 hover:text-red-700">
          Delete
        </button>
      </td>
    </tr>
  );
};

export default UserTableRow;
