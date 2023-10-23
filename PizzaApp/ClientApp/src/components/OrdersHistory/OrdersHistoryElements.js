import styled from "styled-components";
import ImgBg from "../../Images/pizza-3.png";

export const HistoryContainer = styled.div`
  background: linear-gradient(to right, rgba(0, 0, 0, 0.7), rgba(0, 0, 0, 0.1)),
    url(${ImgBg});
  height: 100vh;
  background-position: center;
  background-size: cover;
`;

export const FlexWrapper = styled.div`
  display: flex;
  flex-wrap: wrap;
`;

export const OrderHistoryItem = styled.div`
  font-size: 20px;
  color: #fff;
  flex: 0 0 calc(33.33% - 20px);
  margin: 10px;
  padding: 20px;
  border: 1px solid #ccc;
`;

export const OrdersHistoryH1 = styled.h1`
  color: #fff;
  font-size: clamp(2.5rem, 10vw, 5rem);
  margin-bottom: 1rem;
  box-shadow: 3px 5px #e9ba23;
  letter-spacing: 3px;
`;

export const PaginationContainer = styled.div`
  display: flex;
  justify-content: center;
  margin-top: 20px; /* Adjust the margin as needed */
`;
