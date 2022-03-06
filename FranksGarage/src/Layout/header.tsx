import { useState } from "react";
import { Navbar, Nav, NavDropdown, Container } from "react-bootstrap";
import ShoppingChart from "../Data/ShoppingChart";
import IVehicleProxyModel from "../Model/VehicleProxyModel";

export interface Props {
    cartItems: IVehicleProxyModel[];
    removeFromCart: (id: number) => void;
};

const Header: React.FC<Props> = ({ cartItems, removeFromCart }) => {
    return (
        <header>
            <Navbar bg="light" expand="lg">
                <Container>
                    <Navbar.Brand href="#home">Frank's Garage</Navbar.Brand>
                    <Navbar.Toggle aria-controls="basic-navbar-nav" />
                    <Navbar.Collapse id="basic-navbar-nav">
                        <Nav className="me-auto">
                            <ShoppingChart cartItems={cartItems}
                                removeFromCart={removeFromCart} />
                        </Nav>
                    </Navbar.Collapse>
                </Container>
            </Navbar>
        </header>
    );
}

export default Header;
