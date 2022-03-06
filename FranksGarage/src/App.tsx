import { useState } from "react";
import { Alert, Container, Row, Col } from "react-bootstrap";
import VehiclesList from "./Data/VehicleList";
import Header from "./Layout/header";
import IVehicleProxyModel from "./Model/VehicleProxyModel";


const App: React.FC = () => {
    const [cartItems, setCartItems] = useState([] as IVehicleProxyModel[]);

    const handleAddToCart = (clickedItem: IVehicleProxyModel) => {
        setCartItems(prev => {
            const isItemInCart = prev.find(item => item.id === clickedItem.id);

            if (isItemInCart) {
                return prev.map(item =>
                    item.id === clickedItem.id
                        ? { ...item }
                        : item
                );
            }

            return [...prev, { ...clickedItem }];
        });
    };

    const handleRemoveFromCart = (id: number) => {
        setCartItems(cartItems.filter(item => item.id !== id));
    };

    return (
        <div className="BaseApp">
            <Header cartItems={cartItems} removeFromCart={handleRemoveFromCart} />
            <VehiclesList addToCart={handleAddToCart} />
        </div>
    );
}

export default App;