import axiosBase from "../Api/AxiosBase";
import IVehicleModel from "../Model/VehicleModel";

const getAll = () => {
    return axiosBase.get<Array<IVehicleModel>>("/Vehicles");
};

const Vehicles = {
    getAll
};

export default Vehicles;