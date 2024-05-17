import React from 'react';

const ProfilePage = () => {
  const user = {
    userId: '12345',
    username: 'johndoe',
    password: 'password123',
    email: 'johndoe@example.com',
    fullName: 'John Doe',
    createdDate: '2023-05-17'
  };

  return (
    <div className="min-h-screen bg-gray-100 flex flex-col items-center">
      <nav className="w-full bg-white shadow-md py-4">
        <div className="container mx-auto flex justify-between items-center px-4">
          <div className="text-2xl font-bold">Neotropolis Transport</div>
        </div>
      </nav>
      
      <header className="my-10">
        <h1 className="text-4xl font-bold text-center text-gray-800">
          User Profile
        </h1>
      </header>
      
      <main className="container mx-auto flex-grow flex flex-col items-center">
        <div className="bg-white shadow-md rounded-lg p-8 w-full md:w-1/2 lg:w-1/3">
          <h2 className="text-2xl font-bold mb-6">Profile Details</h2>
          <div className="mb-4">
            <label className="block text-gray-700 font-semibold">User ID:</label>
            <div className="mt-1 text-gray-900">{user.userId}</div>
          </div>
          <div className="mb-4">
            <label className="block text-gray-700 font-semibold">Username:</label>
            <div className="mt-1 text-gray-900">{user.username}</div>
          </div>
          <div className="mb-4">
            <label className="block text-gray-700 font-semibold">Password:</label>
            <div className="mt-1 text-gray-900">{user.password}</div>
          </div>
          <div className="mb-4">
            <label className="block text-gray-700 font-semibold">Email:</label>
            <div className="mt-1 text-gray-900">{user.email}</div>
          </div>
          <div className="mb-4">
            <label className="block text-gray-700 font-semibold">Full Name:</label>
            <div className="mt-1 text-gray-900">{user.fullName}</div>
          </div>
          <div className="mb-4">
            <label className="block text-gray-700 font-semibold">Created Date:</label>
            <div className="mt-1 text-gray-900">{user.createdDate}</div>
          </div>
        </div>
      </main>
      
      <footer className="w-full bg-white py-4 mt-10">
        <div className="container mx-auto text-center text-gray-600">
          © 2024 Neotropolis Transport. All rights reserved.
        </div>
      </footer>
    </div>
  );
};

export default ProfilePage;
