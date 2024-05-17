import React from 'react';
import { useNavigate } from 'react-router-dom';

const LandingPage = () => {
  const navigate = useNavigate();

  const handleProfileClick = () => {
    navigate('/profile');
  };

  const handlePaymentClick = () => {
    navigate('/payment');
  };

  const handleTrackingClick = () => {
    navigate('/tracking');
  };

  return (
    <div className="min-h-screen bg-gray-100 flex flex-col items-center">
      <nav className="w-full bg-white shadow-md py-4">
        <div className="container mx-auto flex justify-between items-center px-4">
          <div className="text-2xl font-bold">Neotropolis Transport</div>
          <div className="flex items-center">
            <div className="mr-4 text-gray-700">Token ID: 12345ABC</div>
            <img
              src="https://via.placeholder.com/40"
              alt="Profile"
              className="w-10 h-10 rounded-full cursor-pointer"
              onClick={handleProfileClick}
            />
          </div>
        </div>
      </nav>

      <header className="my-10">
        <h1 className="text-4xl font-bold text-center text-gray-800">
          Welcome to Neotropolis Transport
        </h1>
      </header>

      <main className="container mx-auto flex-grow flex flex-col items-center">
        <div className="w-full h-96 bg-gray-300 rounded-md shadow-md mb-6">
          {/* Map view will be integrated here */}
          <iframe
            src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3151.8354345093875!2d144.9537363153184!3d-37.81627917975192!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x6ad642af0f11fd81%3A0xf577de7580b7a354!2sMelbourne%20VIC%2C%20Australia!5e0!3m2!1sen!2sus!4v1626116792571!5m2!1sen!2sus"
            width="100%"
            height="100%"
            style={{ border: 0 }}
            allowFullScreen=""
            loading="lazy"
          ></iframe>
        </div>
        <button
          onClick={handlePaymentClick}
          className="mt-10 bg-green-500 text-white py-2 px-4 rounded-md hover:bg-green-600"
        >
          Go to Payment
        </button>
        <button
          onClick={handleTrackingClick}
          className="mt-4 bg-blue-500 text-white py-2 px-4 rounded-md hover:bg-blue-600"
        >
          Track Transport
        </button>
      </main>
      
      <footer className="w-full bg-white py-4 mt-10">
        <div className="container mx-auto text-center text-gray-600">
          © 2024 Neotropolis Transport. All rights reserved.
        </div>
      </footer>
    </div>
  );
};

export default LandingPage;
