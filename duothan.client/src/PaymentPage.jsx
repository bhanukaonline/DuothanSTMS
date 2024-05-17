import React, { useState } from 'react';

const PaymentPage = () => {
  const [amount, setAmount] = useState('');
  const [paymentStatus, setPaymentStatus] = useState(null);

  const handleTopUp = () => {
    // Simulate a payment process
    setPaymentStatus('Processing...');
    setTimeout(() => {
      setPaymentStatus('Top-up Successful!');
    }, 2000);
  };

  const handleTransportPayment = () => {
    // Simulate a payment process
    setPaymentStatus('Processing...');
    setTimeout(() => {
      setPaymentStatus('Payment Successful!');
    }, 2000);
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
          Integrated Payment System
        </h1>
      </header>
      
      <main className="container mx-auto flex-grow flex flex-col items-center">
        <div className="bg-white shadow-md rounded-lg p-8 w-full md:w-1/2 lg:w-1/3">
          <h2 className="text-2xl font-bold mb-6">Top-Up Transport Pass</h2>
          <div className="mb-4">
            <label className="block text-gray-700 font-semibold">Amount:</label>
            <input
              type="number"
              value={amount}
              onChange={(e) => setAmount(e.target.value)}
              className="mt-1 p-2 border border-gray-300 rounded-md w-full"
              placeholder="Enter amount to top-up"
            />
          </div>
          <button
            onClick={handleTopUp}
            className="w-full bg-blue-500 text-white py-2 rounded-md hover:bg-blue-600"
          >
            Top-Up
          </button>
          
          <h2 className="text-2xl font-bold mb-6 mt-10">Make Payment for Transport</h2>
          <button
            onClick={handleTransportPayment}
            className="w-full bg-green-500 text-white py-2 rounded-md hover:bg-green-600"
          >
            Pay for Transport
          </button>
          
          {paymentStatus && (
            <div className="mt-4 p-2 bg-yellow-100 border border-yellow-300 text-yellow-700 rounded-md">
              {paymentStatus}
            </div>
          )}
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

export default PaymentPage;
