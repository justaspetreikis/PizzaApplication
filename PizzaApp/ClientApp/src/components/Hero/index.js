import React, { useState } from "react";
import Navbar from "../Navbar";
import Sidebar from "../Sidebar";
import Footer from "../Footer";
import { Link } from "react-router-dom"; // Import Link from React Router
import {
  HeroContainer,
  HeroContent,
  HeroItems,
  HeroH1,
  HeroP,
  HeroBtn,
} from "./HeroElements";

const Hero = () => {
  const [isOpen, setIsOpen] = useState(false);

  const toggle = () => {
    setIsOpen(!isOpen);
  };

  return (
    <HeroContainer>
      <Navbar toggle={toggle} />
      <Sidebar isOpen={isOpen} toggle={toggle} />
      <HeroContent>
        <HeroItems>
          <HeroH1>Pizza Perfection</HeroH1>
          <HeroP>With every slice, we deliver happiness to your doorstep.</HeroP>
          <Link to="/pizzaOrder">
            <HeroBtn>Place Order</HeroBtn>
          </Link>
        </HeroItems>
      </HeroContent>
      <Footer />
    </HeroContainer>
  );
};

export default Hero;
