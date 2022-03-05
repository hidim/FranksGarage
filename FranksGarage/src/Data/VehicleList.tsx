import React, { useState, useEffect, ChangeEvent } from "react";
import { Container, Row, Col, ListGroup, ListGroupItem, Badge, Card } from "react-bootstrap";
import Vehicles from "../Api/Vehicles";
import IVehicleModel from '../Model/VehicleModel';
import IVehicleProxyModel from '../Model/VehicleProxyModel';
import moment from 'moment';

const VehicleList: React.FC = () => {
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
    const [vehicles, setVehicles] = useState<Array<IVehicleModel>>([]);

    const buttonHandler = (event: React.MouseEvent<HTMLButtonElement>) => {
        event.preventDefault();

        const button: HTMLButtonElement = event.currentTarget;
        getVehicle(button.id);
    };

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

    const getVehicle = (id: string) => {
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
        <Container className="mt-3">
            <Row>
                <Col><h2>Vehicle List</h2></Col>
                <Col></Col>
            </Row>
            <Row>
                <Col>
                    <ListGroup className="overflow-auto">
                        {vehicles &&
                            vehicles.map((vehicle, index) => (
                                vehicle.isLicensed ? (
                                    <ListGroup.Item key={index} className="d-flex justify-content-between align-items-start"
                                        onClick={buttonHandler} id={vehicle.id}>
                                        <div className="ms-2 me-auto">
                                            <div><span className="fw-bold">{vehicle.make}</span> {vehicle.model} {vehicle.modelYear} </div>
                                            {vehicle.isLicensed ? <Badge bg="success" pill>Licensed</Badge> : <Badge bg="danger" pill>Not Licensed</Badge>} <span className="fw-bold">Price: </span> <Badge bg="info">{vehicle.price}</Badge>
                                        </div>
                                        <Badge bg="secondary" pill>
                                            {moment(vehicle.insertedDate, "YYYY-MM-DD").format("DD-MM-YYYY")}
                                        </Badge>
                                    </ListGroup.Item>
                                ) : ""
                            ))}
                    </ListGroup>
                </Col>
                <Col>
                    {vehicleProxy.vehicleMake ? (
                        <Card style={{ width: '18rem' }}>
                            <Card.Img variant="top" src={"https://maps.googleapis.com/maps/api/staticmap?center=" + vehicleProxy.warehouseLocationLat + "," + vehicleProxy.warehouseLocationLong + "&zoom=14&size=286x180&markers=color:red&key=AIzaSyD2JycruLi8LCKGwuTMrvcC-7t2NQlu56M"} />
                            <Card.Body>
                                <Card.Title><span className="fw-bold">{vehicleProxy.vehicleMake}</span> {vehicleProxy.vehicleModel} {vehicleProxy.vehicleModelYear}</Card.Title>
                            </Card.Body>
                            <ListGroup className="list-group-flush">
                                <ListGroupItem>Warehouse Name: {vehicleProxy.warehouseName}</ListGroupItem>
                                <ListGroupItem>Car Location Name: {vehicleProxy.carLocationName}</ListGroupItem>
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
                                <p>Please select a vehicle!</p>
                            </div>
                        )
                    }
                </Col>
            </Row>
            {/*<Alert variant="primary">This is a test alert!</Alert>*/}

        </Container>

    )
};

export default VehicleList;