import React, { useState, useEffect, ChangeEvent } from "react";
import { Card, Stack } from "react-bootstrap";
import Vehicles from "../Api/Vehicles";
import IVehicleModel from '../Model/VehicleModel';

const VehicleList: React.FC = () => {
    const [vehicles, setVehicles] = useState<Array<IVehicleModel>>([]);

    useEffect(() => {
        getVehiclesList();
    }, []);

    const getVehiclesList = () => {
        Vehicles.getAll()
            .then((response: any) => {
                setVehicles(response.data);
                console.log(response.data);
            })
            .catch((e: Error) => {
                console.log(e);
            });
    };

    return (
        <div>
            {vehicles &&
                vehicles.map((vehicle, index) => (
                    <Card key={index}>
                        <Card.Body>
                            <Card.Title>{vehicle.make}</Card.Title>
                            <Card.Text>
                                {vehicle.model}
                            </Card.Text>
                        </Card.Body>
                        <Card.Footer>
                            <small className="text-muted">{vehicle.insertedDate}</small>
                        </Card.Footer>
                    </Card>
                ))}
        </div>
    )
};

export default VehicleList;