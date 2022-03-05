import React, { useState, useEffect, ChangeEvent } from "react";
import { ListGroup, ListGroupItem, Badge, Card } from "react-bootstrap";
import Vehicles from "../Api/Vehicles";
import IVehicleProxyModel from '../Model/VehicleProxyModel';
import moment from 'moment';

interface Props {
    id: number;
}

const VehicleDetails: React.FC<Props> = (props) => {
    const initialVehicleProxy = {
        vehicleMake: "",
        vehicleModel: "",
        vehicleInsertedDate: new Date(),
        vehicleModelYear: 0,
        vehiclePrice: 0,
        vehicleIsLicensed: false,
        carLocationName: "",
        warehouseName: "",
        warehouseLocationLat: "",
        warehouseLocationLong: ""
    };

    const [vehicleProxy, setVehicle] = useState<IVehicleProxyModel>(initialVehicleProxy);

    useEffect(() => {
        getVehicle(props.id);
    }, []);

    const getVehicle = (id: number) => {
        Vehicles.get(id)
            .then((response: any) => {
                setVehicle(response.data);
                console.log(response.data);
            })
            .catch((e: Error) => {
                console.log(e);
            });
    };

    return (
        <>
            {vehicleProxy ? (
                <Card style={{ width: '18rem' }}>
                    <Card.Img variant="top" src="holder.js/100px180" />
                    <Card.Body>
                        <Card.Title><span className="fw-bold">{vehicleProxy.vehicleMake}</span> {vehicleProxy.vehicleModel} {vehicleProxy.vehicleModelYear}</Card.Title>
                        <Card.Text>
                            Some quick example text to build on the card title and make up the bulk of
                            the card's content.
                        </Card.Text>
                    </Card.Body>
                    <ListGroup className="list-group-flush">
                        <ListGroupItem><span className="fw-bold">Price: </span> <Badge bg="info">{vehicleProxy.vehiclePrice}</Badge></ListGroupItem>
                        <ListGroupItem>License Info: {vehicleProxy.vehicleIsLicensed ? <Badge bg="success" pill>Licensed</Badge> : <Badge bg="danger" pill>Not Licensed</Badge>}</ListGroupItem>
                        <ListGroupItem>Inserted Date: {moment(vehicleProxy.vehicleInsertedDate, "YYYY-MM-DD").format("DD-MM-YYYY")}</ListGroupItem>
                    </ListGroup>
                    <Card.Body>
                        <Card.Link href="#">Add to chart</Card.Link>
                    </Card.Body>
                </Card>)
                : (
                    <div>
                        <br />
                        <p>There is no vehicle at this ID...</p>
                    </div>
                )
            }
        </>
    )
};

export default VehicleDetails;