import styled from "styled-components";
import ImgBg from "../../Images/pizza-3.png";

export const PizzaOrderContainer = styled.div`
  background: linear-gradient(to right, rgba(0, 0, 0, 0.7), rgba(0, 0, 0, 0.1)),
    url(${ImgBg});
  height: 100vh;
  background-position: center;
  background-size: cover;
`;

export const OrderItem = styled.div`
  font-size: 20px;
  color: #fff;
  flex: 0 0 calc(33.33% - 20px);
  margin: 10px;
  padding: 0px;
  border: 1px solid #ccc;
  display: flex;
  justify-content: center;
  align-items: center;
  background: yellow;
`;

export const OrderH2 = styled.h2`
  color: #fff;
  display: flex;
  justify-content: center;
  align-items: center;
  font-size: clamp(1rem, 5vw, 2rem);
  margin-top: 1rem; /* Adjust the font size as needed */
  margin-bottom: 1rem;
  box-shadow: 3px 5px #e9ba23;
  letter-spacing: 3px;
`;

export const OrderBtn = styled.button`
  margin: 2rem auto;
  font-size: 1.4rem;
  padding: 1rem 4rem;
  border: none;
  background: #e31837;
  color: #fff;
  transition: 0.2s ease-out;
  display: block;

  &:hover {
    background: #ffc500;
    transition: 0.2s ease-out;
    cursor: pointer;
    color: #000;
  }
`;

export const OrderButton = styled.button`
  flex: 1;
  background: ${(props) => (props.selected ? "#00FF00" : "yellow")};
  border: none;
  padding: 10px 0;
  font-size: 16px;
  cursor: pointer;
`;

export const FlexWrapUl = styled.ul`
  display: flex;
  flex-wrap: wrap;
`;

export const OrderInformationDiv = styled.div`
  text-align: center;
  background: rgba(0, 0, 0, 0.7);
  color: #fff;
  padding: 20px;
  margin: 0 auto;
  max-width: 600px;
  border: 1px solid #ccc;
`;
