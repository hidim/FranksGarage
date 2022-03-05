import axiosBase from "../Api/AxiosBase";
import IVehicleModel from "../Model/VehicleModel";
import IVehicleProxyModel from "../Model/VehicleProxyModel";

const getAll = () => {
    return axiosBase.get<Array<IVehicleModel>>("/Vehicles");
};

const get = (id: any) => {
    return axiosBase.get<IVehicleProxyModel>(`/Vehicles/${id}`);
};

const Vehicles = {
    getAll,
    get
};

export default Vehicles;