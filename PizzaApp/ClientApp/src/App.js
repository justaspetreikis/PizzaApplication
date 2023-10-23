import React from "react";
import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import { GlobalStyle } from "./globalStyles";
import Hero from "./components/Hero";
import PizzaOrder from "./components/PizzaOrder/PizzaOrder";
import OrdersHistory from "./components/OrdersHistory/OrdersHistory";
import Footer from "./components/Footer";

function App() {
  return (
    <Router>
      <GlobalStyle />
      <Routes>
        <Route path="/" exact element={<Hero />} />
        <Route path="/pizzaOrder" element={<PizzaOrder />} />
        <Route path="/ordersHistory" element={<OrdersHistory />} />
      </Routes>
      <Footer />
    </Router>
  );
}

export default App;
