import React from 'react';
import UserTableRow from './UserTableRow';

const UserTable = ({ users, setUsers }) => {
  return (
    <div>
      <table className="min-w-full">
        <thead>
          <tr>
            <th>DTP Code</th>
            <th>Username</th>
            <th>First Name</th>
            <th>Last Name</th>
            <th>Mobile</th>
            <th>Email</th>
            <th>Status</th>
            <th>Action</th>
          </tr>
        </thead>
        <tbody>
          {users.map((user) => (
            <UserTableRow key={user.id} user={user} users={users} setUsers={setUsers} />
          ))}
        </tbody>
      </table>
    </div>
  );
};

export default UserTable;
