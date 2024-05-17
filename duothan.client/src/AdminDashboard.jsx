import React, { useState, useEffect } from 'react';
import axios from 'axios';
import UserTable from './UserTable';
import PaymentPage from './PaymentPage';
import AdminDetailsTable from './AdminDetailsTable';

const AdminDashboard = () => {
  // State variables for users, payments, and admin details
  const [users, setUsers] = useState([]);
  const [payments, setPayments] = useState([]);
  const [adminDetails, setAdminDetails] = useState([]);

  // Fetch users, payments, and admin details on component mount
  useEffect(() => {
    const fetchUsers = async () => {
      try {
        const response = await axios.get('/api/users');
        setUsers(response.data);
      } catch (error) {
        console.error('Error fetching users', error);
      }
    };

    const fetchPayments = async () => {
      try {
        const response = await axios.get('/api/payments');
        setPayments(response.data);
      } catch (error) {
        console.error('Error fetching payments', error);
      }
    };

    const fetchAdminDetails = async () => {
      try {
        const response = await axios.get('/api/admins');
        setAdminDetails(response.data);
      } catch (error) {
        console.error('Error fetching admin details', error);
      }
    };

    fetchUsers();
    fetchPayments();
    fetchAdminDetails();
  }, []);

  return (
    <div className="container mx-auto mt-8">
      <div className="grid grid-cols-2 gap-8">
        <div>
          <h2 className="text-lg font-bold mb-4">Total Users: {users.length}</h2>
         
        </div>
        <div>
          <h2 className="text-lg font-bold mb-4">Total Payments: {users.length}</h2>
        
        </div>
       
      </div>
    
      {/* <div className="mt-8">
        <h2 className="text-lg font-bold mb-4">Admin Details</h2>
        <AdminDetailsTable adminDetails={adminDetails} setAdminDetails={setAdminDetails} />
      </div> */}
    </div>
  );
};

export default AdminDashboard;
