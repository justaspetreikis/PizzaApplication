import React, { useState, useEffect } from "react";
import Navbar from "../Navbar";
import Sidebar from "../Sidebar";
import Footer from "../Footer";
import {
  PizzaOrderContainer,
  OrderItem,
  OrderH2,
  OrderButton,
  FlexWrapUl,
  OrderBtn,
  OrderInformationDiv,
} from "./PizzaOrderElements";

const PizzaOrder = () => {
  const [pizzaSizes, setPizzaSizes] = useState([]);
  const [pizzaToppings, setPizzaToppings] = useState([]);
  const [selectedSize, setSelectedSize] = useState(null);
  const [selectedToppings, setSelectedToppings] = useState([]);
  const [orderDetails, setOrderDetails] = useState(null);
  const [isOpen, setIsOpen] = useState(false);

  const toggle = () => {
    setIsOpen(!isOpen);
  };

  useEffect(() => {
    fetch("pizzaorder/sizes")
      .then((response) => response.json())
      .then((data) => {
        setPizzaSizes(data);
      })
      .catch((error) => {
        console.error("Error fetching pizza sizes:", error);
      });

    fetch("pizzaorder/toppings")
      .then((response) => response.json())
      .then((data) => {
        setPizzaToppings(data);
      })
      .catch((error) => {
        console.error("Error fetching pizza toppings:", error);
      });
  }, []);

  const handleSizeSelection = (size) => {
    setSelectedSize(size);
  };

  const handleToppingSelection = (topping) => {
    if (selectedToppings.includes(topping)) {
      setSelectedToppings(selectedToppings.filter((item) => item !== topping));
    } else {
      setSelectedToppings([...selectedToppings, topping]);
    }
  };

  const placeOrder = () => {
    if (selectedSize && selectedToppings.length > 0) {
      const orderRequest = {
        SizeId: selectedSize.id,
        ToppingIds: selectedToppings.map((topping) => topping.id),
      };

      fetch("/pizzaorder", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(orderRequest),
      })
        .then((response) => {
          if (response.ok) {
            return response.json();
          } else {
            console.error("Error placing the order.");
          }
        })
        .then((orderData) => {
          if (orderData) {
            console.log("Order placed successfully!");
            console.log(orderData);
            setOrderDetails(orderData);
            setSelectedSize(null);
            setSelectedToppings([]);
          }
        })
        .catch((error) => {
          console.error("Error placing the order:", error);
        });
    } else {
      console.error(
        "Please select a size and at least one topping before placing the order."
      );
    }
  };

  function renderToppings() {
    return (
      <FlexWrapUl>
        {pizzaToppings &&
          pizzaToppings.map((topping) => (
            <OrderItem key={topping.id}>
              <OrderButton
                selected={selectedToppings.includes(topping)}
                onClick={() => handleToppingSelection(topping)}
              >
                {topping.name}
              </OrderButton>
            </OrderItem>
          ))}
      </FlexWrapUl>
    );
  }

  function renderPizzaSizes() {
    return (
      <FlexWrapUl>
        {pizzaSizes &&
          pizzaSizes.map((size) => (
            <OrderItem key={size.id}>
              <OrderButton
                onClick={() => handleSizeSelection(size)}
                selected={size === selectedSize}
              >
                {size.name}
              </OrderButton>
            </OrderItem>
          ))}
      </FlexWrapUl>
    );
  }

  function renderOrderDetails() {
    return (
      <div>
        <OrderBtn onClick={placeOrder}>Place Order</OrderBtn>
        {orderDetails && (
          <OrderInformationDiv>
            <h2>Your Order Information</h2>
            <p>Pizza Size: {orderDetails.sizeId}</p>
            <p>
              Toppings:{" "}
              {orderDetails.pizzaOrderToppings
                .map((topping) => topping.topping.name)
                .join(", ")}
            </p>
            <p>Total cost: {orderDetails.totalCost} Eur</p>
          </OrderInformationDiv>
        )}
      </div>
    );
  }

  return (
    <PizzaOrderContainer>
      <Navbar toggle={toggle} />
      <Sidebar isOpen={isOpen} toggle={toggle} />
      <OrderH2>Select Pizza Size</OrderH2>
      {renderPizzaSizes()}
      <OrderH2>Select Toppings</OrderH2>
      {renderToppings()}
      {renderOrderDetails()}
      <Footer />
    </PizzaOrderContainer>
  );
};

export default PizzaOrder;
