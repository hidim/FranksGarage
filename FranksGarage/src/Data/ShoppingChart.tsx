import IVehicleProxyModel from '../Model/VehicleProxyModel';
import { NavDropdown, Button, ButtonGroup } from "react-bootstrap";

type Props = {
    cartItems: IVehicleProxyModel[];
    removeFromCart: (id: number) => void;
};

const ShoppingChart: React.FC<Props> = ({ cartItems, removeFromCart }) => {
    const calculateTotal = (items: IVehicleProxyModel[]) =>
        items.reduce((ack: number, item) => ack + item.vehiclePrice, 0);

    return (
        <NavDropdown title="Shopping Chart" id="collasible-nav-dropdown">
            {cartItems.length === 0 ? <NavDropdown.Item>No items in cart.</NavDropdown.Item> : null}
            {cartItems.map(item => (
                <NavDropdown.Item>
                    <h3>{item.vehicleMake + " " + item.vehicleModel}</h3>
                    <div className='information'>
                        <p>Price: ${item.vehiclePrice}</p>
                    </div>
                    <Button variant="primary" size="sm" onClick={() => removeFromCart(item.id)}>
                        Remove from cart
                    </Button>
                </NavDropdown.Item>
            ))}
            <NavDropdown.Divider />
            <NavDropdown.Item>Total: ${calculateTotal(cartItems).toFixed(2)}</NavDropdown.Item>
        </NavDropdown>
    );
};

export default ShoppingChart;