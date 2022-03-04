import { Alert, Container } from "react-bootstrap";
import VehiclesList from "./Data/VehicleList";

function App() {
    return (
        <Container className="pb-3">
            {/*<Alert variant="primary">This is a test alert!</Alert>*/}
            <VehiclesList />
        </Container>
    );
}

export default App;
