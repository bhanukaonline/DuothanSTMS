import React, { useState, useEffect } from 'react';
import axios from 'axios';

const TransportTracking = () => {
  const [transportData, setTransportData] = useState([]);
  const [trafficData, setTrafficData] = useState([]);

  useEffect(() => {
    const fetchTransportData = async () => {
      try {
        const response = await axios.get('/api/transport');
        setTransportData(response.data);
      } catch (error) {
        console.error('Error fetching transport data', error);
      }
    };

    const fetchTrafficData = async () => {
      try {
        const response = await axios.get('/api/traffic');
        setTrafficData(response.data);
      } catch (error) {
        console.error('Error fetching traffic data', error);
      }
    };

    fetchTransportData();
    fetchTrafficData();
  }, []);

  return (
    <div className="min-h-screen bg-gray-100 flex flex-col items-center">
      <nav className="w-full bg-white shadow-md py-4">
        <div className="container mx-auto flex justify-between items-center px-4">
          <div className="text-2xl font-bold">Neotropolis Transport Tracking</div>
        </div>
      </nav>

      <header className="my-10">
        <h1 className="text-4xl font-bold text-center text-gray-800">
          Real-Time Transport Tracking
        </h1>
      </header>

      <main className="container mx-auto flex-grow flex flex-col items-center">
        <div className="w-full h-96 bg-gray-300 rounded-md shadow-md mb-6">
          {/* Map view to be integrated here */}
          <iframe
            src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3151.8354345093875!2d144.9537363153184!3d-37.81627917975192!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x6ad642af0f11fd81%3A0xf577de7580b7a354!2sMelbourne%20VIC%2C%20Australia!5e0!3m2!1sen!2sus!4v1626116792571!5m2!1sen!2sus"
            width="100%"
            height="100%"
            style={{ border: 0 }}
            allowFullScreen=""
            loading="lazy"
          ></iframe>
        </div>

        <div className="w-full">
          <h2 className="text-2xl font-bold mb-4">Public Transport Vehicles</h2>
          <ul className="bg-white shadow-md rounded-md p-4">
            {transportData.map((vehicle) => (
              <li key={vehicle.vehicleId} className="mb-2">
                Vehicle ID: {vehicle.vehicleId}, Route: {vehicle.route}, Location: ({vehicle.latitude}, {vehicle.longitude})
              </li>
            ))}
          </ul>
        </div>

        <div className="w-full mt-10">
          <h2 className="text-2xl font-bold mb-4">Traffic Optimization</h2>
          <ul className="bg-white shadow-md rounded-md p-4">
            {trafficData.map((traffic) => (
              <li key={traffic.id} className="mb-2">
                Route: {traffic.route}, Status: {traffic.status}
              </li>
            ))}
          </ul>
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

export default TransportTracking;
