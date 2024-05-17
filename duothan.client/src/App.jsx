import logo from "./logo.svg";
import "./App.css";
import TopNavigationBar from "./Components/TopNavigationBar";
import SignIn from "./Components/SignIn";
import TestDashboard from "./Components/TestDashboard";
import LandingPage from "./Components/LandingPage";
import ProfilePage from "./Components/ProfilePage";
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import PaymentPage from "./Components/PaymentPage";
import SignUpPage from "./Components/SignUpPage";
import TransportTracking from "./Components/TransportTracking";
import AdminDashboard from "./Components/AdminDashboard";

function App() {
  return (
    <Router>

      <Routes>
        <Route path="/profile" element={<ProfilePage />} />
        <Route path="/payment" element={<PaymentPage />} />
        <Route path="/signup" element={<SignUpPage />} />
        <Route path="/tracking" element={<TransportTracking />} />
        <Route path="/" element={<LandingPage />} />
      </Routes>
  </Router>
//   <div>
// <AdminDashboard/>
//   </div>

  );
}

export default App;
