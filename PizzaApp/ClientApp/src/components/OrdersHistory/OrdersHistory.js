import React, { useState, useEffect } from "react";
import Navbar from "../Navbar";
import Sidebar from "../Sidebar";
import Footer from "../Footer";
import {
  HistoryContainer,
  OrderHistoryItem,
  OrdersHistoryH1,
  PaginationContainer,
  FlexWrapper,
} from "./OrdersHistoryElements";

const OrdersHistory = () => {
  const [orders, setOrders] = useState([]);
  const [currentPage, setCurrentPage] = useState(1);
  const [ordersPerPage] = useState(6);
  const [isOpen, setIsOpen] = useState(false);

  const toggle = () => {
    setIsOpen(!isOpen);
  };

  useEffect(() => {
    fetch("pizzaorder")
      .then((response) => response.json())
      .then((data) => {
        setOrders(data);
      })
      .catch((error) => {
        console.error("Error fetching order history:", error);
      });
  }, []);

  const indexOfLastOrder = currentPage * ordersPerPage;
  const indexOfFirstOrder = indexOfLastOrder - ordersPerPage;
  const currentOrders = orders.slice(indexOfFirstOrder, indexOfLastOrder);

  const paginate = (pageNumber) => {
    setCurrentPage(pageNumber);
  };

  const renderOrderItem = (order) => (
    <OrderHistoryItem key={order.orderId}>
      <p>Order ID: {order.orderId}</p>
      <p>Pizza Size: {order.sizeName}</p>
      <p>
        Toppings: {order.toppings.map((topping) => topping.name).join(", ")}
      </p>
      <p>Total Cost: {order.totalCost}</p>
    </OrderHistoryItem>
  );

  const renderPaginationButtons = () => {
    return Array.from({ length: Math.ceil(orders.length / ordersPerPage) }).map(
      (_, index) => (
        <button key={index} onClick={() => paginate(index + 1)}>
          {index + 1}
        </button>
      )
    );
  };

  return (
    <HistoryContainer>
      <Navbar toggle={toggle} />
      <Sidebar isOpen={isOpen} toggle={toggle} />
      <OrdersHistoryH1>Orders History</OrdersHistoryH1>
      <FlexWrapper>{currentOrders.map(renderOrderItem)}</FlexWrapper>
      <PaginationContainer>{renderPaginationButtons()}</PaginationContainer>
      <Footer />
    </HistoryContainer>
  );
};

export default OrdersHistory;
